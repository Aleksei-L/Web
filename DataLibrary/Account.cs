namespace DataLibrary;

public record Account(
    Guid id,
    string username,
    string passwordHash
);