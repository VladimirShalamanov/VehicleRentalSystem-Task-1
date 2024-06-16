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
            // Example inputs for the Demo NOT real user data for production environment
            string[] typesVehicle = Inputs.TypesVehicles.Split(", ");

            for (int i = 0; i < typesVehicle.Length; i++)
            {
                try
                {
                    this.controller.AddVehicle(typesVehicle[i]);

                    if (i == typesVehicle.Length - 1)
                    {
                        writer.WriteLine(this.controller.Report());

                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
