namespace VehicleRentalSystem.Models.Invoices
{
    using System.Collections.Generic;
    using System.Text;

    using VehicleRentalSystem.Models.Invoices.Contracts;
    using VehicleRentalSystem.Models.Vehicles.Contracts;

    public class Invoice : IInvoice
    {
        public Invoice()
        {
            this.RentalVehicles = new HashSet<IVehicle>();
        }

        public ICollection<IVehicle> RentalVehicles { get; }

        public void AddVehicle(IVehicle vehicle)
        {
            this.RentalVehicles.Add(vehicle);
        }

        public string GetInfo()
        {
            // check name of user
            var sb = new StringBuilder();

            foreach (var v in RentalVehicles)
            {
                sb
                    .AppendLine($"some{v.Brand}")
                    .AppendLine($"some");
            }

            return sb.ToString();
        }
    }
}
