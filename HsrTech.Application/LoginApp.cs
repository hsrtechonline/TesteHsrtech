using HsrTech.Application.Interface;
using HsrTech.Domain.Entities;
using HsrTech.Domain.Interface.Service;

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
