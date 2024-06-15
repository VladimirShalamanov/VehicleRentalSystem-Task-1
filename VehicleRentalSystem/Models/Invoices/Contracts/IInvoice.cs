namespace VehicleRentalSystem.Models.Invoices.Contracts
{
    using VehicleRentalSystem.Models.Vehicles.Contracts;

    public interface IInvoice
    {
        ICollection<IVehicle> RentalVehicles { get; }

        void AddVehicle(IVehicle vehicle);

        string GetInfo();
    }
}
