using NexusEMS.Shared.Models;
using NexusEMS.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace NexusEMS.Web.Services;

public class AuthService
{
    private readonly TestDataService _repo;
    private User? currentUser = null;
    private SessionLog? currentSession = null;

    public AuthService(TestDataService repo)
    {
        _repo = repo;
    }

    public event Action? OnUserChanged;
    public User? CurrentUser
    {
        get => currentUser;
        set
        {
            currentUser = value;
            OnUserChanged?.Invoke();
        }
    }
    public bool IsAuthenticated => CurrentUser != null;

    public async Task<User?> Login(string email, string password)
    {
        await Task.Delay(100);
        var user = _repo.GetUsers().FirstOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.PasswordHash.Equals(password, StringComparison.OrdinalIgnoreCase));

        if (user != null && !user.IsOnline)
        {
            // Update user status
            user.IsOnline = true;
            user.LastLoginAt = DateTime.Now;

            // Create new session log
            var session = new SessionLog
            {
                UserId = user.Id,
                LoginAt = DateTime.Now,
                IsActive = true,
                // Note: In Blazor WebAssembly, we can't easily get real IP/UserAgent from server-side
                // These would typically be captured by the backend API
                IpAddress = "127.0.0.1", // Placeholder - should come from backend
                UserAgent = "Blazor WebAssembly", // Placeholder - could use JSInterop to get real value
                DeviceInfo = "Web Browser" // Placeholder
            };

            // Add session to user's session logs (preserves existing sessions)
            user.SessionLogs.Add(session);
            currentSession = session;

            CurrentUser = user;
            return user;

        }

        return null;
    }


    public void Logout()
    {
        if (CurrentUser is not null)
        {
            // Update user status
            CurrentUser.IsOnline = false;
            CurrentUser.LastLogoutAt = DateTime.Now;

            // Update current session
            if (currentSession != null)
            {
                currentSession.LogoutAt = DateTime.Now;
                currentSession.IsActive = false;
            }

            // Clear current user and session
            currentSession = null;
            CurrentUser = null;
        }
    }

    public UserRole? GetUserRole()
    {
        if (CurrentUser is not null)
        {
            return CurrentUser?.Role;
        }
        return null;
    }

    public SessionLog? GetCurrentSession()
    {
        return currentSession;
    }

    public IEnumerable<SessionLog> GetUserSessionHistory(Guid userId)
    {
        var user = _repo.GetUsers().FirstOrDefault(u => u.Id == userId);
        return user?.SessionLogs?.OrderByDescending(s => s.LoginAt) ?? Enumerable.Empty<SessionLog>();
    }

    public IEnumerable<SessionLog> GetActiveSessionsForUser(Guid userId)
    {
        var user = _repo.GetUsers().FirstOrDefault(u => u.Id == userId);
        return user?.SessionLogs?.Where(s => s.IsActive) ?? Enumerable.Empty<SessionLog>();
    }
}
