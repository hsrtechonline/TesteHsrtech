[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AplicacaoWebHsrTech.App_Start.InjectorWeb), "Initialize")]


namespace AplicacaoWebHsrTech.App_Start
{
    using HsrTech.CrossCutting;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    public class InjectorWeb
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.Register(ref container);
        }
    }
}