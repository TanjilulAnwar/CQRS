using CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Data.Interface
{
    public interface IDataAccess
    {
        List<EmployeeModel> GetEmployees();
        EmployeeModel AddEmployee(EmployeeModel employeeModel);
    }
}
