using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Model;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Command
{
    internal class CreateUserCommand : IRequest<bool>
    {
        public Users? User { get; set; }
    }
}