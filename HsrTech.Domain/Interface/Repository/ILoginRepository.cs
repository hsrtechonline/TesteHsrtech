using HsrTech.Domain.Entities;

namespace HsrTech.Domain.Interface.Repository
{
    public interface ILoginRepository : IRepositoryBase<Client>
    {
        bool ValidateLogin(string login, string password);
    }
}
