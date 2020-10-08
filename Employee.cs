using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Vjezba5
{
    public class Employee
    {
        public Employee()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string JobName { get; set; }
        public string Qualification { get; set; }
        public string PersonQualification { get; set; }
        public string PersonProfession { get; set; }
        public string JobStartDate { get; set; }
        public string JobEndDate { get; set; }
        public string JobPeriodDate { get; set; }
        public string BasicSalary { get; set; }

        public string GetFullName()
        {
            string fullName = FirstName + ", " + LastName;
            return fullName;
        }
        public string GetValuesWithComma()
        {
            return $"{FirstName}, {LastName}, {CompanyName}," +
                    $"{CompanyLocation}, {JobName}, {Qualification}," +
                    $" {PersonQualification}, {PersonProfession}, {JobStartDate}," +
                    $"{JobEndDate}, {JobPeriodDate}, {BasicSalary}";
        }
    }


}
