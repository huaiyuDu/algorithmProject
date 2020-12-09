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
            InitializaDefaultValues();
 
        }

        private void InitializaDefaultValues(){
            nSeries.Text = algorithm.InputMeta.DefaultSeries;
            caseNumber.Text = algorithm.InputMeta.DefaultN;
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
            string path = outputPath.Text;
            string n_series = nSeries.Text;
            int number = int.Parse(caseNumber.Text);
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("please choose file path!", "Input Missing", MessageBoxButtons.OK,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (string.IsNullOrEmpty(n_series))
            {
                //throw new Exception("please input N series");
                MessageBox.Show("please input N series!", "Input Missing", MessageBoxButtons.OK,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (number == 0)
            {
                //throw new Exception("please input case number for each N");
                MessageBox.Show("please input case number for each N!", "Input Missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            Task.Factory.StartNew(() =>
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                algorithm.createInputFiles(path, n_series, number);
            }).ContinueWith((t) =>
            {
                System.Console.WriteLine("Done!");
                //displayAlert("Done !");
            }, System.Threading.CancellationToken.None, 
            TaskContinuationOptions.None, 
            TaskScheduler.FromCurrentSynchronizationContext());
            this.Close();
            
        }

        private void nSeries_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
