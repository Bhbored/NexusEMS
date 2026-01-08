# User Roles and Permissions in NexusEMS

## Overview
Every user in the system has:
1. **User Account** (`User` model) - for system login and authentication
2. **Employee Profile** (`Employee` model) - for HR records (optional for Admin)
3. **UserRole** - defines what they can do in the system (primary role)
4. **SecondaryRole** (optional) - for dual responsibilities

## Important Notes
- **HR and Accounting are BRANCH-SPECIFIC**: Each branch has its own HR and Accounting departments
- **HR does NOT handle salaries**: Salary management is exclusively handled by Accounting
- **Users can have dual roles**: A user can have both a primary and secondary role (e.g., Accounting chief who also acts as a DepartmentChief)

---

## 1. Admin Role

### Purpose
System administrator with full access to everything.

### What Admin Can Do
✅ **Everything** - No restrictions

**Key Abilities**:
- Manage all branches, departments, and employees
- View all audit logs across the entire system
- Approve/reject any requests
- Access all financial data
- Manage system users and roles
- View all complaints (from any branch/department)
- Create/modify salary configurations
- Run payroll for all branches
- Access all reports and analytics

**Data Visibility**:
- All branches
- All departments
- All employees
- All complaints
- All salary information
- All audit logs

**Can Create/Modify**:
- Branches
- Departments
- Employees
- Salary configurations
- System-wide settings

**Navigation Properties Used**:
- `AuditLogs` - All audit logs
- Everything else (no filtering)

---

## 2. BranchManager Role

### Purpose
Manages a specific branch, oversees all departments within that branch.

### What BranchManager Can Do
✅ Manage their branch
✅ Oversee all departments in their branch
✅ Approve work schedules from DepartmentChiefs
✅ Rate DepartmentChiefs, HumanResources chief, Accounting chief weekly
✅ Handle escalated complaints forwarded by department chiefs
✅ View branch-wide reports and analytics
✅ Manage branch budget

**Data Visibility**:
- Their assigned branch (`User.BranchId`)
- All departments in their branch
- All employees in their branch
- Complaints from their branch
- Audit logs with their `BranchId`
- Salary information for their branch employees

**Can Create/Modify**:
- Departments within their branch
- Employees within their branch
- Approve/reject work schedules
- Rate department chiefs

**Can View**:
- Branch budget and expenditures
- All activity logs for their branch
- All complaints from their branch (including forwarded ones)
- Performance ratings of all employees in their branch

**Navigation Properties Used**:
- `Branch` - The branch they manage
- `Branch.Departments` - All departments in their branch
- `Branch.Employees` - All employees in their branch
- `Branch.ComplaintCases` - Complaints from their branch
- `Branch.AuditLogs` - Activity in their branch
- `ManagedBranches` - Branches they manage (usually 1)
- `WorkSchedulesApproved` - Schedules they've approved
- `WeeklyRatingsCreated` - Ratings they've given to chiefs

**Cannot Do**:
❌ Access other branches
❌ Modify system-wide configurations
❌ Access other branches' financial data

---

## 3. DepartmentChief Role

### Purpose
Manages a specific department, supervises employees within that department.

### What DepartmentChief Can Do
✅ Manage their department
✅ Create monthly work schedules for their team
✅ Rate employees in their department weekly
✅ View department complaints
✅ Forward complaints to BranchManager if needed
✅ Approve attendance and time-off requests
✅ View department performance metrics

**Data Visibility**:
- Their assigned department (`User.DepartmentId`)
- All employees in their department
- Complaints from their department
- Audit logs with their `DepartmentId`
- Weekly ratings for their employees
- Work schedules for their department

**Can Create/Modify**:
- Work schedules for their department
- Weekly ratings for their employees
- Attendance records for their team
- Respond to complaints in their department

**Can View**:
- Department budget
- Employee attendance
- Performance metrics
- Complaint tickets (non-anonymous or owned)

**Navigation Properties Used**:
- `Department` - The department they manage
- `ChiefOfDepartments` - Departments they're chief of (usually 1)
- `Department.Employees` - Employees in their department
- `Department.ComplaintCases` - Complaints from their department
- `Department.AuditLogs` - Activity in their department
- `WorkSchedulesCreated` - Schedules they've created
- `WeeklyRatingsCreated` - Ratings they've given

