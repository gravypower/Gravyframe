﻿using System;
using System.Collections.Generic;
using Gravyframe.Constants;
using Gravyframe.Data.Content;

namespace Gravyframe.Service.Content.Tasks
{
    public class PopulateContentByCategoryIdResponseHydrator : ContentResponseHydrator
    {
        public PopulateContentByCategoryIdResponseHydrator(IContentDao contentDao, IContentConstants contentConstants) : base(contentDao, contentConstants)
        {
        }

        public override void PopulateResponse(ContentRequest request, ContentResponse response)
        {
            response.ContentList = ContentDao.GetContentByCategory(request.CategoryId);         
        }

        public override IEnumerable<string> ValidateResponse(ContentRequest request)
        {
            if (String.IsNullOrEmpty(request.CategoryId))
                return new List<string>
                    {
                        ContentConstants.ContenIdError
                    };

            return new List<string>();
        }
    }
}