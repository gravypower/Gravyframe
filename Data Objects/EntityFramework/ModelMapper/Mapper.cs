using System;
using System.Linq;
using WebsiteKernel.Mapping;
using BusinessObjects;
using DataObjects.EntityFramework;

namespace DataObjects.EntityFramework.ModelMapper
{
    internal class Mapper : CommentDaoMapper, ICommentDaoMapper<Comment>
    {
                
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentDaoMapper" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public Mapper(IMapper mapper)
            : base(mapper)
        {
        }

        /// <summary>
        /// Maps Comment to ArticleComment
        /// </summary>
        /// <param name="entity">Comment entity form entity framework</param>
        /// <returns>the mapped ArticleComment</returns>
        public override ArticleComment Map(Comment entity)
        {
            return mapper.Map<Comment, ArticleComment>(entity);
        }

        /// <summary>
        /// Maps ArticleComment to Comment
        /// </summary>
        /// <param name="articleComment">ArticleComment business object </param>
        /// <returns></returns>
        public override Comment Map(ArticleComment articleComment)
        {
            return mapper.Map<ArticleComment, Comment>(articleComment);
        }
    }
}
