using BlogApi.Application.Posts;
using BlogApi.Domain.Entities;
using BlogApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure.Posts;

public class PostService : IPostService
{
    private readonly BlogDbContext _context;

    public PostService(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<PostResponse> CreateAsync(CreatePostRequest request, Guid userId)
    {
        var post = new Post(request.Title, request.Content, userId);
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        var author = await _context.Users.FindAsync(userId);
        return ToResponse(post, author!.Username);
    }

    public async Task<IEnumerable<PostResponse>> GetAllAsync()
    {
        return await _context.Posts
            .Include(p => p.Author)
            .Select(p => ToResponse(p, p.Author.Username))
            .ToListAsync();
    }

    public async Task<PostResponse?> GetByIdAsync(Guid id)
    {
        var post = await _context.Posts
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Id == id);

        return post is null ? null : ToResponse(post, post.Author.Username);
    }

    public async Task<PostResponse?> UpdateAsync(Guid id, UpdatePostRequest request, Guid userId)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.AuthorId == userId);
        if (post is null) return null;

        post.Update(request.Title, request.Content);
        await _context.SaveChangesAsync();

        return ToResponse(post, post.Author.Username);
    }

    public async Task<bool> DeleteAsync(Guid id, Guid userId)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.AuthorId == userId);
        if (post is null) return false;

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return true;
    }

    private static PostResponse ToResponse(Post post, string username) => new()
    {
        Id = post.Id,
        Title = post.Title,
        Content = post.Content,
        CreatedAt = post.CreatedAt,
        Author = username
    };
}
