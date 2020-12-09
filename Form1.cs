using algorithmProject.algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace algorithmProject
{

    public partial class Form1 : Form
    {
        private Form activeForm = null;

        public delegate void TaskStatusHandler(string status);

        // 基于上面的委托定义事件
        public event TaskStatusHandler taskStatusHandler;

        private Dictionary<string, Main> childForms = new Dictionary<string, Main>();



        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
        }
        private void hideSubMenu()
        {
            panelDevideConquer.Visible = false;
            greedyPanel.Visible = false;
            panelDynamicProgram.Visible = false;
            //panelplaylistsubmenu.visible = false;
            //paneltoolssubmenu.visible = false;
        }


        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pingpong_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(createForm(AlgorithmFactory.PING_PONG));
        }

        private Main createForm(string algorithmName) {
            if (!childForms.ContainsKey(algorithmName))
            {
                Main mianForm = new Main(algorithmName, this);
                childForms.Add(algorithmName, mianForm);
            }
            return childForms[algorithmName];


        }

        private void DivideConquer_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDevideConquer);
        }

        private void openChildFormInPanel(Main childForm)
        {
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.taskStatusHandler += new
            TaskStatusHandler(childForm.receveTaskStatusEvent);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStopButton_Click(object sender, EventArgs e)
        {
            if (taskStatusHandler != null)
            {
                taskStatusHandler("cancel");
            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripclearLog_Click(object sender, EventArgs e)
        {
            textBoxLogs.Text = "";
        }

        private void greedyBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(greedyPanel);
        }

        private void huffmanbutton_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(createForm(AlgorithmFactory.HUFFMAN));
        }

        private void dynamicBtn_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDynamicProgram); 
        }

        private void activitySelDynBtn_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(createForm(AlgorithmFactory.ACTIVIT_SELECTION_DYN));
        }

        private void activitySel_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(createForm(AlgorithmFactory.ACTIVIT_SELECTION_GREEDY));
        }

        private void closestPairPointButton_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(createForm(AlgorithmFactory.CLOSEST_PAIR_POINTS));
        }
    }
}
