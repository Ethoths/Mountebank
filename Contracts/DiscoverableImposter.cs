using System.Collections.Generic;
using MbDotNet;
using MbDotNet.Enums;
using MbDotNet.Models.Imposters;

namespace Contracts
{
    public abstract class DiscoverableImposter : Imposter, IDiscoverableImposter
    {
        protected DiscoverableImposter(int port, Protocol protocol, string name, bool recordRequests, IClient client, ICollection<Imposter> imposters) 
            : base(port, protocol, name, recordRequests)
        {
            Imposter = client.CreateHttpImposter(port, name);
            imposters.Add(Imposter);
        }

        public HttpImposter Imposter { get; set; }

        protected void Create()
        {
        }

        public virtual void SetUpStubbs()
        {
            throw new System.NotImplementedException();
        }
    }
}