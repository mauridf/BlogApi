using BlogApi.Application.Posts;
using BlogApi.Domain.Entities;
using BlogApi.Infrastructure.Persistence;
using BlogApi.Infrastructure.Posts;
using BlogApi.Infrastructure.RealTime;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class PostServiceTests
{
    private BlogDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<BlogDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new BlogDbContext(options);
    }

    [Fact]
    public async Task CreateAsync_Should_Add_Post()
    {
        // Arrange
        var context = GetDbContext();
        var hubContext = new Mock<IHubContext<NotificationHub>>();
        var logger = new Mock<ILogger<PostService>>();

        var service = new PostService(context, hubContext.Object, logger.Object);

        var user = User.Create("john", "password");
        context.Users.Add(user);
        await context.SaveChangesAsync();

        var request = new CreatePostRequest
        {
            Title = "First Post",
            Content = "Hello World!"
        };

        // Act
        var post = await service.CreateAsync(request, user.Id);

        // Assert
        Assert.NotNull(post);
        Assert.Equal("First Post", post.Title);
        Assert.Equal("john", post.Author); // Usa o nome de usuário no response
    }
}
