using System;
using System.Collections.Generic;
using System.Text;

namespace CONSOLEPROJECT
{
    class Employee
    {
        public string Fullname;
        public DateTime BirthYear;
        private string _position;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length > 2)
                {
                    _position = value;
                }
            }
        }
        private double _salary;
        public double Salary 
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value > 250)
                {
                    _salary = value;
                }
            }
        }
        public DateTime StartDate;
        private static int TotalCount = 1000;
        public string No;
        public string DepartmentName;

        public Employee(string fullname,DateTime birthyear,string position,double salary,DateTime startdate,string department)
        {
            this.Fullname = fullname;
            this.BirthYear = birthyear;
            this.Position = position;
            this.Salary = salary;
            this.StartDate = startdate;
            this.DepartmentName = department;
            TotalCount++;
            this.No = this.DepartmentName.ToUpper().Substring(0, 2) + TotalCount;
            

        }
        
    }
}
