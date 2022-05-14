using CryptlexDotNet.Core.Services;

namespace CryptlexDotNet.Core
{
    public interface ICryptlexClient
    {
        ILicensesService Licenses { get; }
        IActivationsService Activations { get; }
    }

    public class CryptlexClient : ICryptlexClient
    {
        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }

        public CryptlexClient(
            ILicensesService licenses,
            IActivationsService activations)
        {
            Licenses = licenses;
            Activations = activations;
        }
    }
}