**Cannot Do**:
❌ Access other departments
❌ Approve final schedules (needs BranchManager approval)
❌ Modify salaries
❌ Access other departments' data

---

## 4. HumanResources Role

### Purpose
HR department chief for a specific branch, manages HR team and handles employee-related issues within their branch.

### What HumanResources Can Do
✅ Manage HR department team (in their branch)
✅ Access HR-targeted complaints (from their branch)
✅ Manage employee records (in their branch only)
✅ Handle onboarding and offboarding (for their branch)
✅ Access employee personal information (branch employees only)
✅ Generate HR reports (for their branch)
✅ Handle employee disputes and disciplinary actions

**Data Visibility**:
- HR department in their branch (`IsSystemDepartment = true`, `Department.BranchId`)
- Employees in their branch only
- HR-targeted complaints from their branch
- Audit logs related to HR activities in their branch
- **NO access to salary information** (that's Accounting's job)

**Can Create/Modify**:
- Employee records (in their branch)
- Employee personal information
- Create work schedules for HR team
- Rate HR team members
- Close/resolve HR complaints
- Manage employee lifecycle (hiring, termination)

**Can View**:
- Employee personal information (branch only)
- HR tickets (branch only)
- Employee attendance records
- Performance reviews
- Disciplinary records

**Navigation Properties Used**:
- `Department` - HR department (IsSystemDepartment, in their branch)
- `ChiefOfDepartments` - HR department
- `Department.ComplaintCases` - HR complaints from their branch
- `Branch` - Their assigned branch
- `WorkSchedulesCreated` - Schedules for HR team

**Special Access**:
- Can view complaints across departments within their branch if targeted to HR
- Can access employee personal data for HR purposes (branch scope)

