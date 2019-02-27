namespace JourneyBackEnd
{
    using JourneyBackEnd.Utilities;
    using System.Web.Http;
    using Unity;
    using Unity.WebApi;
    using RefactorMe.DontRefactor.Data;
    using RefactorMe.DontRefactor.Data.Implementation;
    using RefactorMe.DontRefactor.Models;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IPriceCalculator, PriceCalculator>();
            container.RegisterType<IProductDtoBuilder, ProductDtoBuilder>();
            container.RegisterType<IProductAggregator, ProductAggregator>();
            container.RegisterType<IReadOnlyRepository<Lawnmower>, LawnmowerRepository>();
            container.RegisterType<IReadOnlyRepository<PhoneCase>, PhoneCaseRepository>();
            container.RegisterType<IReadOnlyRepository<TShirt>, TShirtRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}