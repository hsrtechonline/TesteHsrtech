using HsrTech.Domain.Entities.Partial;
using System.Threading.Tasks;

namespace HsrTech.Application.Interface
{
    public interface ISimulationApp : IAppBase<Simulation>
    {        
        Task<decimal> GetDolarFromUOLAsync();
    }
}
