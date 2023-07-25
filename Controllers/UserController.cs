using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using UserCrudWithAspDotNetCoreWithAngular.Features.Command;
using UserCrudWithAspDotNetCoreWithAngular.Features.Query;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using UserCrudWithAspDotNetCoreWithAngular.RabitMQ;

namespace UserCrudWithAspDotNetCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRabitMQProducer _rabitMQProducer;
        public UserController(IMediator mediator, IRabitMQProducer rabitMQProducer)
        {
            _mediator = mediator;
            _rabitMQProducer = rabitMQProducer;
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<Users>> GetAllUsers()
        {
            List<Users> users = await _mediator.Send(new GetAllUserQuery());
            _rabitMQProducer.SendUserMessage(users);
            return users;
        }

        [HttpGet]
        [Route("GetUserById/{id:int}")]

        public async Task<Users> GetUserById(int id)
        {
            Users user= await _mediator.Send(new GetUserByIdQuery() { Id = id });
            _rabitMQProducer.SendUserByIdMessage(user);
            return user;
        }



        [HttpPut]
        [Route("UpdateUser/{id:int}")]
        public async Task<bool> UpdateUser(int id,Users users)
        {
            return await _mediator.Send(new UpdateUserCommand() { User=users ,Id = id });
        }
        [HttpDelete]
        [Route("DeleteUser/{id:int}")]

        public async Task<bool> DeleteUser(int id)
        {
            return await _mediator.Send(new DeleteUserCommand()  { Id = id });
        }
    }
}
