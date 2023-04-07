using MediatR;

namespace API.Commands.UserCommand
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
