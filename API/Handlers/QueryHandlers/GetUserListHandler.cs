using API.Queries.UserQueries;
using Domain.Entities.UserEntity;
using Infrastructure.Repositories.UserRepositories;
using MediatR;
using Microsoft.VisualBasic;

namespace API.Handlers.QueryHandlers
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserRepository userRepo;

        public GetUserListHandler(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var list = await userRepo.GetAllAsync();
            return list.ToList();
        }
    }
}