**Cannot Do**:
❌ Access other branches' HR data
❌ Approve salary changes (that's Accounting, not HR)
❌ Access salary information (Accounting handles this)
❌ Run payroll (Accounting only)
❌ Modify other branches' employee records

---

## 5. Accounting Role

### Purpose
Accounting department chief for a specific branch, manages accounting team and handles all financial operations within their branch.

### What Accounting Can Do
✅ Manage accounting department team (in their branch)
✅ Create and submit salary change requests (for branch employees)
✅ Run monthly payroll (for their branch)
✅ Generate salary slips (for branch employees)
✅ Manage salary packages (for branch employees)
✅ Handle financial reports (for their branch)
✅ Track budget expenditures (for their branch)
✅ Review and approve salary change requests (submitted by them or others in branch)

**Data Visibility**:
- Accounting department in their branch (`IsSystemDepartment = true`, `Department.BranchId`)
- Employees' salary information (in their branch only)
- Salary packages and components (branch scope)
- Payroll runs (for their branch)
- Salary change requests (branch scope)
- Audit logs related to financial activities (in their branch)

**Can Create/Modify**:
- Salary packages (branch employees)
- Salary change requests
- Payroll runs (for their branch)
- Salary slips (branch employees)
- Salary configurations (for their branch/departments)
- Work schedules for accounting team
- Rate accounting team members

**Can View**:
- Employee salaries (branch only)
- Financial reports (branch only)
- Budget tracking (branch scope)
- Salary change history (branch scope)

**Navigation Properties Used**:
- `Department` - Accounting department (IsSystemDepartment, in their branch)
- `ChiefOfDepartments` - Accounting department
- `Branch` - Their assigned branch
- `SalaryChangeRequestsCreated` - Salary changes they've created
- `SalaryChangeRequestsReviewed` - Salary changes they've reviewed
- `PayrollRunsCreated` - Payroll runs they've executed
- `WorkSchedulesCreated` - Schedules for accounting team

**Special Access**:
- Can view all employees' financial data within their branch
- Can modify salary structures for branch employees
- Can generate payroll for their branch

**Cannot Do**:
❌ Access other branches' financial data
❌ Run payroll for other branches
❌ Approve their own salary change requests (needs Admin approval)
❌ Access HR-specific employee personal data (HR handles this)
❌ Modify other branches' salary information

---

## 6. Employee Role (Regular Employee)

### Purpose
Regular employee with basic access to their own information.

### What Employee Can Do
✅ View their own profile
✅ Check in/out daily (attendance)
✅ View their work schedule
✅ Create complaint tickets
✅ View their salary slips
✅ View their performance ratings
✅ Update personal contact information

**Data Visibility**:
- Their own employee profile (`User.EmployeeProfileId`)
- Their own attendance records
- Their own salary slips (read-only)
- Their own weekly ratings (read-only)
- Their own complaints
- Their work schedule

**Can Create/Modify**:
- Complaint tickets
- Attendance check-in/out
- Personal contact information (limited)

**Can View**:
- Own salary slips
- Own performance ratings
- Own attendance history
- Own work schedule
- Own complaints and their status

**Navigation Properties Used**:
- `EmployeeProfile` - Their employee record
- `EmployeeProfile.AttendanceEvents` - Their attendance
- `EmployeeProfile.WeeklyRatingsReceived` - Their ratings
- `EmployeeProfile.SalarySlips` - Their salary slips
- `EmployeeProfile.ComplaintsCreated` - Their complaints
- `SessionLogs` - Their login history

**Cannot Do**:
❌ View other employees' data
❌ Modify salary information
❌ Create work schedules
❌ Rate anyone
❌ Approve requests
❌ Access department-wide data
❌ View audit logs

---

## Hierarchy Summary

```
Admin (Full Access)
  ↓
BranchManager (Branch-wide Access)
  ↓
DepartmentChief / HumanResources / Accounting (Department-wide Access)
  ↓
Employee (Self Access Only)
```

---

## Key Relationships Per Role

### Admin
- Can create Branches
- Can create Departments
- Can create Users with any role
- Can assign BranchManagers to Branches
- Can assign DepartmentChiefs to Departments

### BranchManager
- `User.BranchId` links them to their branch
- Creates `WeeklyRating` for DepartmentChiefs
- Approves `WorkSchedule` from chiefs
- Handles forwarded `ComplaintCase`

### DepartmentChief
- `User.DepartmentId` links them to their department
- Creates `WorkSchedule` for their team
- Creates `WeeklyRating` for employees
- Forwards `ComplaintCase` to BranchManager

### HumanResources
- `User.DepartmentId` links to HR department
- Reviews `SalaryChangeRequest`
- Accesses all HR-targeted `ComplaintCase`
- Manages employee lifecycle

### Accounting
- `User.DepartmentId` links to Accounting department
- Creates `SalaryChangeRequest`
- Creates `PayrollRun`
- Manages `SalaryPackage`

### Employee
- `User.EmployeeProfileId` links to their employee record
- Creates `AttendanceEvent` (check-in/out)
- Creates `ComplaintCase`
- Views own `SalarySlipSnapshot`

---

## Secondary Roles (Dual Responsibilities)

### Purpose
Some users may need to perform duties from multiple roles simultaneously.

### Implementation
```csharp
user.Role = UserRole.Accounting;  // Primary role
user.SecondaryRole = UserRole.DepartmentChief;  // Also acts as chief
```

### Common Scenarios

1. **Accounting + DepartmentChief**
   - Manages accounting department AND another regular department
   - Can do both accounting operations and department management

2. **HumanResources + DepartmentChief**
   - Manages HR department AND another regular department
   - Can handle HR duties and department operations

3. **DepartmentChief + BranchManager (Temporary)**
   - Chief temporarily acting as branch manager
   - Can approve schedules and manage department

### Permission Checking
```csharp
// Check if user has a specific role (primary or secondary)
if (user.HasRole(UserRole.Accounting)) {
    // Can do accounting stuff
}

// Check if user has any of multiple roles
if (user.HasAnyRole(UserRole.Accounting, UserRole.HumanResources)) {
    // Can access financial or HR data
}
```

### Helper Methods in User Model
- `HasRole(UserRole role)` - Returns true if user has this role (primary or secondary)
- `HasAnyRole(params UserRole[] roles)` - Returns true if user has any of these roles

---

## Complete Navigation Properties Usage

All relationships are now properly bidirectional, enabling:

1. **Easy Querying**: Get all entities related to a user
2. **EF Core Optimization**: Proper Include() statements
3. **Permission Checking**: Quick access to check ownership/permissions (with secondary role support)
4. **Audit Trails**: Track who created/modified what
5. **Hierarchy Filtering**: Filter data based on user's position in hierarchy
6. **Branch-Scoped Operations**: HR and Accounting operate within their branch only

