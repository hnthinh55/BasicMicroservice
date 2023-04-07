using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.Commands.UserCommand
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public UpdateUserCommand(Guid id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
        }   
    }
}
