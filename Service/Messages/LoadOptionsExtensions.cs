using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Messages
{
    public static class LoadOptionsExtensions
    {
        public static LoadOptions FlagLoadOptions(this LoadOptions[] loadOptions)
        {
            LoadOptions returnLoadOption = LoadOptions.None;

            for (int i = 0; i < loadOptions.Length; i++)
            {
                if (i == 0)
                {
                    returnLoadOption = loadOptions[0];
                }
                else
                {
                    returnLoadOption = returnLoadOption | loadOptions[i];
                }
            }
            return returnLoadOption;
        }
    }
}
