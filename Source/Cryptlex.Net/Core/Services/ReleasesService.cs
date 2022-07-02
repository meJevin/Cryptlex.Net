using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Releases;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cryptlex.Net.Core.Services
{
    public interface IReleasesService :
           IListable<Release, ListReleasesData>,
           ICreatable<Release, CreateReleaseData>,
           IRetrievable<Release>,
           IUpdatable<Release, UpdateReleaseData>,
           IDeletable<Release>
    {
        Task<Release> CheckForUpdate(CheckForUpdateReleaseData data);
        Task<Release> GetLatestRelease(GetLatestReleaseData data);
        Task<Release> Publish(string id);
    }

    public class ReleasesService : BaseService<Release>, IReleasesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Releases);

        public static class Actions
        {
            public static string CheckForUpdate = "update";
            public static string GetLatestRelease = "latest";
            public static string Publish = "publish";
        }

        public ReleasesService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory cryptlexAccessTokenFactory)
            : base(httpClientFactory, cryptlexAccessTokenFactory)
        {
        }

        public async Task<Release> CreateAsync(CreateReleaseData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<Release> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<Release>> ListAsync(ListReleasesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<Release> ListAutoPagingAsync(ListReleasesData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<Release> UpdateAsync(string id, UpdateReleaseData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task<Release> CheckForUpdate(CheckForUpdateReleaseData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.CheckForUpdate);

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"Could not check for update.");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }

        public async Task<Release> GetLatestRelease(GetLatestReleaseData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.GetLatestRelease);

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"Could not get latest release for product wth id {data.ProductId}.");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }

        public async Task<Release> Publish(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Publish);

            var result = await RequestAsync(uri, HttpMethod.Post, null);

            result.ThrowIfFailed($"Could not publish release with id {id}");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }
    }
}
