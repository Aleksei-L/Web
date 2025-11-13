namespace Data;

public class Account {
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public string PasswordHash { get; set; }
}