# NexusEMS Model Structure Documentation

## Overview
This document explains the complete data model structure for NexusEMS - an Employee Management System with hierarchical access control and comprehensive tracking capabilities.

---

## Core Hierarchy

### User
**Purpose**: Authentication and authorization (system access)
- Represents anyone who can log into the system
- Stores credentials (username, email, password hash)
- Defines role (Admin, BranchManager, DepartmentChief, HumanResources, Accounting, Employee)
- Tracks online status and last login/logout times
- Links to Employee profile (one-to-one, optional)
- Links to Branch and Department (for hierarchy)

**Key Fields**:
- `EmployeeProfileId`: Optional link to Employee record
- `BranchId`: Which branch this user belongs to
- `DepartmentId`: Which department this user belongs to
- `Role`: UserRole enum defining permissions

### Employee
**Purpose**: HR records (personal and employment information)
- Complete employee information (personal, employment, salary)
- Every person in the company has an Employee record
- Not all Employees have User accounts (some may not need system access)
- Employees are assigned to Departments and Branches

**Key Fields**:
- `AssignedToUserId`: Optional link to User account
- `ReportsToEmployeeId`: Self-referencing for organizational hierarchy
- `DepartmentId`: Required - every employee belongs to a department
- `BranchId`: Optional - for multi-branch companies

**Relationships**:
- One Employee → One User (optional)
- One Employee → Many WeeklyRatings (received)
- One Employee → Many SalaryPackages
- One Employee → Many AttendanceEvents
- One Employee → Many ComplaintCases (created)

---

## Organizational Structure

### Branch
**Purpose**: Physical company locations/offices
- Managed by a BranchManager (User with BranchManager role)
- Contains multiple Departments
- Has budget and contact information

**Key Fields**:
- `ManagerUserId`: User with BranchManager role
- `Departments`: Collection of departments in this branch
- `Employees`: Collection of employees in this branch

### Department
**Purpose**: Organizational units within branches
- Can be regular departments OR system departments (HR, Accounting)
- Managed by a DepartmentChief (User with DepartmentChief role)
- Belongs to a Branch

**Key Fields**:
- `ChiefUserId`: User with DepartmentChief role
- `BranchId`: Parent branch
- `IsSystemDepartment`: Marks HR/Accounting departments

**Special System Departments**:
- **HumanResources Department**: HR chief manages HR team, has ticket access
- **Accounting Department**: Accounting chief manages accounting team, handles salaries

### Position
**Purpose**: Job titles and salary ranges
- Defines role/title in the organization
- Contains salary range information
- Linked to Employees

---

## Attendance & Work Management

### AttendanceEvent
**Purpose**: Daily check-in/check-out tracking
- Tracks when employees physically arrive/leave work
- Types: CheckIn, CheckOut, BreakStart, BreakEnd
- Different from system login/logout (SessionLog)

**Key Fields**:
- `EmployeeId`: Who checked in/out
- `EventType`: CheckIn/CheckOut/Break
- `Timestamp`: When the event occurred

### WorkSchedule
**Purpose**: Monthly work schedules created by DepartmentChiefs
- DepartmentChief creates schedule for their team
- Requires BranchManager approval
- Contains daily assignments for employees

**Key Fields**:
- `DepartmentId`: Which department this schedule is for
- `CreatedByUserId`: The chief who created it
- `ApprovedByUserId`: The branch manager who approved it
- `Status`: Draft/Submitted/Approved/Rejected/Published

### WorkScheduleAssignment
**Purpose**: Individual daily work assignments within a schedule
- Links Employee to specific dates and times
- Part of a WorkSchedule

---

## Performance Management

### WeeklyRating
**Purpose**: Weekly performance ratings for employees
- Created by supervisors (DepartmentChief, BranchManager)
- One rating per employee per week
- Contains multiple revisions (history/snapshots)

**Key Fields**:
- `EmployeeProfileId`: Employee being rated
- `CreatedByUserId`: Who created the rating (chief/manager)
- `WeekStartDate`: Week this rating is for
- `IsFinalized`: Whether rating is locked

### WeeklyRatingRevision
**Purpose**: Historical snapshots of ratings with notes
- Each time a rating is updated, a revision is created
- Maintains complete history
- Includes score (1-5) and comments

**Key Fields**:
- `WeeklyRatingId`: Parent rating
- `Score`: 1-5 rating
- `Comment`: Notes about performance
- `CreatedByUserId`: Who made this revision

---

## Salary Management System

### SalaryConfiguration
**Purpose**: Salary calculation rules and formulas
- Defines base salaries and multipliers
- Can be per-branch or per-department
- Used by SalaryCalculationService for auto-calculation

**Key Fields**:
- `BaseSalary`: Starting salary amount
- `HraPercentage`, `DaPercentage`: Allowance percentages
- `MarriedMultiplier`, `ChildMultiplier`: Family multipliers
- `PostGraduateMultiplier`, `PhdMultiplier`: Education multipliers

