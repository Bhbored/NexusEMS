using NexusEMS.Shared.Models;
using NexusEMS.Shared.Enums;

namespace NexusEMS.Web.Tests;

public static class MockUsers
{
    public static List<User> GetUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@nexus.com",
                Role = UserRole.Admin,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = 2,
                Username = "chief",
                Email = "chief@nexus.com",
                Role = UserRole.DepartmentChief,
                DepartmentId = 1,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }

    public static Dictionary<string, string> GetUserPasswords()
    {
        return new Dictionary<string, string>
        {
            { "admin", "admin" },
            { "chief", "chief" }
        };
    }
}

