using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using temaCsharp.Entities;
using temaCsharp.Models;

/*
 * Represents the `workspace` in which the app runs -- I felt the need to use 
 * a separate class from the Form to deal with state
 * 
 */
namespace temaCsharp.Util
{
    [Serializable]
    public class HardwareSessionManager
    {
        public List<Computer> computers;

        public List<Component> components;

        [NonSerialized]
        public List<String> platforms;

        public HardwareSessionManager()
        {
            computers  = new List<Computer>();
            components = new List<Component>();
            // hardcoded for now, do not serialize
            platforms = new List<String>(){"AMD", "ARM", "INTEL", "SPARC"};
        }

        public void saveState(String filename)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public void retrieveState(String filename)
        {
            IFormatter formatter = new BinaryFormatter();
            HardwareSessionManager stateManager = null;
            Stream stream = new FileStream(filename,
                                     FileMode.Open,
                                     FileAccess.Read, FileShare.None);
            stateManager = (HardwareSessionManager)formatter.Deserialize(stream);
            stream.Close();
            this.components = stateManager.components;
            this.computers  = stateManager.computers;
        }

        public void saveState(OleDbConnection connection)
        {
            HardwareModel hardwareModel = HardwareModel.getInstance(connection);
            foreach (Component component in components)
            {
                //HardwareUtil.log(Loglevel.general, hardwareModel.componentExists(component).ToString());
                if (!hardwareModel.componentExists(component))
                {
                    hardwareModel.insertComponent(component);
                }
                else {
                    hardwareModel.editComponent(component);
                }
            }
            foreach (Computer computer in computers)
            {
                //HardwareUtil.log(Loglevel.general, hardwareModel.computerExists(computer).ToString());
                if (!hardwareModel.computerExists(computer))
                {
                    hardwareModel.insertComputer(computer);
                }
                else {
                    hardwareModel.editComputer(computer);
                }
            }
        }

        public void retrieveState(OleDbConnection connection)
        {
            HardwareModel hardwareModel = HardwareModel.getInstance(connection);
            components = hardwareModel.listComponents();
            computers  = hardwareModel.listComputers();
        }

        public String getReportAsString()
        {
            String report = "";
            report += "*************************** Hardware store report ***************************\r\n";
            report += "************************* DATE: " + DateTime.Now.ToString() + "*************************\r\n";
            report += "\r\n\r\n";
            report += "Your components:\r\n";
            foreach (Component component in components)
            {
                report += "- " + component.ToString(true) + "\r\n";
            }
            report += "\r\n\r\n";
            report += "Your PCs:\r\n";
            foreach (Computer computer in computers)
            {
                report += computer.ToString(true);
            }
            report += "\r\n\r\n";
            report += "In total you have " + computers.Count + " PCs and " + components.Count + " components.";
            report += "\r\n\r\n";
            report += "********************************************************************************";
            return report;
        }
    }
}
