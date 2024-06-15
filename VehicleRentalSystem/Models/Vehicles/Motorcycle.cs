namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class Motorcycle : Vehicle
    {
        private int riderAge;

        public Motorcycle(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int riderAge) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.RiderAge = riderAge;
        }

        public int RiderAge
        {
            get { return this.riderAge; }
            private set
            {
                if (value < VehicleRules.MinRiderAge || value > VehicleRules.MaxRiderAge)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRiderAge);
                }

                this.riderAge = value;
            }
        }

        public override void someAction()
        {
            throw new NotImplementedException();
        }
    }
}
