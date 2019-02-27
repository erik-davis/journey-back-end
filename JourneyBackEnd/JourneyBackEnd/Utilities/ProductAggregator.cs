using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Models;

namespace JourneyBackEnd.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ProductAggregator : IProductAggregator
    {
        private readonly IProductDtoBuilder _productDtoBuilder;
        private readonly IReadOnlyRepository<Lawnmower> _lawnmowerRepository;
        private readonly IReadOnlyRepository<PhoneCase> _phoneCaseRepository;
        private readonly IReadOnlyRepository<TShirt> _tShirtRepository;

        public ProductAggregator(IProductDtoBuilder productDtoBuilder, 
                                IReadOnlyRepository<Lawnmower> lawnmowerRepository,
                                IReadOnlyRepository<PhoneCase> phoneCaseRepository,
                                IReadOnlyRepository<TShirt> tShirtRepository)
        {
            _productDtoBuilder = productDtoBuilder;
            _lawnmowerRepository = lawnmowerRepository;
            _phoneCaseRepository = phoneCaseRepository;
            _tShirtRepository = tShirtRepository;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var result = new List<IEnumerable<ProductDto>> {GetLawnmowers(), GetPhoneCases(), GetTShirts()};
            return result.SelectMany(p => p);
        }

        public IEnumerable<ProductDto> GetLawnmowers()
        {
            return _lawnmowerRepository.GetAll()
                .Select(l => _productDtoBuilder.BuildProductDto(l.Id, l.Name, l.Price, ProductType.Lawnmower.Value));
        }

        public IEnumerable<ProductDto> GetPhoneCases()
        {
            return _phoneCaseRepository.GetAll()
                .Select(p => _productDtoBuilder.BuildProductDto(p.Id, p.Name, p.Price, ProductType.PhoneCase.Value));
        }

        public IEnumerable<ProductDto> GetTShirts()
        {
            return _tShirtRepository.GetAll()
                .Select(t => _productDtoBuilder.BuildProductDto(t.Id, t.Name, t.Price, ProductType.TShirt.Value));
        }
    }
}