using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Features.Query;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using UserCrudWithAspDotNetCoreWithAngular.Repository;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Users>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Users> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserById(request.Id);
        }
    }
}
