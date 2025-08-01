using BlogApi.Application.Auth;
using BlogApi.Domain.Entities;
using BlogApi.Infrastructure.Auth;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

public class AuthServiceTests
{
    private BlogDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new BlogDbContext(options);
    }

    private IConfiguration GetFakeConfig()
    {
        var inMemorySettings = new Dictionary<string, string>
        {
            { "Jwt:Key", "MySecretKey1234567890" }, // valor fictício para testes
            { "Jwt:Issuer", "TestIssuer" }
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();
    }

    [Fact]
    public async Task RegisterAsync_Should_Create_User()
    {
        var context = GetDbContext();
        var config = GetFakeConfig();
        var service = new AuthService(context, config);

        await service.RegisterAsync("testuser", "123456");

        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == "testuser");

        Assert.NotNull(user);
        Assert.Equal("testuser", user.Username);
    }

    [Fact]
    public async Task LoginAsync_Should_Authenticate_User()
    {
        var context = GetDbContext();
        var config = GetFakeConfig();

        var user = User.Create("john", "secret");
        context.Users.Add(user);
        await context.SaveChangesAsync();

        var service = new AuthService(context, config);

        var result = await service.LoginAsync("john", "secret");

        Assert.NotNull(result);
        Assert.Equal("john", result.Username);
    }
}
