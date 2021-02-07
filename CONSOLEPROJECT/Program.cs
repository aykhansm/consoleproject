using System;

namespace CONSOLEPROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager Azercell = new HumanResourceManager();
            bool check = true;
            bool check1 = true;
            bool check2 = true;
            do
            {
                Console.WriteLine("\n==============\n");
                Console.WriteLine("1 - Departamentlere aid emeliyyatlar\n");
                Console.WriteLine("2 - Iscilere aid emeliyyatlar\n");
                Console.WriteLine("3 - Isi sonlandirmaq\n");
                Console.WriteLine("\n==============\n");
                string options = Console.ReadLine();
                options = options.Trim();
                switch (options)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("\n==============\n");
                            Console.WriteLine("1 - Departamentlerin siyahisini gostermek\n");
                            Console.WriteLine("2 - Departamenet yaratmaq\n");
                            Console.WriteLine("3 - Departamanetde deyisiklik etmek\n");
                            Console.WriteLine("4 - Evvelki menyuya qayitmaq\n");
                            string options1 = Console.ReadLine();
                            options1 = options1.Trim();
                            switch (options1)
                            {
                                case "1":
                                    ShowDepartments(ref Azercell);
                                    break;

                                case "2":
                                    AddDepartment(ref Azercell);
                                    break;

                                case "3":
                                    ResetValuesofADepartment(ref Azercell);
                                    break;
                                case "4":
                                    check1 = false;
                                    Console.WriteLine("\n==============\n");
                                    break;


                            }


                        } while (check1);
                        break;
                    case "2":
                        do
                        {
                            Console.WriteLine("\n==============\n");
                            Console.WriteLine("1 - Iscilerin siyahisini gostermek\n");
                            Console.WriteLine("2 - Departamentdeki iscilerin siyahisini gostermrek\n");
                            Console.WriteLine("3 - Isci elave etmek\n");
                            Console.WriteLine("4 - Isci uzerinde deyisiklik etmek\n");
                            Console.WriteLine("5 - Departamentden isci silinmesi\n");
                            Console.WriteLine("6 - Evvelki menyuya qayitmaq");
                            string options2 = Console.ReadLine();
                            options2 = options2.Trim();
                            switch (options2)
                            {
                                case "1":
                                    ShowAllWorkersInfo(ref Azercell);
                                    break;

                                case "2":
                                    ShowWorkersInfoByDepartment(ref Azercell);
                                    break;

                                case "3":
                                    AddEmployeeToADepartment(ref Azercell);
                                    break;

                                case "4":
                                    ResetValuesofAnEmployee(ref Azercell);
                                    break;

                                case "5":
                                    DeleteAnEmployeeFromADepartment(ref Azercell);
                                    break;

                                case "6":
                                    check2 = false;
                                    Console.WriteLine("\n==============\n");
                                    break;
                            }
                        } while (check2);
                        break;
                    
                    case "3":
                        check = false;
                        break;
                }


            } while (check);


        }
            public static void ShowDepartments(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");
                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.WriteLine("Hal-hazirda 1 dene bele olsun departament movcud deyil!");
                    return;
                }
                foreach (var item in humanResourceManager.GetDepartments())
                {
                    if (item.Employees.Length == 0)
                    {
                        Console.WriteLine($"\nDepartment name: {item.Name}\nDepartment worker limit: {item.WorkerLimit}\nDepartment sum of salary limit: {item.SalaryLimit}\nDepartamentde isci yoxdur!");
                    }
                    else
                    {
                        Console.WriteLine($"\nDepartment name: {item.Name}\nWorker count: {item.Employees.Length}\nDepartment worker limit: {item.WorkerLimit}\nDepartment sum of salary limit: {item.SalaryLimit} Worker's average salary: {humanResourceManager.GetSalaryMeanOfDepartment(item.Name)}");
                    }
                }
                Console.WriteLine("\n ======================= \n");

            }

            public static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {
                string depname;
                string workerlimitStr;
                int workerlimit;
                string salarylimitStr;
                double salarylimit;
                Console.WriteLine("\n ======================= \n");
                do
                {
                    Console.Write("Department adi daxil edin: ");
                    depname = Console.ReadLine();
                    if (humanResourceManager.IsDepartmentExistByName(depname) == true)
                    {
                        Console.WriteLine("Bu adda departament artiq movcuddur!");
                    }
                } while (string.IsNullOrWhiteSpace(depname) || humanResourceManager.IsDepartmentExistByName(depname) == true || depname.Length <= 2);

                do
                {
                    Console.Write("Isci limitini daxil edin: ");
                    workerlimitStr = Console.ReadLine();
                } while (!int.TryParse(workerlimitStr, out workerlimit) || workerlimit <= 1);

                do
                {

                    Console.Write("Iscilerin maaslarinin maksimum cemini daxil edin: ");
                    salarylimitStr = Console.ReadLine();
                } while (!double.TryParse(salarylimitStr, out salarylimit));
                humanResourceManager.AddDepartment(depname, workerlimit, salarylimit);
                Console.WriteLine("\n ======================= \n");





            }

            public static void ResetValuesofADepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");
                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.WriteLine("Hal-hazirda 1 dene bele olsun departament movcud deyil ona gore de hec neyi deyise bilmezsiniz!");
                    return;
                }
                Console.Write("Zehmet olmasa deyerlerini yenilemek istediyiniz departmentin adini daxil edin: ");
                string depname = Console.ReadLine();
                string newdepname;
                string newworkerlimitStr;
                int newworkerlimit;
                string newsalarylimitStr;
                double newsalarylimit;

                if (humanResourceManager.IsDepartmentExistByName(depname))
                {

                    do
                    {
                        Console.Write("Yeni adi daxil edin: ");
                        newdepname = Console.ReadLine();
                        if (humanResourceManager.IsDepartmentExistByName(newdepname))
                        {
                            Console.WriteLine("Bu adda department artiq movcuddur!");
                        }
                    } while (string.IsNullOrWhiteSpace(newdepname) || humanResourceManager.IsDepartmentExistByName(newdepname) || newdepname.Length < 2);

                    do
                    {
                        Console.Write("Yeni isci limitini teyin edin: ");
                        newworkerlimitStr = Console.ReadLine();
                        newworkerlimitStr = newworkerlimitStr.Trim();

                    } while (!int.TryParse(newworkerlimitStr, out newworkerlimit) || newworkerlimit < 1);

                    do
                    {
                        Console.Write("Iscilerin maaslarinin yeni maksimum cemini daxil edin: ");
                        newsalarylimitStr = Console.ReadLine();
                        newsalarylimitStr = newsalarylimitStr.Trim();

                    } while (!double.TryParse(newsalarylimitStr, out newsalarylimit));

                    {
                        Department editeddepartment = humanResourceManager.GetDepartmentByName(depname);
                        editeddepartment.Name = newdepname;
                        editeddepartment.WorkerLimit = newworkerlimit;
                        editeddepartment.SalaryLimit = newsalarylimit;
                        Console.WriteLine("Deyisdirildi!");
                    }


                }
                else
                {
                    Console.WriteLine("Bu adda department movcud deyil!");
                }

                Console.WriteLine("\n ======================= \n");


            }

            public static void ShowAllWorkersInfo(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");
                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.WriteLine("Hal-hazirda 1 dene bele olsun departament movcud deyil ona gore de isci siyahisini gore bilmezsiniz!");
                    return;
                }
                humanResourceManager.ShowAllEmployees();
                Console.WriteLine("\n ======================= \n");
            }

            public static void ShowWorkersInfoByDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");
                if (humanResourceManager.Departments.Length == 0)
                {
                    Console.WriteLine("Hal-hazirda 1 dene bele olsun departament movcud deyil ona gore de departamente gore isci siyahisini gore bilmezsiniz!");
                    return;
                }
                Console.Write("Iscilerin siyahisini gormek istediyiniz departamentin adini daxil edin: ");
                string depname = Console.ReadLine();
                depname = depname.Trim();

                if (humanResourceManager.IsDepartmentExistByName(depname))
                {
                    if (humanResourceManager.GetEmployeesbyDepartment(depname).Length == 0)
                    {
                        Console.WriteLine("Bu departamentde isci yoxdur!");
                        return;
                    }

                    int i = 0;
                    foreach (var item in humanResourceManager.GetDepartmentByName(depname).Employees)
                    {
                        Console.WriteLine($"\n ======================= \n{i + 1}. iscinin tam adi: {item.Fullname}\nNomresi: {item.No}\nMovqesi: {item.Position}\nMaasi: {item.Salary}\nDepartamenti: {item.DepartmentName}\nTevelludu: {item.BirthYear.ToString()}\nIse baslama tarixi: {item.StartDate.Year.ToString()} ");
                    }
                }
                else
                {
                    Console.WriteLine("Bu adda department yoxdur!");
                }
                Console.WriteLine("\n ======================= \n");

            }

            public static void AddEmployeeToADepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");

                Console.Write("Iscini elave edeceyiniz departamenti secin: ");
                string department = Console.ReadLine();
                department = department.Trim();
                string fullname;
                string birthDateStr;
                DateTime birthDate;
                string position;
                string salaryStr;
                double salary;

                if (humanResourceManager.IsDepartmentExistByName(department))
                {
                    if (humanResourceManager.GetDepartmentByName(department).Employees.Length == humanResourceManager.GetDepartmentByName(department).WorkerLimit)
                    {
                        Console.WriteLine("Departamentin isci limiti dolub!");
                        return;
                    }
                    else
                    {
                        do
                        {
                            Console.Write("Iscinin tam adini daxil edin: ");
                            fullname = Console.ReadLine();
                            fullname = fullname.Trim();
                            if (fullname.Split(' ').Length == 2)
                            {
                                fullname = fullname.Split(' ')[0].ToUpper().Substring(0, 1) + fullname.Split(' ')[0].ToLower().Substring(1) + ' ' + fullname.Split(' ')[1].ToUpper().Substring(0, 1) + fullname.Split(' ')[1].ToLower().Substring(1);
                            }
                        } while (string.IsNullOrWhiteSpace(fullname) || fullname.Split(' ').Length != 2);

                        do
                        {
                            Console.WriteLine("Iscinin dogum ilini,ayini ve gununu daxil edin(yyyy/mm/dd): ");
                            birthDateStr = Console.ReadLine();
                            birthDateStr = birthDateStr.Trim();
                            if (!DateTime.TryParse(birthDateStr, out birthDate))
                            {
                                Console.WriteLine("Tarixi dogru daxil edin!");
                            }

                        } while (!DateTime.TryParse(birthDateStr, out birthDate));

                        do
                        {
                            Console.Write("Iscinin departamentdeki movqesini teyin edin: ");
                            position = Console.ReadLine();
                            position = position.Trim();
                            if (position.Length <= 2)
                            {
                                Console.WriteLine("Movqe adinin uzunlugu 2 ve daha kicik ola bilmez!");
                            }
                        } while (position.Length <= 2);

                        do
                        {
                            Console.Write("Iscinin maasini teyin edin: ");
                            salaryStr = Console.ReadLine();
                            salaryStr = salaryStr.Trim();
                            if (double.TryParse(salaryStr, out salary) && salary < 250)
                            {
                                Console.WriteLine("Iscinin maasi 250 ve daha az ola bilmez!");
                            }
                            else if (!double.TryParse(salaryStr, out salary))
                            {
                                Console.WriteLine("Maasi ededle ifade edin!");
                            }
                        } while (!double.TryParse(salaryStr, out salary) || salary < 250);




                        humanResourceManager.AddEmployee(fullname, birthDate, position, salary, DateTime.Now, department);


                    }
                }
                else
                {
                    Console.WriteLine("Bele bir departament movcud deyil!");
                }
                Console.WriteLine("\n ======================= \n");

            }

            public static void ResetValuesofAnEmployee(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("\n ======================= \n");
                Console.Write("Deyerlerini yenilemek istediyiniz iscinin nomresini daxil edin: ");

                string employeeNo = Console.ReadLine();
                employeeNo = employeeNo.Trim();
                employeeNo = employeeNo.ToUpper();
                string newposition;
                string newsalaryStr;
                double newsalary;
                if (humanResourceManager.IsEmployeeExistByNo(employeeNo))
                {
                    Employee ouremployee = humanResourceManager.GetEmployeeExistByNo(employeeNo);
                    Console.WriteLine("Iscinin hazirki melumatlari:\n");
                    Console.WriteLine($"Adi: {ouremployee.Fullname}\nMaasi: {ouremployee.Salary}\nMovqesi: {ouremployee.Position}\nDepartamenti: {ouremployee.DepartmentName}");
                    do
                    {
                        Console.Write("Iscinin yeni movqesini teyin edin: ");
                        newposition = Console.ReadLine();
                        newposition = newposition.Trim();
                        if (newposition == ouremployee.Position)
                        {
                            Console.WriteLine("Iscinin hazirki vezifesi ele budur!");
                            return;
                        }
                        if (newposition.Length <= 2)
                        {
                            Console.WriteLine("Iscinin movqesi 2 herfden boyuk olmalidir!");
                        }
                    } while (newposition.Length <= 2);
                    do
                    {
                        Console.Write("Iscinin yeni maasini teyin edin: ");
                        newsalaryStr = Console.ReadLine();
                        newsalaryStr = newsalaryStr.Trim();
                        if (double.TryParse(newsalaryStr, out newsalary) && newsalary == ouremployee.Salary)
                        {
                            Console.WriteLine("Iscinin hazirki maasi ele budur!");
                            return;
                        }
                        if (double.TryParse(newsalaryStr, out newsalary) && newsalary < 250)
                        {
                            Console.WriteLine("Iscinin maasi 250 ve daha az ola bilmez!");
                        }
                        else if (!double.TryParse(newsalaryStr, out newsalary))
                        {
                            Console.WriteLine("Maasi ededle ifade edin!");
                        }

                    } while (!double.TryParse(newsalaryStr, out newsalary) || newsalary < 250);
                    ouremployee.Position = newposition;
                    ouremployee.Salary = newsalary;
                    Console.WriteLine("Deyisdirildi!");
                }
                else
                {
                    Console.WriteLine("Bu nomreli bir isci movcud deyil!");
                }
                Console.WriteLine("\n ======================= \n");
            }

            public static void DeleteAnEmployeeFromADepartment(ref HumanResourceManager humanResourceManager)
            {
                string depname;
                string employeeNo;

                Console.WriteLine("\n ======================= \n");
                Console.Write("Silmek istediyiniz iscinin departmentinin adini daxil edin: ");
                depname = Console.ReadLine();
                depname = depname.Trim();
                if (!humanResourceManager.IsDepartmentExistByName(depname))
                {
                    Console.WriteLine("Bele bir departament movcud deyil!");
                    return;
                }
                Console.Write("Silmek istediyiniz iscinin nomresini daxil edin: ");
                employeeNo = Console.ReadLine();
                employeeNo = employeeNo.Trim();
                employeeNo = employeeNo.ToUpper();
                if (humanResourceManager.IsEmployeeExistByDepartmentNameAndNo(depname, employeeNo))
                {
                    humanResourceManager.RemoveEmployee(depname, employeeNo);


                }
                else
                {
                    Console.WriteLine("Bele bir  isci movcud deyil!");
                }
                Console.WriteLine("\n ======================= \n");


        }
        
    }
}

