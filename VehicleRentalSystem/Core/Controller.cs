namespace VehicleRentalSystem.Core
{
    using VehicleRentalSystem.Core.Contracts;
    using VehicleRentalSystem.Repositories;

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

        public string AddVehicle()
        {
            throw new NotImplementedException();
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
