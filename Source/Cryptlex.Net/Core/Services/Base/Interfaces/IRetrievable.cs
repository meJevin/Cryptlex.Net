namespace Cryptlex.Net.Core.Services.Base
{
    public interface IRetrievable<T>
    {
        Task<T> GetAsync(string id);
    }
}
