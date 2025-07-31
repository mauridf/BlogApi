namespace BlogApi.Application.Posts;

public class UpdatePostRequest
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
