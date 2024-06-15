namespace VehicleRentalSystem.Core.Contracts
{
    public interface IController
    {
        string AddInvoice();

        string AddVehicle();

        string CalculateValue();

        string Report();
    }
}
