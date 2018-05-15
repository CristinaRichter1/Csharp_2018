using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using temaCsharp.Library;
using temaCsharp.Library.Entities;

/*
 * Utility/shared/helper functions go here 
 * 
 */
namespace temaCsharp.Util
{
    class HardwareUtil
    {
        // common interactivity functions
        public static void validationAlert(String msg)
        {
            MessageBox.Show(msg, "Invalid input");
        }

        public static void showDefaultCredentials(String msg)
        {
            MessageBox.Show(msg, "Default Credentials", MessageBoxButtons.OK);
        }

        public static void savingSuccess(String msg)
        {
            MessageBox.Show(msg, "Data succesfully saved", MessageBoxButtons.OK);
        }

        public static Boolean confirmDeleteComputer(String msg)
        {
            DialogResult choice = MessageBox.Show(msg, "Confirm computer deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand);
            Boolean retval = false;
            switch (choice) {
                case DialogResult.Yes:
                    retval = true;
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    break;
            }
            return retval;
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

        // functions for interacting with treeview
        public static TreeNode getLastNode(TreeNode subroot)
        {
            if (subroot.Nodes.Count == 0)
                return subroot;

            return getLastNode(subroot.Nodes[subroot.Nodes.Count - 1]);
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
        public static void log(LogLevel level, String logText)
        {
            String log = "";
            log += "DATE: " + DateTime.Now.ToString();

            if (level == LogLevel.general)
            {
                log += " LEVEL: GENERAL ";
            } else if (level == LogLevel.error)
            {
                log += " LEVEL: ERROR ";
            }
           
            log += logText;

            String path = Properties.Settings.Default.LogPath;

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine( log );
            }
        }

        /**
         * Transforms platform share data into an array that can be passed into the custom user control, with random colours assigned each time
         * 
         */ 
        public static PieChartCategory[] getStatsAsChart(IDictionary<String, double> platformShare)
        {
            PieChartCategory[] pieCategories = new PieChartCategory[platformShare.Count];
            int i = 0;
            Random rand = new Random();
            foreach (var kvpair in platformShare) {
                Color randomColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                pieCategories[i] = new PieChartCategory(kvpair.Key, (int)Math.Round(kvpair.Value), randomColor);
                i++;
            }
            return pieCategories;
        }

        /**
         * Retrieves data from the log file
         * 
         */ 
        public static String getLogsAsString()
        {
            String path = Properties.Settings.Default.LogPath;
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else {
                return "Application has not yet generated any logs.";
            }
            
        }
    }
}
