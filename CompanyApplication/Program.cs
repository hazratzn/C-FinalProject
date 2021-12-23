using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.WriteToConsole(ConsoleColor.Magenta,  "Welcome");
            Helper.WriteToConsole(ConsoleColor.Blue, "Select Options");

            CompanyService companyService = new CompanyService();

            while (true)
            {
                Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company , 2 - Update Company , 3 - Delete Company   , " +
                "4 - Get Company by id, 5 - Get all Company  by name,6 - Get all Company, 7 - Create Employee  8 - Update Employee   , " +
                "9 - Get Employee by id, 10 - Delete Employee,11 - Get Employee  by age, 12 - Get all Employee  by Company  id");

                EnterOption: string selectOption = Console.ReadLine();
                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case 1:
                            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name : ");
                            string companyName = Console.ReadLine();
                            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company address name : ");
                            string address = Console.ReadLine();
                            Company company = new Company
                            {
                                Name = companyName,
                                Address = address
                            };
                            var result = companyService.Create(company);
                            if (result != null)
                            {
                                Helper.WriteToConsole(ConsoleColor.Cyan, $"{company.Id} - {company.Name} - {company.Address} company created");
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                                return;
                            }
                                
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
            
        }
    }
}
