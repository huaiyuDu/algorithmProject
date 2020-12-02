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

namespace algorithmProject
{
    public partial class Main : Form
    {
        private IAlgorithm algorithm;

        private IExecuteObserver observer;

        // cancel token, used for cancel task
        //public CancellationToken cancellationToken;

        private CancellationTokenSource cancellationTokenSource;
        public Main(string algorithmName,Form1 basicform)
        {
            InitializeComponent();
            observer = new UIExecuteObserver(this,basicform);
            // TODO factory
            algorithm = new PingPongAlgorithm(observer);

            InitializeValues();

        }

        public void receveTaskStatusEvent(string status) {
            // only cancel now
            stopCurrentTask();
        }

        private void InitializeValues() {
            alrorithmNameText.Text = algorithm.GetAlgorithmName();
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
            fileDialog.Filter = "input file(*.txt)|*.txt";
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
            dialog.Filter = "all files(*.txt)|*.txt";
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
            this.fileListView.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            this.fileListView.Items.Clear();
            List<IAlgorithmInput> list = algorithm.GetBatchInputFiles();

            foreach (IAlgorithmInput input in list)   //添加10行数据
            {
                ListViewItem lvi = new ListViewItem();

                //lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标
                renderListVieTime(lvi, input);



                this.fileListView.Items.Add(lvi);
            }

            this.fileListView.EndUpdate();
        }

        public static void renderListVieTime(ListViewItem lvi, IAlgorithmInput input)
        {
            lvi.Text = input.GetFileName();
            lvi.SubItems.Add(input.getN() != null ? input.getN().ToString() : "-");
            lvi.SubItems.Add(input.GetExecuteTime() != null ? input.GetExecuteTime().ToString() : "-");
            (bool? res, string desc) = input.GetResult();
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
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            IProgress<int> progress = new Progress<int>(value => {
                observer.setPercentage(value);
            });
            Task currentTask = Task.Factory.StartNew(() =>
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                algorithm.executeBatch(progress,cancellationToken);
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
    }


    public class UIExecuteObserver : IExecuteObserver
    {
        private Main mainform;

        private Form1 basicform;


        public UIExecuteObserver(Main mainform, Form1 basicform) {
            this.mainform = mainform;
            this.basicform = basicform;

        }

        public void BatchFinished(List<IAlgorithmInput> batchInputs)
        {
            basicform.toolStripStopButton.Enabled = false;
            mainform.executeBatchBtn.Enabled = true; 
            mainform.chart.Series["runtime"].Points.Clear();
            Dictionary<long, List<long>> map = new Dictionary<long, List<long>>();
            foreach (IAlgorithmInput input in batchInputs) {
                if (input.getN() == null || input.GetExecuteTime() == null)
                {
                    continue;
                }
                long key = input.getN()??0;
                if (map.ContainsKey(key))
                {
                    map[key].Add(input.GetExecuteTime() ?? 0);
                }
                else {
                    List<long> timeList = new List<long>();
                    timeList.Add(input.GetExecuteTime() ?? 0);
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

                mainform.chart.Series["runtime"].Points.AddXY(key, avg);

            }
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

        public void printResult(string result)
        {
            Console.WriteLine(result);
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
            input.SetExecuteTime(time);
            input.SetResult(true, "Finished");
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
            mainform.chart.Series["runtime"].Points.Clear();
            basicform.toolStripStopButton.Enabled = true;
            mainform.executeBatchBtn.Enabled = false; 
        }

        public void updateTask(IAlgorithmInput input, int index)
        {
            if (index != -1)
            {
                // update list
                mainform.fileListView.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                ListViewItem lvi = mainform.fileListView.Items[index];
                //lvi.Text = input.GetFileName();
                lvi.SubItems[1].Text = input.getN() != null ? input.getN().ToString() : "-";
                lvi.SubItems[2].Text = input.GetExecuteTime() != null ? input.GetExecuteTime().ToString() : "-";
                (bool? res, string desc) = input.GetResult();
                lvi.SubItems[3].Text = desc != null ? desc : "waiting";
                mainform.fileListView.EndUpdate();
            }
        }
        

    }

}


