using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public interface IServerTypeService
    {
        IEnumerable<ServerType> GetAll();
    }
}
