using Domain.Entities.UserEntity;
using MediatR;

namespace API.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
