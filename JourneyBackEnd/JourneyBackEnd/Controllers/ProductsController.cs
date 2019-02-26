namespace JourneyBackEnd.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Models;
    using Utilities;

    public class ProductsController : ApiController
    {
        private readonly IProductAggregator _productAggregator;

        public ProductsController(IProductAggregator productAggregator)
        {
            _productAggregator = productAggregator;
        }

        [HttpGet]
        [Route("api/products")]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productAggregator.GetAllProducts();
        }

        [HttpGet]
        [Route("api/products/lawnmowers")]
        public IEnumerable<ProductDto> GetLawnmowers()
        { 
            return _productAggregator.GetLawnmowers();
        }

        [HttpGet]
        [Route("api/products/phonecases")]
        public IEnumerable<ProductDto> GetPhoneCases()
        {
            return _productAggregator.GetPhoneCases();
        }

        [HttpGet]
        [Route("api/products/tshirts")]
        public IEnumerable<ProductDto> GetTShirts()
        {
            return _productAggregator.GetTShirts();
        }
    }
}
