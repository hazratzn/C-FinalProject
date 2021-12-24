using Domain.Models;
using Repository.Exceptions;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository { get; }
        private CompanyRepository companyRepository { get; }
        private int count { get; set; }

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
            companyRepository = new CompanyRepository();
        }
        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = companyRepository.Get(m => m.Id == companyId);
                if (company == null) throw new CustomException("Company was not found");
                model.Company = company;
                model.Id = count;
                count++;
                employeeRepository.Create(model);
                return model;
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        
    }
}
