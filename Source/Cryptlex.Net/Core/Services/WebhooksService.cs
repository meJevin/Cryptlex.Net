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
        Task<IEnumerable<Event>> ListEvents(RequestOptions? requestOptions = null);
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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<Webhook> CreateAsync(CreateWebhookData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<Webhook> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<Webhook>> ListAsync(ListWebhooksData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Webhook> UpdateAsync(string id, UpdateWebhookData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task<IEnumerable<Event>> ListEvents(RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.ListEvents);

            var result = await RequestAsync(uri, HttpMethod.Get, requestOptions: requestOptions);

            result.ThrowIfFailed("Could not list all webhook events.");

            var resultData = await result.ExtractDataAsync<IEnumerable<Event>>();

            return resultData;
        }
    }
}
