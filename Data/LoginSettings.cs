namespace Data;

public class LoginSettings {
    public required TimeSpan Expires { get; init; }
    public required string SecretKey { get; init; }
}