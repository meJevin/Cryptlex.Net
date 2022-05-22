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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<ProductVersion> CreateAsync(CreateProductVersionData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<ProductVersion> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<ProductVersion>> ListAsync(ListProductVersionsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<ProductVersion> UpdateAsync(string id, UpdateProductVersionData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }
    }
}
