# Journey Products API

This project was completed as part of the back-end technical exercise for Journey.
It is hosted in Azure as a WebAPI with the following routes:
https://journeyproductsapi.azurewebsites.net/api/products
https://journeyproductsapi.azurewebsites.net/api/products/lawnmowers
https://journeyproductsapi.azurewebsites.net/api/products/phonecases
https://journeyproductsapi.azurewebsites.net/api/products/tshirts

And the source is available in GitHub: https://github.com/erik-davis/journey-back-end

## Considerations

The "Do Not Refactor" code has been left unchanged, but the project was renamed to "JourneyBackEnd.Repositories."

The data returned is not sorted, and the prices are not rounded. These decisions are left to the client that is consuming the data.

## Features

The project is a WebAPI that returns an array of JSON objects on four routes. 

The ProductDataConsolidator is now split into three classes: ProductAggregator, ProductDtoBuilder, and PriceCalculator. Each one of those classes has a single responsibility and work together to return the list of Products.

## Tests

Unit tests are provided for all code that was added. Moq was used as the mocking library.

## Future Considerations

If the specific product models were all changed to extend Product, the code could be consolidated further by having a single repo that accepts a product type and returns a list of Product objects. Those objects could then be converted to DTOs after price calculation.
