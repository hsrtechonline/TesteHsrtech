using SimpleInjector;
using HsrTech.Domain.Interface.Repository;
using HsrTech.Repository;
using HsrTech.Domain.Interface.Service;
using HsrTech.Application.Interface;
using HsrTech.Application;
using HsrTech.Domain.Service;

namespace HsrTech.CrossCutting
{
    public class BootStrapper
    {
        public static void Register(ref Container container)
        {
            //Application
            container.Register(typeof(IAppBase<>), typeof(AppBase<>));
            container.Register<ILoginApp, LoginApp>(Lifestyle.Scoped);
            container.Register<IBankAccountApp, BankAccountApp>(Lifestyle.Scoped);
            container.Register<ISimulationApp, SimulationApp>(Lifestyle.Scoped);

            //Service
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<IBankAccountService, BankAccountService>(Lifestyle.Scoped);
            container.Register<ISimulationService, SimulationService>(Lifestyle.Scoped);

            //Repository
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<ILoginRepository, LoginRepository>(Lifestyle.Scoped);
            container.Register<IBankAccountRepository, BankAccountRepository>(Lifestyle.Scoped);
            container.Register<ISimulationRepository, SimulationRepository>(Lifestyle.Scoped);
        }
    }
}
