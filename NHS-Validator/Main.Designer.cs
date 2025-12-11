namespace NHSValidator
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNHSNumber = new TextBox();
            lblStatus = new Label();
            rtbNumbers = new RichTextBox();
            numQty = new NumericUpDown();
            label1 = new Label();
            btnGenerate = new Button();
            groupBox1 = new GroupBox();
            btnCopyNumbers = new Button();
            label2 = new Label();
            cbValidNumbers = new ComboBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtNHSNumber
            // 
            txtNHSNumber.Location = new Point(6, 34);
            txtNHSNumber.Name = "txtNHSNumber";
            txtNHSNumber.Size = new Size(346, 23);
            txtNHSNumber.TabIndex = 0;
            txtNHSNumber.TextChanged += txtNHSNumber_TextChanged;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(6, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 2;
            // 
            // rtbNumbers
            // 
            rtbNumbers.Location = new Point(6, 22);
            rtbNumbers.Name = "rtbNumbers";
            rtbNumbers.Size = new Size(316, 188);
            rtbNumbers.TabIndex = 3;
            rtbNumbers.Text = "";
            // 
            // numQty
            // 
            numQty.Location = new Point(202, 221);
            numQty.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numQty.Name = "numQty";
            numQty.Size = new Size(120, 23);
            numQty.TabIndex = 4;
            numQty.ValueChanged += numQty_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 223);
            label1.Name = "label1";
            label1.Size = new Size(186, 15);
            label1.TabIndex = 5;
            label1.Text = "How many values would you like?";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(136, 279);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCopyNumbers);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbValidNumbers);
            groupBox1.Controls.Add(rtbNumbers);
            groupBox1.Controls.Add(btnGenerate);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numQty);
            groupBox1.Location = new Point(382, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(328, 314);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "NHS Number Generator";
            // 
            // btnCopyNumbers
            // 
            btnCopyNumbers.Location = new Point(217, 279);
            btnCopyNumbers.Name = "btnCopyNumbers";
            btnCopyNumbers.Size = new Size(105, 23);
            btnCopyNumbers.TabIndex = 9;
            btnCopyNumbers.Text = "Copy Numbers";
            btnCopyNumbers.UseVisualStyleBackColor = true;
            btnCopyNumbers.Click += btnCopyNumbers_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 253);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 8;
            label2.Text = "Should these values be valid?";
            // 
            // cbValidNumbers
            // 
            cbValidNumbers.FormattingEnabled = true;
            cbValidNumbers.Items.AddRange(new object[] { "Yes", "No" });
            cbValidNumbers.Location = new Point(202, 250);
            cbValidNumbers.Name = "cbValidNumbers";
            cbValidNumbers.Size = new Size(120, 23);
            cbValidNumbers.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtNHSNumber);
            groupBox2.Controls.Add(lblStatus);
            groupBox2.Location = new Point(18, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(358, 314);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "NHS Number Validator";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 333);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "Main";
            Text = "NHS Number Validator";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNHSNumber;
        private Label lblStatus;
        private RichTextBox rtbNumbers;
        private NumericUpDown numQty;
        private Label label1;
        private Button btnGenerate;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox cbValidNumbers;
        private GroupBox groupBox2;
        private Button btnCopyNumbers;
    }
}
