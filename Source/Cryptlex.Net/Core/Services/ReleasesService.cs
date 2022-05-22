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
        Task<Release> CheckForUpdate(CheckForUpdateReleaseData data, RequestOptions? requestOptions = null);
        Task<Release> GetLatestRelease(GetLatestReleaseData data, RequestOptions? requestOptions = null);
        Task<Release> Publish(string id, RequestOptions? requestOptions = null);
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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<Release> CreateAsync(CreateReleaseData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<Release> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<Release>> ListAsync(ListReleasesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Release> UpdateAsync(string id, UpdateReleaseData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task<Release> CheckForUpdate(CheckForUpdateReleaseData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.CheckForUpdate);

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"Could not check for update.");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }

        public async Task<Release> GetLatestRelease(GetLatestReleaseData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.GetLatestRelease);

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"Could not get latest release for product wth id {data.productId}.");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }

        public async Task<Release> Publish(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Publish);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not publish release with id {id}");

            var resultData = await result.ExtractDataAsync<Release>();

            return resultData;
        }
    }
}
