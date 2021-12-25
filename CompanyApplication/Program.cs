using CompanyApplication.Controller;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    class Program
    {
        //public static object employeeController;

        static void Main(string[] args)
        {
            

            Helper.WriteToConsole(ConsoleColor.Magenta,  "Welcome Cavid Bashirov");
            Helper.WriteToConsole(ConsoleColor.Blue, "Please select your options");

            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();


            while (true)
            {
                GetMenus();
                
                

                EnterOption: string selectOption = Console.ReadLine();
                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        //Company cases

                        case(int) MyEnums.Menus.CreateCompany:
                            companyController.Create();
                            break;

                        case (int)MyEnums.Menus.UpdateCompany:
                            companyController.Update();
                            break;

                        case (int)MyEnums.Menus.DeleteCompany:
                            companyController.Delete();
                            break;

                        case(int)MyEnums.Menus.GetCompanyById:
                            companyController.GetById();
                            break;

                        case (int)MyEnums.Menus.GetAllCompanyByName:
                            companyController.GetAllByName();
                            break;
                        case (int)MyEnums.Menus.GetAllCompany:
                            companyController.GetAll();
                            break;

                        //Employee cases

                        case (int)MyEnums.Menus.CreateEmployee:
                            employeeController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateEmployee:
                            employeeController.Update();
                            break;
                        case (int)MyEnums.Menus.DeleteEmployee:
                            employeeController.Delete();
                            break;
                        case (int)MyEnums.Menus.GetEmployeeById:
                            employeeController.GetById();
                            break;
                        case (int)MyEnums.Menus.GetEmployeeByAge:
                            employeeController.GetByAge();
                            break;
                        case (int)MyEnums.Menus.GetAllEmployeeByCompanyId:
                            employeeController.GetAllByCompanyId();
                            break;
                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
            
        }

        private static void GetMenus()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "1-Create Company, 2-Update Company, 3-Delete Company, " +
                "4-Get Company by id, 5-Get all Company by name, 6-Get all Company, 7-Create Employee  8-Update Employee, " +
                "9-Delete Employee, 10-Get Employee By Id, 11-Get Employee by age, 12-Get all Employee by Company id");
        }
    }

    
}
