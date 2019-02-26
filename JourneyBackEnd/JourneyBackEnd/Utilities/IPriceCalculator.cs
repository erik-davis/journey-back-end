namespace JourneyBackEnd.Utilities
{
    public interface IPriceCalculator
    {
        double GetInNzd(double price);
        double GetInUsd(double price);
        double GetInEuros(double price);
    }
}
