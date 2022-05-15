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
           IListable<ReleaseFile, GetAllReleaseFilesData>,
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
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<ReleaseFile> CreateAsync(CreateReleaseFileData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<ReleaseFile> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<ReleaseFile>> ListAsync(GetAllReleaseFilesData data)
        {
            return await base.ListEntitiesAsync(data);
        }
    }
}