### SalaryPackage
**Purpose**: Current salary structure for an employee
- Replaces old hardcoded Salary model
- Flexible component-based system
- Can be Auto, Manual, or Mixed calculation mode
- Has effective date range

**Key Fields**:
- `EmployeeProfileId`: Employee this package is for
- `EffectiveFrom/To`: When this package is active
- `CalculationMode`: Auto/Manual/Mixed
- `Components`: Collection of salary items

### SalaryComponent
**Purpose**: Individual salary items (earnings/deductions)
- Part of a SalaryPackage
- Can be earning (Base, Allowances, Bonus) or deduction (Tax, Insurance)
- Tracks source (AutoRule/Manual/Imported)

**Key Fields**:
- `Type`: Base/HousingAllowance/Tax/etc (SalaryComponentType enum)
- `Amount`: Monetary value
- `IsDeduction`: True for deductions
- `Source`: AutoRule/Manual/Imported

### SalaryChangeRequest
**Purpose**: Request changes to employee salary
- Created by Accounting department
- Requires approval from HR/Admin
- Tracks full audit trail

**Key Fields**:
- `EmployeeProfileId`: Employee to change
- `RequestedByUserId`: Who requested (Accounting)
- `ReviewedByUserId`: Who approved/rejected
- `Status`: Draft/Submitted/Approved/Rejected/Applied

### SalaryChangeItem
**Purpose**: Individual changes within a change request
- Each component being added/updated/removed
- Part of SalaryChangeRequest

### SalarySlipSnapshot
**Purpose**: Monthly payslip records
- Generated during PayrollRun
- Immutable snapshot of what was paid
- Stores breakdown as JSON

**Key Fields**:
- `PayrollRunId`: Which payroll run generated this
- `EmployeeProfileId`: Employee who received payment
- `Gross`, `TotalDeductions`, `NetPaid`: Calculated amounts
- `SnapshotJson`: Detailed breakdown

### PayrollRun
**Purpose**: Monthly payroll processing
- Groups all salary slips for a period
- Status workflow: Draft → Finalized → Paid
- Created by Accounting department

---

## Complaint/Ticket System

### ComplaintCase
**Purpose**: Employee complaints and tickets
- Created by any employee
- Can be targeted to HR, DepartmentChief, or Both
- Supports anonymity to chief
- Can be forwarded to BranchManager
- Assigned to specific users for handling

**Key Fields**:
- `CreatedByEmployeeProfileId`: Who created the complaint
- `DepartmentId`, `BranchId`: For access filtering
- `Target`: HR/DepartmentChief/Both
- `IsForwardedToBranchManager`: Escalation flag
- `ForwardedByUserId`: Who escalated it
- `AssignedToUserId`: Who's handling it

**Access Rules**:
- Employee sees their own complaints
- DepartmentChief sees department complaints (may be anonymous)
- HR department sees all HR-targeted complaints
- BranchManager sees forwarded complaints + their branch complaints
- Admin sees everything

### ComplaintMessage
**Purpose**: Conversation thread within a complaint
- Multiple messages per complaint
- Can be internal (HR/Admin notes) or visible to employee

### ComplaintAttachment
**Purpose**: File attachments on complaints
- Linked to ComplaintCase
- Stores reference to file storage (not the file itself)

---

## Audit & Tracking

### AuditLog
**Purpose**: Complete activity tracking with hierarchy visibility
- Records all actions in the system
- Includes actor, action, entity modified, old/new values
- **Hierarchy Visibility**: Logs include BranchId, DepartmentId, EmployeeId
- Enables filtering: "Show all activities in my branch/department"

**Key Fields**:
- `ActorUserId`: Who performed the action
- `Action`: Create/Update/Delete/Approve/Reject/Apply
- `EntityType`, `EntityId`: What was modified
- `DepartmentId`, `BranchId`, `EmployeeId`: For hierarchy filtering
- `OldValuesJson`, `NewValuesJson`: Change tracking

**Visibility Rules**:
- Admin: Sees all logs
- BranchManager: Sees logs with their BranchId
- DepartmentChief: Sees logs with their DepartmentId
- Regular employees: See their own logs only
- Accounting/HR activities visible to their chiefs and branch managers

### SessionLog
**Purpose**: System login/logout tracking (separate from attendance)
- Tracks when users log into/out of the system
- Different from AttendanceEvent (physical presence)
- Stores session duration, IP, device info

**Key Fields**:
- `UserId`: Who logged in
- `LoginAt`, `LogoutAt`: Session times
- `IsActive`: Currently logged in
- `IpAddress`, `UserAgent`, `DeviceInfo`: Security tracking

**Difference from AttendanceEvent**:
- **SessionLog**: Digital system access (can work remotely)
- **AttendanceEvent**: Physical office presence

---

## Enums

