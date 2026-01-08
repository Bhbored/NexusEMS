# NexusEMS Unit Tests

## Overview
Comprehensive unit tests for all models in the NexusEMS system with realistic test data.

## Test Data Structure

The `TestDataBuilder` creates a complete organizational structure:

- **1 Admin** - System administrator
- **5 Branches** - Each with a BranchManager
- **50 Departments** (10 per branch):
  - 8 Regular departments per branch
  - 1 HR department per branch (IsSystemDepartment = true)
  - 1 Accounting department per branch (IsSystemDepartment = true)
- **~200 Employees** - Distributed across all departments
- **All Relationships** - Properly linked with navigation properties
- **Snapshots** - SalarySlipSnapshots, WeeklyRatingRevisions
- **Complete Data** - WorkSchedules, Complaints, Attendance, Sessions, AuditLogs

## Test Classes

### Core Models
- ✅ `UserTests.cs` - User authentication and roles
- ✅ `EmployeeTests.cs` - Employee records and relationships
- ✅ `BranchTests.cs` - Branch management
- ✅ `DepartmentTests.cs` - Department structure

### Salary Models
- ✅ `SalaryPackageTests.cs` - Salary packages
- ✅ `SalaryComponentTests.cs` - Salary components
- ✅ `SalaryChangeRequestTests.cs` - Salary change requests
- ✅ `SalaryChangeItemTests.cs` - Salary change items
- ✅ `SalarySlipSnapshotTests.cs` - Salary slip snapshots
- ✅ `PayrollRunTests.cs` - Payroll runs
- ✅ `SalaryConfigurationTests.cs` - Salary configurations

### Performance & Scheduling
- ✅ `WeeklyRatingTests.cs` - Weekly performance ratings
- ✅ `WeeklyRatingRevisionTests.cs` - Rating revision snapshots
- ✅ `WorkScheduleTests.cs` - Work schedules
- ✅ `WorkScheduleAssignmentTests.cs` - Schedule assignments

### Complaints & Tickets
- ✅ `ComplaintCaseTests.cs` - Complaint cases
- ✅ `ComplaintMessageTests.cs` - Complaint messages
- ✅ `ComplaintAttachmentTests.cs` - Complaint attachments

### Tracking & Logging
- ✅ `AttendanceEventTests.cs` - Attendance tracking
- ✅ `SessionLogTests.cs` - Login/logout sessions
- ✅ `AuditLogTests.cs` - Activity audit logs

### Supporting Models
- ✅ `PositionTests.cs` - Job positions
- ✅ `AddressTests.cs` - Address information
- ✅ `EntityBaseTests.cs` - Base entity properties

## Running Tests

```bash
# Run all tests
dotnet test

# Run specific test class
dotnet test --filter "FullyQualifiedName~UserTests"

# Run with coverage
dotnet test /p:CollectCoverage=true
```

## Test Data Statistics

- **Users**: ~200+ (1 Admin, 5 BranchManagers, 40 DepartmentChiefs, 5 HR Chiefs, 5 Accounting Chiefs, ~150 Employees)
- **Employees**: ~200+
- **Branches**: 5
- **Departments**: 50 (10 per branch)
- **SalaryPackages**: ~200
- **SalaryComponents**: ~1400+ (7 per package)
- **PayrollRuns**: 3 (3 months)
- **SalarySlipSnapshots**: ~150
- **WeeklyRatings**: Multiple per department
- **WorkSchedules**: 40+ (one per regular department)
- **WorkScheduleAssignments**: 1000+
- **ComplaintCases**: 15
- **AttendanceEvents**: 200+
- **SessionLogs**: 60
- **AuditLogs**: 50

## Test Coverage

All models are tested for:
- ✅ Required fields validation
- ✅ Relationships (navigation properties)
- ✅ Enum values
- ✅ Data integrity
- ✅ Business logic constraints
- ✅ Snapshot models
- ✅ Collection properties

## Notes

- All relationships are properly linked
- Snapshot models (SalarySlipSnapshot, WeeklyRatingRevision) are included
- Test data reflects real-world organizational structure
- Each branch operates independently with its own HR and Accounting departments
