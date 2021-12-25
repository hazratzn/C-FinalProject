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
        private EmployeeRepository _employeeRepository { get; }
        private CompanyRepository _companyRepository { get; }
        private int count { get; set; }

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }
        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.GetById(m => m.Id == companyId);
                if (company == null) throw new CustomException("Company was not found");
                model.Company = company;
                model.Id = count;
                count++;
                _employeeRepository.Create(model);
                return model;
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(m => m.Id == id);
        }

        public List<Employee> GetByAge(int age)
        {
            return _employeeRepository.GetByAge(m => m.Age == age);
        }

        public List<Employee> GetAllByCompanyId(int companyId)
        {
            return _employeeRepository.GetAllByCompanyId(m => m.Company.Id == companyId);
        }

        public Employee Update(int id, Employee model, Company company)
        {
            var employee = GetById(id);
            model.Company = company;
            model.Id = employee.Id;
            _employeeRepository.Update(model, company);
            return model;
        }
    }
}
