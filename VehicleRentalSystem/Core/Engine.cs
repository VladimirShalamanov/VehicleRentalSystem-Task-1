namespace VehicleRentalSystem.Core
{

    using VehicleRentalSystem.IO;
    using VehicleRentalSystem.IO.Contracts;
    using VehicleRentalSystem.Core.Contracts;

    using VehicleRentalSystem.Utilities.ExampleInputs;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            string[] typesForInvoice = Inputs.TypesVehicles.Split(", ");

            foreach (string type in typesForInvoice)
            {
                try
                {
                    
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
            // print


            //DateTime r = DateTime.Parse(Inputs.CargoVanReturnDate);
            //DateTime s = DateTime.Parse(Inputs.CargoVanReservationStartDate);
            //DateTime e = DateTime.Parse(Inputs.CargoVanReservationEndDate);


            //var diff = e - s;
            //Console.WriteLine(r.ToString("yyyy-MM-dd"));
            //Console.WriteLine(diff.Days);
        }
    }
}
