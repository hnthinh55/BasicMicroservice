using Domain.Entities.UserEntity;
using MediatR;

namespace API.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        
        public CreateUserCommand(string UserName, string UserEmail, string UserPassword)
        {
            this.UserName = UserName;
            this.UserEmail = UserEmail;
            this.UserPassword = UserPassword;
        }
    }
}
