using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.Content
{
    public class HomeVariant
    {
        public string Heading { get; set; }
        public string Body { get; set; }
        public Glass.Sitecore.Mapper.FieldTypes.Image PageImage { get; set; }
        public string TextLocation { get; set; }
        public string ImageLocation { get; set; }
        public Glass.Sitecore.Mapper.FieldTypes.Image TextFooterIcon { get; set; }
    }
}
