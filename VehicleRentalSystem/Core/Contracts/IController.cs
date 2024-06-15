namespace VehicleRentalSystem.Core.Contracts
{
    public interface IController
    {
        string AddInvoice();

        string AddVehicle(
            string typeVehicle,
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate);

        string CalculateValue();

        string Report();
    }
}
