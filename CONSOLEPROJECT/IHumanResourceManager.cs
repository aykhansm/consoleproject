using System;
using System.Collections.Generic;
using System.Text;

namespace CONSOLEPROJECT
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; }
        public void AddDepartment(string name, int workerlimit, double salarylimit);
        public Department[] GetDepartments();


    }
}
