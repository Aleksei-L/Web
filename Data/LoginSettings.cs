namespace Data;

public class LoginSettings {
    public required TimeSpan expires { get; init; }
    public required string secretKey { get; init; }
}