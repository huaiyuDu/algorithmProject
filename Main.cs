using algorithmProject.algorithms;
using algorithmProject.algorithms.devideconquer.pingpong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static algorithmProject.algorithms.AlgorithmFactory;

namespace algorithmProject
{
    public partial class Main : Form
    {
        private IAlgorithm algorithm;

        private IExecuteObserver observer;

        // cancel token, used for cancel task
        //public CancellationToken cancellationToken;

        private CancellationTokenSource cancellationTokenSource;
        public Main(Algorithm algorithmName,Form1 basicform)
        {
            InitializeComponent();
            observer = new UIExecuteObserver(this,basicform);
            algorithm = AlgorithmFactory.getAlorithm(algorithmName, observer);

            InitializeValues();

        }

        public void receveTaskStatusEvent(string status) {
            // only cancel now
            stopCurrentTask();
        }

        private void InitializeValues() {
            alrorithmNameText.Text = algorithm.GetAlgorithmName();
            if (algorithm.supportCompairAlogirthm())
            {
                checkBoxExecuteCompair.Visible = true;
            }
            else {
                checkBoxExecuteCompair.Visible = false; 
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chooseSingleInputBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "please select input files";
            fileDialog.Filter = "input file(*.input)|*.input";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                algorithm.SetInputSingleFiles(new BaseAlgorithmInput(fileDialog.FileName));
                textBoxInputFile.Text = fileDialog.FileName;
            }

        }

        private void singleExeBtn_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            if (algorithm.GetInputSingleFiles() == null) {
                MessageBox.Show("please choose input files!", "Input Missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            
            Task currentTask = Task.Factory.StartNew(() =>
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                algorithm.execute(cancellationToken);
            }).ContinueWith((t) =>
            {
                System.Console.WriteLine("Done!");
                //displayAlert("Done !");
            }, cancellationToken,
            TaskContinuationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonChooseBatch_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "choose input files";
            dialog.Filter = "all files(*.input)|*.input";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string file = dialog.FileName;
                List<IAlgorithmInput> list = new List<IAlgorithmInput>();
                foreach (string file in dialog.FileNames) {
                    list.Add(new BaseAlgorithmInput(file));

                }
                algorithm.SetBatchInputFiles(list);
                showFileList();
            }
        }
        private void showFileList() {
            this.fileListView.BeginUpdate();  
            this.fileListView.Items.Clear();
            List<IAlgorithmInput> list = algorithm.GetBatchInputFiles();

            foreach (IAlgorithmInput input in list)   
            {
                ListViewItem lvi = new ListViewItem();
                renderListVieTime(lvi, input);
                this.fileListView.Items.Add(lvi);
            }

            this.fileListView.EndUpdate();
        }

        public static void renderListVieTime(ListViewItem lvi, IAlgorithmInput input)
        {
            lvi.Text = input.FileName;
            lvi.SubItems.Add(input.N != null ? input.N.ToString() : "-");
            lvi.SubItems.Add(input.ExecuteTime != null ? input.ExecuteTime.ToString() : "-");
            (bool? res, string desc) = input.Result;
            lvi.SubItems.Add(desc != null ? desc : "waiting");
        }

