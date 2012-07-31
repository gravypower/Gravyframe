using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.MessageBase;
using System.Runtime.Serialization;

namespace Service.Messages
{
    [DataContract(Namespace = "http://www.gravypower.net/types/")]
    public class WebsiteNewsRequest : RequestBase<LoadOptions>
    {

        [DataMember]
        public DateTime From;

        [DataMember]
        public DateTime To;

        [DataMember]
        public int Offset;

        [DataMember]
        public int Number;

        [DataMember]
        public string CategoryId;

        [DataMember]
        public IList<string> CategoryIds;

        [DataMember]
        public string BucketId;

        [DataMember]
        public string NewsId;
    }
}
