namespace JourneyBackEnd.Utilities
{
    public class PriceCalculator: IPriceCalculator
    {
        private double _nzdConversionRate = 1.0;
        private double _usdConversionRate = 0.76;
        private double _eurosConversionRate = 0.67;

        public double GetInNzd(double price)
        {
            return price * _nzdConversionRate;
        }

        public double GetInUsd(double price)
        {
            return price * _usdConversionRate;
        }

        public double GetInEuros(double price)
        {
            return price * _eurosConversionRate;
        }
    }
}