using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteKernel;
using BusinessObjects;
using DataObjects.EntityFramework.ModelMapper;

namespace DataObjects.EntityFramework.Implementation
{
    public class EntityCommentDao : ICommentDao
    {
        private readonly ICommentDaoMapper<Comment> commentDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCommentDao" /> class.
        /// </summary>
        /// <param name="commentDao">The comment DAO.</param>
        public EntityCommentDao(ICommentDaoMapper<Comment> commentDao)
        {
            Guard.IsNotNull(() => commentDao);
            Guard.IsCorrectType<CommentDaoMapper>(commentDao);
            this.commentDao = commentDao;
        }

        /// <summary>
        /// Gets the article comments.
        /// </summary>
        /// <param name="articleID">The article ID.</param>
        /// <returns></returns>
        public IEnumerable<ArticleComment> GetArticleComments(Guid articleID)
        {
            throw new NotImplementedException();
        }
    }
}
