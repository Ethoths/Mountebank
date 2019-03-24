using System;
using FuelServiceImposter.Models;

namespace FuelServiceImposter.Builders
{
    public class AccountPeriodBuilder
    {
        private int _id = Randomiser.Int();
        private int _customerPeriodId = Randomiser.Int();
        private int _accountId = Randomiser.Int();
        private int? _payrollId = Randomiser.Int();
        private DateTime? _payrollRollbackDate = Randomiser.PastDate;
        private DateTime _startDate = Randomiser.PastDate;
        private DateTime _endDate = Randomiser.FutureDate;

        public AccountPeriodBuilder Id(int id)
        {
            _id = id;

            return this;
        }

        public AccountPeriodBuilder CustomerPeriodId(int customerPeriodId)
        {
            _customerPeriodId = customerPeriodId;

            return this;
        }

        public AccountPeriodBuilder AccountId(int accountId)
        {
            _accountId = accountId;

            return this;
        }

        public AccountPeriodBuilder PayrollId(int? payrollId)
        {
            _payrollId = payrollId;

            return this;
        }

        public AccountPeriodBuilder PayrollRollbackDate(DateTime? payrollRollbackDate)
        {
            _payrollRollbackDate = payrollRollbackDate;

            return this;
        }

        public AccountPeriodBuilder StartDate(DateTime startDate)
        {
            _startDate = startDate;

            return this;
        }

        public AccountPeriodBuilder EndDate(DateTime endDate)
        {
            _endDate = endDate;

            return this;
        }

        public AccountPeriod Build()
        {
            return new AccountPeriod
            {
                Id = _id,
                CustomerPeriodId = _customerPeriodId,
                AccountId = _accountId,
                PayrollId = _payrollId,
                PayrollRollbackDate = _payrollRollbackDate,
                StartDate = _startDate,
                EndDate = _endDate
            };
        }
    }
}