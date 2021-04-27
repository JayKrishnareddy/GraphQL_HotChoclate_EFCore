using GraphQL_HotChoclate_EFCore.Models;
using GraphQL_HotChoclate_EFCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.GraphQL
{
    public class Query
    {
        #region Property
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public Query(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        public IQueryable<Employee> Employees => _employeeService.GetAll();
        public async Task<Employee> Create(Employee employee) => await _employeeService.Create(employee);
        public async Task<bool> Delete(DeleteVM deleteVM) => await _employeeService.Delete(deleteVM);
    }
}
