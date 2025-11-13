namespace Data;

public record Account(
    Guid Id,
    string Username,
    string PasswordHash
);