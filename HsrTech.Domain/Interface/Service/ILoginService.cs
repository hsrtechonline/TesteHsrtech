using HsrTech.Domain.Entities;

namespace HsrTech.Domain.Interface.Service
{
    public interface ILoginService : IServiceBase<Client>
    {
        bool ValidateLogin(string login, string password);
    }
}
