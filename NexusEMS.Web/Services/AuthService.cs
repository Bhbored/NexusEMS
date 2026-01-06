using NexusEMS.Shared.Models;
using NexusEMS.Shared.Enums;
using NexusEMS.Web.Tests;

namespace NexusEMS.Web.Services;

public class AuthService
{
    private User? _currentUser;
    private readonly List<User> _users;
    private readonly Dictionary<string, string> _userPasswords;

    public AuthService()
    {
        _users = MockUsers.GetUsers();
        _userPasswords = MockUsers.GetUserPasswords();
    }

    public async Task<User?> Login(string username, string password)
    {
        await Task.Delay(100);
        
        var user = _users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (user != null && user.IsActive)
        {
            if (_userPasswords.TryGetValue(user.Username, out var storedPassword) && 
                storedPassword == password)
            {
                _currentUser = user;
                return user;
            }
        }
        
        return null;
    }

    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    public void Logout()
    {
        _currentUser = null;
    }

    public bool IsAuthenticated()
    {
        return _currentUser != null;
    }

    public UserRole? GetUserRole()
    {
        return _currentUser?.Role;
    }
}
