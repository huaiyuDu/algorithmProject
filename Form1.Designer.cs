﻿namespace algorithmProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDevideConquer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pingpongMenu = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.navagatorPanel.SuspendLayout();
            this.panelDevideConquer.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(786, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 100);
            this.panel1.TabIndex = 0;
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
            // panelDevideConquer
            // 
            this.panelDevideConquer.Controls.Add(this.pingpongMenu);
            this.panelDevideConquer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDevideConquer.Location = new System.Drawing.Point(0, 123);
            this.panelDevideConquer.Name = "panelDevideConquer";
            this.panelDevideConquer.Size = new System.Drawing.Size(186, 100);
            this.panelDevideConquer.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(186, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 162);
            this.panel2.TabIndex = 3;
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
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(186, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(614, 288);
            this.panelMain.TabIndex = 4;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
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
    }
}

