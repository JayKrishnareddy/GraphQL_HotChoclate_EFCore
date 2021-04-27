using GraphQL_HotChoclate_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_HotChoclate_EFCore.Services
{
   public interface IEmployeeService
    {
        Task<Employee> Create(Employee employee);
        Task<bool> Delete(DeleteVM deleteVM);
        IQueryable<Employee> GetAll();
    }
}
