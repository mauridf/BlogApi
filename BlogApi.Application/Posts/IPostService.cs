namespace BlogApi.Application.Posts;

public interface IPostService
{
    Task<PostResponse> CreateAsync(CreatePostRequest request, Guid userId);
    Task<IEnumerable<PostResponse>> GetAllAsync();
    Task<PostResponse?> GetByIdAsync(Guid id);
    Task<PostResponse?> UpdateAsync(Guid id, UpdatePostRequest request, Guid userId);
    Task<bool> DeleteAsync(Guid id, Guid userId);
}
