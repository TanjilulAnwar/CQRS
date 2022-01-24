using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Application.Employees.Commands;
using CQRS.Application.Employees.Queries;
using CQRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{

    public class EmployeeController : BaseController
    {
       [HttpGet]
       public async Task<List<EmployeeModel>> GetAll()
       {
            return await Mediator.Send(new GetEmployeeListQuery());
       }
        [HttpGet("{id}")]
        public async Task<EmployeeModel> Get(int id)
        {
            return await Mediator.Send(new GetEmployeeByIdQuery(){Id = id});
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertEmployeeCommand command)
        {
            var UpsertedEmployee = await Mediator.Send(command);
            return Ok(UpsertedEmployee);
        }



    }
}