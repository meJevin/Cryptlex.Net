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
        IListable<Product, GetAllProductsData>,
        ICreatable<Product, CreateProductData>,
        IRetrievable<Product>,
        IUpdatable<Product, UpdateProductData>,
        IDeletable<Product>
    {
        Task<Stream> DownloadDAT(string id);
    }

    public class ProductsService : BaseService<Product>, IProductsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Products);

        public ProductsService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<Stream> DownloadDAT(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id, "product.dat");

            var result = await RequestAsync(uri, HttpMethod.Get, null);

            result.ThrowIfFailed($"Could not download product.dat file for product with id {id}");

            return await result.ResponseMessage.Content.ReadAsStreamAsync();
        }

        public async Task<IEnumerable<Product>> ListAsync(GetAllProductsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async Task<Product> CreateAsync(CreateProductData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<Product> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<Product> UpdateAsync(string id, UpdateProductData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
