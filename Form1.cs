﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        public Form1(HardwareSessionManager hsm)
        {
            session = hsm;
            InitializeComponent();
        }

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
            int selectedComponent = listBox1.SelectedIndex;
            Console.WriteLine(selectedComponent);
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
                        //HardwareUtil.printList(ls);
                        // Add a node to tree and add its associated component to the session
                        treeView1.Nodes[ls[0]].Nodes.Add(session.components[selectedComponent].Name);
                        session.computers[ls[0]].addComponent(session.components[selectedComponent]);
                        treeView1.ExpandAll();
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}