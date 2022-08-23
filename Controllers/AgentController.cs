using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreezeDanceTouring.Services.AgentService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreezeDanceTouring.MVC.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _aService;

        public AgentController(IAgentService aService)
        {
            _aService = aService;
        }

        public async Task<IActionResult> Index()
        {
            var agents = await _aService.GetAgentList();
                return View(agents);
        }

        public async Task<IActionResult> AgentDetails(int? id)
        {
            if (id == null) return BadRequest();

            var agent = await _aService.GetAgentDetails(id.Value);
            if (agent == null) return NotFound();
            return View(agent);
        }

        public IActionResult AgentCreate()
        {
          
            return View();
        }
    }
}

