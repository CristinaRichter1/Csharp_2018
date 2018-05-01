using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Represents a PC hradware component 
 * 
 */
namespace temaCsharp
{
    [Serializable]
    public class Component
    {
        #region props

        public int ID { get; private set; }

        public String Name { get; set; }

        public String Platform { get; private set; }

        #endregion

        #region ctors
        public Component()
        {
            this.ID       = 0;
            this.Name     = "N/A";
            this.Platform = "N/A";
        }

        public Component(int ID, String name, String platform)
        {
            this.ID       = ID;
            this.Name     = name;
            this.Platform = platform;
        }
        #endregion

        #region methods
        public override String ToString()
        {
            String retval = "";
            retval += "Object Component {";
            retval += "ID: " + ID + ";";
            retval += "Name: " + Name + ";";
            retval += "Platform: " + Platform + ";";
            retval += "}";
            return retval;
        }

        public String ToString(Boolean pretty)
        {
            String retval = "";
            retval += "Component: ";
            retval += "ID: " + ID + "; ";
            retval += "Name: " + Name + "; ";
            retval += "Platform: " + Platform + "; ";
            return retval;
        }
        #endregion
    }
}
