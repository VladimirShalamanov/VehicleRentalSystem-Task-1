namespace VehicleRentalSystem.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidBrandName = "Brand name cannot be null or empty.";

        public const string InvalidModelName = "Model name cannot be null or empty.";

        public const string InvalidVehiclePrice = "Vehicle price cannot be below or equal to 0.";

        public const string InvalidCarSecurityRating = "The car's security rating cannot be lower than 1 or higher than 5.";

        public const string InvalidRiderAge = "Rider age is invalid.";

        public const string InvalidDriverExperience = "Driver experience must be a positive number.";
    }
}
