namespace Cryptlex.Net.Core.Services.Base
{
    public interface IListable<T, TListData>
        where TListData : IListRequest
    {
        Task<IEnumerable<T>> ListAsync(TListData data);
        /// <summary>
        /// Enumerates over Cryptlex entities, requesting page by page asynchronously
        /// </summary>
        /// <param name="data">This argument will be used to queury entities, each page request to Cryptlex only increments tha Page parameter</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        IAsyncEnumerable<T> ListAutoPagingAsync(TListData data);
    }
}
