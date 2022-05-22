namespace Cryptlex.Net.Core.Services.Base
{
    public interface ICreatable<T, TCreateData>
    {
        Task<T> CreateAsync(TCreateData data, RequestOptions? requestOptions = null);
    }
}
