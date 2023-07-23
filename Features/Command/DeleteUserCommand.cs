using MediatR;

namespace UserCrudWithAspDotNetCoreWithAngular.Features.Command
{
    internal class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}