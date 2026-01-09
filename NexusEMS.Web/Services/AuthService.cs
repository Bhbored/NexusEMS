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
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        if (user != null && user.PasswordHash == password)
        {
            if (user.IsOnline)
            {
                return null;
            }

            user.IsOnline = true;
            user.LastLoginAt = DateTime.Now;

            var session = new SessionLog
            {
                UserId = user.Id,
                LoginAt = DateTime.Now,
                IsActive = true,
                IpAddress = "127.0.0.1",
                UserAgent = "Blazor WebAssembly",
                DeviceInfo = "Web Browser"
            };

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
