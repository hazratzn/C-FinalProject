using Domain.Models;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class EmployeeController
    {
        private EmployeeService _employeeServise { get; }
        private CompanyService _companyServise { get; }

        

        public EmployeeController()
        {
            _employeeServise = new EmployeeService();
            _companyServise = new CompanyService();

        }
        public void Create()
        {
        EnterOption:
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Name: ");
            string employeeName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Surname: ");
            string employeeSurname = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Age: ");
            string Age = Console.ReadLine();
            int employeeAge;
            bool isTrueAge = int.TryParse(Age, out employeeAge);
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            string Id = Console.ReadLine();
            int companyId;
            bool isTrueId = int.TryParse(Id, out companyId);
            if (isTrueAge && isTrueId)
            {
                if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(employeeSurname))
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Try again");
                    goto EnterOption;
                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name = employeeName,
                        Surname = employeeSurname,
                        Age = employeeAge,

                    };
                    var createResult = _employeeServise.Create(employee, companyId);
                    if (createResult != null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Surname} employee in {employee.Company.Name} created");
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                        goto EnterOption;
                    }
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again");
                goto EnterOption;
            }
        }

        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Id: ");
            EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee1 = _employeeServise.GetById(id);

                if (employee1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{employee1.Id} - {employee1.Name} - {employee1.Surname} works in {employee1.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }






        }

        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Id: ");
            EnterId: string employeeId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee1 = _employeeServise.GetById(id);
                if(employee1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    _employeeServise.Delete(employee1);
                    Helper.WriteToConsole(ConsoleColor.Green, "Employee is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }

        }
        public void GetByAge()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Age: ");
            EnterAge: string employeeAge = Console.ReadLine();

            int age;
            bool isTrueAge = int.TryParse(employeeAge, out age);
            if (isTrueAge)
            {
                var employeeAges = _employeeServise.GetByAge(age);

                foreach (var item in employeeAges)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Surname} works in {item.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try age again");
                goto EnterAge;
            }
        }
        public void GetAllByCompanyId()
        {
            EnterCompanyId:
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);

            if (isTrueId)
            {
                var companysId = _employeeServise.GetAllByCompanyId(id);

                foreach (var item in companysId)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Surname}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try id again");
                goto EnterCompanyId;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Id: ");
            EnterId: string employeeId = Console.ReadLine();
            
            Helper.WriteToConsole(ConsoleColor.Blue, "Add new Employee Name: ");
            EnterName: string newName = Console.ReadLine();
            
            Helper.WriteToConsole(ConsoleColor.Blue, "Add new Employee Surname: ");
            string newSurname = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Blue, "Add new Employee Age: ");
            string newAge = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            string newCompanyId = Console.ReadLine();

            int companyId;
            int id;
            int age;

            bool isIdTrue = int.TryParse(employeeId, out id);
            bool isAgeTrue = int.TryParse(newAge, out age);
            bool isCompanyIdTrue = int.TryParse(newCompanyId, out companyId);

            if (isIdTrue && isAgeTrue && isCompanyIdTrue)
            {
                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newSurname))
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Try Name and Address again");
                    goto EnterName;
                }
                else
                {
                    var newCompany = _companyServise.GetById(companyId);

                    if (newCompany == null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company not found, try id again");
                        goto EnterId;
                    }
                    else
                    {
                        Employee employee = new Employee
                        {
                            Name = newName,
                            Surname = newSurname,
                            Age = age,
                            Company = newCompany,

                        };
                        var newEmployee = _employeeServise.Update(id, employee, newCompany);

                        Helper.WriteToConsole(ConsoleColor.Green, $"{newEmployee.Id} - {newEmployee.Name} - {newEmployee.Surname} works in {newEmployee.Company.Name} updated");
                    }
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }
        }
    }
}
