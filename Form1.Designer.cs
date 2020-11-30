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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.navagatorPanel.SuspendLayout();
            this.panelDevideConquer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navagatorPanel
            // 
            this.navagatorPanel.Controls.Add(this.panelDevideConquer);
            this.navagatorPanel.Controls.Add(this.button1);
            this.navagatorPanel.Controls.Add(this.panel1);
            this.navagatorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navagatorPanel.Location = new System.Drawing.Point(0, 0);
            this.navagatorPanel.Name = "navagatorPanel";
            this.navagatorPanel.Size = new System.Drawing.Size(186, 450);
            this.navagatorPanel.TabIndex = 0;
            // 
            // panelDevideConquer
            // 
            this.panelDevideConquer.Controls.Add(this.pingpongMenu);
            this.panelDevideConquer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDevideConquer.Location = new System.Drawing.Point(0, 123);
            this.panelDevideConquer.Name = "panelDevideConquer";
            this.panelDevideConquer.Size = new System.Drawing.Size(186, 100);
            this.panelDevideConquer.TabIndex = 4;
            // 
            // pingpongMenu
            // 
            this.pingpongMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pingpongMenu.Location = new System.Drawing.Point(0, 0);
            this.pingpongMenu.Name = "pingpongMenu";
            this.pingpongMenu.Size = new System.Drawing.Size(186, 23);
            this.pingpongMenu.TabIndex = 0;
            this.pingpongMenu.Text = "Ping Pong";
            this.pingpongMenu.UseVisualStyleBackColor = true;
            this.pingpongMenu.Click += new System.EventHandler(this.pingpong_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Divide&Conquer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DivideConquer_Click);
            // 
            // panel1
            // 
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
            this.panel2.Location = new System.Drawing.Point(186, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 162);
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
            this.textBoxLogs.Size = new System.Drawing.Size(614, 137);
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
            this.toolStrip1.Size = new System.Drawing.Size(614, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripclearLog
            // 
            this.toolStripclearLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripclearLog.Image")));
            this.toolStripclearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripclearLog.Name = "toolStripclearLog";
            this.toolStripclearLog.Size = new System.Drawing.Size(56, 22);
            this.toolStripclearLog.Text = "clear";
            // 
            // toolStripStopButton
            // 
            this.toolStripStopButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStopButton.Image")));
            this.toolStripStopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStopButton.Name = "toolStripStopButton";
            this.toolStripStopButton.Size = new System.Drawing.Size(54, 22);
            this.toolStripStopButton.Text = "stop";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 22);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(186, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(614, 288);
            this.panelMain.TabIndex = 4;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.navagatorPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.navagatorPanel.ResumeLayout(false);
            this.panelDevideConquer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripclearLog;
        private System.Windows.Forms.ToolStripButton toolStripStopButton;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        public System.Windows.Forms.TextBox textBoxLogs;
    }
}

