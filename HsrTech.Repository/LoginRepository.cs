using HsrTech.Context;
using HsrTech.Domain.Entities;
using HsrTech.Domain.Interface.Repository;
using HsrTech.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Repository
{
    public class LoginRepository : RepositoryBase<Client>, ILoginRepository
    {
        public bool ValidateLogin(string login, string password)
        {
            using (var context = new HsrTechContext()) {
                HsrTechADO connection = new HsrTechADO(context.Database.Connection.ConnectionString);
                var data = connection.ExecuteQuery($"select count(*) as auth from Client where Login = '{login}' and Password = '{password}'");
                                               
                var property = data[0] as Dictionary<string, object>;

                int countUser = int.Parse(property.ValueAsString("auth"));

                return countUser == 0 ? false : true;                           
            }
        }
    }
}
