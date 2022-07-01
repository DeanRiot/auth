using contacts.Models;
using contacts.Models.DTO;
using contacts.Models.EF;
using System.Net;

namespace contacts.ControllersFacades
{
    public abstract class BaseControllerFacade
    {
        protected NotifyContext _context;
        protected IAuthInfo _auth_service;
        public BaseControllerFacade(NotifyContext provider, IAuthInfo auth_service)
        {
            _context = provider;
            _auth_service = auth_service;
        }
        public abstract List<Contact> Get(string user_token);
        public abstract Task Update(Contact contact, string user_token);
        public abstract Task Insert(Contact contact, string user_token);
        public abstract Task Delete(Contact contact, string user_token);
        /// <summary>
        /// Get user_id from auth service
        /// </summary>
        /// <param name="user_token"></param>
        /// <returns>User Guid from auth service </returns>
        /// <returns>Guid.Empty if service unavailabe or on error</returns>
        protected Guid GetUserId(string user_token)
        {
            string uri = CreateUri(user_token);
            HttpWebRequest request = ConfigureReq(uri);
            string response_data = StartGetReq(request);
            if (response_data == "") return Guid.Empty;
            return findUserID(response_data);
        }

        protected string CreateUri(string user_token)
        {
            UriBuilder uri = new UriBuilder();
            uri.Scheme = "https";
            uri.Host = _auth_service.address;
            if (int.TryParse(_auth_service.port, out int port)) uri.Port = port;
            uri.Query = $"?token={user_token}";
            return uri.ToString();
        }

        protected static HttpWebRequest ConfigureReq(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            return request;
        }

        protected string StartGetReq(HttpWebRequest request)
        {
            string response_data;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                    response_data = reader.ReadToEnd();
            }
            catch
            {
                response_data = "";
            }

            return response_data;
        }
        private Guid findUserID(string response_data)
        {
            int index = response_data.IndexOf("user_id:");
            if (index + 8 == 7 || index + 8 == 8) return Guid.Empty;
            else
            {
                try
                {
                    var user_id = Guid.Parse(response_data.Substring(index + 8, index + 44));
                    return user_id;
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }
    }
}
