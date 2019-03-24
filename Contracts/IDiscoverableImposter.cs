using MbDotNet.Models.Imposters;

namespace Contracts
{
    public interface IDiscoverableImposter
    {
        HttpImposter Imposter { get; set; }

        void SetUpStubbs();
    }
}