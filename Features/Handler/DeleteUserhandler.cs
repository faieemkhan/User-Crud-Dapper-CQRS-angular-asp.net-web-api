using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Features.Command;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Handler
{
    public class DeleteUserhandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserhandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        Task<bool> IRequestHandler<DeleteUserCommand, bool>.Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.DeleteUser(request.Id);
        }
    }
}
