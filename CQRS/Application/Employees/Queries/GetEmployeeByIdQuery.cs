using CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Employees.Queries
{
    public class GetEmployeeByIdQuery:IRequest<EmployeeModel>
    {
        public int Id { get; set; }

    }


    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery ,EmployeeModel>
    {
        private readonly IMediator _mediator;
        public GetEmployeeByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employees = await _mediator.Send(new GetEmployeeListQuery());
            var requestedEmployee = employees.FirstOrDefault(x => x.Id == request.Id);

            if (requestedEmployee == null) return new EmployeeModel();

            return requestedEmployee;
        }
    }
}
