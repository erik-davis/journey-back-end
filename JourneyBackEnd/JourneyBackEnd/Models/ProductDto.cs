namespace JourneyBackEnd.Models
{
    using RefactorMe.DontRefactor.Models;

    public class ProductDto : Product
    {
        public double PriceInNzd;
        public double PriceInUsd;
        public double PriceInEuros;
    }
}