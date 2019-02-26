namespace JourneyBackEnd.Utilities
{
    using System.Collections.Generic;
    using Models;

    public interface IProductAggregator
    {
        IEnumerable<ProductDto> GetAllProducts();
        IEnumerable<ProductDto> GetLawnmowers();
        IEnumerable<ProductDto> GetPhoneCases();
        IEnumerable<ProductDto> GetTShirts();
    }
}
