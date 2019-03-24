using System.Collections.Generic;
using System.Net;
using Contracts;
using MbDotNet;
using MbDotNet.Enums;
using MbDotNet.Models.Imposters;
using MbDotNet.Models.Responses;
using MbDotNet.Models.Responses.Fields;
using UserServiceImposter.Builders;
using UserServiceImposter.Models;

namespace UserServiceImposter
{
    public class UserService : DiscoverableImposter
    {
        private static readonly Dictionary<string, string> Headers = new Dictionary<string, string> { { "Access-Control-Allow-Origin", "*" } };

        public UserService(string serviceName, int port, bool serviceRecordRequests, IClient client, ICollection<Imposter> imposters)
            : base(port, MbDotNet.Enums.Protocol.Http, serviceName, serviceRecordRequests, client, imposters) { }

        public override void SetUpStubbs()
        {
            Imposter.AddStub()
                .OnPathAndMethodEqual("/", Method.Get)
                .Returns(AllUsersResponse());

            Imposter.AddStub()
                .OnPathAndMethodEqual("/SpecificUser", Method.Get)//{id}
                .ReturnsJson(HttpStatusCode.OK, SpecificUser());

            Imposter.AddStub()
                .OnPathAndMethodEqual("/InactiveUsers", Method.Get)//Inactive
                .ReturnsJson(HttpStatusCode.OK, InactiveUsers());
        }
        
        #region Data Provider Methods
        // There is a one to one relationship between these private methods and the imposters that call them. 
        // Do not re-use these private methods as this will make the tests brittle.

        private static IsResponse<HttpResponseFields> AllUsersResponse()
        {
            return new IsResponse<HttpResponseFields>(
                new HttpResponseFields
                {
                    StatusCode = HttpStatusCode.OK,
                    Headers = Headers,
                    ResponseObject = new[]
                    {
                        new UserBuilder().UserId(1234).Build(),
                        new UserBuilder().Build(),
                        new UserBuilder().Build()
                    }
                }
            );
        }

        private static User SpecificUser()
        {
            return new UserBuilder().EmailAddress("specific.user@userservice.co.uk").Build();
        }

        private static User[] InactiveUsers()
        {
            return new[]
            {
                new UserBuilder().IsActive(false).Build(),
                new UserBuilder().IsActive(false).Build()
            };
        }

        #endregion
    }
}