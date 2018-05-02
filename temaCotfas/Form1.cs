using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temaCsharp
{
    public partial class Form1 : Form
    {
        // Holds state
        public HardwareSessionManager session;

        public Form1()
        {
            session = new HardwareSessionManager();
            InitializeComponent();
            updateState();
            treeView1.ExpandAll();
        }

        public Form1(HardwareSessionManager hsm)
        {
            session = hsm;
            InitializeComponent();
            // populate everything with the proper data from state
            updateState();
            treeView1.ExpandAll();
        }

        private void updateState()
        {
            if (session.components.Count > 0)
            {
                foreach (Component component in session.components)
                {
                    listBox1.Items.Add(component.Name);
                }

                foreach (String platform in session.platforms)
                {
                    comboBox1.Items.Add(platform);
                }

            }

            if (session.computers.Count() > 0)
            {
                int i = treeView1.Nodes.Count;
                foreach (Computer computer in session.computers)
                {
                    treeView1.Nodes.Add("PC " + computer.ID.ToString());
                    List<Component> components = computer.getComponents();
                    foreach (Component component in components)
                    {
                        treeView1.Nodes[i].Nodes.Add(component.Name);
                    }
                    i++;
                }
            }
        }

        // Event handlers

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedComponent = listBox1.SelectedIndex;
            if (selectedComponent > -1)
            {
                session.components.RemoveAt(selectedComponent);
                listBox1.Items.RemoveAt(selectedComponent); ;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input
            int id;
            Boolean idok, nameok, platfok;
            idok = nameok = platfok = true;
            String validationMsg = "";

            if (!Int32.TryParse(textBox1.Text, out id))
            {
                validationMsg += "`" +id+"` is not a valid component ID.";
                idok = false;
            }
            
            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                validationMsg += "`" + textBox2.Text.Trim() + "` is not a valid component name.";
                nameok = false;
            }
            String componentName = textBox2.Text.Trim();

            if (String.IsNullOrEmpty(comboBox1.Text.Trim()))
            {
                validationMsg += "`" + comboBox1.Text.Trim() + "` is not a valid platform.";
                platfok = false;
            }
            String componentPlatform = comboBox1.Text;

            // If all is well
            if (idok && nameok && platfok)
            {
                // Add component to data store
                Component newComponent = new Component(id, componentName, componentPlatform);

                if (!HardwareUtil.isStringInArray(listBox1.Items, newComponent.Name))
                {
                    listBox1.Items.Add(newComponent.Name);
                    session.components.Add(newComponent);
                }
                else
                {
                    HardwareUtil.validationAlert("`" + newComponent.Name + "` already exists in the component store.");
                }
            }
            else
            {
                HardwareUtil.validationAlert(validationMsg);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // if we have a pc 
            if (treeView1.Nodes.Count > 0)
            {
                // if we have selected a component
                int selectedIndex = listBox1.SelectedIndex;
                if (selectedIndex > -1)
                {
                    // if we have selected a node
                    if (treeView1.SelectedNode != null)
                    {
                        Component selectedComponent = session.components[selectedIndex];
                        List<int> ls = HardwareUtil.getAddrOfNode(treeView1.SelectedNode);

                        if (HardwareCompatibilityManager.isCompatible(selectedComponent, session.computers[ls[0]]))
                        {
                            HardwareUtil.compatibilityInfo("The component is compatible!");
                        } else {
                            HardwareUtil.compatibilityInfo("The component is not compatible.");
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int currentIndex = treeView1.Nodes.Count + 1;
            
            Computer c = new Computer(currentIndex, "INTEL", new List<Component>());
            session.computers.Add(c);
            treeView1.Nodes.Add("PC " + c.ID.ToString());
            treeView1.ExpandAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // if we have a pc 
            if (treeView1.Nodes.Count > 0)
            {
                // if we have selected a component
                int selectedComponent = listBox1.SelectedIndex;
                if (selectedComponent > -1)
                {
                    // if we have selected a node
                    if (treeView1.SelectedNode != null)
                    {
                        // this is done poorly but works for now
                        List<int> ls = HardwareUtil.getAddrOfNode(treeView1.SelectedNode);
                
                        // Add a node to tree and add its associated component to the session
                        if (HardwareCompatibilityManager.isCompatible(session.components[selectedComponent], session.computers[ls[0]]))
                        {
                            treeView1.Nodes[ls[0]].Nodes.Add(session.components[selectedComponent].Name);
                            session.computers[ls[0]].addComponent(session.components[selectedComponent]);
                        }
                        else {
                            String msg = String.Format(
                                "Component `{0}` (platform `{1}`) is not compatible with PC {2} (platform `{3}`).",
                                session.components[selectedComponent].Name,
                                session.components[selectedComponent].Platform,
                                session.computers[ls[0]].ID,
                                session.computers[ls[0]].Platform
                                );

                            HardwareUtil.compatibilityAlert(msg);
                        }
                        treeView1.ExpandAll();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // if we have a pc 
            if (treeView1.Nodes.Count > 0)
            {
                // if we have selected a node
                if (treeView1.SelectedNode != null)
                {
                    // refactor when possible
                    List<int> ls = HardwareUtil.getAddrOfNode(treeView1.SelectedNode);
                    if (ls.Count > 1)
                    {
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        session.computers[ls[1]].removeComponent(ls[0]);
                    }
                    else {
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        session.computers.Remove(session.computers[ls[0]]);
                    }
                    treeView1.ExpandAll();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stream stream;
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            sfd.FileName = "report.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if ((stream = sfd.OpenFile()) != null)
                {
                    String path   = Path.GetFullPath(sfd.FileName);
                    String report = session.getReportAsString();

                    // Close the stream as the process will be unable to write to 
                    // it with WriteAllText while opened as stream
                    stream.Close();
                    File.WriteAllText(path, report);
                }
            }
        }
    }
}
