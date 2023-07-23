using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Controllers;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Handler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
         Task<bool> IRequestHandler<UpdateUserCommand, bool>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return  _userRepository.UpdateUser(request.User,request.Id);
        }
    }
}
