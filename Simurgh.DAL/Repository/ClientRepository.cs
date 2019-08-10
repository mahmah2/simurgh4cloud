using Microsoft.Extensions.Logging;
using Simurgh.DAL.Model;

namespace Simurgh.DAL
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(ILogger logger, bool inMemory) :
            base(logger, inMemory)
        {

        }
    }
}
