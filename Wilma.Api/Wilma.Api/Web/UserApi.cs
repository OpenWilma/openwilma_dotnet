using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Utilities;
using Wilma.Api.Web.Model;

namespace Wilma.Api.Web
{
    public class UserApi
    {
        private readonly WilmaApiContext _context;

        public UserApi(WilmaApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Logins asynchronously to the Wilma web service.
        /// </summary>
        /// <param name="username">The name or email of the wilma user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The <see cref="WilmaSession"/> </returns>
        public async Task<WilmaSession> LoginAsync(string username, string password)
        {
            string sessionId = await GetSessionIdAsync().ConfigureAwait(false);

            string apiKey = "sha1:" +
                Helper.SHA1Hash($"{username}|{sessionId}|{_context.Key}");

            var parameters = new Dictionary<string, string>
            {
                { "Login", username },
                { "Password", password },
                { "SessionID", sessionId },
                { "ApiKey", apiKey },
                { "format", "json" }
            };

            using (var request = WAPI.CreateRequest(_context, HttpMethod.Post, "/login", parameters))
            using (var response = await request.SendAsync().ConfigureAwait(false))
            {
                var indexResponse = await response.DeserializeContentAsync<IndexResponse>().ConfigureAwait(false);
                return new WilmaSession(_context, indexResponse);
            }
        }

        /// <summary>
        /// Logs out the session.
        /// </summary>
        public async Task LogoutAsync(WilmaSession session)
        {
            using (var request = WAPI.CreateRequest(session, HttpMethod.Post, "/logout"))
            {
                var response = await request.SendAsync().ConfigureAwait(false);
            }
        }
        
        /// <summary>
        /// Gets the Wilma session identifier asynchronously.
        /// </summary>
        private async Task<string> GetSessionIdAsync()
        {
            var response = await WAPI.GetContentAsync<IndexResponse>(_context, "/index_json").ConfigureAwait(false);

            return response.SessionId;
        }
    }
}
