using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportService.Interfaces;
using SupportService.Entities;
using Microsoft.EntityFrameworkCore;

namespace SupportService
{
    public class AgentRepository : IAgentRepository
    {
        private readonly AppDbContext userDbContext;
        private readonly ILogger logger;

        public AgentRepository(AppDbContext AppDbContext, ILoggerFactory loggerFactory)
        {
            this.userDbContext = AppDbContext;
            this.logger = loggerFactory.CreateLogger(nameof(AgentRepository));
        }
        
        public Agent Add(Agent agent)
        {
            userDbContext.Agents.Add(agent);
            try
            {
                userDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(AgentRepository)} " + e.Message);
            }
            return agent;
        }

        public IEnumerable<Agent> GetAllAgents() => userDbContext.Agents.OrderBy(x => x.Name).ToList();
    }
}
