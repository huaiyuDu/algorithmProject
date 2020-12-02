namespace algorithmProject
{
    partial class Form1
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
            this.navagatorPanel = new System.Windows.Forms.Panel();
            this.panelDevideConquer = new System.Windows.Forms.Panel();
            this.pingpongMenu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripclearLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripStopButton = new System.Windows.Forms.ToolStripButton();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panelMain = new System.Windows.Forms.Panel();
            this.introLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.navagatorPanel.SuspendLayout();
            this.panelDevideConquer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // navagatorPanel
            // 
            this.navagatorPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.navagatorPanel.Controls.Add(this.panelDevideConquer);
            this.navagatorPanel.Controls.Add(this.button1);
            this.navagatorPanel.Controls.Add(this.panel1);
            this.navagatorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navagatorPanel.Location = new System.Drawing.Point(0, 0);
            this.navagatorPanel.Name = "navagatorPanel";
            this.navagatorPanel.Size = new System.Drawing.Size(186, 561);
            this.navagatorPanel.TabIndex = 0;
            // 
            // panelDevideConquer
            // 
            this.panelDevideConquer.Controls.Add(this.pingpongMenu);
            this.panelDevideConquer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDevideConquer.Location = new System.Drawing.Point(0, 140);
            this.panelDevideConquer.Name = "panelDevideConquer";
            this.panelDevideConquer.Size = new System.Drawing.Size(186, 100);
            this.panelDevideConquer.TabIndex = 4;
            // 
            // pingpongMenu
            // 
            this.pingpongMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pingpongMenu.Location = new System.Drawing.Point(0, 0);
            this.pingpongMenu.Name = "pingpongMenu";
            this.pingpongMenu.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.pingpongMenu.Size = new System.Drawing.Size(186, 35);
            this.pingpongMenu.TabIndex = 0;
            this.pingpongMenu.Text = "Ping Pong";
            this.pingpongMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pingpongMenu.UseVisualStyleBackColor = true;
            this.pingpongMenu.Click += new System.EventHandler(this.pingpong_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 100);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(186, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Divide&Conquer";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DivideConquer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.introLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(786, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxLogs);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(186, 311);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 250);
            this.panel2.TabIndex = 3;
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogs.Location = new System.Drawing.Point(0, 25);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(698, 225);
            this.textBoxLogs.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripclearLog,
            this.toolStripStopButton,
            this.progressBar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(698, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripclearLog
            // 
            this.toolStripclearLog.Image = global::algorithmProject.Properties.Resources.bin_closed;
            this.toolStripclearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripclearLog.Name = "toolStripclearLog";
            this.toolStripclearLog.Size = new System.Drawing.Size(56, 22);
            this.toolStripclearLog.Text = "clear";
            this.toolStripclearLog.Click += new System.EventHandler(this.toolStripclearLog_Click);
            // 
            // toolStripStopButton
            // 
            this.toolStripStopButton.Enabled = false;
            this.toolStripStopButton.Image = global::algorithmProject.Properties.Resources.cancel;
            this.toolStripStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStopButton.Name = "toolStripStopButton";
            this.toolStripStopButton.Size = new System.Drawing.Size(54, 22);
            this.toolStripStopButton.Text = "stop";
            this.toolStripStopButton.Click += new System.EventHandler(this.toolStripStopButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 22);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(186, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(698, 311);
            this.panelMain.TabIndex = 4;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // introLabel
            // 
            this.introLabel.AutoSize = true;
            this.introLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(12, 21);
            this.introLabel.Name = "introLabel";
            this.introLabel.Size = new System.Drawing.Size(167, 20);
            this.introLabel.TabIndex = 0;
            this.introLabel.Text = "Advanced Alogrithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "author： \r\nHuaiyu Du\r\nCairong Yang";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "please choose a algorithm ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navagatorPanel);
            this.Name = "Form1";
            this.Text = "Advanced Algorithms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.navagatorPanel.ResumeLayout(false);
            this.panelDevideConquer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel navagatorPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelDevideConquer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button pingpongMenu;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripclearLog;
        public System.Windows.Forms.TextBox textBoxLogs;
        public System.Windows.Forms.ToolStripProgressBar progressBar;
        public System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.Label label3;
    }
}

