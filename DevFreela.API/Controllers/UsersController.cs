using VisionCar.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VisionCar.Application.Commands.User;
using VisionCar.Application.Queries.QueriesUser;
using VisionCar.Core.Entities;
using VisionCar.Application.Commands._User;

namespace VisionCar.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            command.ativo = true;
            command.data_add = System.DateTime.Now;
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/users/1/login
        [HttpGet("login/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new Application.Queries.QueriesUser.GetUseremailQuery(email);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        //api/users/1/login
        [HttpGet("Empresa/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var query = new Application.Queries.QueriesUser.GetUserEmpresaQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        // api/user/2
        [HttpPut()]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUsersCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // api/user/2
        [HttpPut("/Ativo")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUsersAtivoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // api/user/2
        [HttpPut("/Senha/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUsersSenhaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
