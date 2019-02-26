namespace JourneyBackEnd.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using RefactorMe.DontRefactor.Data.Implementation;

    public class ProductAggregator : IProductAggregator
    {
        private readonly IProductDtoBuilder _productDtoBuilder;
        private readonly LawnmowerRepository _lawnmowerRepository;
        private readonly PhoneCaseRepository _phoneCaseRepository;
        private readonly TShirtRepository _tShirtRepository;
        private const string LawnmowerType = "Lawnmower";
        private const string PhoneCaseType = "Phone Case";
        private const string TShirtType = "T-Shirt";

        public ProductAggregator(IProductDtoBuilder productDtoBuilder)
        {
            _productDtoBuilder = productDtoBuilder;
            _lawnmowerRepository = new LawnmowerRepository();
            _phoneCaseRepository = new PhoneCaseRepository();
            _tShirtRepository = new TShirtRepository();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var result = new List<IEnumerable<ProductDto>> {GetLawnmowers(), GetPhoneCases(), GetTShirts()};

            return result.SelectMany(p => p);
        }

        public IEnumerable<ProductDto> GetLawnmowers()
        {
            return _lawnmowerRepository.GetAll().Select(l => _productDtoBuilder.BuildProductDto(l.Id, l.Name, l.Price, LawnmowerType));
        }

        public IEnumerable<ProductDto> GetPhoneCases()
        {
            return _phoneCaseRepository.GetAll().Select(p => _productDtoBuilder.BuildProductDto(p.Id, p.Name, p.Price, PhoneCaseType));
        }

        public IEnumerable<ProductDto> GetTShirts()
        {
            return _tShirtRepository.GetAll().Select(t => _productDtoBuilder.BuildProductDto(t.Id, t.Name, t.Price, TShirtType));
        }
    }
}