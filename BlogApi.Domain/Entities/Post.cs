namespace BlogApi.Domain.Entities;

public class Post
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Guid AuthorId { get; private set; }
    public User Author { get; private set; }

    private Post() { }

    public Post(string title, string content, Guid authorId)
    {
        Title = title;
        Content = content;
        AuthorId = authorId;
    }

    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
    }
}
