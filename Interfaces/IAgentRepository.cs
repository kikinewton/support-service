using SupportService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportService.Interfaces
{
    public interface IAgentRepository
    {
        Agent Add(Agent agent);
        IEnumerable<Agent> GetAllAgents();
    }
}
