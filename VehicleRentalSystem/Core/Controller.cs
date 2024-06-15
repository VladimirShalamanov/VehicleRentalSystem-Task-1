namespace VehicleRentalSystem.Core
{
    using VehicleRentalSystem.Core.Contracts;
    using VehicleRentalSystem.Models.Vehicles;
    using VehicleRentalSystem.Models.Vehicles.Contracts;
    using VehicleRentalSystem.Repositories;
    using VehicleRentalSystem.Utilities.ExampleInputs;
    using VehicleRentalSystem.Utilities.Messages;

    public class Controller : IController
    {
        private readonly VehicleRepository vehicles;

        public Controller()
        {
            this.vehicles = new VehicleRepository();
        }

        public string AddInvoice()
        {
            throw new NotImplementedException();
        }

        public string AddVehicle(
            string typeVehicle,
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate)
        {
            IVehicle vehicle;

            if (typeVehicle == "car")
            {
                vehicle = new Car(
                    Inputs.CarBrand,
                    Inputs.CarModel,
                    Inputs.CarValue,
                    DateTime.Parse(Inputs.CarReturnDate),
                    DateTime.Parse(Inputs.CarReservationEndDate),
                    DateTime.Parse(Inputs.CarReservationEndDate),
                    Inputs.CarSecurityRating);
            }
            else if (typeVehicle == "motorcycle")
            {
                vehicle = new Motorcycle(
                    Inputs.MotorcycleBrand,
                    Inputs.MotorcycleModel,
                    Inputs.MotorcycleValue,
                    DateTime.Parse(Inputs.MotorcycleReturnDate),
                    DateTime.Parse(Inputs.MotorcycleReservationStartDate),
                    DateTime.Parse(Inputs.MotorcycleReservationEndDate),
                    Inputs.MotorcycleRiderAge);
            }
            else if (typeVehicle == "cargo van")
            {
                vehicle = new CargoVan(
                    Inputs.CargoVanBrand,
                    Inputs.CargoVanModel,
                    Inputs.CargoVanValue,
                    DateTime.Parse(Inputs.CargoVanReturnDate),
                    DateTime.Parse(Inputs.CargoVanReservationStartDate),
                    DateTime.Parse(Inputs.CargoVanReservationEndDate),
                    Inputs.CargoVanDriverExperience);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            // here - add invoice (akvarium)
        }

        public string CalculateValue()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
