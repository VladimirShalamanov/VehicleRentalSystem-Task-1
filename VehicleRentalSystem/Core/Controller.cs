namespace VehicleRentalSystem.Core
{
    using VehicleRentalSystem.Core.Contracts;
    using VehicleRentalSystem.Models.Invoices;
    using VehicleRentalSystem.Models.Vehicles;
    using VehicleRentalSystem.Models.Vehicles.Contracts;
    using VehicleRentalSystem.Repositories;
    using VehicleRentalSystem.Utilities.ExampleInputs;
    using VehicleRentalSystem.Utilities.Messages;

    public class Controller : IController
    {
        private VehicleRepository vehicles;
        private Invoice invoice;

        public Controller()
        {
            this.vehicles = new VehicleRepository();
            this.invoice = new Invoice();
        }

        public string AddInvoice()
        {
            throw new NotImplementedException();
        }

        public void AddVehicle(string typeVehicle)
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

            this.vehicles.Add(vehicle);
            this.invoice.AddVehicle(vehicle);
        }

        public string Report()
        {
            return this.invoice.GetInfo();
        }
    }
}
