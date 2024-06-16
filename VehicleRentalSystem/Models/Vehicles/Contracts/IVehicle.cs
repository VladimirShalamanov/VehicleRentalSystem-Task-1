namespace VehicleRentalSystem.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        string Brand { get; }

        string Model { get; }

        decimal ValueVehicle { get; }

        DateTime ReturnDate { get; }

        DateTime ReservationStartDate { get; }

        DateTime ReservationEndDate { get; }

        int ReservedDays();

        int ActualDays();

        decimal RentalCostPerDay();

        decimal InitInsurancePerDay();

        decimal UpdateInsurancePerDay();

        decimal InsurancePerDay();

        decimal EarlyDiscountRent();

        decimal EarlyDiscountInsurance();
    }
}
