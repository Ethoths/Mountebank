using System;
using System.Collections.Generic;
using System.Net;
using Contracts;
using FuelServiceImposter.Builders;
using FuelServiceImposter.Models;
using MbDotNet;
using MbDotNet.Enums;
using MbDotNet.Models.Imposters;

namespace FuelServiceImposter
{
    public class FuelService : DiscoverableImposter
    {
        public FuelService(string serviceName, int port, bool serviceRecordRequests, IClient client, ICollection<Imposter> imposters)
            : base(port, MbDotNet.Enums.Protocol.Http, serviceName, serviceRecordRequests, client, imposters) { }

        public override void SetUpStubbs()
        {
            Imposter.AddStub()
                .OnPathAndMethodEqual("/AccountPeriods", Method.Get)
                .ReturnsJson(HttpStatusCode.OK, TestAccountPeriods());

            Imposter.AddStub()
                .OnPathAndMethodEqual("/AccountPeriods/21", Method.Get)
                .ReturnsJson(HttpStatusCode.OK, TestAccountPeriod21());
        }

        #region Data Provider Methods
        // There is a one to one relationship between these private methods and the imposters that call them. 
        // Do not re-use these private methods as this will make the tests brittle.

        private static AccountPeriod[] TestAccountPeriods()
        {
            var now = DateTime.Now;

            return new[]
            {
                new AccountPeriodBuilder().AccountId(1).StartDate(now.AddMonths(-1)).Build(),
                new AccountPeriodBuilder().AccountId(2).StartDate(now.AddMonths(0)).Build(),
                new AccountPeriodBuilder().AccountId(3).StartDate(now.AddMonths(-2)).Build()
            };
        }

        private static AccountPeriod TestAccountPeriod21()
        {
            return new AccountPeriodBuilder().Id(21).Build();
        }

        #endregion
    }
}