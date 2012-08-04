using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.cms.businesslogic.property;

namespace WebsiteKernel.Umbraco.Extensions
{
    public static class PropertyExtensions
    {
        /// <summary>
        /// Extension to force the field to a datetime output
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this Property property)
        {
            var returnDate = DateTime.MinValue;
            if (property != null && property.Value is DateTime)
            {
                returnDate = (DateTime)property.Value;
            }

            return returnDate;
        }
    }
}
