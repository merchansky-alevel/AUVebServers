using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lib.Models;
using Newtonsoft.Json;

namespace Lib.Services
{
    public class ServerService : IServerService
    {
        private static string _path = @"C:\Users\evgen\Desktop\module-task-mvc-and-api\db.txt";

        private static List<Server> _db = new List<Server>();

        static ServerService()
        {
            _db.Add(new Server { Id = 1, Domen = "www.test.com", Name = "Test name", Type = ServerType.Gaming });

            _db = JsonConvert.DeserializeObject<List<Server>>(File.ReadAllText(_path));
        }

        private void Save()
        {
            string productList = JsonConvert.SerializeObject(_db);

            File.WriteAllText(_path, _db.ToString());
        }

        private int GetMaxInt()
        {
            if (_db != null && !_db.Any())
            {
                return 0;
            }
            else
            {
                return _db.Max(x => x.Id) + 1;
            }
        }

        // POST:
        public void Add(Server server)
        {
            server.Id = GetMaxInt();

            _db.Add(server);

            Save();
        }

        // DELETE:
        public void Delete(int id)
        {
            Server currentServer = _db.FirstOrDefault(x => x.Id == id);

            if (currentServer != null)
            {
                _db.Remove(currentServer);
            }

            Save();
        }

        // GET:
        public Server Get(int id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }

        // GET:
        public IEnumerable<Server> GetAll()
        {
            return _db
                .OrderBy(x => x.Name)
                .ToList();
        }

        // PUT:
        public void Update(Server server)
        {
            Server oldServer = _db.FirstOrDefault(x => x.Id == server.Id);

            oldServer.Name = server.Name;

            oldServer.Domen = server.Domen;

            oldServer.Type = server.Type;

            Save();
        }
    }
}
