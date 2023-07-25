using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCrudWithAspDotNetCoreWithAngular.Features.Command;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> CreateUser(Users users)
        {
            bool res = await _mediator.Send(new CreateUserCommand() { User = users });
            if (res)
            {
                
            }

            return res;
        }
        //[HttpGet]
        //public async Task<bool> LoginUser(Users users)
        //{
        //    return await mediator.Send(new LoginUserCommand() { User = users });
        //}

    }
}
