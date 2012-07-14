﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using SitecoreClient.Repositories;
using Service.DataTransferObjects;

namespace SitecoreClient.Layouts.sublayouts
{
    public partial class Articles : Ninject.Web.Sitecore.UserControlBase
    {
        [Inject]
        public IArticleRepository ArticleRepository { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            rptArticles.DataSource = ArticleRepository.GetArticles();
            rptArticles.DataBind();
        }

        protected void RptArticlesItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var article = (ArticleDto)e.Item.DataItem;
                var hypArticle = (HyperLink)e.Item.FindControl("hypArticle");
                hypArticle.Text = article.Title;
            }
        }
    }
}