using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.interfaces;
using umbraco.cms.businesslogic.web;
using umbraco.BusinessLogic;
using umbraco.businesslogic;
using umbraco.NodeFactory;
using WebsiteKernel.Extensions;

namespace WebsiteKernel.Umbraco.Extensions
{
    public static class DocumentExtensions
    {
        #region OrganiseInFolder
        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        public static void OrganiseInFolder(this Document contextItem, int rootItemID)
        {
            contextItem.OrganiseInFolder(rootItemID, null, 0, null);
        }

        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="targetDepth">The target depth.</param>
        public static void OrganiseInFolder(this Document contextItem, int rootItemID, DocumentType documnetType, int targetDepth)
        {
            contextItem.OrganiseInFolder(rootItemID, documnetType, targetDepth, null);

        }

        public static void OrganiseInFolder(this Document contextItem, int rootItemID, DocumentType documnetType, DateTime date, Constants.Enums.DateFiling fileingOptions)
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

            contextItem.OrganiseInFolder(rootItemID, documnetType, filingPath);
        }

        /// <summary>
        /// Organises the in folder.
        /// </summary>
        /// <param name="contextItem">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="filingPath">The filing path.</param>
        public static void OrganiseInFolder(this Document contextDocument, int rootItemID, DocumentType documnetType, IList<string> filingPath)
        {
            contextDocument.OrganiseInFolder(rootItemID, documnetType, 0, filingPath);
        }

        /// <summary>
        /// Organises the item in a manageable folder structure.
        /// </summary>
        /// <param name="contextDocument">The context item.</param>
        /// <param name="rootItemID">The root item ID.</param>
        /// <param name="folderTemplateId">The folder template id.</param>
        /// <param name="targetDepth">The target depth.</param>
        /// <param name="filingPath">The filing path.</param>
        private static void OrganiseInFolder(this Document contextDocument, int rootItemID, DocumentType documnetType, int targetDepth, IList<string> filingPath)
        {
            if (targetDepth == 0)
                targetDepth = 2;

            int currentDepth = 0;

            //the target folder is the root ID for the moment
            var targetFolderItem = new Document(rootItemID);

            //if the filing path is not null then we have been told what folders to make
            if (filingPath != null)
            {
                foreach (var path in filingPath)
                {
                    targetFolderItem = GetOrCreateFolder(targetFolderItem, path, documnetType);
                }
            }
            else if (documnetType != null) 
            {
                string initial = "";
                while (currentDepth < targetDepth)
                {
                    initial = contextDocument.Text.Substring(0, currentDepth + 1).ToUpper();

                    // if the first character of supplier name isn't alphanumeric, put it in the underscore folder
                    if (!initial.IsAlphaNumeric())
                    {
                        initial = "_";
                    }

                    targetFolderItem = GetOrCreateFolder(targetFolderItem, initial, documnetType);
                    currentDepth++;
                }
            }

            //move the item to the path that has been found/created
            MoveItem(contextDocument, targetFolderItem);


        }

        /// <summary>
        /// Moves the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="targetFolderItem">The target folder item.</param>
        private static void MoveItem(Document document, Document targetFolderDocument)
        {
            if (document != null && targetFolderDocument != null)
            {
                // if the item isn't already in the right place, move it to the right place
                if (document.ParentId != targetFolderDocument.Id)
                {
                    document.Move(targetFolderDocument.Id);
                }
            }
        }

        private static Document GetOrCreateFolder(Document targetFolderDocument, string initial, DocumentType documnetType)
        {
            var folderItem = targetFolderDocument.Children.SingleOrDefault(x => x.Text == initial);
            if (folderItem == null)
            {
                folderItem = Document.MakeNew(initial, documnetType , User.GetCurrent(), targetFolderDocument.Id);
            }

            return folderItem;
        }

        #endregion
    }
}
