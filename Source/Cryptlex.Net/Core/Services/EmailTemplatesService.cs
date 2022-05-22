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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<EmailTemplate>> ListAsync(ListEmailTemplatesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<EmailTemplate> CreateAsync(CreateEmailTemplateData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<EmailTemplate> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<EmailTemplate> UpdateAsync(string id, UpdateEmailTemplateData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
