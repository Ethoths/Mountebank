using System;

namespace FuelServiceImposter.Models
{
    public class AccountPeriod
    {
        public int Id { get; set; }

        public int CustomerPeriodId { get; set; }

        public int AccountId { get; set; }

        public int? PayrollId { get; set; }

        public DateTime? PayrollRollbackDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}