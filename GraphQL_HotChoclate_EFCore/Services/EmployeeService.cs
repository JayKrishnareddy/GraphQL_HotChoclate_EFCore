using GraphQL_HotChoclate_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_HotChoclate_EFCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Property
        private readonly DatabaseContext _dbContext;
        #endregion

        #region Constructor
        public EmployeeService(DatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
        }
        #endregion

        public async Task<Employee> Create(Employee employee)
        {
            var data = new Employee
            {
                Name = employee.Name,
                Designation = employee.Designation
            };
            await _dbContext.Employees.AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }
        public bool Delete(int Id)
        {
            var employee =  _dbContext.Employees.FirstOrDefault(c => c.Id == Id);
            if(employee is not null) 
            {
                _dbContext.Employees.Remove(employee);
                return true;
            }
            return false;
        }
        public IQueryable<Employee> GetAll()
        {
            return _dbContext.Employees.AsQueryable();
        }
    }
}
