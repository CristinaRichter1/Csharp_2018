using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Utility/shared/helper functions go here 
 * 
 */
namespace temaCsharp
{
    // log levels
    enum Loglevel {
        general,
        error
    }

    class HardwareUtil
    {
        // common interactivity functions
        public static void validationAlert(String msg)
        {
            MessageBox.Show(msg, "Invalid input");
        }

        public static void error(String msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void compatibilityInfo(String msg)
        {
            MessageBox.Show(msg, "Compatibility information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void compatibilityAlert(String msg)
        {
            MessageBox.Show(msg, "Compatibility alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // utility functions 
        public static bool isStringInArray(string[] strArray, string key)
        {

            if (strArray.Contains(key))
                return true;
            return false;
        }

        public static bool isStringInArray(ListBox.ObjectCollection items, string key)
        {
            if (items.Contains(key))
                return true;
            return false;
        }

        public static List<int> getAddrOfNode(TreeNode tn)
        {
            List<int> retval = new List<int>();
            Console.WriteLine(tn);
            while (tn != null)
            {
                retval.Add(tn.Index);
                tn = tn.Parent;
            }
            return retval;
        }

        public static void printList(List<int> ls)
        {
            Console.WriteLine("[");
            foreach (var li in ls)
            {
                Console.WriteLine(li + ", ");
            }
            Console.WriteLine("]");
        }

        // logging function
        public static void log(Loglevel level, String logText)
        {
            String log = "";
            log += "DATE: " + DateTime.Now.ToString();

            if (level == Loglevel.general)
            {
                log += " LEVEL: GENERAL ";
            } else if (level == Loglevel.error)
            {
                log += " LEVEL: ERROR ";
            }
           
            log += logText;

            String path = "./hardware.log";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine( log );
            }
        }

    }
}
