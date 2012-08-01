using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using SC = global::Sitecore;
using Ninject.Web;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using System.Web.UI;
using WebsiteKernel.Sitecore.Extensions;

namespace WebsiteKernel.Sitecore
{
    public class SublayoutBase : UserControlBase
    {
        #region Private Properties
        /// <summary>
        /// private generic dictionary used to expose the SC sublayout params that apply to this usercontrol
        /// </summary>
        private Dictionary<String, String> parameters;

        /// <summary>
        /// private property used to store a pointer to the sublayout control
        /// </summary>
        private SC.Web.UI.WebControls.Sublayout sublayout;
        #endregion Private Properties

        #region Public Properties
        /// <summary>
        /// Gets the SC Sublayout object, the parent of this control
        /// </summary>
        public SC.Web.UI.WebControls.Sublayout Sublayout
        {
            get
            {
                if (sublayout == null)
                {
                    sublayout = this.FindSublayout();
                }

                return sublayout;
            }
            set { sublayout = value; }
        }

        /// <summary>
        /// Gets or sets the SC sublayout parameters that have been assigned to this usercontrol
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<String, String> Parameters
        {
            get
            {
                if (parameters == null)
                {
                    PopulateParametersCollection();
                }
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is a sublayout
        /// </summary>
        /// <value>
        ///   <c>true</c> is a sublayout otherwise, <c>false</c>.
        /// </value>
        public bool ISSublayout
        {
            get
            {
                return Parent.GetType() == typeof(SC.Web.UI.WebControls.Sublayout);
            }
        }


        public string BaseUrl
        {
            get
            {
                if (HttpContext.Current.Items.Contains("BaseUrl"))
                {
                    return (string)HttpContext.Current.Items["BaseUrl"];
                }
                var baseUrl = String.Format("http://{0}{1}", Request.Url.DnsSafeHost, Request.Url.AbsolutePath);

                HttpContext.Current.Items.Add("BaseUrl", baseUrl);

                return baseUrl;
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Gets the media URL.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        protected String GetMediaUrl(Item item, String fieldName)
        {
            //attempt to get the image field if the field has been completed
            if (item != null && !String.IsNullOrEmpty(item[fieldName]))
            {
                ImageField imageField = new ImageField(item.Fields[fieldName]);

                //if we have an image field then return the src of the image
                if (imageField != null && imageField.MediaItem != null)
                {
                    return MediaManager.GetMediaUrl(imageField.MediaItem);
                }
            }

            //the image field wasn't found so return String.Empty
            return String.Empty;
        }

        /// <summary>
        /// Gets the media alt text.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        protected String GetMediaAlt(Item item, String fieldName)
        {
            //attempt to get the image field if the field has been completed
            if (item != null && !String.IsNullOrEmpty(item[fieldName]))
            {
                ImageField imageField = new ImageField(item.Fields[fieldName]);

                //if we have an image field then return the src of the image
                if (imageField != null && imageField.MediaItem != null)
                {
                    return imageField.MediaItem["Alt"];
                }
            }

            //the image field wasn't found so return String.Empty
            return String.Empty;
        }

        /// <summary>
        /// Gets the content of the field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public string GetFieldContent(string field)
        {

            var fieldValue = String.Empty;
            var continueGetFieldContent = true;
            if (field.Equals("Title", StringComparison.InvariantCultureIgnoreCase) && HttpContext.Current.Items.Contains("Title"))
            {
                fieldValue = HttpContext.Current.Items["Title"].ToString();
                continueGetFieldContent = false;
            }

            if (continueGetFieldContent && SC.Context.Item[field] != null)
            {
                fieldValue = SC.Context.Item[field];
            }

            return fieldValue;
        }

        #endregion Protected Methods

        #region Protected Methods
        /// <summary>
        /// Populates the parameters collection. params come in the form name1=val1&name2=val2.....
        /// </summary>
        protected void PopulateParametersCollection()
        {
            //instantiate the parameters dictrionary
            parameters = new Dictionary<String, String>();

            if (Sublayout != null && !String.IsNullOrEmpty(Sublayout.Parameters))
            {
                PopulateParametersCollection(Sublayout.Parameters);
            }
        }

        /// <summary>
        /// Populates the parameters collection.
        /// </summary>
        /// <param name="paramString">The param string.</param>
        protected void PopulateParametersCollection(String paramString)
        {
            //instantiate the parameters dictrionary
            parameters = new Dictionary<String, String>();

            //if we have some params
            if (!String.IsNullOrEmpty(paramString))
            {
                //get the list of parms
                String[] paramList = paramString.Split('&');

                //iterate the list of params and split them into the dictionary
                foreach (String param in paramList)
                {
                    String[] paramValue = param.Split('=');

                    // we get invalid lengths at times
                    if (paramValue.Length > 1)
                    {
                        parameters.Add(paramValue[0].ToLower(), Server.UrlDecode(paramValue[1]));
                    }
                    else
                    {
                        parameters.Add(paramValue[0].ToLower(), string.Empty);
                    }
                }
            }
        }

        protected List<ID> ParseIdListParameter(String paramName)
        {
           return ParseStringListParameter(paramName).ConvertAll<ID>(x => new ID(x));
        }

        protected List<string> ParseStringListParameter(String paramName)
        {
            var returnList = new List<string>();
            if (Parameters.ContainsKey(paramName) && !String.IsNullOrEmpty(Parameters[paramName]))
            {
                returnList = Parameters[paramName].Split('|').ToList();
            }
            return returnList;
        }

        #endregion Protected Methods
    }
}
