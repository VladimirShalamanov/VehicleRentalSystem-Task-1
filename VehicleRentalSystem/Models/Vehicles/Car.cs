namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class Car : Vehicle
    {
        private int securityRating;

        public Car(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int securityRating) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.SecurityRating = securityRating;
        }

        public int SecurityRating
        {
            get { return this.securityRating; }
            private set
            {
                if (value < VehicleRules.MinSecurityRating || value > VehicleRules.MaxSecurityRating)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarSecurityRating);
                }

                this.securityRating = value;
            }
        }

        public override void someAction()
        {
            throw new NotImplementedException();
        }
    }
}
