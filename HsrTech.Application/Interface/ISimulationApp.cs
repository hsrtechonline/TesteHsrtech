using HsrTech.Domain.Entities.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Application.Interface
{
    public interface ISimulationApp : IAppBase<Simulation>
    {        
        Task<decimal> GetDolarFromUOLAsync();
    }
}
