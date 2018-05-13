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

        [NonSerialized]
        public List<int> computersToDelete;

        [NonSerialized]
        public List<int> componentsToDelete;

        public HardwareSessionManager()
        {
            computers  = new List<Computer>();
            components = new List<Component>();

            computersToDelete  = new List<int>();
            componentsToDelete = new List<int>();

            // hardcoded for now, * means 'any'
            platforms = new List<String>(){"AMD", "ARM", "INTEL", "SPARC", "*"};
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
            foreach (int componentId in componentsToDelete)
            {
                hardwareModel.deleteComponent(componentId);
            }
            foreach (int computerId in computersToDelete)
            {
                hardwareModel.deleteComputer(computerId);
            }
        }

        public void retrieveState(OleDbConnection connection)
        {
            HardwareModel hardwareModel = HardwareModel.getInstance(connection);
            components = hardwareModel.listComponents();
            computers  = hardwareModel.listComputers();
        }

        public IDictionary<string, double> getPlatformShare()
        {
            // searched a lot but couldn't find something more similar to cpp's hash map
            IDictionary<string, int> aggregates = new Dictionary<string, int>();
            IDictionary<string, double> retval  = new Dictionary<string, double>();
            int total = 0;
            foreach (var platform in platforms)
            {
                aggregates[platform] = 0;
            }
            foreach (Computer computer in computers)
            {
                aggregates[computer.Platform]++;
                total++;
            }
            foreach (Component component in components)
            {
                aggregates[component.Platform]++;
                total++;
            }

            // get them as percents -- couldn't think of a better way 
            if (total == 0) total = 1; // seems that c# is very happy to divide by 0 and give me garbage ;)
            foreach (var aggregate in aggregates)
            {
                retval[aggregate.Key] = (double)aggregate.Value / (double)total * 100;
            }
            return retval;
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
