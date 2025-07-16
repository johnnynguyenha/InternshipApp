namespace InternshipApp
{
    partial class Script
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
            this.addButton = new System.Windows.Forms.Button();
            this.loopLabel = new System.Windows.Forms.Label();
            this.loopTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scriptTextBox = new System.Windows.Forms.TextBox();
            this.commandBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.amount2TextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.runScriptButton = new System.Windows.Forms.Button();
            this.loadScriptButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 307);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(92, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // loopLabel
            // 
            this.loopLabel.AutoSize = true;
            this.loopLabel.Location = new System.Drawing.Point(637, 30);
            this.loopLabel.Name = "loopLabel";
            this.loopLabel.Size = new System.Drawing.Size(151, 16);
            this.loopLabel.TabIndex = 2;
            this.loopLabel.Text = "Amount of Times to Run:";
            // 
            // loopTextBox
            // 
            this.loopTextBox.Location = new System.Drawing.Point(640, 51);
            this.loopTextBox.Name = "loopTextBox";
            this.loopTextBox.Size = new System.Drawing.Size(100, 22);
            this.loopTextBox.TabIndex = 3;
            this.loopTextBox.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.scriptTextBox);
            this.groupBox1.Location = new System.Drawing.Point(330, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 385);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script";
            // 
            // scriptTextBox
            // 
            this.scriptTextBox.Location = new System.Drawing.Point(7, 20);
            this.scriptTextBox.Multiline = true;
            this.scriptTextBox.Name = "scriptTextBox";
            this.scriptTextBox.ReadOnly = true;
            this.scriptTextBox.Size = new System.Drawing.Size(288, 288);
            this.scriptTextBox.TabIndex = 0;
            // 
            // commandBox
            // 
            this.commandBox.FormattingEnabled = true;
            this.commandBox.Location = new System.Drawing.Point(6, 21);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(121, 24);
            this.commandBox.TabIndex = 5;
            this.commandBox.SelectedIndexChanged += new System.EventHandler(this.commandBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.amount2TextBox);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Controls.Add(this.amountTextBox);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.commandBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 347);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // amount2TextBox
            // 
            this.amount2TextBox.Location = new System.Drawing.Point(149, 279);
            this.amount2TextBox.Name = "amount2TextBox";
            this.amount2TextBox.Size = new System.Drawing.Size(104, 22);
            this.amount2TextBox.TabIndex = 8;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(6, 279);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(104, 22);
            this.amountTextBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(149, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(137, 179);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(6, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 179);
            this.panel1.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(652, 337);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 33);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save Script";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // runScriptButton
            // 
            this.runScriptButton.Location = new System.Drawing.Point(652, 291);
            this.runScriptButton.Name = "runScriptButton";
            this.runScriptButton.Size = new System.Drawing.Size(123, 33);
            this.runScriptButton.TabIndex = 8;
            this.runScriptButton.Text = "Run Script";
            this.runScriptButton.UseVisualStyleBackColor = true;
            this.runScriptButton.Click += new System.EventHandler(this.runScriptButton_Click);
            // 
            // loadScriptButton
            // 
            this.loadScriptButton.Location = new System.Drawing.Point(652, 383);
            this.loadScriptButton.Name = "loadScriptButton";
            this.loadScriptButton.Size = new System.Drawing.Size(123, 33);
            this.loadScriptButton.TabIndex = 9;
            this.loadScriptButton.Text = "Load Script";
            this.loadScriptButton.UseVisualStyleBackColor = true;
            this.loadScriptButton.Click += new System.EventHandler(this.loadScriptButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 316);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 20);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Edit Script";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(149, 306);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(92, 30);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Delete Line";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(203, 349);
            this.clearButton.Name = "clearButton";
            this.clearButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clearButton.Size = new System.Drawing.Size(92, 30);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear Script";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Script
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadScriptButton);
            this.Controls.Add(this.runScriptButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loopTextBox);
            this.Controls.Add(this.loopLabel);
            this.Name = "Script";
            this.Text = "Script";
            this.Load += new System.EventHandler(this.Script_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label loopLabel;
        private System.Windows.Forms.TextBox loopTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox commandBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox scriptTextBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button runScriptButton;
        private System.Windows.Forms.Button loadScriptButton;
        private System.Windows.Forms.TextBox amount2TextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
    }
}