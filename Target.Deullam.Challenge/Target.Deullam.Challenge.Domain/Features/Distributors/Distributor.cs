using Target.Deullam.Challenge.Domain.Exceptions;

namespace Target.Deullam.Challenge.Domain.Features.Distributors
{
    /// <summary>
    /// Represents a distributor that tracks daily billing data and provides calculations
    /// for minimum, maximum, average billing, and number of days where the billing was above the average.
    /// </summary>
    public class Distributor
    {
        /// <summary>
        /// Gets or sets the list of daily billing values, where each value represents the billing for a day.
        /// </summary>
        public List<double> DailyBillingList { get; set; }

        /// <summary>
        /// A private list of daily billing values filtered to only include business days (i.e., non-zero values).
        /// </summary>
        private List<double> DailyBillingListWithBusinessDays { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Distributor"/> class with empty billing lists.
        /// </summary>
        public Distributor()
        {
            this.DailyBillingList = new List<double>();
            this.DailyBillingListWithBusinessDays = new List<double>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Distributor"/> class with a specified list of daily billing values.
        /// Filters out non-business days (values equal to 0).
        /// </summary>
        /// <param name="_DailyBillingList">A list of daily billing values, where each value represents the billing for a day.</param>
        public Distributor(List<double> _DailyBillingList)
        {
            DailyBillingList = _DailyBillingList;
            DailyBillingListWithBusinessDays = _DailyBillingList.Where(f => f > 0).ToList();
        }

        /// <summary>
        /// Calculates the minimum billing from the list of daily billings.
        /// It filters out non-business days (values equal to 0) and returns the lowest billing amount.
        /// </summary>
        /// <returns>
        /// A double representing the minimum billing amount from the list of business days.
        /// </returns>
        /// <exception cref="ValuesUndefinedException">
        /// Thrown if the list is empty or contains only zero values after filtering non-business days.
        /// </exception>
        public double CalculateMinimumBilling()
        {
            if (DailyBillingListWithBusinessDays.Count == 0)
            {
                DailyBillingListWithBusinessDays = DailyBillingList.Where(f => f > 0).ToList();
            }

            ValidateList(DailyBillingListWithBusinessDays);

            double minBilling = this.DailyBillingListWithBusinessDays.Min();
            return minBilling;
        }

        /// <summary>
        /// Calculates the maximum billing from the list of daily billings.
        /// It filters out non-business days (values equal to 0) and returns the highest billing amount.
        /// </summary>
        /// <returns>
        /// A double representing the maximum billing amount from the list of business days.
        /// </returns>
        /// <exception cref="ValuesUndefinedException">
        /// Thrown if the list is empty or contains only zero values after filtering non-business days.
        /// </exception>
        public double CalculateMaximumBilling()
        {
            if (DailyBillingListWithBusinessDays.Count == 0)
            {
                DailyBillingListWithBusinessDays = DailyBillingList.Where(f => f > 0).ToList();
            }

            ValidateList(DailyBillingListWithBusinessDays);

            double maxBilling = this.DailyBillingListWithBusinessDays.Max();
            return maxBilling;
        }

        /// <summary>
        /// Calculates the average billing from the list of daily billings.
        /// It filters out non-business days (values equal to 0) and returns the average billing amount.
        /// </summary>
        /// <returns>
        /// A double representing the average billing amount from the list of business days.
        /// </returns>
        /// <exception cref="ValuesUndefinedException">
        /// Thrown if the list is empty or contains only zero values after filtering non-business days.
        /// </exception>
        public double CalculateAverageBilling()
        {
            if (DailyBillingListWithBusinessDays.Count == 0)
            {
                DailyBillingListWithBusinessDays = DailyBillingList.Where(f => f > 0).ToList();
            }

            ValidateList(DailyBillingListWithBusinessDays);

            double avgBilling = this.DailyBillingListWithBusinessDays.Average();
            return avgBilling;
        }

        /// <summary>
        /// Calculates the number of days where the daily billing was above the annual average billing.
        /// It filters out non-business days (values equal to 0) and returns the count of such days.
        /// </summary>
        /// <returns>
        /// An integer representing the number of days where the billing was above the average annual billing.
        /// </returns>
        /// <exception cref="ValuesUndefinedException">
        /// Thrown if the list is empty or contains only zero values after filtering non-business days.
        /// </exception>
        public int CalculateDaysAboveAverageBilling()
        {
            if (DailyBillingListWithBusinessDays.Count == 0)
            {
                DailyBillingListWithBusinessDays = DailyBillingList.Where(f => f > 0).ToList();
            }

            double averageAnnual = CalculateAverageBilling();
            int daysAboveAverage = DailyBillingListWithBusinessDays.Count(f => f > averageAnnual);

            ValidateList(DailyBillingListWithBusinessDays);

            return daysAboveAverage;
        }

        /// <summary>
        /// Validates the provided list of billing values to ensure it is not null and does not contain only zero values.
        /// </summary>
        /// <param name="listOfValues">The list of billing values to validate.</param>
        /// <exception cref="ValuesUndefinedException">
        /// Thrown if the list is null or contains only zero values.
        /// </exception>
        public static void ValidateList(List<double> listOfValues)
        {
            if (listOfValues == null)
            {
                throw new ValuesUndefinedException();
            }
            else if (listOfValues.All(v => v == 0))
            {
                throw new ValuesUndefinedException();
            }
        }
    }

}
