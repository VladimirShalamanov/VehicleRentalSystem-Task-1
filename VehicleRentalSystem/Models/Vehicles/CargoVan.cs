namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class CargoVan : Vehicle
    {
        private int driverExperience;

        public CargoVan(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int driverExperience) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.DriverExperience = driverExperience;
        }

        public int DriverExperience
        {
            get { return this.driverExperience; }
            private set
            {
                if (value < VehicleRules.CheckDriverExperiencePositiveNumber)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDriverExperience);
                }

                this.driverExperience = value;
            }
        }

        public override void someAction()
        {
            throw new NotImplementedException();
        }
    }
}
