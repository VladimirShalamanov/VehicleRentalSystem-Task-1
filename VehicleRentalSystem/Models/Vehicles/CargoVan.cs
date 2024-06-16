namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.CostManagement;
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class CargoVan : Vehicle
    {
        private int driverExperience;

        public CargoVan(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int driverExperience) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.DriverExperience = driverExperience;
        }

        public int DriverExperience
        {
            get { return this.driverExperience; }
            private set
            {
                if (value < VehicleRules.CheckDriverExperiencePositiveNumber)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDriverExperience);
                }

                this.driverExperience = value;
            }
        }

        public override int ReservedDays()
        {
            TimeSpan difference = this.ReservationEndDate - this.ReservationStartDate;

            int reservedDays = difference.Days;

            return reservedDays;
        }

        public override int ActualDays()
        {
            TimeSpan difference = this.ReturnDate - this.ReservationStartDate;

            int actualDays = difference.Days;

            return actualDays;
        }

        public override decimal RentalCostPerDay()
        {
            decimal rentalCostPerDay = Prices.DailyRentalPriceCargoVan;

            if (ActualDays() > VehicleRules.OneWeek)
            {
                rentalCostPerDay = Prices.WeekRentalPriceCargoVan;
            }

            return rentalCostPerDay;
        }

        public override decimal InitInsurancePerDay()
        {
            decimal initInsurancePerDay = 0m;

            if (this.DriverExperience > VehicleRules.MinDriverExperience)
            {
                initInsurancePerDay = this.ValueVehicle * Insurance.CargoVanInsurancePerDay;
            }

            return initInsurancePerDay;
        }

        public override decimal UpdateInsurancePerDay()
        {
            decimal updateInsurancePerDay = 0m;
            decimal initInsurancePerDay = InitInsurancePerDay();

            if (initInsurancePerDay != 0m)
            {
                updateInsurancePerDay = initInsurancePerDay * Insurance.CargoVanReduceInsurance;
            }

            return updateInsurancePerDay;
        }

        public override decimal InsurancePerDay()
        {
            decimal insurancePerDay = 0m;
            decimal initInsurancePerDay = InitInsurancePerDay();
            decimal updateInsurancePerDay = UpdateInsurancePerDay();

            if (initInsurancePerDay != 0m && updateInsurancePerDay != 0m)
            {
                insurancePerDay = initInsurancePerDay - updateInsurancePerDay;
            }
            else
            {
                insurancePerDay = this.ValueVehicle * Insurance.CargoVanInsurancePerDay;
            }

            return insurancePerDay;
        }

        public override decimal EarlyDiscountRent()
        {
            decimal earlyDiscountRent = 0m;
            int reservedDays = ReservedDays();
            int actualDays = ActualDays();

            if (reservedDays != actualDays)
            {
                decimal rentalCostPerDay = RentalCostPerDay();
                int daysWithoutRent = reservedDays - actualDays;

                earlyDiscountRent = (daysWithoutRent * rentalCostPerDay) / 2;
            }

            return earlyDiscountRent;
        }

        public override decimal EarlyDiscountInsurance()
        {
            decimal earlyDiscountInsurance = 0m;
            decimal earlyDiscountRent = EarlyDiscountRent();

            if (earlyDiscountRent != 0m)
            {
                int reservedDays = ReservedDays();
                int actualDays = ActualDays();
                decimal insurancePerDay = InsurancePerDay();

                int daysWithoutRent = reservedDays - actualDays;

                earlyDiscountInsurance = daysWithoutRent * insurancePerDay;
            }

            return earlyDiscountInsurance;
        }
    }
}
