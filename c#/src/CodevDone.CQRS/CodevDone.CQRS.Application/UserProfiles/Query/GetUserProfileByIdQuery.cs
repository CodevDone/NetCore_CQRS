
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;

namespace CodevDone.CQRS.Application.UserProfiles
{
    public class GetUserProfileByIdQuery : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}