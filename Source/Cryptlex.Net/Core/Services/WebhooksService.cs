using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Webhooks;
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
    public interface IWebhooksService :
        IListable<Webhook, ListWebhooksData>,
        ICreatable<Webhook, CreateWebhookData>,
        IRetrievable<Webhook>,
        IUpdatable<Webhook, UpdateWebhookData>,
        IDeletable<Webhook>
    {
        Task<IEnumerable<Event>> ListEvents();
    }

    public class WebhooksService : BaseService<Webhook>, IWebhooksService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Webhooks);

        public static class Actions
        {
            public static string ListEvents = "events";
        }

        public WebhooksService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<Webhook> CreateAsync(CreateWebhookData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<Webhook> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<Webhook>> ListAsync(ListWebhooksData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<Webhook> ListAutoPagingAsync(ListWebhooksData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<Webhook> UpdateAsync(string id, UpdateWebhookData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task<IEnumerable<Event>> ListEvents()
        {
            var uri = Utils.CombinePaths(BasePath, Actions.ListEvents);

            var result = await RequestAsync(uri, HttpMethod.Get, null);

            result.ThrowIfFailed("Could not list all webhook events.");

            var resultData = await result.ExtractDataAsync<IEnumerable<Event>>();

            return resultData;
        }
    }
}
