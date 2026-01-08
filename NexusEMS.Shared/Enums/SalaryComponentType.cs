using System;
using System.Collections.Generic;
using System.Text;

namespace NexusEMS.Shared.Enums
{
    public enum SalaryComponentType
    {
        // Earnings
        Base = 1,
        HousingAllowance = 2,
        TransportAllowance = 3,
        MealAllowance = 4,
        MedicalAllowance = 5,
        DearnessAllowance = 6,
        Bonus = 10,
        Overtime = 11,
        OtherAllowance = 50,

        // Deductions
        Tax = 100,
        Insurance = 101,
        Pension = 102,
        OtherDeduction = 150
    }
}
