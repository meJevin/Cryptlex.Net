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
            ICryptlexAccessTokenFactory cryptlexAccessTokenFactory)
            : base(httpClientFactory, cryptlexAccessTokenFactory)
        {
        }

        public async Task<IEnumerable<Tag>> ListAsync(ListTagsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<Tag> ListAutoPagingAsync(ListTagsData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<Tag> CreateAsync(CreateTagData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<Tag> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<Tag> UpdateAsync(string id, UpdateTagData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
