namespace JourneyBackEnd.Utilities
{
    public class PriceCalculator: IPriceCalculator
    {
        public readonly double NzdConversionRate = 1.0;
        public readonly double UsdConversionRate = 0.76;
        public readonly double EurosConversionRate = 0.67;

        public double GetInNzd(double price)
        {
            return price * NzdConversionRate;
        }

        public double GetInUsd(double price)
        {
            return price * UsdConversionRate;
        }

        public double GetInEuros(double price)
        {
            return price * EurosConversionRate;
        }
    }
}