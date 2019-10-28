using HsrTech.Application.Interface;
using HsrTech.Domain.Entities.Partial;
using HsrTech.Domain.Interface.Service;
using System.Threading.Tasks;

namespace HsrTech.Application
{
    public class SimulationApp : AppBase<Simulation>, ISimulationApp
    {
        private readonly ISimulationService _simulationService;
        public SimulationApp(ISimulationService simulationService) : base(simulationService)
        {
            _simulationService = simulationService;
        }           
        public Task<decimal> GetDolarFromUOLAsync()
        {
            return _simulationService.GetDolarFromUOLAsync();
            
        }
    }
}
