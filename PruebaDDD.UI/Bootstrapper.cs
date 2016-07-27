using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace PruebaDDD.UI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();



            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}