namespace algorithmProject
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabBatch = new System.Windows.Forms.TabPage();
            this.panelPlot = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChoosedFiles = new System.Windows.Forms.Panel();
            this.fileListView = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.executeBatchBtn = new System.Windows.Forms.Button();
            this.buttonChooseBatch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.singleExeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseSingleInputBtn = new System.Windows.Forms.Button();
            this.alrorithmNameText = new System.Windows.Forms.Label();
            this.algorithmName = new System.Windows.Forms.Label();
            this.tabSingle = new System.Windows.Forms.TabControl();
            this.tabBatch.SuspendLayout();
            this.panelPlot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panelChoosedFiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabSingle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBatch
            // 
            this.tabBatch.Controls.Add(this.panelPlot);
            this.tabBatch.Controls.Add(this.panelChoosedFiles);
            this.tabBatch.Controls.Add(this.panel1);
            this.tabBatch.Location = new System.Drawing.Point(4, 22);
            this.tabBatch.Name = "tabBatch";
            this.tabBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabBatch.Size = new System.Drawing.Size(792, 424);
            this.tabBatch.TabIndex = 1;
            this.tabBatch.Text = "Batch Test Case";
            this.tabBatch.UseVisualStyleBackColor = true;
            // 
            // panelPlot
            // 
            this.panelPlot.Controls.Add(this.chart);
            this.panelPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlot.Location = new System.Drawing.Point(403, 56);
            this.panelPlot.Name = "panelPlot";
            this.panelPlot.Size = new System.Drawing.Size(386, 365);
            this.panelPlot.TabIndex = 3;
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "runtime";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(386, 365);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            title3.Name = "line chart";
            this.chart.Titles.Add(title3);
            // 
            // panelChoosedFiles
            // 
            this.panelChoosedFiles.Controls.Add(this.fileListView);
            this.panelChoosedFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelChoosedFiles.Location = new System.Drawing.Point(3, 56);
            this.panelChoosedFiles.Name = "panelChoosedFiles";
            this.panelChoosedFiles.Size = new System.Drawing.Size(400, 365);
            this.panelChoosedFiles.TabIndex = 2;
            // 
            // fileListView
            // 
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.number,
            this.time,
            this.Result});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.HideSelection = false;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(400, 365);
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // File
            // 
            this.File.Text = "File Name";
            this.File.Width = 220;
            // 
            // number
            // 
            this.number.Text = "N";
            // 
            // time
            // 
            this.time.Text = "Time(ms)";
            // 
            // Result
            // 
            this.Result.Text = "Result";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.executeBatchBtn);
            this.panel1.Controls.Add(this.buttonChooseBatch);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 53);
            this.panel1.TabIndex = 1;
            // 
            // executeBatchBtn
            // 
            this.executeBatchBtn.Location = new System.Drawing.Point(144, 13);
            this.executeBatchBtn.Name = "executeBatchBtn";
            this.executeBatchBtn.Size = new System.Drawing.Size(133, 23);
            this.executeBatchBtn.TabIndex = 0;
            this.executeBatchBtn.Text = "execute";
            this.executeBatchBtn.UseVisualStyleBackColor = true;
            this.executeBatchBtn.Click += new System.EventHandler(this.executeBatchBtn_Click);
            // 
            // buttonChooseBatch
            // 
            this.buttonChooseBatch.Location = new System.Drawing.Point(5, 13);
            this.buttonChooseBatch.Name = "buttonChooseBatch";
            this.buttonChooseBatch.Size = new System.Drawing.Size(133, 23);
            this.buttonChooseBatch.TabIndex = 0;
            this.buttonChooseBatch.Text = "choose Input Files";
            this.buttonChooseBatch.UseVisualStyleBackColor = true;
            this.buttonChooseBatch.Click += new System.EventHandler(this.buttonChooseBatch_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(647, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "create input files";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outputTextBox);
            this.tabPage1.Controls.Add(this.textBoxInputFile);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.singleExeBtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chooseSingleInputBtn);
            this.tabPage1.Controls.Add(this.alrorithmNameText);
            this.tabPage1.Controls.Add(this.algorithmName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Single TestCase";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(37, 132);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(724, 284);
            this.outputTextBox.TabIndex = 7;
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputFile.Location = new System.Drawing.Point(112, 42);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.ReadOnly = true;
            this.textBoxInputFile.Size = new System.Drawing.Size(520, 21);
            this.textBoxInputFile.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output:";
            // 
            // singleExeBtn
            // 
            this.singleExeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleExeBtn.Location = new System.Drawing.Point(638, 69);
            this.singleExeBtn.Name = "singleExeBtn";
            this.singleExeBtn.Size = new System.Drawing.Size(123, 23);
            this.singleExeBtn.TabIndex = 4;
            this.singleExeBtn.Text = "Execute";
            this.singleExeBtn.UseVisualStyleBackColor = true;
            this.singleExeBtn.Click += new System.EventHandler(this.singleExeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input File:";
            // 
            // chooseSingleInputBtn
            // 
            this.chooseSingleInputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseSingleInputBtn.Location = new System.Drawing.Point(638, 40);
            this.chooseSingleInputBtn.Name = "chooseSingleInputBtn";
            this.chooseSingleInputBtn.Size = new System.Drawing.Size(123, 23);
            this.chooseSingleInputBtn.TabIndex = 2;
            this.chooseSingleInputBtn.Text = "choose Input File";
            this.chooseSingleInputBtn.UseVisualStyleBackColor = true;
            this.chooseSingleInputBtn.Click += new System.EventHandler(this.chooseSingleInputBtn_Click);
            // 
            // alrorithmNameText
            // 
            this.alrorithmNameText.AutoSize = true;
            this.alrorithmNameText.Location = new System.Drawing.Point(136, 19);
            this.alrorithmNameText.Name = "alrorithmNameText";
            this.alrorithmNameText.Size = new System.Drawing.Size(0, 12);
            this.alrorithmNameText.TabIndex = 1;
            // 
            // algorithmName
            // 
            this.algorithmName.AutoSize = true;
            this.algorithmName.Location = new System.Drawing.Point(35, 19);
            this.algorithmName.Name = "algorithmName";
            this.algorithmName.Size = new System.Drawing.Size(95, 12);
            this.algorithmName.TabIndex = 0;
            this.algorithmName.Text = "algorithm Name:";
            this.algorithmName.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabSingle
            // 
            this.tabSingle.Controls.Add(this.tabPage1);
            this.tabSingle.Controls.Add(this.tabBatch);
            this.tabSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSingle.Location = new System.Drawing.Point(0, 0);
            this.tabSingle.Name = "tabSingle";
            this.tabSingle.SelectedIndex = 0;
            this.tabSingle.Size = new System.Drawing.Size(800, 450);
            this.tabSingle.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabSingle);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabBatch.ResumeLayout(false);
            this.panelPlot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panelChoosedFiles.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabSingle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabBatch;
        private System.Windows.Forms.Panel panelPlot;
        private System.Windows.Forms.Panel panelChoosedFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button executeBatchBtn;
        private System.Windows.Forms.Button buttonChooseBatch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBoxInputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button singleExeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseSingleInputBtn;
        private System.Windows.Forms.Label alrorithmNameText;
        private System.Windows.Forms.Label algorithmName;
        private System.Windows.Forms.TabControl tabSingle;
        public System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader time;
        public System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader Result;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}