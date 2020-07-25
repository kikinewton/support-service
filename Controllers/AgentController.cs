using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportService.Interfaces;

namespace SupportService.Controllers
{
    public class AgentController : Controller
    {
        private readonly ILogger logger;
        private readonly IAgentRepository agentRepository;

        public AgentController(IAgentRepository agentRepository, ILoggerFactory loggerFactory)
        {
            this.agentRepository = agentRepository;
            this.logger = loggerFactory.CreateLogger(nameof(AgentController));
        }
        // GET: Agent
        public IActionResult Index()
        {
            var agents = agentRepository.GetAllAgents();
            return View(agents);
        }

        // GET: Agent/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Agent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Agent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}