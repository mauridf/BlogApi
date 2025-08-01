namespace BlogApi.Domain.Entities;

public class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }

    public ICollection<Post> Posts { get; private set; } = new List<Post>();

    private User() { }

    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    public static User Create(string username, string passwordHash)
    {
        // Aqui você pode adicionar validações simples, ex:
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.", nameof(username));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

        return new User(username, passwordHash);
    }
}
