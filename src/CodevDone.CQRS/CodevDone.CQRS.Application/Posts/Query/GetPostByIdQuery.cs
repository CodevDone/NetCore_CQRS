
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using MediatR;

namespace CodevDone.CQRS.Application.Posts.Query
{
    public class GetPostByIdQuery : IRequest<OperationResult<Post>>
    {
        public Guid PostId { get; set; }
    }



}