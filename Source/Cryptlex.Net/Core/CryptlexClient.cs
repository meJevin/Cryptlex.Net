using Cryptlex.Net.Core.Services;

namespace Cryptlex.Net.Core
{
    public interface ICryptlexClient
    {
        ILicensesService Licenses { get; }
        IActivationsService Activations { get; }
        ITagsService Tags { get; }
    }

    public class CryptlexClient : ICryptlexClient
    {
        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }
        public ITagsService Tags { get; init; }

        public CryptlexClient(
            ILicensesService licenses,
            IActivationsService activations,
            ITagsService tags)
        {
            Licenses = licenses;
            Activations = activations;
            Tags = tags;
        }
    }
}
