namespace VehicleRentalSystem
{
    using VehicleRentalSystem.Core;
    using VehicleRentalSystem.Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
