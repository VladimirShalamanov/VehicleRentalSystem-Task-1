namespace VehicleRentalSystem.Models.Vehicles
{
    using VehicleRentalSystem.Utilities.CostManagement;
    using VehicleRentalSystem.Utilities.Messages;
    using VehicleRentalSystem.Utilities.RentalRules;

    public class Motorcycle : Vehicle
    {
        private int riderAge;

        public Motorcycle(
            string brand,
            string model,
            decimal valueVehicle,
            DateTime returnDate,
            DateTime reservationStartDate,
            DateTime reservationEndDate,
            int riderAge) : base(
                  brand,
                  model,
                  valueVehicle,
                  returnDate,
                  reservationStartDate,
                  reservationEndDate)
        {
            this.RiderAge = riderAge;
        }

        public int RiderAge
        {
            get { return this.riderAge; }
            private set
            {
                if (value < VehicleRules.MinRiderAge || value > VehicleRules.MaxRiderAge)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRiderAge);
                }

                this.riderAge = value;
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
            decimal rentalCostPerDay = Prices.DailyRentalPriceMotorcycle;

            if (ActualDays() > VehicleRules.OneWeek)
            {
                rentalCostPerDay = Prices.WeekRentalPriceMotorcycle;
            }

            return rentalCostPerDay;
        }

        public override decimal InitInsurancePerDay()
        {
            decimal initInsurancePerDay = 0m;

            if (this.RiderAge < VehicleRules.YoungRiderAge)
            {
                initInsurancePerDay = this.ValueVehicle * Insurance.MotorcycleInsurancePerDay;
            }

            return initInsurancePerDay;
        }

        public override decimal UpdateInsurancePerDay()
        {
            decimal updateInsurancePerDay = 0m;
            decimal initInsurancePerDay = InitInsurancePerDay();

            if (initInsurancePerDay != 0m)
            {
                updateInsurancePerDay = initInsurancePerDay * Insurance.MotorcycleIncreaseInsurance;
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
                insurancePerDay = initInsurancePerDay + updateInsurancePerDay;
            }
            else
            {
                insurancePerDay = this.ValueVehicle * Insurance.MotorcycleInsurancePerDay;
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
