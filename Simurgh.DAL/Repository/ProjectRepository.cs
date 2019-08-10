using Microsoft.Extensions.Logging;
using Simurgh.DAL.Model;
using System.Linq;

namespace Simurgh.DAL
{
    public class ProjectRepository: BaseRepository<Project>
    {
        public ProjectRepository(ILogger logger, bool inMemory) :
                    base(logger, inMemory)
        {
        }

        public IQueryable<Project> GetClientProjects(string clientId)
        {
            var result = GetAll().Where(p => p.ClientId.ToString() == clientId);

            return result;
        }
    }
}
