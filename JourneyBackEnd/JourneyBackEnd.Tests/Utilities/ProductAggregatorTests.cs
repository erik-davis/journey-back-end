using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JourneyBackEnd.Controllers;
using JourneyBackEnd.Models;
using JourneyBackEnd.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Models;

namespace JourneyBackEnd.Tests.Utilities
{
    [TestClass]
    public class ProductAggregatorTests
    {
        private ProductAggregator _aggregator;
        private Mock<IProductDtoBuilder> _builder;
        private Mock<IReadOnlyRepository<Lawnmower>> _lawnmowerRepo;
        private Mock<IReadOnlyRepository<PhoneCase>> _phoneCaseRepo;
        private Mock<IReadOnlyRepository<TShirt>> _tshirtRepo;

        [TestInitialize]
        public void Setup()
        {
            _builder = new Mock<IProductDtoBuilder>();
            _lawnmowerRepo = new Mock<IReadOnlyRepository<Lawnmower>>();
            _phoneCaseRepo = new Mock<IReadOnlyRepository<PhoneCase>>();
            _tshirtRepo = new Mock<IReadOnlyRepository<TShirt>>();
            _aggregator = new ProductAggregator(_builder.Object, _lawnmowerRepo.Object, _phoneCaseRepo.Object,
                _tshirtRepo.Object);
        }

        [TestMethod]
        public void ShouldGetAllProducts()
        {           
            SetupLawnmowerMocks();
            SetupPhoneMocks();
            SetupTShirtMocks();
            var testDto = GetTestDto("foo");

            var products = _aggregator.GetAllProducts().ToList();

            Assert.AreEqual(products.Count(), 3);
            foreach (var dto in products)
            {
                Assert.AreEqual(dto.Id, testDto.Id);
                Assert.AreEqual(dto.Name, testDto.Name);
                Assert.AreEqual(dto.PriceInNzd, testDto.PriceInNzd);
                Assert.AreEqual(dto.PriceInUsd, testDto.PriceInUsd);
                Assert.AreEqual(dto.PriceInEuros, testDto.PriceInEuros);
            }

            Assert.AreEqual(products.Count(dto => dto.Type == ProductType.Lawnmower.Value), 1);
            Assert.AreEqual(products.Count(dto => dto.Type == ProductType.PhoneCase.Value), 1);
            Assert.AreEqual(products.Count(dto => dto.Type == ProductType.TShirt.Value), 1);

            _builder.Verify();
            _lawnmowerRepo.Verify();
            _phoneCaseRepo.Verify();
            _tshirtRepo.Verify();
        }

        private void SetupLawnmowerMocks()
        {
            var lawnmowersResult = GetAllLawnmowersResult();
            var lawnmowerResult = GetAllLawnmowersResult().First();
            _lawnmowerRepo.Setup(r => r.GetAll()).Returns(lawnmowersResult).Verifiable();

            _builder.Setup(b => b.BuildProductDto(lawnmowerResult.Id, lawnmowerResult.Name, lawnmowerResult.Price,
                ProductType.Lawnmower.Value)
            ).Returns(GetTestDto(ProductType.Lawnmower.Value)).Verifiable();
        }

        private void SetupPhoneMocks()
        {
            var phoneCaseResults = GetAllPhoneCasesResult();
            var phoneCaseResult = phoneCaseResults.First();

            _phoneCaseRepo.Setup(r => r.GetAll()).Returns(phoneCaseResults).Verifiable();
            _builder.Setup(b => b.BuildProductDto(phoneCaseResult.Id, phoneCaseResult.Name, phoneCaseResult.Price,
                ProductType.PhoneCase.Value)
            ).Returns(GetTestDto(ProductType.PhoneCase.Value)).Verifiable();
        }

        private void SetupTShirtMocks()
        {
            var tShirtResults = GetAllTShirtsResult();
            var tShirtResult = tShirtResults.First();

            _tshirtRepo.Setup(r => r.GetAll()).Returns(tShirtResults).Verifiable();
            _builder.Setup(b => b.BuildProductDto(tShirtResult.Id, tShirtResult.Name, tShirtResult.Price,
                ProductType.TShirt.Value)
            ).Returns(GetTestDto(ProductType.TShirt.Value)).Verifiable();
        }

        private IQueryable<Lawnmower> GetAllLawnmowersResult()
        {
            return new[]
            {
                new Lawnmower()
                {
                    Id = Guid.Empty,
                    Name = "Hewlett-Packard Rideable Lawnmower",
                    FuelEfficiency = "Very Low",
                    IsVehicle = true,
                    Price = 3000.0
                }
            }.AsQueryable();
        }

        private IQueryable<PhoneCase> GetAllPhoneCasesResult()
        {
            return new[]
            {
                new PhoneCase() {
                    Id = Guid.Empty,
                    Name = "Amazon Fire Burgundy Phone Case",
                    Colour = "Burgundy",
                    Material = "PVC",
                    TargetPhone = "Amazon Fire",
                    Price = 14.0
                },
            }.AsQueryable();
        }

        private IQueryable<TShirt> GetAllTShirtsResult()
        {
            return new[]
            {
                new TShirt() {
                    Id = Guid.Empty,
                    Colour = "Blue",
                    Name = "Xamarin C# T-Shirt",
                    Price = 15.0,
                    ShirtText = "C#, Xamarin"
                },
            }.AsQueryable();
        }

        private ProductDto GetTestDto(string type)
        {
            var testDto = new ProductDto
            {
                Id = Guid.Empty,
                Name = "Journey",
                Price = 3.50,
                PriceInEuros = 3.60,
                PriceInNzd = 3.50,
                PriceInUsd = 2.70,
                Type = type
            };
            return testDto;
        }
    }
}
