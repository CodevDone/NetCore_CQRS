using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using MediatR;

namespace CodevDone.CQRS.Application.Posts.Query
{
    public class GetAllPostsQuery : IRequest<OperationResult<IEnumerable<Post>>>
    {

    }
}