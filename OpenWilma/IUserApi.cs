namespace OpenWilma;

#nullable enable
public interface IUserApi
{
    Task<WilmaSession?> LoginAsync(string username, string password);
    Task<bool> LogoutAsync(WilmaSession session);
    Task<bool> ForgotPasswordAsync(string email, string? username);
}