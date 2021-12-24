using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementation
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity, string companyName)
        {
            try
            {
                if (entity == null) throw new CustomException("Entity is null");

                AppDbContext<Employee>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
        }

        public bool Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
