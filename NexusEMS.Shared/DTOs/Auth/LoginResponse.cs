using NexusEMS.Shared.DTOs.Responses;

namespace NexusEMS.Shared.DTOs.Auth;

public class LoginResponse
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public UserResponse? User { get; set; }
    public string? Message { get; set; }
}