namespace VehicleRentalSystem.Utilities.RentalRules
{
    public static class VehicleRules
    {
        // Range and a High car safety Rating
        public const int MinSecurityRating = 1;
        public const int HighSecurityRating = 4;
        public const int MaxSecurityRating = 5;

        // Rules for rider Age
        public const int MinRiderAge = 1;
        public const int MaxRiderAge = 100;
        public const int YoungRiderAge = 25;

        // Rules for driver Experience
        public const int CheckDriverExperiencePositiveNumber = 0;
        public const int MinDriverExperience = 5;

        // One week Rule
        public const int OneWeek = 7;
    }
}
