﻿using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Util;
using System.Text.Json;

namespace Cryptlex.Net.Core.Services
{
    public class RequestResult
    {
        public HttpResponseMessage ResponseMessage { get; private set; }
        public Error? CryptlexError { get; private set; }
        public string? ReasonPhrase { get; private set; }

        public bool IsSuccessStatusCode => ResponseMessage is not null && ResponseMessage.IsSuccessStatusCode;

        private RequestResult(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public async Task<T> ExtractDataAsync<T>()
        {
            var stringContent = await ResponseMessage.Content.ReadAsStringAsync();

            if (stringContent is null)
            {
                throw new ArgumentNullException("Cannot extract data from RequestResult, because its HttpResponseMessage.Content is null");
            }

            return JsonSerializer.Deserialize<T>(stringContent)!;
        }

        public override string ToString()
        {
            if (IsSuccessStatusCode) return String.Empty;

            var errors = new List<string>
            {
                $"Failed with code {ResponseMessage.StatusCode}"
            };

            if (CryptlexError is not null)
            {
                errors.Add($"Cryptlex error: {CryptlexError.message}");
            }

            if (ReasonPhrase is not null)
            {
                errors.Add($"Reason phrase: {ReasonPhrase}");
            }

            return String.Join(". ", errors);
        }

        public void ThrowIfFailed(string? errorStartMsg)
        {
            if (IsSuccessStatusCode) return;

            if (CryptlexError is not null)
            {
                throw new CryptlexException(errorStartMsg + " " + ToString());
            }

            if (ReasonPhrase is not null)
            {
                throw new HttpRequestException(errorStartMsg + " " + ToString());
            }
        }

        public static async Task<RequestResult> FromHttpResponseAsync(HttpResponseMessage message)
        {
            var result = new RequestResult(message);

            if (!message.IsSuccessStatusCode)
            {
                result.CryptlexError = await message.Content.ReadCryptlexErrorAsync();
                result.ReasonPhrase = message.ReasonPhrase;
            }

            return result;
        }
    }
}