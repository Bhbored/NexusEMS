using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;

namespace NexusEMS.Tests.TestData;

public class TestDataBuilder
{
    public List<User> Users { get; private set; } = new();
    public List<Employee> Employees { get; private set; } = new();
    public List<Branch> Branches { get; private set; } = new();
    public List<Department> Departments { get; private set; } = new();
    public List<Position> Positions { get; private set; } = new();
    public List<SalaryConfiguration> SalaryConfigurations { get; private set; } = new();
    public List<SalaryPackage> SalaryPackages { get; private set; } = new();
    public List<SalaryComponent> SalaryComponents { get; private set; } = new();
    public List<SalaryChangeRequest> SalaryChangeRequests { get; private set; } = new();
    public List<SalaryChangeItem> SalaryChangeItems { get; private set; } = new();
    public List<PayrollRun> PayrollRuns { get; private set; } = new();
    public List<SalarySlipSnapshot> SalarySlipSnapshots { get; private set; } = new();
    public List<WeeklyRating> WeeklyRatings { get; private set; } = new();
    public List<WeeklyRatingRevision> WeeklyRatingRevisions { get; private set; } = new();
    public List<WorkSchedule> WorkSchedules { get; private set; } = new();
    public List<WorkScheduleAssignment> WorkScheduleAssignments { get; private set; } = new();
    public List<ComplaintCase> ComplaintCases { get; private set; } = new();
    public List<ComplaintMessage> ComplaintMessages { get; private set; } = new();
    public List<ComplaintAttachment> ComplaintAttachments { get; private set; } = new();
    public List<AttendanceEvent> AttendanceEvents { get; private set; } = new();
    public List<SessionLog> SessionLogs { get; private set; } = new();
    public List<AuditLog> AuditLogs { get; private set; } = new();

    public TestDataBuilder Build()
    {
        CreatePositions();
        CreateAdmin();
        CreateBranches();
        CreateDepartments();
        CreateEmployees();
        CreateSalaryConfigurations();
        CreateSalaryPackages();
        CreateSalaryChangeRequests();
        CreatePayrollRuns();
        CreateWeeklyRatings();
        CreateWorkSchedules();
        CreateComplaintCases();
        CreateAttendanceEvents();
        CreateSessionLogs();
        CreateAuditLogs();

        return this;
    }

    private void CreatePositions()
    {
        var positionNames = new[] { "Software Developer", "Senior Developer", "Team Lead", "Manager", "HR Specialist", "Accountant", "Senior Accountant", "Analyst", "Designer", "QA Engineer" };
        
        for (int i = 0; i < positionNames.Length; i++)
        {
            Positions.Add(new Position
            {
                Title = positionNames[i],
                Description = $"Position for {positionNames[i]}",
                BaseSalary = 30000 + (i * 5000),
                SalaryRangeMin = 25000 + (i * 4000),
                SalaryRangeMax = 50000 + (i * 8000)
            });
        }
    }

    private void CreateAdmin()
    {
        var adminUser = new User
        {
            Username = "admin",
            Email = "admin@nexusems.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
            Role = Shared.Enums.UserRole.Admin,
            IsOnline = false
        };

        var adminEmployee = new Employee
        {
            FirstName = "System",
            LastName = "Administrator",
            Email = "admin@nexusems.com",
            Phone = "+1234567890",
            Gender = Gender.Male,
            EmployeeCode = "ADM001",
            EducationLevel = EducationLevel.PhD,
            DateOfBirth = new DateTime(1980, 1, 1),
            IsMarried = true,
            NumberOfChildren = 2,
            HireDate = new DateTime(2020, 1, 1),
            ContractType = ContractType.FullTime,
            EmploymentStatus = EmploymentStatus.Active,
            WorkLocation = "Headquarters"
        };

        adminUser.EmployeeProfileId = adminEmployee.Id;
        adminEmployee.AssignedToUserId = adminUser.Id;

        Users.Add(adminUser);
        Employees.Add(adminEmployee);
    }

