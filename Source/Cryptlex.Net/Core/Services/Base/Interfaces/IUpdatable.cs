namespace Cryptlex.Net.Core.Services.Base
{
    public interface IUpdatable<T, TUpdateData>
    {
        Task<T> UpdateAsync(string id, TUpdateData data);
    }
}
