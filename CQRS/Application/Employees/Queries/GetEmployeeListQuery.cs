using CQRS.Data.Interface;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Employees.Queries
{
    public class GetEmployeeListQuery:IRequest<List<EmployeeModel>>
    {


    }

    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
    {

        private readonly IDataAccess _dataAccess;
        public GetEmployeeListHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<List<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetEmployees());
        }
    }


}
