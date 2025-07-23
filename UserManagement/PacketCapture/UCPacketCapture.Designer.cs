namespace InternshipApp.PacketCapture
{
    partial class UCPacketCapture
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.networkInterfaceGroupBox = new System.Windows.Forms.GroupBox();
            this.networkTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.networkChoiceBox = new System.Windows.Forms.ComboBox();
            this.packetsDataGridView = new System.Windows.Forms.DataGridView();
            this.networkInterfaceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // networkInterfaceGroupBox
            // 
            this.networkInterfaceGroupBox.Controls.Add(this.networkTextBox);
            this.networkInterfaceGroupBox.Controls.Add(this.stopButton);
            this.networkInterfaceGroupBox.Controls.Add(this.startButton);
            this.networkInterfaceGroupBox.Controls.Add(this.networkChoiceBox);
            this.networkInterfaceGroupBox.Location = new System.Drawing.Point(9, 8);
            this.networkInterfaceGroupBox.Name = "networkInterfaceGroupBox";
            this.networkInterfaceGroupBox.Size = new System.Drawing.Size(955, 150);
            this.networkInterfaceGroupBox.TabIndex = 7;
            this.networkInterfaceGroupBox.TabStop = false;
            this.networkInterfaceGroupBox.Text = "Network Interface";
            this.networkInterfaceGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // networkTextBox
            // 
            this.networkTextBox.Location = new System.Drawing.Point(6, 52);
            this.networkTextBox.Multiline = true;
            this.networkTextBox.Name = "networkTextBox";
            this.networkTextBox.Size = new System.Drawing.Size(942, 89);
            this.networkTextBox.TabIndex = 3;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(808, 21);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(140, 23);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click_1);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(645, 21);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(140, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // networkChoiceBox
            // 
            this.networkChoiceBox.FormattingEnabled = true;
            this.networkChoiceBox.Location = new System.Drawing.Point(6, 21);
            this.networkChoiceBox.Name = "networkChoiceBox";
            this.networkChoiceBox.Size = new System.Drawing.Size(620, 24);
            this.networkChoiceBox.TabIndex = 0;
            // 
            // packetsDataGridView
            // 
            this.packetsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.packetsDataGridView.Location = new System.Drawing.Point(15, 164);
            this.packetsDataGridView.Name = "packetsDataGridView";
            this.packetsDataGridView.RowHeadersWidth = 51;
            this.packetsDataGridView.RowTemplate.Height = 24;
            this.packetsDataGridView.Size = new System.Drawing.Size(1111, 478);
            this.packetsDataGridView.TabIndex = 8;
            this.packetsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // UCPacketCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.networkInterfaceGroupBox);
            this.Controls.Add(this.packetsDataGridView);
            this.Name = "UCPacketCapture";
            this.Size = new System.Drawing.Size(1142, 648);
            this.Load += new System.EventHandler(this.UCPacketCapture_Load);
            this.networkInterfaceGroupBox.ResumeLayout(false);
            this.networkInterfaceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.packetsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox networkInterfaceGroupBox;
        private System.Windows.Forms.TextBox networkTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox networkChoiceBox;
        private System.Windows.Forms.DataGridView packetsDataGridView;
    }
}
