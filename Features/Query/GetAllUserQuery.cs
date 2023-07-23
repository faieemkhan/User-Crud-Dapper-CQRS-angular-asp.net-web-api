using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Model;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Query
{
    public class GetAllUserQuery : IRequest<List<Users>>
    {
    }
}
