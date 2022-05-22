using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Tags;
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
    public interface ITagsService :
        IListable<Tag, ListTagsData>,
        ICreatable<Tag, CreateTagData>,
        IRetrievable<Tag>,
        IUpdatable<Tag, UpdateTagData>,
        IDeletable<Tag>
    {
    }

    public class TagsService : BaseService<Tag>, ITagsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Tags);

        public TagsService(
            IHttpClientFactory httpClientFactory, 
            ICryptlexAccessTokenFactory tokenFactory) 
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<Tag>> ListAsync(ListTagsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Tag> CreateAsync(CreateTagData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<Tag> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<Tag> UpdateAsync(string id, UpdateTagData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
