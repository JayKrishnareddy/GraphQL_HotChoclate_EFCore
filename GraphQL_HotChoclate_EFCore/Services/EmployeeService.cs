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
        public async Task<bool> Delete(DeleteVM deleteVM)
        {
            var employee = await  _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == deleteVM.Id);
            if(employee is not null) 
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public IQueryable<Employee> GetAll()
        {
            return _dbContext.Employees.AsQueryable();
        }
    }

    public class DeleteVM
    {
        public int Id { get; set; }
    }
}
