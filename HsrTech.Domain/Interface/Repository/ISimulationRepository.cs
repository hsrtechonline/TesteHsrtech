using HsrTech.Domain.Entities.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Interface.Repository
{
    public interface ISimulationRepository : IRepositoryBase<Simulation>
    {        
        Task<decimal> GetDolarFromUOLAsync();
    }
}
