using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Application.Models;
using CodevDone.CQRS.Dal;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodevDone.CQRS.Application.Posts.Query
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, OperationResult<IEnumerable<Post>>>
    {
        private readonly DataContext _ctx;

        public GetAllPostsQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<IEnumerable<Post>>> Handle(GetAllPostsQuery request,
        CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<Post>>();
            try
            {
                result.Payload = await _ctx.Post.ToListAsync();
            }
            catch (System.Exception ex)
            {
                result.IsError = true;
                result.Errors.Add(new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"{ex.Message}"
                });
            }


            return result;
        }
    }
}