using backend_pairing_interview_project.catalog;
using backend_pairing_interview_project.offers;
using backend_pairing_interview_project.Orders;
using backend_pairing_interview_project.utils;
using backend_pairing_interview_project.Utils;
using System.Collections.Generic;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace backend_pairing_interview_project
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<OrderService>(new ContainerControlledLifetimeManager());

            container.RegisterType<OfferStore>(new ContainerControlledLifetimeManager());

            container.RegisterType<ItemStore>(new ContainerControlledLifetimeManager());

            container.RegisterType<ItemAvailabilityManager>(new ContainerControlledLifetimeManager());           

            container.RegisterType<ItemsService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IApplicationEventPublisher, ApplicationEventPublisher>
                (new ContainerControlledLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}