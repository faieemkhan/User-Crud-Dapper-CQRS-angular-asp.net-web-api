using MediatR;
using UserCrudWithAspDotNetCoreWithAngular.Model;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Query
{
    public class GetUserByIdQuery:IRequest<Users>
    {
        public int Id { get; set; }
    }
}
