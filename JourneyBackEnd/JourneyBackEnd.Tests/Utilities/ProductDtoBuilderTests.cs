namespace JourneyBackEnd.Tests.Utilities
{
    using System;
    using JourneyBackEnd.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ProductDtoBuilderTests
    {
        private Mock<IPriceCalculator> _priceCalculator;
        private IProductDtoBuilder _builder;

        [TestInitialize]
        public void Setup()
        {
            _priceCalculator = new Mock<IPriceCalculator>();
            _builder = new ProductDtoBuilder(_priceCalculator.Object);
        }

        [TestMethod]
        public void ShouldBuildProductDto()
        {
            var testId = Guid.NewGuid();
            const string testName = "Gandalf's wizard staff";
            const string testType = "Staff";
            const double testPrice = 10000;

            const int priceInUsd = 9000;
            const int priceInEuros = 8000;
            const int priceInNzd = 10000;

            _priceCalculator.Setup(c => c.GetInUsd(testPrice)).Returns(priceInUsd).Verifiable();
            _priceCalculator.Setup(c => c.GetInEuros(testPrice)).Returns(priceInEuros).Verifiable();
            _priceCalculator.Setup(c => c.GetInNzd(testPrice)).Returns(priceInNzd).Verifiable();

            var resultDto = _builder.BuildProductDto(testId, testName, testPrice, testType);

            Assert.AreEqual(resultDto.Id, testId);
            Assert.AreEqual(resultDto.Name, testName);
            Assert.AreEqual(resultDto.Type, testType);
            Assert.AreEqual(resultDto.Price, testPrice);
            Assert.AreEqual(resultDto.PriceInEuros, priceInEuros);
            Assert.AreEqual(resultDto.PriceInUsd, priceInUsd);
            Assert.AreEqual(resultDto.PriceInNzd, priceInNzd);
        }
    }
}
