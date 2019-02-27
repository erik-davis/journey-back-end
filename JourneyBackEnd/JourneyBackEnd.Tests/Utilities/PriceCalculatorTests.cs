namespace JourneyBackEnd.Tests.Utilities
{
    using JourneyBackEnd.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PriceCalculatorTests
    {
        private PriceCalculator _priceCalculator;
        private delegate double CalculateFunction(double price); 

        [TestInitialize]
        public void Setup()
        {
            _priceCalculator = new PriceCalculator();
        }

        [TestMethod]
        public void ShouldCalculateNzdPrice()
        {
            VerifyCalculation(_priceCalculator.GetInNzd, _priceCalculator.NzdConversionRate);
        }

        [TestMethod]
        public void ShouldCalculateUsdPrice()
        {
            VerifyCalculation(_priceCalculator.GetInUsd, _priceCalculator.UsdConversionRate);
        }

        [TestMethod]
        public void ShouldCalculateEurosPrice()
        {
            VerifyCalculation(_priceCalculator.GetInEuros, _priceCalculator.EurosConversionRate);
        }

        private static void VerifyCalculation(CalculateFunction calculate, double conversionRate)
        {
            const int price = 1;
            var calculated = calculate(price);

            Assert.AreEqual(calculated, price * conversionRate);
        }
    }
}
