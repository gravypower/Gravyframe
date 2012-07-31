using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SC = global::Sitecore;
namespace WebsiteKernel.Sitecore.Extensions
{

    public static class FieldExtensions
    {
        #region ConvertTo
        /// <summary>
        /// Converts the Field into a DateField
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.DateField ConvertToDateField(this SC.Data.Fields.Field fld)
        {
            return new SC.Data.Fields.DateField(fld);
        }

        /// <summary>
        /// Converts the field to a checkbox field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.CheckboxField ConvertToCheckboxField(this SC.Data.Fields.Field fld)
        {
            return new SC.Data.Fields.CheckboxField(fld);
        }

        /// <summary>
        /// Converts the field into an internal link field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.InternalLinkField ConvertToInternalLinkField(this SC.Data.Fields.Field fld)
        {
            return new SC.Data.Fields.InternalLinkField(fld);
        }

        /// <summary>
        /// Converts to a link field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.LinkField ConvertToLinkField(this SC.Data.Fields.Field fld)
        {
            SC.Data.Fields.LinkField returnField = null;
            if (fld != null)
            {
                returnField = new SC.Data.Fields.LinkField(fld);
            }
            return returnField;
        }

        /// <summary>
        /// Converts to an image field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.ImageField ConvertToImageField(this SC.Data.Fields.Field fld)
        {
            SC.Data.Fields.ImageField returnField = null;
            if (fld != null)
            {
                returnField = new SC.Data.Fields.ImageField(fld);
            }
            return returnField;
        }


        /// <summary>
        /// Converts the field into a lookup field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.LookupField ConvertToLookupField(this SC.Data.Fields.Field fld)
        {
            if (fld != null)
            {
                return new SC.Data.Fields.LookupField(fld);
            }

            return null;
        }

        /// <summary>
        /// Converts the field into a multi list field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Fields.MultilistField ConvertToMultilistField(this SC.Data.Fields.Field fld)
        {
            if (fld != null)
            {
                return new SC.Data.Fields.MultilistField(fld);
            }

            return null;
        }

        #endregion

        /// <summary>
        /// Extension to force the field to a datetime output
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this SC.Data.Fields.Field fld)
        {
            if (fld != null)
            {
                // convert to a date field
                SC.Data.Fields.DateField dateFld = fld.ConvertToDateField();

                if (dateFld != null)
                {
                    return dateFld.DateTime;
                }
            }

            return DateTime.MinValue;
        }

        /// <summary>
        /// Is the field checked
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static bool IsChecked(this SC.Data.Fields.Field fld)
        {
            if (fld != null)
            {
                SC.Data.Fields.CheckboxField chckFld = fld.ConvertToCheckboxField();

                if (chckFld != null)
                {
                    return chckFld.Checked;
                }
            }

            return false;
        }

        /// <summary>
        /// Is the Item the same item
        /// </summary>
        /// <param name="fld">The Internal link field with the linked item</param>
        /// <param name="itmToCompare">The item to compare to the linked item</param>
        /// <returns>Returns true if the linked item and the item are the same</returns>
        public static bool IsItem(this SC.Data.Fields.InternalLinkField fld, SC.Data.Items.Item itmToCompare)
        {
            // we have to make sure we have the data
            if (fld != null && !string.IsNullOrEmpty(fld.Value) && !fld.TargetID.IsNull && itmToCompare != null)
            {
                // does the id's match
                return fld.TargetID.Equals(itmToCompare.ID);
            }

            // nothing so false the return
            return false;
        }

        /// <summary>
        /// Gets the target item from either an internal link or look up field
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static SC.Data.Items.Item TargetItem(this SC.Data.Fields.Field fld)
        {
            if (fld != null)
            {
                if (fld.TypeKey.Equals("internal link"))
                {
                    SC.Data.Fields.InternalLinkField intFld = fld.ConvertToInternalLinkField();

                    if (intFld != null && intFld.TargetItem != null)
                    {
                        // have to make sure the item is actually avaible
                        return intFld.TargetItem;
                    }
                }
                else
                {
                    SC.Data.Fields.LookupField lckFld = fld.ConvertToLookupField();

                    if (lckFld != null && lckFld.TargetItem != null)
                    {
                        // have to make sure the item is actually avaible
                        return lckFld.TargetItem;
                    }
                }
            }

            return null;
        }

        public static string GetUrl(this SC.Data.Fields.LinkField fld)
        {
            if (!fld.IsInternal)
                return fld.Url;

            var item = fld.TargetItem;
            if (item == null)
            {
                item = SC.Context.Database.GetItem(fld.TargetID);
            }

            if (item != null)
                return SC.Links.LinkManager.GetItemUrl(item);
            else
                return null;
        }

        public static string GetText(this SC.Data.Fields.LinkField fld)
        {
            if (!String.IsNullOrEmpty(fld.Text))
                return fld.Text;

            if (!fld.IsInternal)
                return null;

            var targetitem = SC.Context.Database.GetItem(fld.TargetID);
            if (targetitem == null)
                return null;

            string text = targetitem["Title"];
            if (String.IsNullOrEmpty(text))
                text = targetitem.Name;

            return text;
        }

        public static string GetTitle(this SC.Data.Fields.LinkField fld)
        {
            if (!String.IsNullOrEmpty(fld.Title))
                return fld.Title;

            if (!fld.IsInternal)
                return null;

            var targetitem = SC.Context.Database.GetItem(fld.TargetID);
            if (targetitem == null)
                return null;

            string title = targetitem["Title"];
            if (String.IsNullOrEmpty(title))
                title = targetitem.Name;

            return title;
        }

        public static bool HasLink(this SC.Data.Fields.LinkField fld)
        {
            if (fld.IsInternal)
                return !SC.Data.ID.IsNullOrEmpty(fld.TargetID);
            else
                return !String.IsNullOrEmpty(fld.Url);
        }
    }
}
