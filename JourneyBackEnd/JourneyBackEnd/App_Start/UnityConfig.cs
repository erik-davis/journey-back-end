namespace JourneyBackEnd
{
    using JourneyBackEnd.Utilities;
    using System.Web.Http;
    using Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IPriceCalculator, PriceCalculator>();
            container.RegisterType<IProductDtoBuilder, ProductDtoBuilder>();
            container.RegisterType<IProductAggregator, ProductAggregator>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}