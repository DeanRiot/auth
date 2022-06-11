using notifier.Models;
using System.Collections.Generic;

namespace notifier.Facade
{
    public interface IMethodsFacade
    {
        void Add(string user, Method method);
        void Update(string user, Method method);
        void Delete(string user, Method method);
        List<object> Read(string user, Method method);
    }
}
