namespace JourneyBackEnd.Utilities
{
    using System;
    using Models;

    public interface IProductDtoBuilder
    {
        ProductDto BuildProductDto(Guid id, string name, double price, string type);
    }
}