### UserRole
- `Admin`: Full system access
- `BranchManager`: Manages a branch, approves schedules, rates chiefs
- `DepartmentChief`: Manages a department, creates schedules, rates employees
- `HumanResources`: HR department chief, handles tickets and HR operations
- `Accounting`: Accounting department chief, manages salaries
- `Employee`: Regular employee, basic access

### WorkScheduleStatus
- `Draft`: Being created
- `Submitted`: Awaiting approval
- `Approved`: Approved by BranchManager
- `Rejected`: Rejected by BranchManager
- `Published`: Active and visible to employees

### SalaryCalculationMode
- `Auto`: Calculated by system rules
- `Manual`: Completely manual entry
- `Mixed`: Some auto, some manual components

### SalaryChangeStatus
- `Draft`: Being prepared
- `Submitted`: Awaiting review
- `Approved`: Approved by HR/Admin
- `Rejected`: Rejected
- `Applied`: Changes applied to employee

### ComplaintStatus
- `Submitted`: New complaint
- `InReview`: Being investigated
- `WaitingOnEmployee`: Needs employee response
- `Resolved`: Closed successfully
- `Rejected`: Dismissed

### PayrollRunStatus
- `Draft`: Being prepared
- `Finalized`: Locked, ready for payment
- `Paid`: Payment completed

### AttendanceEventType
- `CheckIn`: Arrived at work
- `CheckOut`: Left work
- `BreakStart`: Started break
- `BreakEnd`: Returned from break

---

## Key Relationships Summary

1. **User ↔ Employee**: One-to-one (optional on both sides)
2. **Branch → Departments**: One-to-many
3. **Branch → Employees**: One-to-many
4. **Department → Employees**: One-to-many
5. **Employee → WeeklyRatings**: One-to-many
6. **WeeklyRating → Revisions**: One-to-many (history)
7. **Employee → SalaryPackages**: One-to-many (time-based)
8. **SalaryPackage → Components**: One-to-many
9. **Department → WorkSchedules**: One-to-many
10. **WorkSchedule → Assignments**: One-to-many
11. **Employee → ComplaintCases**: One-to-many
12. **ComplaintCase → Messages/Attachments**: One-to-many
13. **User → SessionLogs**: One-to-many
14. **User → AuditLogs**: One-to-many

---

## Hierarchy & Visibility

### Access Control Levels:
1. **Admin**: Everything
2. **BranchManager**: Their branch + all departments in branch
3. **DepartmentChief**: Their department only
4. **HR/Accounting Chiefs**: Their department + tickets/salaries
5. **Employee**: Their own data only

### Activity Visibility:
- All activities logged in `AuditLog` with hierarchy tags
- Activities by Accounting → visible to Accounting Chief, BranchManager, Admin
- Activities by HR → visible to HR Chief, BranchManager, Admin
- Activities by Department Employee → visible to DepartmentChief, BranchManager, Admin
- Regular employee work → only visible to them and their chief

---

## Workflow Examples

### 1. Monthly Schedule Creation & Approval
1. DepartmentChief creates `WorkSchedule` (Draft)
2. Adds `WorkScheduleAssignment` for each employee/day
3. Submits schedule (Submitted)
4. BranchManager reviews and approves (Approved)
5. Chief publishes schedule (Published)
6. Employees can view their schedule

### 2. Salary Change Process
1. Accounting creates `SalaryChangeRequest` (Draft)
2. Adds `SalaryChangeItem` for components to change
3. Submits request (Submitted)
4. HR/Admin reviews and approves (Approved)
5. System applies changes to `SalaryPackage` (Applied)
6. Activity logged in `AuditLog` with EmployeeId, DepartmentId, BranchId

### 3. Complaint Escalation
1. Employee creates `ComplaintCase` (Submitted)
2. DepartmentChief sees it, adds `ComplaintMessage`
3. If needed, chief forwards to BranchManager (`IsForwardedToBranchManager = true`)
4. BranchManager investigates and resolves
5. All messages stored in `ComplaintMessage`
6. Case closed (Resolved)

### 4. Weekly Performance Rating
1. DepartmentChief creates `WeeklyRating` for employee
2. Adds initial `WeeklyRatingRevision` with score and comment
3. If rating is updated, adds new revision (maintains history)
4. Finalizes rating (`IsFinalized = true`)
5. BranchManager can rate the DepartmentChief
6. All revisions preserved as snapshots

---

## Notes

- **Everyone is both User and Employee**: All system users should have both records
- **Deleted old Salary model**: Now using flexible SalaryPackage + SalaryComponent system
- **Snapshots everywhere**: WeeklyRatingRevision, SalarySlipSnapshot, AuditLog preserve history
- **Hierarchy in all logs**: BranchId, DepartmentId, EmployeeId enable proper filtering
- **Separation of concerns**: SessionLog (system access) vs AttendanceEvent (physical presence)
- **Flexible salary system**: Can mix auto-calculated and manual components
- **Complete audit trail**: Every action tracked with full context

