using HsrTech.Domain.Entities;
using HsrTech.Domain.Interface.Repository;
using HsrTech.Domain.Interface.Service;

namespace HsrTech.Domain.Service
{
    public class LoginService : ServiceBase<Client>, ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository) : base (loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public bool ValidateLogin(string login, string password)
        {
            return _loginRepository.ValidateLogin(login, password);
        }
    }
}
