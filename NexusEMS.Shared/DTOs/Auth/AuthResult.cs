namespace NexusEMS.Shared.DTOs.Auth;

public class AuthResult
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public List<string>? Errors { get; set; }
    public string? Message { get; set; }
}