    private void CreateBranches()
    {
        var branchNames = new[] { "North Branch", "South Branch", "East Branch", "West Branch", "Central Branch" };
        var locations = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };

        for (int i = 0; i < 5; i++)
        {
            var branchManager = new User
            {
                Username = $"branchmanager{i + 1}",
                Email = $"bm{i + 1}@nexusems.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Manager123!"),
                Role = Shared.Enums.UserRole.BranchManager,
                IsOnline = false
            };

            var branchManagerEmployee = new Employee
            {
                FirstName = $"Branch",
                LastName = $"Manager{i + 1}",
                Email = $"bm{i + 1}@nexusems.com",
                Phone = $"+123456789{i + 1}",
                Gender = i % 2 == 0 ? Gender.Male : Gender.Female,
                EmployeeCode = $"BM{i + 1:D3}",
                EducationLevel = EducationLevel.Master,
                DateOfBirth = new DateTime(1985 + i, 1, 1),
                IsMarried = true,
                NumberOfChildren = i % 2,
                HireDate = new DateTime(2021, 1, 1),
                ContractType = ContractType.FullTime,
                EmploymentStatus = EmploymentStatus.Active,
                WorkLocation = locations[i]
            };

            branchManager.EmployeeProfileId = branchManagerEmployee.Id;
            branchManagerEmployee.AssignedToUserId = branchManager.Id;

            var branch = new Branch
            {
                Name = branchNames[i],
                Description = $"Main branch located in {locations[i]}",
                Code = $"BR{i + 1:D3}",
                Location = locations[i],
                Budget = 1000000 + (i * 200000),
                ContactNumber = $"+1-555-000-{1000 + i}",
                ManagerUserId = branchManager.Id
            };

            branchManager.BranchId = branch.Id;
            branchManagerEmployee.BranchId = branch.Id;

