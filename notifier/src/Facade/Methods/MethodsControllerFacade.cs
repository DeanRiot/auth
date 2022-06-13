using notifier.EF.Entity;
using notifier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace notifier.Facade.Methods
{
    public class MethodsControllerFacade : IMethodsFacade
    {
        private readonly NotifyContext _context;
        public MethodsControllerFacade(NotifyContext context) => _context = context;

        public void Add(string user, TypedMethod method)
        {
            method.type = method.type != null ? method.type.ToUpper() : null;
            switch (method.type)
            {
                case null: throw new ArgumentException($"Method arg has no type");
                case "SMS":
                    AddSmsNotifyingMethod(user, method);
                    break;
                case "MAIL":
                    AddMailNotifyingMethod(user, method);
                    break;
                default: throw new ArgumentException($"Method arg type not found");
            }
        }

        private void AddMailNotifyingMethod(string user, TypedMethod method)
        {
            var mailNotifyMethod = new MAIL { user_id = Guid.Parse(user), mail = method.data };
            if (_context.MAIL.Where(r =>
                     r.user_id.Equals(Guid.Parse(user)) &&
                     r.mail.Equals(method.data)).Count() == 0)
            {
                mailNotifyMethod.enabled = method.enabled;
                AddMail(user, mailNotifyMethod);
            }
        }

        private void AddMail(string user, MAIL mailNotifyMethod)
        {
            _context.Add<MAIL>(mailNotifyMethod);
            _context.SaveChanges();
        }

        private void AddSmsNotifyingMethod(string user, TypedMethod method)
        {
            if (_context.SMS.Where(r =>
                        r.user_id.Equals(Guid.Parse(user)) &&
                        r.phone.Equals(method.data)).Count()==0)
                AddPhoneNumber(user, method);
        }

        private void AddPhoneNumber(string user, TypedMethod method)
        {
            _context.SMS.Add(new SMS { user_id = Guid.Parse(user), phone= method.data, enabled = method.enabled });
            _context.SaveChanges();
        }

        public Dictionary<string, List<Method>> Read(string user, string type = null)
        { return GetMethodsDictonary(user, type); }
        private Dictionary<string, List<Method>> GetMethodsDictonary(string user, string type)
        {
            return GetMethods(user, type);
        }

        private Dictionary<string, List<Method>> GetMethods(string user, string type)
        {
            type = type != null ? type.ToUpper() : null;
            switch (type)
            {
                case null: return GetAll(user);
                case "SMS": return GetSMS(user);
                case "MAIL": return GetMail(user);
                default: throw new System.ArgumentException($"Server has no type:{type}");
            }
        }

        private Dictionary<string, List<Method>> GetAll(string user)
        {
            Dictionary<string, List<Method>> findedMethods = GetSMS(user);
            return findedMethods.Concat(GetMail(user)).ToDictionary(x=>x.Key,x=>x.Value);
        }

        private Dictionary<string, List<Method>> GetSMS(string user)
        {
            List<SMS> finded;
            Dictionary<string, List<Method>> findedResponse = new Dictionary<string, List<Method>>() { { "sms", new List<Method>() } };
            finded = _context.SMS.Where(u => u.user_id == Guid.Parse(user)).ToList();
            List<TypedMethod> smsMethods = new List<TypedMethod>();
            foreach (var smsRow in finded)
                findedResponse["sms"].Add(new Method { enabled = smsRow.enabled, data = smsRow.phone});
            return findedResponse;
        }

        private Dictionary<string,List<Method>> GetMail(string user)
        {
            List<MAIL> finded;
            Dictionary<string, List<Method>> findedResponse = new Dictionary<string, List<Method>>() { { "mail", new List<Method>() } };
            finded = _context.MAIL.Where(u => u.user_id.Equals(Guid.Parse(user))).ToList();
            List<TypedMethod> methods = new List<TypedMethod>();
            foreach (var row in finded)
                findedResponse["mail"].Add(new Method { enabled = row.enabled, data = row.mail });
            return findedResponse;
        }

        public void Update(string user, UpdatableEntity info)
        {
            info.type = info.type != null ? info.type.ToUpper() : null;
            switch (info.type)
            {
                case null: throw new System.ArgumentException($"Server has no type:{info.type}");
                case "SMS": UpdateSMS(user, info); break;
                case "MAIL": UpdateMail(user, info); break;
                default: throw new System.ArgumentException($"Server has no type:{info.type}");
            }
        }

        private void UpdateMail(string user, UpdatableEntity info)
        {
            var finded = _context.MAIL.Where(u => u.user_id == Guid.Parse(user))
                                      .First(m => m.mail == info.target.data);
            finded.mail = info.data.data ?? finded.mail;
            finded.enabled = info.data.enabled;
            _context.SaveChanges();
        }

        private void UpdateSMS(string user, UpdatableEntity info)
        {
            var finded = _context.SMS.Where(u => u.user_id == Guid.Parse(user))
                          .First(s => s.phone == info.target.data);
            finded.phone = info.data.data ?? finded.phone;
            finded.enabled = info.data.enabled;
            _context.SaveChanges();
        }

        public void Delete(string user, TypedMethod method)
        {
            method.type = method.type != null ? method.type.ToUpper() : null;
            switch (method.type)
            {
                case null:throw new System.ArgumentException($"Server has no type:{method.type}");
                case "SMS": DropSMS(user,method); break;
                case "MAIL": DropMail(user, method); break;
                default: throw new System.ArgumentException($"Server has no type:{method.type}");
            }
        }

        private void DropMail(string user, TypedMethod method)
        {
            var record = _context.MAIL.Where(u=>u.user_id == Guid.Parse(user))
                         .First(r=>r.mail==method.data);
      
             _context.MAIL.Remove(record);
            _context.SaveChanges();
        }

        private void DropSMS(string user, TypedMethod method)
        {
            var record = _context.SMS.Where(u => u.user_id == Guid.Parse(user))
              .First(r => r.phone == method.data);

            _context.SMS.Remove(record);
            _context.SaveChanges();
        }
    }
}