        private void executeBatchBtn_Click(object sender, EventArgs e)
        {


            if (algorithm.GetBatchInputFiles() == null)
            {
                MessageBox.Show("please choose batch input files!", "Input Missing", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            foreach (IAlgorithmInput input in algorithm.GetBatchInputFiles())
            {
                input.N = null;
                input.ExecuteTime = null;
                input.Result = (false,"waiting");

            }
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            IProgress<int> progress = new Progress<int>(value => {
                observer.setPercentage(value);
            });
            Task currentTask = Task.Factory.StartNew(() =>
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                algorithm.executeBatch(progress,cancellationToken, checkBoxExecuteCompair.Checked);
            }).ContinueWith((t) =>
            {
                System.Console.WriteLine("Done!");
                //displayAlert("Done !");
            }, cancellationToken,
            TaskContinuationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateTestCase createTestDialog = new CreateTestCase(algorithm);
            createTestDialog.ShowDialog(this);
        }

        public void stopCurrentTask() {
            if (cancellationTokenSource!= null) {
                cancellationTokenSource.Cancel();
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }


    public class UIExecuteObserver : IExecuteObserver
    {
        private Main mainform;

        private Form1 basicform;


        public UIExecuteObserver(Main mainform, Form1 basicform) {
            this.mainform = mainform;
            this.basicform = basicform;

        }

        public void BatchFinished(List<IAlgorithmInput> batchInputs, bool executeComparison)
        {
            string seriesName = executeComparison ? "comparison runtime" : "runtime";
            basicform.toolStripStopButton.Enabled = false;
            mainform.executeBatchBtn.Enabled = true; 
            mainform.chart.Series[seriesName].Points.Clear();
            Dictionary<long, List<long>> map = new Dictionary<long, List<long>>();
            foreach (IAlgorithmInput input in batchInputs) {
                if (input.N == null || input.ExecuteTime == null)
                {
                    continue;
                }
                long key = input.N??0;
                if (map.ContainsKey(key))
                {
                    map[key].Add(input.ExecuteTime ?? 0);
                }
                else {
                    List<long> timeList = new List<long>();
                    timeList.Add(input.ExecuteTime ?? 0);
                    map[key] = timeList;
                }
            }

            foreach (long key in map.Keys) {
                List<long> timeList = map[key];
                long sum = 0;
                foreach (long time in timeList) {
                    sum = sum + time;
                }
                long avg = sum / timeList.Count();

                mainform.chart.Series[seriesName].Points.AddXY(key, avg);

            }
            mainform.chart.Update();
            basicform.progressBar.Value = 0;
        }

        public void printConsole(string message)
        {
            Console.WriteLine(message);
            basicform.textBoxLogs.AppendText(message);
            basicform.textBoxLogs.AppendText(Environment.NewLine);
            basicform.textBoxLogs.ScrollToCaret();
        }

        public void printDebugToConsole(string message)
        {
            Console.WriteLine(message);
            basicform.textBoxLogs.AppendText(message);
            basicform.textBoxLogs.AppendText(Environment.NewLine);
            basicform.textBoxLogs.ScrollToCaret();
        }

        public void printResult(string result, bool cleanResult = false)
        {
            Console.WriteLine(result);
            if (cleanResult) {
                mainform.outputTextBox.Text = "";
            }
            mainform.outputTextBox.AppendText(result);
            mainform.outputTextBox.AppendText(Environment.NewLine);
            mainform.outputTextBox.ScrollToCaret();
        }

        public void setPercentage(int percentage)
        {
            basicform.progressBar.Value = percentage;
        }

        public void SetStatitcis(IAlgorithmInput input, long time, int index = -1)
        {
            input.ExecuteTime=time;
            input.Result=(true, "Finished");
            if (index != -1) {
                // update list
                updateTask(input, index);
            }
        }

        public void startTask()
        {
            //basicform.progressBar.Style = ProgressBarStyle.Marquee;
            basicform.toolStripStopButton.Enabled = true;
            mainform.singleExeBtn.Enabled = false; 
        }

        public void finishTask()
        {
           // basicform.progressBar.Style = ProgressBarStyle.Blocks;
            basicform.toolStripStopButton.Enabled = false;
            mainform.singleExeBtn.Enabled = true;
        }

        public void startBatchTask()
        {
            //mainform.chart.Series["runtime"].Points.Clear();
            basicform.toolStripStopButton.Enabled = true;
            mainform.executeBatchBtn.Enabled = false; 
        }

        public void updateTask(IAlgorithmInput input, int index)
        {
            if (index != -1)
            {
                // update list
                mainform.fileListView.BeginUpdate();  
                ListViewItem lvi = mainform.fileListView.Items[index];
                //lvi.Text = input.GetFileName();
                lvi.SubItems[1].Text = input.N != null ? input.N.ToString() : "-";
                lvi.SubItems[2].Text = input.ExecuteTime != null ? input.ExecuteTime.ToString() : "-";
                (bool? res, string desc) = input.Result;
                lvi.SubItems[3].Text = desc != null ? desc : "waiting";
                mainform.fileListView.EndUpdate();
            }
        }
        

    }

}


