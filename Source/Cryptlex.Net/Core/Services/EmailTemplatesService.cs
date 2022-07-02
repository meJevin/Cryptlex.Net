using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.EmailTemplates;
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
    public interface IEmailTemplatesService :
        IListable<EmailTemplate, ListEmailTemplatesData>,
        ICreatable<EmailTemplate, CreateEmailTemplateData>,
        IRetrievable<EmailTemplate>,
        IUpdatable<EmailTemplate, UpdateEmailTemplateData>,
        IDeletable<EmailTemplate>
    {
    }

    public class EmailTemplatesService : BaseService<EmailTemplate>, IEmailTemplatesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.EmailTemplates);

        public EmailTemplatesService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<EmailTemplate>> ListAsync(ListEmailTemplatesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<EmailTemplate> ListAutoPagingAsync(ListEmailTemplatesData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<EmailTemplate> CreateAsync(CreateEmailTemplateData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<EmailTemplate> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<EmailTemplate> UpdateAsync(string id, UpdateEmailTemplateData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
