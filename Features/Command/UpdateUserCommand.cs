using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Model;

namespace UserCrudWithAspDotNetCoreWithAngular.Controllers
{
    internal class UpdateUserCommand : IRequest<bool>
    {
        public Users? User { get; set; }
        public int Id { get; set; }
    }
}