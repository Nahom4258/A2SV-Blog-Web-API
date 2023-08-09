using A2SV___Blog_CRUD.Models;

namespace A2SV___Blog_CRUD
{
    public class CommentManager
    {
        private readonly AppDbContext DbContext;

        public CommentManager(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddCommentToPost(int postId, string comment)
        {
            var post = DbContext.Posts.Find(postId);

            if (post != null)
            {
                var newComment = new Comment
                {
                    Text = comment,
                    CreatedAt = DateTime.Now
                };

                post.Comments.Add(newComment);
                DbContext.SaveChanges();
            }
        }

        public void UpdateCommentOnPost(int postId, int commentId, string comment)
        {
            var post = DbContext.Posts.Find(postId);

            if (post != null)
            {
                var commentToUpdate = post.Comments.FirstOrDefault(c => c.Id == commentId);

                if (commentToUpdate != null)
                {
                    commentToUpdate.Text = comment;
                    DbContext.SaveChanges();
                }
            }
        }

        public void DeleteCommentFromPost(int postId, int commentId)
        {
            var post = DbContext.Posts.Find(postId);

            if (post != null)
            {
                var commentToDelete = post.Comments.FirstOrDefault(c => c.Id == commentId);

                if (commentToDelete != null)
                {
                    post.Comments.Remove(commentToDelete);
                    DbContext.SaveChanges();
                }
            }
        }
    }
}