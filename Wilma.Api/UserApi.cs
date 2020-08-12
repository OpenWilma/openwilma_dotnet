using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Model;
using Wilma.Api.Utilities;
using Wilma.Api.Wilma.Enum;

namespace Wilma.Api
{
#nullable enable
    public class UserApi
    {
        private readonly WilmaContext _context;

        public UserApi(WilmaContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Authenticates user using the provided details.
        /// </summary>
        /// <param name="username">The name (or email) of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A session object which can then be used to access user's other information. If <c>null</c>, authentication was unsuccesful.</returns>
        public async Task<WilmaSession?> LoginAsync(string username, string password)
        {
            string sessionId = await GetSessionIdAsync().ConfigureAwait(false);

            string apiKey = "sha1:" +
                Utils.DeriveSHA1Digest($"{username}|{sessionId}|{_context.Key}");

            var parameters = new Dictionary<string, string>
            {
                { "Login", username },
                { "Password", password },
                { "SessionID", sessionId },
                { "ApiKey", apiKey },
                { "format", "json" }
            };

            var response = await WAPI.PostAsync<IndexResponse>(_context, "/login",
                parameters).ConfigureAwait(false);

            if (response.LoginResult == LoginResult.Ok)
                return new WilmaSession(_context, response);

            return null;
        }

        /// <summary>
        /// Logs out the session.
        /// </summary>
        public async Task<bool> LogoutAsync(WilmaSession session)
        {
            using var response = await WAPI.PostAsync(session, "/logout").ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
        
        /// <summary>
        /// Fetch the Wilma session identifier which is required for authentication.
        /// </summary>
        private async Task<string> GetSessionIdAsync()
        {
            var response = await WAPI.GetAsync<IndexResponse>(_context, "/index_json").ConfigureAwait(false);
            return response.SessionID;
        }
    }
}
