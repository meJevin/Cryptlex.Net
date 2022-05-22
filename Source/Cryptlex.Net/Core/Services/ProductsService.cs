using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Products;
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
    public interface IProductsService :
        IListable<Product, ListProductsData>,
        ICreatable<Product, CreateProductData>,
        IRetrievable<Product>,
        IUpdatable<Product, UpdateProductData>,
        IDeletable<Product>
    {
        Task<Stream> DownloadDAT(string id, RequestOptions? requestOptions = null);
    }

    public class ProductsService : BaseService<Product>, IProductsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Products);

        public ProductsService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<Stream> DownloadDAT(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, "product.dat");

            var result = await RequestAsync(uri, HttpMethod.Get, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not download product.dat file for product with id {id}");

            return await result.ResponseMessage.Content.ReadAsStreamAsync();
        }

        public async Task<IEnumerable<Product>> ListAsync(ListProductsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Product> CreateAsync(CreateProductData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<Product> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<Product> UpdateAsync(string id, UpdateProductData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
