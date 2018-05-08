using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Represents a computer
 * 
 */ 
namespace temaCsharp.Entities
{
    [Serializable]
    public class Computer
    {
        #region props

        public int ID { get; private set; }

        public String Platform { get; private set; }

        private List<Component> components;

        #endregion

        #region ctors
        public Computer()
        {
            ID = 0;
            Platform = "N/A";
            components = new List<Component>();
        }

        public Computer(int ID, String platform, List<Component> components)
        {
            this.ID         = ID;
            Platform        = platform;
            this.components = components;
        }

        #endregion

        #region methods

        public void addComponent(Component c)
        {
            components.Add(c);
        }

        public void addComponents(List<Component> list)
        {
            foreach (Component c in list)
            {
                components.Add(c);
            }
        }

        public void removeComponent(Component c0)
        {
            foreach (Component c1 in components)
            {
                if (c0 == c1)
                {
                    components.Remove(c1);
                }
            }
        }

        public void removeComponent(int index)
        {
            components.RemoveAt(index);
        }

        public List<Component> getComponents()
        {
            return components;
        }

        public override String ToString()
        {
            String retval = "";
            retval += "Object Computer {";
            retval += "ID: " + ID + ";";
            retval += "Platform: " + Platform + ";";
            retval += "Components: [";
            foreach (Component component in components)
            {
                retval += component.ToString() + ", ";
            }
            retval += "]";
            retval += "}";
            return retval;
        }

        public String ToString(Boolean pretty)
        {
            String retval = "";
            retval += "Computer :\r\n";
            retval += "ID: " + ID + ";\r\n";
            retval += "Platform: " + Platform + ";\r\n";
            retval += "Components: \r\n";
            foreach (Component component in components)
            {
                retval += "\t- " + component.ToString(true) + ";\r\n";
            }

            return retval;
        }
        #endregion
    }
}
