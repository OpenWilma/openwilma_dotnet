using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Wilma;
using Wilma.Api.Web.Json;

using Utf8Json;
using Utf8Json.Resolvers;
using Utf8Json.Formatters;

namespace Wilma.Api.Web
{
    public static class WAPI
    {
        public const string WILMAT_ENDPOINT = "https://www.starsoft.fi/wilmat/wilmat.json";

        private readonly static HttpClient _client;

        static WAPI()
        {
            //TODO: Proxies
            _client = new HttpClient();
            
            CompositeResolver.RegisterAndSetAsDefault(
                new IJsonFormatter[]
                {
                    new DateTimeFormatter("yyyy-MM-dd HH:mm"),
                    new NullableDateTimeFormatter("yyyy-MM-dd HH:mm")
                }, new IJsonFormatterResolver[]
                {
                    WilmaListResolver.Instance,
                    EnumResolver.UnderlyingValue,
                    StandardResolver.Default
                });
        }

        /// <summary>
        /// Gets the list of the official Wilma servers from Starsoft's server asynchronously.
        /// </summary>
        /// <returns>Official Wilma servers</returns>
        public static async Task<IList<WilmaServer>> GetServersAsync()
        {
            return await GetContentAsync<IList<WilmaServer>>(WILMAT_ENDPOINT).ConfigureAwait(false);
        }

        public static HttpRequestMessage CreateRequest(WilmaSession session, HttpMethod method, string path, 
            Dictionary<string, string> formParameters = default)
        {
            var request = CreateRequest(session.Context, method, path, formParameters);
            
            if (method == HttpMethod.Post)
                request.Headers.Add("FormKey", session?.FormKey ?? throw new Exception());

            return request;
        }
        public static HttpRequestMessage CreateRequest(WilmaApiContext context, HttpMethod method, string path,
            Dictionary<string, string> formParameters = default)
        {
            var request = new HttpRequestMessage(method, context.BaseUri.GetLeftPart(UriPartial.Authority) + path);

            if (formParameters != null)
                request.Content = new FormUrlEncodedContent(formParameters);

            return request;
        }

        public static async Task<HttpResponseMessage> SendAsync(this HttpRequestMessage request)
        {
            return await _client.SendAsync(request).ConfigureAwait(false);
        }

        public static async Task<T> GetContentAsync<T>(string requestUrl,
            Func<HttpContent, Task<T>> deserializer = null)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUrl))
            using (var response = await _client.SendAsync(request).ConfigureAwait(false))
            {
                return await DeserializeContentAsync(response, deserializer).ConfigureAwait(false);
            }
        }
        public static async Task<T> GetContentAsync<T>(WilmaApiContext context, string path,
            Func<HttpContent, Task<T>> deserializer = null)
        {
            using (var request = CreateRequest(context, HttpMethod.Get, path, null)) //TODO: formParameters
            using (var response = await _client.SendAsync(request).ConfigureAwait(false))
            {
                return await DeserializeContentAsync(response, deserializer).ConfigureAwait(false);
            }
        }
        public static async Task<T> GetContentAsync<T>(WilmaSession session, string path,
            Func<HttpContent, Task<T>> deserializer = null)
        {
            using (var request = CreateRequest(session, HttpMethod.Get, path, null)) //TODO: formParameters
            using (var response = await _client.SendAsync(request).ConfigureAwait(false))
            {
                return await DeserializeContentAsync(response, deserializer).ConfigureAwait(false);
            }   
        }

        public static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage response, Func<HttpContent, Task<T>> responseContentConverter = null)
        {
            if (!response.IsSuccessStatusCode) return default;

            if (responseContentConverter != null)
                return await responseContentConverter(response.Content).ConfigureAwait(false);

            if (typeof(T) == typeof(string))
                return (T)(object)await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (typeof(T) == typeof(byte[]))
                return (T)(object)await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            if (response.Content.Headers.ContentType.MediaType == "application/json")
                return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));

            return default;
        }
    }
}
