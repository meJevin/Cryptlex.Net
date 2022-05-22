using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.ReleaseFiles;
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
    public interface IReleaseFilesService :
           IListable<ReleaseFile, ListReleaseFilesData>,
           ICreatable<ReleaseFile, CreateReleaseFileData>,
           IRetrievable<ReleaseFile>,
           IDeletable<ReleaseFile>
    {
    }

    public class ReleaseFilesService : BaseService<ReleaseFile>, IReleaseFilesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.ReleaseFiles);

        public ReleaseFilesService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<ReleaseFile> CreateAsync(CreateReleaseFileData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<ReleaseFile> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<ReleaseFile>> ListAsync(ListReleaseFilesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }
    }
}
