using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using temaCsharp.Entities;

/*
 * Utility class that deals with validating compatibility between parts 
 * 
 */
namespace temaCsharp.Util
{
    
    public class HardwareCompatibilityManager
    {

        public static bool isCompatible(Component c1, Component c2)
        {
            if (c1.Platform == "*" || c2.Platform == "*") { return true; }
            return (String.Compare(c1.Platform, c2.Platform) == 0) ;
        }


        public static bool isCompatible(Component c1, Computer comp1)
        {
            if (c1.Platform == "*") { return true; }
            return (String.Compare(c1.Platform, comp1.Platform) == 0);
        }
    }
}
