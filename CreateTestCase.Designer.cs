namespace algorithmProject
{
    partial class CreateTestCase
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nSeries = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.caseNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outputPath = new System.Windows.Forms.TextBox();
            this.chooseOutputPathBtn = new System.Windows.Forms.Button();
            this.createTestCaseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createTestCaseButton);
            this.panel1.Controls.Add(this.chooseOutputPathBtn);
            this.panel1.Controls.Add(this.outputPath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.caseNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nSeries);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // nSeries
            // 
            this.nSeries.Location = new System.Drawing.Point(120, 12);
            this.nSeries.Name = "nSeries";
            this.nSeries.Size = new System.Drawing.Size(394, 21);
            this.nSeries.TabIndex = 0;
            this.nSeries.Text = "10,100,500,1000,5000";
            this.nSeries.TextChanged += new System.EventHandler(this.nSeries_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "N size series:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "case number for each N:";
            // 
            // caseNumber
            // 
            this.caseNumber.Location = new System.Drawing.Point(188, 40);
            this.caseNumber.Name = "caseNumber";
            this.caseNumber.Size = new System.Drawing.Size(326, 21);
            this.caseNumber.TabIndex = 3;
            this.caseNumber.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "output path:";
            // 
            // outputPath
            // 
            this.outputPath.Location = new System.Drawing.Point(120, 68);
            this.outputPath.Name = "outputPath";
            this.outputPath.ReadOnly = true;
            this.outputPath.Size = new System.Drawing.Size(394, 21);
            this.outputPath.TabIndex = 5;
            // 
            // chooseOutputPathBtn
            // 
            this.chooseOutputPathBtn.Location = new System.Drawing.Point(521, 65);
            this.chooseOutputPathBtn.Name = "chooseOutputPathBtn";
            this.chooseOutputPathBtn.Size = new System.Drawing.Size(140, 23);
            this.chooseOutputPathBtn.TabIndex = 6;
            this.chooseOutputPathBtn.Text = "Choose Output Path";
            this.chooseOutputPathBtn.UseVisualStyleBackColor = true;
            this.chooseOutputPathBtn.Click += new System.EventHandler(this.chooseOutputPathBtn_Click);
            // 
            // createTestCaseButton
            // 
            this.createTestCaseButton.Location = new System.Drawing.Point(316, 372);
            this.createTestCaseButton.Name = "createTestCaseButton";
            this.createTestCaseButton.Size = new System.Drawing.Size(140, 23);
            this.createTestCaseButton.TabIndex = 6;
            this.createTestCaseButton.Text = "create";
            this.createTestCaseButton.UseVisualStyleBackColor = true;
            this.createTestCaseButton.Click += new System.EventHandler(this.createTestCaseButton_Click);
            // 
            // CreateTestCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "CreateTestCase";
            this.Text = "CreateTestCase";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button createTestCaseButton;
        private System.Windows.Forms.Button chooseOutputPathBtn;
        private System.Windows.Forms.TextBox outputPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox caseNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nSeries;
    }
}