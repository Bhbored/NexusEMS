using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;

namespace NexusEMS.Web.Services
{
    public class SalaryCalculationService
    {

        public SalaryPackage CalculateAutoSalaryPackage(Employee employee, SalaryConfiguration config, Guid createdByUserId)
        {
            var baseSalary = CalculateBaseSalary(employee, config);
            var houseRent = (baseSalary * config.HraPercentage) / 100;
            var dearnessAllowance = (baseSalary * config.DaPercentage) / 100;
            var grossSalary = baseSalary + houseRent + dearnessAllowance + config.ConveyanceAllowance + config.MedicalAllowance;

            var salaryPackage = new SalaryPackage
            {
                EmployeeProfileId = employee.Id,
                EffectiveFrom = DateOnly.FromDateTime(DateTime.Now),
                CalculationMode = SalaryCalculationMode.Auto,
                CreatedByUserId = createdByUserId,
                Notes = $"Auto-generated salary package based on {config.Name}",
                Components = new List<SalaryComponent>()
            };

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.Base,
                Amount = baseSalary,
                IsDeduction = false,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.HousingAllowance,
                Amount = houseRent,
                IsDeduction = false,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.DearnessAllowance,
                Amount = dearnessAllowance,
                IsDeduction = false,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.TransportAllowance,
                Amount = config.ConveyanceAllowance,
                IsDeduction = false,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.MedicalAllowance,
                Amount = config.MedicalAllowance,
                IsDeduction = false,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.Tax,
                Amount = CalculateIncomeTax(grossSalary),
                IsDeduction = true,
                Source = SalaryComponentSource.AutoRule
            });

            salaryPackage.Components.Add(new SalaryComponent
            {
                Type = SalaryComponentType.Pension,
                Amount = (baseSalary * 12) / 100,
                IsDeduction = true,
                Source = SalaryComponentSource.AutoRule
            });

            return salaryPackage;
        }

        public decimal CalculateBaseSalary(Employee employee, SalaryConfiguration config)
        {
            decimal baseSalary = config.BaseSalary;

            baseSalary = ApplyEducationMultiplier(baseSalary, employee.EducationLevel, config);

            if (employee.IsMarried)
            {
                baseSalary *= config.MarriedMultiplier;
            }

            if (employee.NumberOfChildren > 0)
            {
                baseSalary *= (1 + (config.ChildMultiplier * employee.NumberOfChildren));
            }

            var yearsOfService = (DateTime.Now - employee.HireDate).Days / 365;
            var completedTwoYearPeriods = yearsOfService / 2;

            if (completedTwoYearPeriods > 0)
            {
                baseSalary += (baseSalary * config.TwoYearIncrementPercentage / 100) * completedTwoYearPeriods;
            }

            return baseSalary;
        }

        private decimal ApplyEducationMultiplier(decimal baseSalary, EducationLevel educationLevel, SalaryConfiguration config)
        {
            return educationLevel switch
            {
                EducationLevel.PostGraduate => baseSalary * config.PostGraduateMultiplier,
                EducationLevel.PhD => baseSalary * config.PhdMultiplier,
                _ => baseSalary
            };
        }

        private decimal CalculateIncomeTax(decimal grossSalary)
        {
            var annualGross = grossSalary * 12;
            if (annualGross <= 250000) return 0;
            if (annualGross <= 500000) return (annualGross - 250000) * 0.05m / 12;
            if (annualGross <= 1000000) return (12500 + (annualGross - 500000) * 0.20m) / 12;
            return (12500 + 100000 + (annualGross - 1000000) * 0.30m) / 12;
        }

        public decimal CalculateGrossSalary(SalaryPackage package)
        {
            return package.Components
                .Where(c => !c.IsDeduction)
                .Sum(c => c.Amount);
        }

        public decimal CalculateTotalDeductions(SalaryPackage package)
        {
            return package.Components
                .Where(c => c.IsDeduction)
                .Sum(c => c.Amount);
        }

        public decimal CalculateNetSalary(SalaryPackage package)
        {
            return CalculateGrossSalary(package) - CalculateTotalDeductions(package);
        }
    }
}
