using Lib.Models;
using System.Collections.Generic;

namespace Lib.Services
{
    public interface IServerService
    {
        void Add(Server server);

        void Update(Server server);

        void Delete(int id);

        Server Get(int id);

        IEnumerable<Server> GetAll();
    }
}
