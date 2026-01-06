using NexusEMS.Shared.Models;
using NexusEMS.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace NexusEMS.Web.Services;

public class AppStateService
{
    private User? _currentUser;

    public event Action? OnUserChanged;

    public User? CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            OnUserChanged?.Invoke();
        }
    }

    public bool IsAuthenticated => _currentUser != null;

    public UserRole? UserRole => _currentUser?.Role;

    public bool IsAdmin => _currentUser != null && _currentUser.Role == NexusEMS.Shared.Enums.UserRole.Admin;

    public bool IsDepartmentChief => _currentUser != null && _currentUser.Role == NexusEMS.Shared.Enums.UserRole.DepartmentChief;
}

