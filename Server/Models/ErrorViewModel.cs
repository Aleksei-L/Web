namespace Server.Models;

public class ErrorViewModel {
    public string? requestId { get; init; }

    public bool showRequestId => !string.IsNullOrEmpty(requestId);
}