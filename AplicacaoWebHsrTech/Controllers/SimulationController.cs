using HsrTech.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AplicacaoWebHsrTech.Controllers
{
    public class SimulationController : Controller
    {
        private readonly ISimulationApp _simulationApp;
        public SimulationController(ISimulationApp simulationApp)
        {
            _simulationApp = simulationApp;
        }
        // GET: Simulation
        public async Task<ActionResult> Index()
        {
            ViewBag.DolarValue = await _simulationApp.GetDolarFromUOLAsync();
            return View();
        }
    }
}