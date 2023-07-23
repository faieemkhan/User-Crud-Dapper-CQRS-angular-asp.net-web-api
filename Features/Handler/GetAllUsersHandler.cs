using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Features.Query;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Handler
{

    public class GetAllUsersHandler : IRequestHandler<GetAllUserQuery, List<Users>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<List<Users>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAllUsersAsync();
        }
    }
}
