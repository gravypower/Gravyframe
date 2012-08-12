using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsiteKernel.Constants
{
    public interface IContentLocation
    {
        string GetTopLeft();
        string GetTopMiddle();
        string GetTopRight();
        string GetBottomLeft();
        string GetBottomMiddle();
        string GetBottomRight();
    }
}
