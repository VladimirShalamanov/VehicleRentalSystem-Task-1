namespace VehicleRentalSystem.Core.Contracts
{
    public interface IController
    {
        string AddInvoice();

        void AddVehicle(string typeVehicle);

        string Report();
    }
}
