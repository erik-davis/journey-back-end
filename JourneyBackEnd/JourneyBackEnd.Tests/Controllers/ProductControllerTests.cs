namespace JourneyBackEnd.Tests.Controllers
{
    using System.Collections.Generic;
    using JourneyBackEnd.Controllers;
    using Models;
    using JourneyBackEnd.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ProductControllerTests
    {
        private ProductsController _controller;
        private Mock<IProductAggregator> _aggregator;

        [TestInitialize]
        public void Setup()
        {
            _aggregator = new Mock<IProductAggregator>();
            _controller = new ProductsController(_aggregator.Object);
        }

        [TestMethod]
        public void ShouldGetAllProducts()
        {
            var testResults = new List<ProductDto>();
            _aggregator.Setup(a => a.GetAllProducts()).Returns(testResults).Verifiable();

            var result = _controller.GetAllProducts();

            Assert.AreSame(result, testResults);
            _aggregator.Verify();
        }

        [TestMethod]
        public void ShouldGetLawnmowers()
        {
            var testResults = new List<ProductDto>();
            _aggregator.Setup(a => a.GetLawnmowers()).Returns(testResults).Verifiable();

            var result = _controller.GetLawnmowers();

            Assert.AreSame(result, testResults);
            _aggregator.Verify();
        }

        [TestMethod]
        public void ShouldGetPhoneCases()
        {
            var testResults = new List<ProductDto>();
            _aggregator.Setup(a => a.GetPhoneCases()).Returns(testResults).Verifiable();

            var result = _controller.GetPhoneCases();

            Assert.AreSame(result, testResults);
            _aggregator.Verify();
        }

        [TestMethod]
        public void ShouldGetTShirts()
        {
            var testResults = new List<ProductDto>();
            _aggregator.Setup(a => a.GetTShirts()).Returns(testResults).Verifiable();

            var result = _controller.GetTShirts();

            Assert.AreSame(result, testResults);
            _aggregator.Verify();
        }

    }
}
