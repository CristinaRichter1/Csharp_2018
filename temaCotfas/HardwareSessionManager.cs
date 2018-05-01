using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
 * Represents the `workspace` in which the app runs -- I felt the need to use 
 * a separate class from the Form to deal with state
 * 
 */
namespace temaCsharp
{
    public class HardwareSessionManager
    {
        public List<Computer> computers;

        public List<Component> components;

        public HardwareSessionManager()
        {
            computers  = new List<Computer>();
            components = new List<Component>();
        }

        public static void saveState(HardwareSessionManager stateManager, String filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, stateManager);
            stream.Close();
        }

        public static HardwareSessionManager retrieveState(String filename)
        {
            IFormatter formatter = new BinaryFormatter();
            HardwareSessionManager stateManager = null;
            Stream stream = new FileStream(filename,
                                     FileMode.Create,
                                     FileAccess.Read, FileShare.None);
            stateManager = (HardwareSessionManager)formatter.Deserialize(stream);
            stream.Close();
            return stateManager;
        }
    }
}
