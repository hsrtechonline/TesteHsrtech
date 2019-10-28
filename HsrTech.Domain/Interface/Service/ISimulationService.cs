using HsrTech.Domain.Entities.Partial;
using System.Threading.Tasks;

namespace HsrTech.Domain.Interface.Service
{
    public interface ISimulationService : IServiceBase<Simulation>
    {
        Task<decimal> GetDolarFromUOLAsync();
    }
}
