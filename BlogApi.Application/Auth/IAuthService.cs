namespace BlogApi.Application.Auth;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(string username, string password);
    Task<AuthResponse> LoginAsync(string username, string password);
}
