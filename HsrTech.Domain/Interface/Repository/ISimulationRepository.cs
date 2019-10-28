using HsrTech.Domain.Entities.Partial;
using System.Threading.Tasks;

namespace HsrTech.Domain.Interface.Repository
{
    public interface ISimulationRepository : IRepositoryBase<Simulation>
    {        
        Task<decimal> GetDolarFromUOLAsync();
    }
}
