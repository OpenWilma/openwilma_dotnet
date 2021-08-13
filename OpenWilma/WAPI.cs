using System;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using OpenWilma.Json;
using OpenWilma.Wilma;
using OpenWilma.Model;

namespace OpenWilma
{
    public static class WAPI
    {
        private const string USER_AGENT = "OpenWilma/1.0.0.dotnet";
        private const string OFFICIAL_SERVERS_ENDPOINT = "https://www.starsoft.fi/wilmat/wilmat.json";

        private readonly static HttpClient _client;
        private readonly static JsonSerializerOptions _serializerOptions;

        static WAPI()
        {
            //TOOD: Multiple logins on single instance => Cookies are screwed => give each session own cookiecontainer or something
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };
            
            _serializerOptions.Converters.Add(new HexColorConverter());
            _serializerOptions.Converters.Add(new DateTimeConverter());
            _serializerOptions.Converters.Add(new NullableDateTimeConverter());

            _serializerOptions.Converters.Add(new NestedArrayConverter<Exam>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<Group>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<Message>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<MessageRecord>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<News>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<NewsRecord>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<Observation>());
            _serializerOptions.Converters.Add(new NestedArrayConverter<WilmaServer>());
        }

        /// <summary>
        /// Fetches the list of the official Wilma servers from Starsoft's server asynchronously.
        /// </summary>
        public static Task<IEnumerable<WilmaServer>> GetOfficialServersAsync() => GetAsync<IEnumerable<WilmaServer>>(OFFICIAL_SERVERS_ENDPOINT);

        private static string GetQueryString(IEnumerable<KeyValuePair<string, object>> parameters)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            foreach (var (key, value) in parameters)
            {
                query.Add(key, value.ToString());
            }
            return "?" + query.ToString();
        }

        public static HttpRequestMessage CreateRequest(HttpMethod method, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default,
            ICollection<KeyValuePair<string, string>> parameters = default)
        {
            if (queryParameters?.Count > 0)
                path += GetQueryString(queryParameters);

            var request = new HttpRequestMessage(method, path);

            if (parameters?.Count > 0)
                request.Content = new FormUrlEncodedContent(parameters);

            return request;
        }
        public static HttpRequestMessage CreateRequest(WilmaSession session, HttpMethod method, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default,
            ICollection<KeyValuePair<string, string>> parameters = default)
        {
            var request = CreateRequest(session.Context, method, path, queryParameters, parameters);
            request.Headers.Add("FormKey", session.FormKey);
            return request;
        }
        public static HttpRequestMessage CreateRequest(WilmaContext context, HttpMethod method, string path,
           ICollection<KeyValuePair<string, object>> queryParameters = default,
           ICollection<KeyValuePair<string, string>> parameters = default)
        {
            queryParameters ??= new Dictionary<string, object>();
            queryParameters.Add(new KeyValuePair<string, object>("LangID", (int)context.Language));
            queryParameters.Add(new KeyValuePair<string, object>("format", "json"));

            var request = new HttpRequestMessage(method,
                context.Url + path + GetQueryString(queryParameters));

            if (parameters?.Count > 0)
                request.Content = new FormUrlEncodedContent(parameters);

            return request;
        }

        public static async Task<T> GetAsync<T>(string requestUrl,
            Func<HttpContent, Task<T>> contentDeserializer = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            using var response = await _client.SendAsync(request).ConfigureAwait(false);

            return await DeserializeContentAsync(response, contentDeserializer).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> GetAsync(WilmaContext context, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default)
        {
            using var request = CreateRequest(context, HttpMethod.Get, path, queryParameters);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }
        public static async Task<T> GetAsync<T>(WilmaContext context, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default,
            Func<HttpContent, Task<T>> contentDeserializer = default)
        {
            using var request = CreateRequest(context, HttpMethod.Get, path, queryParameters);
            using var response = await _client.SendAsync(request).ConfigureAwait(false);

            return await DeserializeContentAsync(response, contentDeserializer).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> GetAsync(WilmaSession session, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default)
        {
            using var request = CreateRequest(session, HttpMethod.Get, path, queryParameters);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }
        public static async Task<T> GetAsync<T>(WilmaSession session, string path,
            ICollection<KeyValuePair<string, object>> queryParameters = default,
            Func<HttpContent, Task<T>> contentDeserializer = default)
        {
            using var request = CreateRequest(session, HttpMethod.Get, path, queryParameters);
            using var response = await _client.SendAsync(request).ConfigureAwait(false);

            return await DeserializeContentAsync(response, contentDeserializer).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> PostAsync(WilmaSession session, string path,
            ICollection<KeyValuePair<string, string>> parameters = default,
            ICollection<KeyValuePair<string, object>> queryParameters = default)
        {
            using var request = CreateRequest(session, HttpMethod.Post, path, queryParameters, parameters);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }
        public static async Task<T> PostAsync<T>(WilmaSession session, string path,
            ICollection<KeyValuePair<string, string>> parameters = default,
            ICollection<KeyValuePair<string, object>> queryParameters = default,
            Func<HttpContent, Task<T>> contentDeserializer = default)
        {
            using var request = CreateRequest(session, HttpMethod.Post, path, queryParameters, parameters);
            using var response = await _client.SendAsync(request).ConfigureAwait(false);

            return await DeserializeContentAsync(response, contentDeserializer).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> PostAsync(WilmaContext context, string path,
            ICollection<KeyValuePair<string, string>> parameters = default,
            IDictionary<string, object> queryParameters = default)
        {
            using var request = CreateRequest(context, HttpMethod.Post, path, queryParameters, parameters);
            return await _client.SendAsync(request).ConfigureAwait(false);
        }
        public static async Task<T> PostAsync<T>(WilmaContext context, string path,
            ICollection<KeyValuePair<string, string>> parameters = default,
            IDictionary<string, object> queryParameters = default,
            Func<HttpContent, Task<T>> contentDeserializer = default)
        {
            using var request = CreateRequest(context, HttpMethod.Post, path, queryParameters, parameters);
            using var response = await _client.SendAsync(request).ConfigureAwait(false);

            return await DeserializeContentAsync(response, contentDeserializer).ConfigureAwait(false);
        }

        public static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage response,
            Func<HttpContent, Task<T>> responseContentConverter = default)
        {
            if (!response.IsSuccessStatusCode)
            {
                string exceptionMessage = $"{response.StatusCode}\r\n";
                exceptionMessage += $"RequestUri: {response.RequestMessage.RequestUri}\r\n";

                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>(_serializerOptions).ConfigureAwait(false);

                    exceptionMessage += $"{errorResponse.Error.StatusCode} - {errorResponse.Error.Id}\r\n";
                    exceptionMessage += $"{errorResponse.Error.Message} - {errorResponse.Error.Description}\r\n";
                    exceptionMessage += $"{errorResponse.Error.WhatNext}";
                }

                throw response.StatusCode switch
                {
                    HttpStatusCode.Unauthorized => new UnauthorizedAccessException(exceptionMessage),

                    _ => new Exception(exceptionMessage)
                };
            }

            if (responseContentConverter != null)
                return await responseContentConverter(response.Content).ConfigureAwait(false);

            if (typeof(T) == typeof(string))
                return (T)(object)await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (typeof(T) == typeof(byte[]))
                return (T)(object)await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            if (response.Content.Headers.ContentType.MediaType == "application/json")
                return await response.Content.ReadFromJsonAsync<T>(_serializerOptions).ConfigureAwait(false);

            return default;
        }
    }
}