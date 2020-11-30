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
    public partial class CreateTestCase : Form
    {
        private IAlgorithm algorithm;
        public CreateTestCase(IAlgorithm algorithm)
        {
            InitializeComponent();
            this.algorithm = algorithm;
        }

        private void chooseOutputPathBtn_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outputPath.Text = fbd.SelectedPath;
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void createTestCaseButton_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                algorithm.createInputFiles(outputPath.Text, nSeries.Text, int.Parse(caseNumber.Text));
            }).ContinueWith((t) =>
            {
                System.Console.WriteLine("Done!");
                //displayAlert("Done !");
            }, System.Threading.CancellationToken.None, 
            TaskContinuationOptions.None, 
            TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        private void nSeries_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
