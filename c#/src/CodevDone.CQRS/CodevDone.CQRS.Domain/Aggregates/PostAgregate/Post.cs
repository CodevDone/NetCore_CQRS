using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Domain.Aggregates.UserProfileAgregate;
using CodevDone.CQRS.Domain.Exceptions;
using CodevDone.CQRS.Domain.Validators.PostValidator;

namespace CodevDone.CQRS.Domain.Aggregates.PostAgregate
{
    public class Post
    {
        private readonly List<PostComment> _comment = new List<PostComment>();
        private readonly List<PostInteraction> _interactions = new List<PostInteraction>();
        private Post()
        {

        }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile profile { get; private set; }
        public string TextContent { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public IEnumerable<PostComment> Comments { get { return _comment; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }
        //Factories
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            PostValidator validator = new PostValidator();

            var post = new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
            var validatorResult = validator.Validate(post);

            if (!validatorResult.IsValid)
            {
                var exception = new PostNotValidException("The post is not valid");
                foreach (var ex in validatorResult.Errors)
                {
                    exception.ValidationErrors.Add(ex.ErrorMessage);
                }

                throw exception;
            }
            return post;

        }

        //public method
        /// <summary>
        /// Update the post text
        /// </summary>
        /// <param name="newText"> the updated post text</param>
        /// <exception cref="PostNotValidException">Thrown when the post is not valid</exception>
        public void UpdatePostText(string newText)
        {
            // valid input
            if (string.IsNullOrWhiteSpace(newText))
            {
                var exception = new PostNotValidException("Can not update post with empty text");
                throw exception;
            }

            TextContent = newText;
            LastModified = DateTime.UtcNow;
        }
        public void AddPostComment(PostComment newComment)
        {
            _comment.Add(newComment);
        }

        public void Remuvecomment(PostComment toRemove)
        {
            _comment.Remove(toRemove);
        }
        public void AddInteraction(PostInteraction newInteraction)
        {
            _interactions.Add(newInteraction);
        }

        public void RemoveInteraction(PostInteraction toRemove)
        {
            _interactions.Remove(toRemove);
        }

    }
}