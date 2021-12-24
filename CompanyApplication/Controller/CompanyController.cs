using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controller
{
    public class CompanyController
    {
        private CompanyService _companyservice { get; }
        public CompanyController()
        {
            _companyservice = new CompanyService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name : ");
            string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company address name : ");
            string address = Console.ReadLine();
            Company company = new Company
            {
                Name = companyName,
                Address = address
            };
            var result = _companyservice.Create(company);
            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Cyan, $"{company.Id} - {company.Name} - {company.Address} company created");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                return;
            }
        }

        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company id : ");
            EnterId: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var companydata = _companyservice.GetById(id);

                if (companydata == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Add company id ");
                    
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{companydata.Id } - {companydata.Name} - {companydata.Address}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again id");
                goto EnterId;
            }
        }

        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Not found Company : ");
            EnterId: string companyId = Console.ReadLine();
            
            int id; 

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var companydata = _companyservice.GetById(id);

                if (companydata == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, " Company not found ");
                    goto EnterId;
                }
                else
                {
                    _companyservice.Delete(companydata);
                    Helper.WriteToConsole(ConsoleColor.Red, "Company deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again id");
                goto EnterId;
            }
        }

        public void GetAll()
        {
            var companies = _companyservice.GetAll();

            foreach (var item in companies)
            {

                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id } - {item.Name} - {item.Address}");
            }
        }

        public void GetAllByName()
        {

            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Name: ");
            EnterCompanyName:
            string companyName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(companyName))
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try Company Name again");
                goto EnterCompanyName;
            }
            else
            {
                var companyNames = _companyservice.GetAll();
                foreach (var item in companyNames)
                {
                    if (item.Name != companyName)
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company not found try again");
                        goto EnterCompanyName;
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Address}");

                    }
                
                }



            }

        }


        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company id : ");
            EnterId: string companyId = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name : ");
            EnterName: string newName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company address name : ");
            string newAddress = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newAddress))
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Try Name and Address again");
                    goto EnterName;
                }
                else
                {
                    Company company = new Company
                    {
                        Name = newName,
                        Address = newAddress,
                    };
                    var newCompany = _companyservice.Update(id, company);
                    Helper.WriteToConsole(ConsoleColor.Green, $"{newCompany.Id} - {newCompany.Name} - {newCompany.Address}");
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
