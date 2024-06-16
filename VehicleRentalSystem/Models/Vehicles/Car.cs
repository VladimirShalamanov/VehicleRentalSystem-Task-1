namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.CostManagement;
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class Car : Vehicle
    {
        private int securityRating;

        public Car(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int securityRating) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.SecurityRating = securityRating;
        }

        public int SecurityRating
        {
            get { return this.securityRating; }
            private set
            {
                if (value < VehicleRules.MinSecurityRating || value > VehicleRules.MaxSecurityRating)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarSecurityRating);
                }

                this.securityRating = value;
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
            decimal rentalCostPerDay = Prices.DailyRentalPriceCar;

            if (ActualDays() > VehicleRules.OneWeek)
            {
                rentalCostPerDay = Prices.WeekRentalPriceCar;
            }

            return rentalCostPerDay;
        }

        public override decimal InitInsurancePerDay()
        {
            decimal initInsurancePerDay = 0m;

            if (this.SecurityRating == VehicleRules.HighSecurityRating || this.SecurityRating == VehicleRules.MaxSecurityRating)
            {
                initInsurancePerDay = this.ValueVehicle * Insurance.CarInsurancePerDay;
            }

            return initInsurancePerDay;
        }

        public override decimal UpdateInsurancePerDay()
        {
            decimal updateInsurancePerDay = 0m;
            decimal initInsurancePerDay = InitInsurancePerDay();

            if (initInsurancePerDay != 0m)
            {
                updateInsurancePerDay = initInsurancePerDay * Insurance.CarReduceInsurance;
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
                insurancePerDay = this.ValueVehicle * Insurance.CarInsurancePerDay;
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
                decimal rentalCostPerDay = RentalCostPerDay();

                int daysWithoutRent = reservedDays - actualDays;

                earlyDiscountInsurance = rentalCostPerDay * daysWithoutRent;
            }

            return earlyDiscountRent;
        }
    }
}