            Users.Add(branchManager);
            Employees.Add(branchManagerEmployee);
            Branches.Add(branch);
        }
    }

    private void CreateDepartments()
    {
        var regularDeptNames = new[] { "Engineering", "Marketing", "Sales", "Operations", "IT Support", "Customer Service", "Research", "Quality Assurance" };
        var hrDeptName = "Human Resources";
        var accountingDeptName = "Accounting";

        int branchIndex = 0;
        foreach (var branch in Branches)
        {
            branchIndex++;

            for (int i = 0; i < 8; i++)
            {
                var chief = new User
                {
                    Username = $"chief{branchIndex}_{i + 1}",
                    Email = $"chief{branchIndex}_{i + 1}@nexusems.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Chief123!"),
                    Role = Shared.Enums.UserRole.DepartmentChief,
                    IsOnline = false,
                    BranchId = branch.Id
                };

                var chiefEmployee = new Employee
                {
                    FirstName = regularDeptNames[i],
                    LastName = "Chief",
                    Email = $"chief{branchIndex}_{i + 1}@nexusems.com",
                    Phone = $"+1234567{branchIndex}{i + 1}",
                    Gender = i % 2 == 0 ? Gender.Male : Gender.Female,
                    EmployeeCode = $"DC{branchIndex}{i + 1:D2}",
                    EducationLevel = EducationLevel.Master,
                    DateOfBirth = new DateTime(1988 + i, 1, 1),
                    IsMarried = true,
                    NumberOfChildren = 1,
                    HireDate = new DateTime(2021, 6, 1),
                    ContractType = ContractType.FullTime,
                    EmploymentStatus = EmploymentStatus.Active,
                    WorkLocation = branch.Location,
                    PositionId = Positions[2].Id
                };

                chief.EmployeeProfileId = chiefEmployee.Id;
                chief.DepartmentId = null;
                chiefEmployee.AssignedToUserId = chief.Id;
                chiefEmployee.BranchId = branch.Id;

                var department = new Department
                {
                    Name = $"{regularDeptNames[i]} - {branch.Name}",
                    Description = $"{regularDeptNames[i]} department in {branch.Name}",
                    Code = $"DEPT{branchIndex}{i + 1:D2}",
                    BranchId = branch.Id,
                    ChiefUserId = chief.Id,
                    Budget = 200000 + (i * 10000),
                    IsSystemDepartment = false
                };

                chief.DepartmentId = department.Id;
                chiefEmployee.DepartmentId = department.Id;

                Users.Add(chief);
                Employees.Add(chiefEmployee);
                Departments.Add(department);
            }

            var hrChief = new User
            {
                Username = $"hrchief{branchIndex}",
                Email = $"hrchief{branchIndex}@nexusems.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("HR123!"),
                Role = Shared.Enums.UserRole.HumanResources,
                IsOnline = false,
                BranchId = branch.Id
            };

            var hrChiefEmployee = new Employee
            {
                FirstName = "HR",
                LastName = $"Chief{branchIndex}",
                Email = $"hrchief{branchIndex}@nexusems.com",
                Phone = $"+1234567{branchIndex}HR",
                Gender = Gender.Female,
                EmployeeCode = $"HR{branchIndex:D2}",
                EducationLevel = EducationLevel.Master,
                DateOfBirth = new DateTime(1987, 1, 1),
                IsMarried = true,
                NumberOfChildren = 1,
                HireDate = new DateTime(2021, 3, 1),
                ContractType = ContractType.FullTime,
                EmploymentStatus = EmploymentStatus.Active,
                WorkLocation = branch.Location,
                PositionId = Positions[4].Id
            };

            hrChief.EmployeeProfileId = hrChiefEmployee.Id;
            hrChiefEmployee.AssignedToUserId = hrChief.Id;
            hrChiefEmployee.BranchId = branch.Id;

            var hrDepartment = new Department
            {
                Name = $"{hrDeptName} - {branch.Name}",
                Description = $"Human Resources department in {branch.Name}",
                Code = $"HR{branchIndex:D2}",
                BranchId = branch.Id,
                ChiefUserId = hrChief.Id,
                Budget = 150000,
                IsSystemDepartment = true
            };

            hrChief.DepartmentId = hrDepartment.Id;
            hrChiefEmployee.DepartmentId = hrDepartment.Id;

            Users.Add(hrChief);
            Employees.Add(hrChiefEmployee);
            Departments.Add(hrDepartment);

            var accountingChief = new User
            {
                Username = $"accountingchief{branchIndex}",
                Email = $"accountingchief{branchIndex}@nexusems.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Acc123!"),
                Role = Shared.Enums.UserRole.Accounting,
                IsOnline = false,
                BranchId = branch.Id
            };

            var accountingChiefEmployee = new Employee
            {
                FirstName = "Accounting",
                LastName = $"Chief{branchIndex}",
                Email = $"accountingchief{branchIndex}@nexusems.com",
                Phone = $"+1234567{branchIndex}AC",
                Gender = Gender.Male,
                EmployeeCode = $"AC{branchIndex:D2}",
                EducationLevel = EducationLevel.Master,
                DateOfBirth = new DateTime(1986, 1, 1),
                IsMarried = true,
                NumberOfChildren = 2,
                HireDate = new DateTime(2021, 2, 1),
                ContractType = ContractType.FullTime,
                EmploymentStatus = EmploymentStatus.Active,
                WorkLocation = branch.Location,
                PositionId = Positions[5].Id
            };

            accountingChief.EmployeeProfileId = accountingChiefEmployee.Id;
            accountingChiefEmployee.AssignedToUserId = accountingChief.Id;
            accountingChiefEmployee.BranchId = branch.Id;

            var accountingDepartment = new Department
            {
                Name = $"{accountingDeptName} - {branch.Name}",
                Description = $"Accounting department in {branch.Name}",
                Code = $"ACC{branchIndex:D2}",
                BranchId = branch.Id,
                ChiefUserId = accountingChief.Id,
                Budget = 180000,
                IsSystemDepartment = true
            };

            accountingChief.DepartmentId = accountingDepartment.Id;
            accountingChiefEmployee.DepartmentId = accountingDepartment.Id;

            Users.Add(accountingChief);
            Employees.Add(accountingChiefEmployee);
            Departments.Add(accountingDepartment);
        }
    }

    private void CreateEmployees()
    {
        int employeeCounter = 1;
        var firstNames = new[] { "John", "Jane", "Michael", "Sarah", "David", "Emily", "Robert", "Jessica", "William", "Amanda" };
        var lastNames = new[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };

        foreach (var department in Departments.Where(d => !d.IsSystemDepartment))
        {
            int employeesPerDept = 4;
            for (int i = 0; i < employeesPerDept; i++)
            {
                var employee = new Employee
                {
                    FirstName = firstNames[employeeCounter % firstNames.Length],
                    LastName = lastNames[employeeCounter % lastNames.Length],
                    Email = $"emp{employeeCounter:D3}@nexusems.com",
                    Phone = $"+1234567{employeeCounter:D4}",
                    Gender = employeeCounter % 2 == 0 ? Gender.Male : Gender.Female,
                    EmployeeCode = $"EMP{employeeCounter:D3}",
                    EducationLevel = (EducationLevel)((employeeCounter % 6) + 1),
                    DateOfBirth = new DateTime(1990 + (employeeCounter % 15), 1, 1),
                    IsMarried = employeeCounter % 3 == 0,
                    NumberOfChildren = employeeCounter % 4,
                    DepartmentId = department.Id,
                    BranchId = department.BranchId,
                    HireDate = new DateTime(2022, 1, 1).AddDays(employeeCounter * 7),
                    ContractType = (ContractType)((employeeCounter % 5) + 1),
                    EmploymentStatus = employeeCounter % 20 == 0 ? EmploymentStatus.OnLeave : EmploymentStatus.Active,
                    PositionId = Positions[employeeCounter % Positions.Count].Id,
                    WorkLocation = department.Branch?.Location ?? "Unknown"
                };

                if (employeeCounter > 1)
                {
                var chiefUser = Users.FirstOrDefault(u => u.DepartmentId == department.Id && u.Role == Shared.Enums.UserRole.DepartmentChief);
                if (chiefUser != null)
                {
                    var chiefEmployee = Employees.FirstOrDefault(e => e.AssignedToUserId == chiefUser.Id);
                    if (chiefEmployee != null)
                    {
                        employee.ReportsToEmployeeId = chiefEmployee.Id;
                    }
                }
                }

                var user = new User
                {
                    Username = $"employee{employeeCounter:D3}",
                    Email = employee.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Emp123!"),
                    Role = Shared.Enums.UserRole.Employee,
                    IsOnline = false,
                    BranchId = department.BranchId,
                    DepartmentId = department.Id,
                    EmployeeProfileId = employee.Id
                };

                employee.AssignedToUserId = user.Id;

                Users.Add(user);
                Employees.Add(employee);
                employeeCounter++;
            }
        }

        foreach (var hrDept in Departments.Where(d => d.IsSystemDepartment && d.Name.Contains("Human Resources")))
        {
            for (int i = 0; i < 2; i++)
            {
                var employee = new Employee
                {
                    FirstName = $"HR{i + 1}",
                    LastName = "Specialist",
                    Email = $"hrspec{hrDept.Code}{i + 1}@nexusems.com",
                    Phone = $"+1234567HR{i + 1}",
                    Gender = Gender.Female,
                    EmployeeCode = $"HR{hrDept.Code}{i + 1}",
                    EducationLevel = EducationLevel.Bachelor,
                    DateOfBirth = new DateTime(1992 + i, 1, 1),
                    IsMarried = false,
                    NumberOfChildren = 0,
                    DepartmentId = hrDept.Id,
                    BranchId = hrDept.BranchId,
                    HireDate = new DateTime(2022, 3, 1),
                    ContractType = ContractType.FullTime,
                    EmploymentStatus = EmploymentStatus.Active,
                    PositionId = Positions[4].Id,
                    WorkLocation = hrDept.Branch?.Location ?? "Unknown"
                };

                var user = new User
                {
                    Username = $"hrspec{hrDept.Code}{i + 1}",
                    Email = employee.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("HR123!"),
                    Role = Shared.Enums.UserRole.Employee,
                    IsOnline = false,
                    BranchId = hrDept.BranchId,
                    DepartmentId = hrDept.Id,
                    EmployeeProfileId = employee.Id
                };

                employee.AssignedToUserId = user.Id;
                var hrChiefEmployee = Employees.FirstOrDefault(e => e.AssignedToUserId == hrDept.ChiefUserId);
                if (hrChiefEmployee != null)
                {
                    employee.ReportsToEmployeeId = hrChiefEmployee.Id;
                }

                Users.Add(user);
                Employees.Add(employee);
            }
        }

        foreach (var accDept in Departments.Where(d => d.IsSystemDepartment && d.Name.Contains("Accounting")))
        {
            for (int i = 0; i < 2; i++)
            {
                var employee = new Employee
                {
                    FirstName = $"Accountant{i + 1}",
                    LastName = "Professional",
                    Email = $"acc{accDept.Code}{i + 1}@nexusems.com",
                    Phone = $"+1234567AC{i + 1}",
                    Gender = i % 2 == 0 ? Gender.Male : Gender.Female,
                    EmployeeCode = $"ACC{accDept.Code}{i + 1}",
                    EducationLevel = EducationLevel.Bachelor,
                    DateOfBirth = new DateTime(1991 + i, 1, 1),
                    IsMarried = true,
                    NumberOfChildren = 1,
                    DepartmentId = accDept.Id,
                    BranchId = accDept.BranchId,
                    HireDate = new DateTime(2022, 2, 1),
                    ContractType = ContractType.FullTime,
                    EmploymentStatus = EmploymentStatus.Active,
                    PositionId = Positions[5].Id,
                    WorkLocation = accDept.Branch?.Location ?? "Unknown"
                };

                var user = new User
                {
                    Username = $"accountant{accDept.Code}{i + 1}",
                    Email = employee.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Acc123!"),
                    Role = Shared.Enums.UserRole.Employee,
                    IsOnline = false,
                    BranchId = accDept.BranchId,
                    DepartmentId = accDept.Id,
                    EmployeeProfileId = employee.Id
                };

                employee.AssignedToUserId = user.Id;
                var accChiefEmployee = Employees.FirstOrDefault(e => e.AssignedToUserId == accDept.ChiefUserId);
                if (accChiefEmployee != null)
                {
                    employee.ReportsToEmployeeId = accChiefEmployee.Id;
                }

                Users.Add(user);
                Employees.Add(employee);
            }
        }
    }

    private void CreateSalaryConfigurations()
    {
        foreach (var branch in Branches)
        {
            SalaryConfigurations.Add(new SalaryConfiguration
            {
                BranchId = branch.Id,
                Name = $"Default Salary Config - {branch.Name}",
                Description = $"Default salary configuration for {branch.Name}",
                BaseSalary = 50000,
                HraPercentage = 20,
                DaPercentage = 10,
                ConveyanceAllowance = 2000,
                MedicalAllowance = 1500,
                MarriedMultiplier = 1.1m,
                ChildMultiplier = 0.05m,
                PostGraduateMultiplier = 1.15m,
                PhdMultiplier = 1.25m,
                TwoYearIncrementPercentage = 5,
                IsActive = true
            });
        }
    }

    private void CreateSalaryPackages()
    {
        var config = SalaryConfigurations.First();
        var accountingUser = Users.FirstOrDefault(u => u.Role == Shared.Enums.UserRole.Accounting);

        foreach (var employee in Employees.Where(e => e.AssignedToUserId.HasValue))
        {
            var package = new SalaryPackage
            {
                EmployeeProfileId = employee.Id,
                EffectiveFrom = DateOnly.FromDateTime(employee.HireDate),
                CalculationMode = Shared.Enums.SalaryCalculationMode.Auto,
                CreatedByUserId = accountingUser?.Id ?? Users.First().Id,
                Notes = $"Initial salary package for {employee.FirstName} {employee.LastName}"
            };

            var baseSalary = 50000m;
            if (employee.EducationLevel == EducationLevel.PostGraduate) baseSalary *= 1.15m;
            if (employee.EducationLevel == EducationLevel.PhD) baseSalary *= 1.25m;
            if (employee.IsMarried) baseSalary *= 1.1m;
            if (employee.NumberOfChildren > 0) baseSalary *= (1 + (0.05m * employee.NumberOfChildren));

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.Base,
                Amount = baseSalary,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.HousingAllowance,
                Amount = baseSalary * 0.20m,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.DearnessAllowance,
                Amount = baseSalary * 0.10m,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.TransportAllowance,
                Amount = 2000,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.MedicalAllowance,
                Amount = 1500,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.Tax,
                Amount = baseSalary * 0.10m,
                IsDeduction = true,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            package.Components.Add(new SalaryComponent
            {
                Type = Shared.Enums.SalaryComponentType.Pension,
                Amount = baseSalary * 0.12m,
                IsDeduction = true,
                Source = Shared.Enums.SalaryComponentSource.AutoRule
            });

            SalaryPackages.Add(package);
            SalaryComponents.AddRange(package.Components);
        }
    }

    private void CreateSalaryChangeRequests()
    {
        var accountingUser = Users.FirstOrDefault(u => u.Role == Shared.Enums.UserRole.Accounting);
        var hrUser = Users.FirstOrDefault(u => u.Role == Shared.Enums.UserRole.HumanResources);

        foreach (var employee in Employees.Take(10).Where(e => e.AssignedToUserId.HasValue))
        {
            var request = new SalaryChangeRequest
            {
                EmployeeProfileId = employee.Id,
                Status = Shared.Enums.SalaryChangeStatus.Approved,
                RequestedByUserId = accountingUser?.Id ?? Users.First().Id,
                ReviewedByUserId = hrUser?.Id ?? Users.First().Id,
                Reason = $"Annual salary review for {employee.FirstName} {employee.LastName}",
                EffectiveFrom = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
                ReviewedAtUtc = DateTime.UtcNow.AddDays(-10),
                AppliedAtUtc = DateTime.UtcNow.AddDays(-5)
            };

            request.Items.Add(new SalaryChangeItem
            {
                ComponentType = Shared.Enums.SalaryComponentType.Bonus,
                Action = SalaryChangeItemAction.AddOrUpdate,
                Amount = 5000,
                IsDeduction = false,
                Source = Shared.Enums.SalaryComponentSource.Manual
            });

            SalaryChangeRequests.Add(request);
            SalaryChangeItems.AddRange(request.Items);
        }
    }

    private void CreatePayrollRuns()
    {
        var accountingUser = Users.FirstOrDefault(u => u.Role == Shared.Enums.UserRole.Accounting);

        for (int month = 1; month <= 3; month++)
        {
            var payrollRun = new PayrollRun
            {
                PeriodStart = new DateOnly(2024, month, 1),
                PeriodEnd = new DateOnly(2024, month, DateTime.DaysInMonth(2024, month)),
                Status = Shared.Enums.PayrollRunStatus.Finalized,
                CreatedByUserId = accountingUser?.Id ?? Users.First().Id,
                FinalizedAtUtc = new DateTime(2024, month, 28)
            };

            foreach (var employee in Employees.Take(50).Where(e => e.AssignedToUserId.HasValue))
            {
                var package = SalaryPackages.FirstOrDefault(p => p.EmployeeProfileId == employee.Id);
                if (package != null)
                {
                    var gross = package.Components.Where(c => !c.IsDeduction).Sum(c => c.Amount);
                    var deductions = package.Components.Where(c => c.IsDeduction).Sum(c => c.Amount);
                    var net = gross - deductions;

                    var snapshot = new SalarySlipSnapshot
                    {
                        PayrollRunId = payrollRun.Id,
                        EmployeeProfileId = employee.Id,
                        Gross = gross,
                        TotalDeductions = deductions,
                        NetPaid = net,
                        Currency = "USD",
                        SnapshotJson = $"{{\"employee\":\"{employee.FirstName} {employee.LastName}\",\"month\":{month}}}"
                    };

                    payrollRun.SalarySlips.Add(snapshot);
                    SalarySlipSnapshots.Add(snapshot);
                }
            }

            PayrollRuns.Add(payrollRun);
        }
    }

    private void CreateWeeklyRatings()
    {
        var weekStart = DateOnly.FromDateTime(DateTime.Now.AddDays(-(DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.Now.DayOfWeek)));

        foreach (var department in Departments.Where(d => !d.IsSystemDepartment))
        {
            var chief = Users.FirstOrDefault(u => u.DepartmentId == department.Id);
            var employees = Employees.Where(e => e.DepartmentId == department.Id && e.AssignedToUserId.HasValue).Take(3);

            foreach (var employee in employees)
            {
                var rating = new WeeklyRating
                {
                    EmployeeProfileId = employee.Id,
                    WeekStartDate = weekStart,
                    CreatedByUserId = chief?.Id ?? Users.First().Id,
                    IsFinalized = true
                };

                rating.Revisions.Add(new WeeklyRatingRevision
                {
                    Score = 4,
                    Comment = $"Good performance this week from {employee.FirstName}",
                    CreatedByUserId = chief?.Id ?? Users.First().Id
                });

                WeeklyRatings.Add(rating);
                WeeklyRatingRevisions.AddRange(rating.Revisions);
            }
        }
    }

    private void CreateWorkSchedules()
    {
        var currentMonth = DateOnly.FromDateTime(DateTime.Now);
        var monthStart = new DateOnly(currentMonth.Year, currentMonth.Month, 1);
        var monthEnd = new DateOnly(currentMonth.Year, currentMonth.Month, DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month));

        foreach (var department in Departments.Where(d => !d.IsSystemDepartment))
        {
            var chief = Users.FirstOrDefault(u => u.DepartmentId == department.Id);
            var branchManager = Users.FirstOrDefault(u => u.BranchId == department.BranchId && u.Role == Shared.Enums.UserRole.BranchManager);

            var schedule = new WorkSchedule
            {
                DepartmentId = department.Id,
                CreatedByUserId = chief?.Id ?? Users.First().Id,
                Title = $"Schedule for {department.Name} - {currentMonth:MMMM yyyy}",
                PeriodStart = monthStart,
                PeriodEnd = monthEnd,
                Description = $"Monthly work schedule for {department.Name}",
                Status = Shared.Enums.WorkScheduleStatus.Approved,
                ApprovedByUserId = branchManager?.Id,
                SubmittedAtUtc = DateTime.UtcNow.AddDays(-5),
                ApprovedAtUtc = DateTime.UtcNow.AddDays(-3),
                ScheduleDataJson = "{}"
            };

            var employees = Employees.Where(e => e.DepartmentId == department.Id && e.AssignedToUserId.HasValue).Take(4);

            foreach (var employee in employees)
            {
                for (int day = 1; day <= 20; day++)
                {
                    if (day % 7 != 0 && day % 7 != 6)
                    {
                        schedule.Assignments.Add(new WorkScheduleAssignment
                        {
                            EmployeeId = employee.Id,
                            Date = monthStart.AddDays(day - 1),
                            StartTime = new TimeOnly(9, 0),
                            EndTime = new TimeOnly(17, 0),
                            IsDayOff = false
                        });
                    }
                }
            }

            WorkSchedules.Add(schedule);
            WorkScheduleAssignments.AddRange(schedule.Assignments);
        }
    }

    private void CreateComplaintCases()
    {
        var employees = Employees.Where(e => e.AssignedToUserId.HasValue).Take(15);

        foreach (var employee in employees)
        {
            var complaint = new ComplaintCase
            {
                CreatedByEmployeeProfileId = employee.Id,
                DepartmentId = employee.DepartmentId != Guid.Empty ? employee.DepartmentId : Guid.Empty,
                BranchId = employee.BranchId,
                Subject = $"Complaint from {employee.FirstName} {employee.LastName}",
                Description = $"This is a test complaint created for testing purposes.",
                Target = Shared.Enums.ComplaintTarget.HR,
                Category = Shared.Enums.ComplaintCategory.Other,
                Severity = Shared.Enums.ComplaintSeverity.Medium,
                Status = Shared.Enums.ComplaintStatus.Submitted,
                IsAnonymousToChief = false
            };

            complaint.Messages.Add(new ComplaintMessage
            {
                AuthorUserId = employee.AssignedToUserId ?? Guid.Empty,
                Body = "Initial complaint message",
                IsInternal = false
            });

            ComplaintCases.Add(complaint);
            ComplaintMessages.AddRange(complaint.Messages);
        }
    }

    private void CreateAttendanceEvents()
    {
        var today = DateTime.UtcNow.Date;
        var employees = Employees.Where(e => e.AssignedToUserId.HasValue).Take(100);

        foreach (var employee in employees)
        {
            var checkIn = new AttendanceEvent
            {
                EmployeeProfileId = employee.Id,
                TimestampUtc = today.AddHours(9),
                EventType = Shared.Enums.AttendanceEventType.CheckIn,
                VerificationMethod = Shared.Enums.VerificationMethod.QR,
                DeviceId = $"DEV{employee.EmployeeCode}",
                LocationLabel = employee.WorkLocation ?? "Office"
            };

            var checkOut = new AttendanceEvent
            {
                EmployeeProfileId = employee.Id,
                TimestampUtc = today.AddHours(17),
                EventType = Shared.Enums.AttendanceEventType.CheckOut,
                VerificationMethod = Shared.Enums.VerificationMethod.QR,
                DeviceId = $"DEV{employee.EmployeeCode}",
                LocationLabel = employee.WorkLocation ?? "Office"
            };

            AttendanceEvents.Add(checkIn);
            AttendanceEvents.Add(checkOut);
        }
    }

    private void CreateSessionLogs()
    {
        int userIndex = 0;
        foreach (var user in Users.Take(50))
        {
            var session = new SessionLog
            {
                UserId = user.Id,
                LoginAt = DateTime.UtcNow.AddHours(-8),
                LogoutAt = DateTime.UtcNow.AddHours(-1),
                IpAddress = $"192.168.1.{(userIndex % 255) + 1}",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)",
                DeviceInfo = "Windows 10",
                IsActive = false
            };

            SessionLogs.Add(session);
            userIndex++;
        }

        userIndex = 50;
        foreach (var user in Users.Skip(50).Take(10))
        {
            var activeSession = new SessionLog
            {
                UserId = user.Id,
                LoginAt = DateTime.UtcNow.AddHours(-2),
                LogoutAt = null,
                IpAddress = $"192.168.1.{(userIndex % 255) + 1}",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)",
                DeviceInfo = "Windows 10",
                IsActive = true
            };

            SessionLogs.Add(activeSession);
            userIndex++;
        }
    }

    private void CreateAuditLogs()
    {
        var actions = new[] { Shared.Enums.AuditAction.Create, Shared.Enums.AuditAction.Update, Shared.Enums.AuditAction.Approve };
        var entityTypes = new[] { "Employee", "SalaryPackage", "ComplaintCase", "WorkSchedule" };

        for (int i = 0; i < 50; i++)
        {
            var user = Users[i % Users.Count];
            var employee = Employees[i % Employees.Count];

            var auditLog = new AuditLog
            {
                ActorUserId = user.Id,
                Action = actions[i % actions.Length],
                EntityType = entityTypes[i % entityTypes.Length],
                EntityId = employee.Id.ToString(),
                DepartmentId = employee.DepartmentId,
                BranchId = employee.BranchId,
                EmployeeId = employee.Id,
                Description = $"{user.Username} performed {actions[i % actions.Length]} on {entityTypes[i % entityTypes.Length]}",
                OldValuesJson = "{}",
                NewValuesJson = "{\"updated\": true}",
                IpAddress = $"192.168.1.{(i % 255) + 1}",
                UserAgent = "Mozilla/5.0"
            };

            AuditLogs.Add(auditLog);
        }
    }
}
