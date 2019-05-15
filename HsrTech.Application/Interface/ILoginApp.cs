using HsrTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Application.Interface
{
    public interface ILoginApp : IAppBase<Client>
    {
        bool ValidateLogin(string login, string password);
    }
}
