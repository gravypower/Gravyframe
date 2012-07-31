using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Messages
{
    [Flags]
    public enum LoadOptions
    {
        None = 0x0,
        ObjectSingle = 0x1,
        ObjectList = 0x2,
        Get = 0x4,
        Current = 0x8,
        Category = 0x10,
        CategoryList = 0x20,
        DateFilter = 0x40,
        LimitResult = 0x80,
        Navigation = 0x160
    }
}
