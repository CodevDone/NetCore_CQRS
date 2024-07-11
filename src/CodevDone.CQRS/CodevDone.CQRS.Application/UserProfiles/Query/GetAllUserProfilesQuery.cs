
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using MediatR;

namespace CodevDone.CQRS.Application.UserProfiles
{
    public class GetAllUserProfilesQuery : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {

    }
}