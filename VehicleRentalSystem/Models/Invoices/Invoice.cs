namespace VehicleRentalSystem.Models.Invoices
{
    using System.Collections.Generic;
    using System.Text;

    using VehicleRentalSystem.Models.Invoices.Contracts;
    using VehicleRentalSystem.Models.Vehicles;
    using VehicleRentalSystem.Models.Vehicles.Contracts;
    using VehicleRentalSystem.Repositories;
    using VehicleRentalSystem.Utilities.CostManagement;

    public class Invoice : IInvoice
    {
        private readonly VehicleRepository vehiclesRepo;

        public Invoice()
        {
            this.vehiclesRepo = new VehicleRepository();
            this.RentalVehicles = new HashSet<IVehicle>();
        }

        public ICollection<IVehicle> RentalVehicles { get; }

        public void AddVehicle(IVehicle vehicle)
        {
            this.RentalVehicles.Add(vehicle);
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            foreach (var v in RentalVehicles)
            {
                sb
                    .AppendLine("XXXXXXXXXX")
                    .AppendLine($"Date: {v.ReturnDate.ToString("yyyy-MM-dd")}")
                    .Append("Customer Name: ");

                if (v.GetType().Name == "Car")
                {
                    sb.AppendLine("John Doe");
                }

                else if (v.GetType().Name == "Motorcycle")
                {
                    sb.AppendLine("Mary Johnson");
                }

                else if (v.GetType().Name == "CargoVan")
                {
                    sb.AppendLine("John Markson");
                }

                sb
                    .Append("Rented Vehicle: ")
                    .AppendLine($"{v.Brand} {v.Model}")
                    .AppendLine()
                    .AppendLine($"Reservation start date: {v.ReservationStartDate.ToString("yyyy-MM-dd")}")
                    .AppendLine($"Reservation end date: {v.ReservationEndDate.ToString("yyyy-MM-dd")}")
                    .AppendLine($"Reserved rental days: {v.ReservedDays()} days")
                    .AppendLine()
                    .AppendLine($"Actual Return date: {v.ReturnDate.ToString("yyyy-MM-dd")}")
                    .AppendLine($"Actual rental days: {v.ActualDays()} days")
                    .AppendLine()
                    .AppendLine($"Rental cost per day: ${v.RentalCostPerDay():f2}");

                if (v.InitInsurancePerDay() > 0)
                {
                    sb
                       .AppendLine($"Initial insurance per day: ${v.InitInsurancePerDay():f2}")
                       .AppendLine($"Insurance discount per day: ${v.UpdateInsurancePerDay():f2}");

                }

                sb.AppendLine($"Insurance per day: ${v.InsurancePerDay():f2}");

                decimal totalRent = v.ActualDays() * v.RentalCostPerDay();
                decimal totalInsurance = v.ActualDays() * v.InsurancePerDay();

                if (v.ActualDays() != v.ReservedDays())
                {
                    decimal earlyDiscountRent = v.EarlyDiscountRent();

                    totalRent += earlyDiscountRent;
                    decimal earlyDiscountInsurance = v.EarlyDiscountInsurance();

                    sb
                       .AppendLine()
                       .AppendLine($"Early return discount for rent: ${earlyDiscountRent:f2}")
                       .AppendLine($"Early return discount for insurance: ${earlyDiscountInsurance:f2}")
                       .AppendLine();
                }


                sb
                    .AppendLine()
                    .AppendLine($"Total rent: ${totalRent:f2}")
                    .AppendLine($"Total insurance: ${totalInsurance:f2}")
                    .AppendLine($"Total: ${(totalRent + totalInsurance):f2}")
                    .AppendLine("XXXXXXXXXX")
                    .AppendLine($"\n\r");
            }

            return sb.ToString();
        }
    }
}
