namespace JourneyBackEnd.Utilities
{
    using System;
    using Models;

    public class ProductDtoBuilder: IProductDtoBuilder
    {
        private readonly IPriceCalculator _priceCalculator;

        public ProductDtoBuilder(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public ProductDto BuildProductDto(Guid id, string name, double price, string type)
        {
            {
                var product = new ProductDto {
                    Id = id,
                    Name = name,
                    Price = price,
                    PriceInNzd = _priceCalculator.GetInNzd(price),
                    PriceInEuros = _priceCalculator.GetInEuros(price),
                    PriceInUsd = _priceCalculator.GetInUsd(price),
                    Type = type};
                return product;
            }

        }
    }
}