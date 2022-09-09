using OpenWilma.Model;
using OpenWilma.Wilma;
using OpenWilma.Utilities;

namespace OpenWilma;

#nullable enable
public class UserApi : IUserApi
{
    private readonly IWilmaContext _context;

    public UserApi(IWilmaContext context)
        => _context = context;

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
            { "SESSIONID", sessionId },
            { "ApiKey", apiKey },
            { "CompleteJson", string.Empty },
            { "format", "json" }
        };

        var response = await WAPI.PostAsync<IndexResponse>(_context, "/login", parameters).ConfigureAwait(false);

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
    /// Send a password reset request to the email which linked to an Wilma user.
    /// </summary>
    /// <remarks>If your Wilma username is an email address, you only need to fill the <paramref name="email"/> parameter.<para/>
    /// If your username is not an email address, also fill in the <paramref name="username"/> parameter.</remarks>
    /// <param name="email">The email address of the user.</param>
    /// <param name="username">The username of the user.</param>
    public async Task<bool> ForgotPasswordAsync(string email, string? username = default)
    {
        var parameters = new Dictionary<string, string>
        {
            { "username", username ?? string.Empty },
            { "email", email }
        };

        using var response = await WAPI.PostAsync(_context, "/forgotpasswd", parameters).ConfigureAwait(false);
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
