using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using notifier.EF.Entity;
using notifier.Facade;
using notifier.Facade.Methods;
using notifier.Models;
using System;

namespace notifier.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class Methods : ControllerBase
    {
        IMethodsFacade _facade;
        public Methods(IMethodsFacade _facade) => this._facade = _facade;
        
        [Host("*:8081")]
        [HttpGet]
        public void GetNotifyMethods(string type = null)
        {    
            try
            {
                var d = _facade.Read("12ead25f-f96c-4771-8fca-421461ea5964", type);
                if (d.Count == 0) Response.StatusCode = 404;
                else WriteAsJson(200, d);
            }
            catch(ArgumentException e)
            {
                WriteAsJson(404, e.Message);
            }

            //or 401 if unauthorized
        }

        [Host("*:8081")]
        [HttpPost]
        public void SetNotifyMethod([FromBody] TypedMethod method)
        {
            try
            {
                _facade.Add("12ead25f-f96c-4771-8fca-421461ea5964", method);
                Response.StatusCode = 201;
            }
            catch (ArgumentException)
            {
                WriteAsJson(400, "notify type error");
            }
            //or 401 if unauthorized
            //or 400 if method type or data is null /type not exists /data not required regex   
        }

        [Host("*:8081")]
        [HttpPut]
        public void UpdateNotifyMethod([FromBody] UpdatableEntity info)
        {
            _facade.Update("12ead25f-f96c-4771-8fca-421461ea5964", info);
            Response.StatusCode = 200;
            //or 401 if unauthorized
            //or 404 if method not found
            //or 400 if method type or data is null /type not exists /data not required regex
        }

        [Host("*:8081")]
        [HttpDelete]
        public void DeleteNotifyMethod([FromBody] TypedMethod method)
        {
            _facade.Delete("12ead25f-f96c-4771-8fca-421461ea5964",method);
            Response.StatusCode = 204;
            //or 401 if unauthorized
            //or 400 if method type or data is null 
        }

        private void WriteAsJson(int status, object data)
        {
            Response.Clear();
            Response.StatusCode = status;
            Response.ContentType = "application/json; charset=utf-8";
            Response.WriteAsJsonAsync(data);
        }

    }
}
