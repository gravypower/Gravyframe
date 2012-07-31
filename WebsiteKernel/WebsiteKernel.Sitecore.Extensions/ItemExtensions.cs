using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.SecurityModel;
using Sitecore.Data.Items;
using Sitecore.Data;
using Sitecore.Data.Templates;
using Sitecore.Data.Managers;
using WebsiteKernel.Extensions;

namespace WebsiteKernel.Sitecore.Extensions
{
    public static class ItemExtensions
    {
        #region is something
        /// <summary>
        /// Determines whether the specified item is a standard values item.
        /// </summary>
        /// <param name="item">The item to test.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is a standard values item otherwise, <c>false</c>.
        /// </returns>
        public static bool IsStandardValues(this Item item)
        {
            if (item == null)
                return false;

            bool isStandardValue = false;

            if (item.Template.StandardValues != null)
                isStandardValue = (item.Template.StandardValues.ID == item.ID);

            return isStandardValue;
        }


        /// <summary>
        /// Determines whether the specified item's template is derived from another template.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="templateId">The template id.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is derived; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDerived(this Item item, ID templateId)
        {
            if (item == null)
                return false;

            if (templateId.IsNull)
                return false;

            TemplateItem templateItem = item.Database.Templates[templateId];

            bool returnValue = false;

            if (templateItem != null)
            {
                Template template = TemplateManager.GetTemplate(item);
                returnValue = template != null && template.ID == templateItem.ID || template.DescendsFrom(templateItem.ID);
            }

            return returnValue;
        }

        #endregion

        #region OrganiseInFolder
        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        public static void OrganiseInFolder(this Item contextItem, ID rootItemID)
        {
            contextItem.OrganiseInFolder(rootItemID, new TemplateID(ID.Undefined), 0, null);
        }

        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="targetDepth">The target depth.</param>
        public static void OrganiseInFolder(this Item contextItem, ID rootItemID, TemplateID folderTemplateId, int targetDepth)
        {
            contextItem.OrganiseInFolder(rootItemID, folderTemplateId, targetDepth, null);
        }

        public static void OrganiseInFolder(this Item contextItem, ID rootItemID, TemplateID folderTemplateId, DateTime date, Constants.Enums.DateFiling fileingOptions)
        {
            var filingPath = new List<string>();
            if (fileingOptions == Constants.Enums.DateFiling.Day)
            {
                filingPath.Add(date.Day.ToString());
            }
            else if (fileingOptions == Constants.Enums.DateFiling.Month)
            {
                filingPath.Add(date.Month.ToString());
            }
            else if (fileingOptions == Constants.Enums.DateFiling.Year)
            {
                filingPath.Add(date.Year.ToString());
            }
            else if (fileingOptions == Constants.Enums.DateFiling.YearMonth)
            {
                filingPath.Add(date.Year.ToString());
                filingPath.Add(date.Month.ToString());
            }
            else if (fileingOptions == Constants.Enums.DateFiling.YearMonthDay)
            {
                filingPath.Add(date.Year.ToString());
                filingPath.Add(date.Month.ToString());
                filingPath.Add(date.Day.ToString());
            }

            contextItem.OrganiseInFolder(rootItemID, folderTemplateId, filingPath);
        }

        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="filingPath">The filing path.</param>
        public static void OrganiseInFolder(this Item contextItem, ID rootItemID, TemplateID folderTemplateId, IList<string> filingPath)
        {
            contextItem.OrganiseInFolder(rootItemID, folderTemplateId, 0, filingPath);
        }

        /// <summary>
        /// Organises the item in a manageable folder structure.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="targetDepth">The target depth.</param>
        /// <param name="filingPath">The filing path.</param>
        private static void OrganiseInFolder(this Item contextItem, ID rootItemID, TemplateID folderTemplateId, int targetDepth, IList<string> filingPath)
        {
            if (targetDepth == 0) targetDepth = 2;

            using (new SecurityDisabler())
            {
                var db = contextItem.Database;
                int currentDepth = 0;

                //the target folder is the root ID for the moment
                var targetFolderItem = db.GetItem(rootItemID);

                //if the filing path is nto null then we have been told what folders to make
                if (filingPath != null)
                {
                    foreach (var path in filingPath)
                    {
                        targetFolderItem = GetOrCreateFolder(targetFolderItem, path, folderTemplateId);
                    }
                }
                else if (folderTemplateId.ID != ID.Undefined) //if the folderTemplateId is not Undefined then we are file alphabetically 
                {
                    string initial = "";
                    while (currentDepth < targetDepth)
                    {
                        initial = contextItem.Name.Substring(0, currentDepth + 1).ToUpper();

                        // if the first character of supplier name isn't alphanumeric, put it in the underscore folder
                        if (!initial.IsAlphaNumeric())
                        {
                            initial = "_";
                        }

                        targetFolderItem = GetOrCreateFolder(targetFolderItem, initial, folderTemplateId);
                        currentDepth++;
                    }
                }

                //move the item to the path that has been found/created
                MoveItem(contextItem, targetFolderItem);
            }
        }

        /// <summary>
        /// Moves the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="targetFolderItem">The target folder item.</param>
        private static void MoveItem(Item item, Item targetFolderItem)
        {
            if (item != null && targetFolderItem != null)
            {
                // if the item isn't already in the right place, move it to the right place
                if (item.ParentID != targetFolderItem.ID)
                {
                    using (new SecurityDisabler())
                    {
                        using (new EditContext(item))
                        {
                            item.MoveTo(targetFolderItem);
                        }
                    }
                }
            }
        }

        private static Item GetOrCreateFolder(Item targetFolderItem, string initial, TemplateID folderTemplateId)
        {
            var folderItem = targetFolderItem.Children[initial];
            if (folderItem == null)
            {
                using (new SecurityDisabler())
                {
                    using (new EditContext(targetFolderItem))
                    {
                        folderItem = targetFolderItem.Add(initial, folderTemplateId);
                    }
                }
            }

            return folderItem;
        }

        #endregion
    }
}
