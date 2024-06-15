namespace VehicleRentalSystem.IO
{
    using System;

    using VehicleRentalSystem.IO.Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
