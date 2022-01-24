using CQRS.Data.Interface;
using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Employees.Commands
{
    public class UpsertEmployeeCommand: EmployeeModel, IRequest<EmployeeModel>
    {

    }

    public class UpsertEmployeeHandler : IRequestHandler<UpsertEmployeeCommand, EmployeeModel>
    {
        private readonly IDataAccess _dataAccess;

        public UpsertEmployeeHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<EmployeeModel> Handle(UpsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != 0)
            {

            }
            return await Task.FromResult(_dataAccess.AddEmployee(request));
        }
    }
}
