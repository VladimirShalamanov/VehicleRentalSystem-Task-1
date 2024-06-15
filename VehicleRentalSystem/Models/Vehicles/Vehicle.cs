namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Models.Vehicles.Contracts;
    using VehicleRentalSystem.Utilities.CostManagement;
    using VehicleRentalSystem.Utilities.Messages;

    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private decimal valueVehicle;
        private DateTime returnDate;
        private DateTime reservationStartDate;
        private DateTime reservationEndDate;

        protected Vehicle(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate)
        {
            this.Brand = brand;
            this.Model = model;
            this.ValueVehicle = valueVehicle;
            this.ReturnDate = returnDate;
            this.ReservationStartDate = reservationStartDate;
            this.ReservationEndDate = reservationEndDate;
        }

        public string Brand
        {
            get { return this.brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrandName);
                }

                this.brand = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModelName);
                }

                this.model = value;
            }
        }

        public decimal ValueVehicle
        {
            get { return this.valueVehicle; }
            private set
            {
                if (value <= Prices.PriceMinValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVehiclePrice);
                }

                this.valueVehicle = value;
            }
        }

        public DateTime ReturnDate { get; private set; }

        public DateTime ReservationStartDate { get; private set; }

        public DateTime ReservationEndDate { get; private set; }

        public abstract void someAction();
    }
}
