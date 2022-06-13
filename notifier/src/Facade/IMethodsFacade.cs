using notifier.Models;
using System.Collections.Generic;

namespace notifier.Facade
{
    public interface IMethodsFacade
    {
        void Add(string user, TypedMethod method);
        void Update(string user, UpdatableEntity info);
        void Delete(string user, TypedMethod method);
        Dictionary<string, List<Method>> Read(string user, string type = null);
    }
}
