using API.Extensions;
using API.Queries.UserQueries;
using Domain.DTO;
using Domain.Entities.UserEntity;
using Domain.Interfaces;
using Infrastructure.Repositories.UserRepositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IMediator mediator;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.mediator = mediator;
        }
        public async Task<bool> AddUser(UserViewModel userVm)
        {
            var hash = new HashPassword();
            var user = userRepository.NewUser(userVm.UserName, userVm.Email, hash.HashMD5(userVm.Password));

            var saved = await unitOfWork.CommitAsync();
            return saved > 0;
        }        
        public async Task<IEnumerable<User>> GetUsers()
        {
            var user = await mediator.Send(new GetUserListQuery());
            return user;
        }
    }
}
