using HsrTech.Domain.Entities.Partial;
using HsrTech.Domain.Interface.Repository;
using HsrTech.Domain.Interface.Service;
using System.Threading.Tasks;

namespace HsrTech.Domain.Service
{
    public class SimulationService : ServiceBase<Simulation>, ISimulationService
    {
        private readonly ISimulationRepository _simulationRepository;
        public SimulationService(ISimulationRepository simulationRepository) : base(simulationRepository)
        {
            _simulationRepository = simulationRepository;
        }       
        Task<decimal> ISimulationService.GetDolarFromUOLAsync()
        {            
            return _simulationRepository.GetDolarFromUOLAsync();
        }
    }
}
