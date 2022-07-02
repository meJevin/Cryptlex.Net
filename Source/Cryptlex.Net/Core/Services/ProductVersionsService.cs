using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.ProductVersions;
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
    public interface IProductVersionsService :
        IListable<ProductVersion, ListProductVersionsData>,
        ICreatable<ProductVersion, CreateProductVersionData>,
        IRetrievable<ProductVersion>,
        IUpdatable<ProductVersion, UpdateProductVersionData>,
        IDeletable<ProductVersion>
    {
    }

    public class ProductVersionsService : BaseService<ProductVersion>, IProductVersionsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.ProductVersions);

        public ProductVersionsService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory cryptlexAccessTokenFactory)
            : base(httpClientFactory, cryptlexAccessTokenFactory)
        {
        }

        public async Task<ProductVersion> CreateAsync(CreateProductVersionData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<ProductVersion> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<ProductVersion>> ListAsync(ListProductVersionsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<ProductVersion> ListAutoPagingAsync(ListProductVersionsData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<ProductVersion> UpdateAsync(string id, UpdateProductVersionData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }
    }
}
