using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Aggregates.PostAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodevDone.CQRS.Dal.Configurations
{
    internal class PostCommentConfig : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.HasKey(pc => pc.CommentId);
            // builder.Property(x => x.Id).ValueGeneratedOnAdd();
            // builder.Property(x => x.Comment).IsRequired();
            // builder.Property(x => x.CreatedDate).IsRequired();
            // builder.Property(x => x.CreatedBy).IsRequired();
            // builder.Property(x => x.PostId).IsRequired();
            // builder.Property(x => x.UserProfileId).IsRequired();
        }
    }

}