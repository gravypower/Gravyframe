using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Mapping;
using WebsiteKernel;

namespace DataObjects.EntityFramework.ModelMapper
{
    internal abstract class CommentDaoMapper : ICommentDaoMapper<Comment>
    {
        protected readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentDaoMapper" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        protected CommentDaoMapper(IMapper mapper)
        {
            Guard.IsNotNull(() => mapper);
            this.mapper = mapper;
        }

        public abstract BusinessObjects.ArticleComment Map(Comment entity);

        public abstract Comment Map(BusinessObjects.ArticleComment articleComment);
    }
}
