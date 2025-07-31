namespace BlogApi.Application.Posts;

public class CreatePostRequest
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
