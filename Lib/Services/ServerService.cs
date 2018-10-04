using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Lib.Models;
using Newtonsoft.Json;

namespace Lib.Services
{
    public class ServerService : IServerService
    {
        private static string _path = @"E:\A_level\Git\AUVebServers\db.txt";

        public static List<Server> _db = new List<Server>() { };

        static ServerService()
        {
            if (JsonConvert.DeserializeObject<List<Server>>(File.ReadAllText(_path)) == null)
            {
                _db = new List<Server> { };
            }
            else
            {
                _db = JsonConvert.DeserializeObject<List<Server>>(File.ReadAllText(_path));
            }
        }

        private void Save()
        {
            string productList = JsonConvert.SerializeObject(_db);

            File.WriteAllText(_path, productList);
        }

        private int GetMaxInt()
        {
            const int seed = 1;
            return _db != null && _db.Any()
                        ? _db.Max(x => x.Id) + seed
                        : seed;
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
