using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Features.Command;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        Task<bool> IRequestHandler<CreateUserCommand, bool>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.CreateUser(request.User));
        }
    }
}
