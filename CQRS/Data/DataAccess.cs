using CQRS.Data.Interface;
using CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Data
{
    public class DataAccess : IDataAccess
    {
        private List<EmployeeModel> _employees = new List<EmployeeModel>();

        public DataAccess()
        {
            _employees.Add(new EmployeeModel { Id = 1, FirstName = "Jack" , LastName= "Kirby"});
            _employees.Add(new EmployeeModel { Id = 2, FirstName = "Stan" , LastName="Lee"});
        }


        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {

            employeeModel.Id = _employees.Max(x => x.Id) + 1;
            return employeeModel;
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _employees;
        }
    }
}
