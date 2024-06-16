namespace VehicleRentalSystem.Utilities.CostManagement
{
    public static class Insurance
    {
        // 0.01% of the car's value
        public const decimal CarInsurancePerDay = 0.0001m;

        // 0.02% of the motorcycle's value
        public const decimal MotorcycleInsurancePerDay = 0.0002m;

        // 0.03% of the cargo van's value
        public const decimal CargoVanInsurancePerDay = 0.0003m;

        // Insurance update
        // Insurance reduced by 10% for cars
        public const decimal CarReduceInsurance = 0.1m;

        // Insurance increased by 20% for motorcycle
        public const decimal MotorcycleIncreaseInsurance = 0.2m;

        // Insurance reduced by 15% for cargo van
        public const decimal CargoVanReduceInsurance = 0.15m;
    }
}
