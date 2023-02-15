using RentInterface.Entities;

namespace RentInterface.Services
{
    internal class RentalService
    {
        public double PricePerDay { get; private set; }
        public double PricePerHour { get; private set; }


        private BrazilTaxService _brazilTaxService = new BrazilTaxService();

        public RentalService(double pricePerDay, double pricePerHour)
        {
            PricePerDay = pricePerDay;
            PricePerHour = pricePerHour;
        }

        public RentalService()
        {
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
