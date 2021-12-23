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
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                    goto EnterId;
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
    }
}
