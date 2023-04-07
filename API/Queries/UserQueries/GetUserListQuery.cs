using Domain.Entities.UserEntity;
using MediatR;

namespace API.Queries.UserQueries
{
    public class GetUserListQuery : IRequest<List<User>>
    {
    }
}
