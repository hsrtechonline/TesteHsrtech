using HsrTech.Application.Interface;
using HsrTech.Domain.Entities;
using HsrTech.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Application
{
    public class LoginApp : AppBase<Client>, ILoginApp
    {
        private readonly ILoginService _loginService;
        public LoginApp(ILoginService loginService) : base(loginService)
        {
            _loginService = loginService;

        }
        public bool ValidateLogin(string login, string password)
        {
            return _loginService.ValidateLogin(login, password);
        }
    }
}
