using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using TiempoEnProcesoBL.Interfaces;
using TiempoEnProcesoBL.Services;
using TiempoEnProcesoBL.Repository;

namespace TiempoEnProcesoUIWeb
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<UnityOfWork>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IPeriodoService, PeriodoService>();
            container.RegisterType<ICapturaService, CapturaService>();

            return container;
        }
    }
}