using System;
using System.Collections.Generic;
using System.Text;

namespace CONSOLEPROJECT
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments
        {
            get
            {
                return _departments;
            }

        }
        private Department[] _departments;

        public HumanResourceManager()
        {
            this._departments = new Department[0];
        }
        public void AddDepartment(string name, int workerlimit, double salarylimit)
        {
            Department newdepartment = new Department(name, workerlimit, salarylimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = newdepartment;


        }

        public Department[] GetDepartments()
        {
            return Departments;
        }

        public bool IsDepartmentExistByName(string name)
        {
            foreach (var item in this.Departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        public double GetSalaryMeanOfDepartment(string name)
        {
            if (IsDepartmentExistByName(name) == true)
            {
                double sum = 0;

                for (int i = 0; i < GetDepartmentByName(name).Employees.Length; i++)
                {
                    sum += GetDepartmentByName(name).Employees[i].Salary;
                }
                return sum / GetDepartmentByName(name).Employees.Length;
            }
            return -1;
        }
        public double GetSalarySumOfDepartment(string name)
        {
            if (IsDepartmentExistByName(name) == true)
            {
                double sum = 0;

                for (int i = 0; i < GetDepartmentByName(name).Employees.Length; i++)
                {
                    sum += GetDepartmentByName(name).Employees[i].Salary;
                }
                return sum;
            }
            return -1;
        }

        public Department GetDepartmentByName(string name)
        {
            foreach (var item in this.Departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
        public void AddEmployee(string fullname, DateTime birthyear, string position, double salary, DateTime startdate, string department)
        {
            Department department1 = GetDepartmentByName(department);
            if (department1 != null)
            {
                Employee newemployee = new Employee(fullname, birthyear, position, salary, startdate, department);
                if (department1.Employees.Length <= department1.WorkerLimit && GetSalarySumOfDepartment(department) < department1.SalaryLimit)
                {
                    Array.Resize(ref department1.Employees, department1.Employees.Length + 1);
                    department1.Employees[department1.Employees.Length - 1] = newemployee;
                }
                else
                {
                    Console.WriteLine("Isci limiti yaxud maas limiti kecildiyi ucun elave edilmedi!");
                }


            }
        }
        public void ShowAllEmployees()
        {
            int i = 0;
            foreach (var item in Departments)
            {
                
                    if (item.Employees.Length > 0 && item.Employees!=null)
                    {
                        Console.WriteLine($"\n ======================= \n{i + 1}. iscinin tam adi: {item.Employees[i].Fullname}\nNomresi: {item.Employees[i].No}\nMovqesi: {item.Employees[i].Position}\nMaasi: {item.Employees[i].Salary}\nDepartamenti: {item.Employees[i].DepartmentName}\nTevelludu: {item.Employees[i].BirthYear.ToString()}\nIse baslama tarixi: {item.Employees[i].StartDate.Year.ToString()} ");
                    }
                
                else
                {
                    Console.WriteLine("Isci yoxdur!");
                }
                i++;
            }
        }
        public bool IsEmployeeExistByDepartmentNameAndNo(string department, string no)
        {
            if (IsDepartmentExistByName(department))
            {
                foreach (Employee item in GetDepartmentByName(department).Employees)
                {
                    if (item.No == no)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public bool IsEmployeeExistByNo(string no)
        {

            foreach (var item in Departments)
            {
                foreach (var employees in item.Employees)
                {
                    if (employees.No == no)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Employee GetEmployeeExistByNo(string no)
        {

            foreach (var item in Departments)
            {
                foreach (var employee in item.Employees)
                {
                    if (employee.No == no)
                    {
                        return employee;
                    }
                }
            }
            return null;
        }

        public void RemoveEmployee(string depname, string employeeNo)
        {
            
                
                Employee[] employees = GetDepartmentByName(depname).Employees;
                employees[Array.IndexOf(employees, GetEmployeeExistByNo(employeeNo))] = null;
                Array.Sort(employees);
                Array.Reverse(employees);
                Array.Resize(ref employees, employees.Length - 1);
                GetDepartmentByName(depname).Employees = employees;
                
                Console.WriteLine("Silindi!");
        }
        public Employee[] GetEmployeesbyDepartment(string name)
        {
            
            return GetDepartmentByName(name).Employees;
        }
    }
}
