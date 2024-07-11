using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Exceptions;
using CodevDone.CQRS.Domain.Validators.PostValidator;

namespace CodevDone.CQRS.Domain.Aggregates.PostAgregate
{
    public class PostComment
    {
        private PostComment()
        {

        }
        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }
        // Factories
        /// <summary>
        ///  Creates a post comment
        /// </summary>
        /// <param name="postId">The ID of the post to which the comment belong</param>
        /// <param name="text"> Text content of the comment</param>
        /// <param name="userProfile">The ID of the user who created </param>
        /// <returns><see cref="PostComment"/> </returns>
        /// <exception cref="PostCommentNotValidException">Thrown when the comment is not valid</exception>
        public static PostComment CreatePostComment(Guid postId, string text, Guid userProfile)
        {
            // TODO: add validation
            PostCommentValidator validator = new PostCommentValidator();

            var postComment = new PostComment
            {
                PostId = postId,
                Text = text,
                UserProfileId = userProfile,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };

            var validatorResult = validator.Validate(postComment);

            if (!validatorResult.IsValid)
            {
                var exception = new PostCommentNotValidException("The post comment is not valid");
                foreach (var ex in validatorResult.Errors)
                {
                    exception.ValidationErrors.Add(ex.ErrorMessage);
                }

                throw exception;
            }

            return postComment;

        }

        //public method

        public void UpdateCommentText(string newText)
        {
            Text = newText;
            LastModified = DateTime.UtcNow;
        }
    }
}