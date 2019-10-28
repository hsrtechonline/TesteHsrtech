using HsrTech.Domain.Entities;

namespace HsrTech.Application.Interface
{
    public interface ILoginApp : IAppBase<Client>
    {
        bool ValidateLogin(string login, string password);
    }
}
