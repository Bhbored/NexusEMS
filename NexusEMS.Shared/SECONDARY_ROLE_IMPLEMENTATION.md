# Secondary Role Implementation

## What Was Added

### 1. User Model Changes

**Added to `User.cs`**:
```csharp
public UserRole Role { get; set; } = UserRole.Employee;      // Primary role
public UserRole? SecondaryRole { get; set; }                 // Optional secondary role

// Helper methods for permission checking
public bool HasRole(UserRole role)
{
    return Role == role || SecondaryRole == role;
}

public bool HasAnyRole(params UserRole[] roles)
{
    foreach (var role in roles)
    {
        if (Role == role || SecondaryRole == role)
            return true;
    }
    return false;
}
```

---

## Why This Is Useful

### Real-World Scenarios

1. **Accounting Chief Managing Another Department**
   ```csharp
   user.Role = UserRole.Accounting;
   user.SecondaryRole = UserRole.DepartmentChief;
   user.DepartmentId = accountingDeptId;  // Primary department
   // Can also manage another department through ChiefOfDepartments collection
   ```

2. **HR Chief Covering for Another Chief**
   ```csharp
   user.Role = UserRole.HumanResources;
   user.SecondaryRole = UserRole.DepartmentChief;
   ```

3. **Temporary Branch Manager**
   ```csharp
   user.Role = UserRole.DepartmentChief;
   user.SecondaryRole = UserRole.BranchManager;
   ```

---

## How to Use

### Permission Checking (Recommended)

```csharp
// Check if user has a specific role
if (user.HasRole(UserRole.Accounting))
{
    // User can access accounting features
    // Works whether it's primary OR secondary role
}

// Check if user has any of multiple roles
if (user.HasAnyRole(UserRole.Accounting, UserRole.HumanResources))
{
    // User can access financial or HR features
}
```

### Direct Checking (Not Recommended)

```csharp
// Bad: Only checks primary role
if (user.Role == UserRole.Accounting)
{
    // Misses users with SecondaryRole = Accounting
}

// Good: Checks both
if (user.Role == UserRole.Accounting || user.SecondaryRole == UserRole.Accounting)
{
    // Works but verbose
}

// Best: Use helper method
if (user.HasRole(UserRole.Accounting))
{
    // Clean and handles both cases
}
```

---

## Updated Authorization Logic

### Before (Wrong)
```csharp
// Only allows primary role
[Authorize(Roles = "Accounting")]
public async Task<IActionResult> RunPayroll()
{
    // Users with SecondaryRole = Accounting can't access this
}
```

### After (Correct)
```csharp
public async Task<IActionResult> RunPayroll()
{
    var user = await GetCurrentUser();
    
    if (!user.HasRole(UserRole.Accounting))
    {
        return Forbid();
    }
    
    // Process payroll
}
```

---

## Database Schema

**User Table**:
```sql
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(100) NOT NULL,
    Role INT NOT NULL,              -- Primary role (enum)
    SecondaryRole INT NULL,         -- Optional secondary role (enum)
    BranchId UNIQUEIDENTIFIER NULL,
    DepartmentId UNIQUEIDENTIFIER NULL,
    ...
);
```

---

## Important Corrections Made

### HR & Accounting Scope

**Before (Wrong)**:
- HR had company-wide access
- Accounting had company-wide access
- HR could approve salary changes

**After (Correct)**:
- ✅ HR is **branch-specific** (filters by `User.BranchId`)
- ✅ Accounting is **branch-specific** (filters by `User.BranchId`)
- ✅ HR handles employee records, NOT salaries
- ✅ Accounting handles all salary operations
- ✅ Each branch has its own HR and Accounting departments

### Query Examples

**HR accessing branch employees**:
```csharp
var hrUser = context.Users
    .Include(u => u.Branch)
    .FirstOrDefault(u => u.Id == userId);

// Only employees in HR's branch
var branchEmployees = context.Employees
    .Where(e => e.BranchId == hrUser.BranchId)
    .ToList();
```

**Accounting running payroll for branch**:
```csharp
var accountingUser = context.Users
    .Include(u => u.Branch)
    .FirstOrDefault(u => u.Id == userId);

// Only employees in Accounting's branch
var payrollRun = new PayrollRun
{
    CreatedByUserId = accountingUser.Id,
    PeriodStart = startDate,
    PeriodEnd = endDate
};

// Generate slips only for branch employees
var employees = context.Employees
    .Where(e => e.BranchId == accountingUser.BranchId)
    .Include(e => e.SalaryPackages)
    .ToList();
```

---

## Testing Secondary Roles

### Unit Test Example
```csharp
[Test]
public void HasRole_ShouldReturnTrue_ForSecondaryRole()
{
    // Arrange
    var user = new User
    {
        Role = UserRole.Accounting,
        SecondaryRole = UserRole.DepartmentChief
    };

    // Act & Assert
    Assert.IsTrue(user.HasRole(UserRole.Accounting));
    Assert.IsTrue(user.HasRole(UserRole.DepartmentChief));
    Assert.IsFalse(user.HasRole(UserRole.BranchManager));
}

[Test]
public void HasAnyRole_ShouldReturnTrue_IfAnyRoleMatches()
{
    // Arrange
    var user = new User
    {
        Role = UserRole.Accounting,
        SecondaryRole = null
    };

    // Act & Assert
    Assert.IsTrue(user.HasAnyRole(
        UserRole.Accounting, 
        UserRole.HumanResources
    ));
    
    Assert.IsFalse(user.HasAnyRole(
        UserRole.Admin, 
        UserRole.BranchManager
    ));
}
```

---

## When to Use Secondary Roles

### ✅ Good Use Cases
- Temporary coverage (chief on leave, someone covers)
- Small branches where one person wears multiple hats
- Cross-functional responsibilities
- Acting positions

### ❌ Don't Use For
- Permanent multiple roles (restructure organization instead)
- More than 2 roles (indicates org structure problem)
- Security escalation (use proper role hierarchy)

---

## Migration Note

If you already have existing Users in the database:
```sql
-- SecondaryRole will be NULL for all existing users
-- No data migration needed
ALTER TABLE Users ADD SecondaryRole INT NULL;
```

Existing functionality works exactly the same. Secondary roles are purely additive.
