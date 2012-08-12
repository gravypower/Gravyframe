using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebsiteKernel.Constants;

namespace WebsiteKernel.Umbraco.Constants
{
    public class ContentLocation : IContentLocation
    {
        private const string TopLeft = "Top Left";
        private const string TopMiddle = "Top Middle";
        private const string TopRight = "Top Right";
        private const string BottomLeft = "Bottom Left";
        private const string BottomMiddle = "Bottom Middle";
        private const string BottomRight = "Bottom Right";

        public string GetTopLeft()
        {
            return TopLeft;
        }

        public string GetTopMiddle()
        {
            return TopMiddle;
        }

        public string GetTopRight()
        {
            return TopRight;
        }

        public string GetBottomLeft()
        {
            return BottomLeft;
        }

        public string GetBottomMiddle()
        {
            return BottomMiddle;
        }

        public string GetBottomRight()
        {
            return BottomRight;
        }
    }
}
