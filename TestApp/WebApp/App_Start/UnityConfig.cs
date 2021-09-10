using BusinessLogic.Manage;
using BusinessLogic.Services;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IBranchRepository, BranchRepository>();
            container.RegisterType<IRepresentativeRepository, RepresentativeRepository>();
            container.RegisterType<IBranchService, BranchManager>();
            container.RegisterType<IRepresentativeService, RepresentativeManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}