namespace AquariumArduinoClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblPH = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tbReadings = new System.Windows.Forms.TabPage();
            this.tbCmdLog = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblTDS = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTDSOffset = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLowPH = new System.Windows.Forms.MaskedTextBox();
            this.tbHighPH = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPHOffset = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOffsetNegative = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSensorIP4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSensorIP3 = new System.Windows.Forms.TextBox();
            this.tbSensorIP2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSensorIP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timerGetSensorData = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGetSenValsEvery = new System.Windows.Forms.MaskedTextBox();
            this.tabSettings.SuspendLayout();
            this.tbReadings.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(27, 12);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(25, 13);
            this.lblPH.TabIndex = 4;
            this.lblPH.Text = "PH:";
            // 
            // tabSettings
            // 
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.tbReadings);
            this.tabSettings.Controls.Add(this.tabPageSettings);
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(584, 285);
            this.tabSettings.TabIndex = 12;
            // 
            // tbReadings
            // 
            this.tbReadings.Controls.Add(this.tbCmdLog);
            this.tbReadings.Controls.Add(this.btnRead);
            this.tbReadings.Controls.Add(this.lblTDS);
            this.tbReadings.Controls.Add(this.lblPH);
            this.tbReadings.Location = new System.Drawing.Point(4, 22);
            this.tbReadings.Name = "tbReadings";
            this.tbReadings.Padding = new System.Windows.Forms.Padding(3);
            this.tbReadings.Size = new System.Drawing.Size(576, 259);
            this.tbReadings.TabIndex = 0;
            this.tbReadings.Text = "Readings";
            this.tbReadings.UseVisualStyleBackColor = true;
            // 
            // tbCmdLog
            // 
            this.tbCmdLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbCmdLog.Location = new System.Drawing.Point(3, 102);
            this.tbCmdLog.Multiline = true;
            this.tbCmdLog.Name = "tbCmdLog";
            this.tbCmdLog.ReadOnly = true;
            this.tbCmdLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCmdLog.Size = new System.Drawing.Size(570, 154);
            this.tbCmdLog.TabIndex = 14;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(306, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 13;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblTDS
            // 
            this.lblTDS.AutoSize = true;
            this.lblTDS.Location = new System.Drawing.Point(6, 39);
            this.lblTDS.Name = "lblTDS";
            this.lblTDS.Size = new System.Drawing.Size(32, 13);
            this.lblTDS.TabIndex = 12;
            this.lblTDS.Text = "TDS:";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.tbGetSenValsEvery);
            this.tabPageSettings.Controls.Add(this.label9);
            this.tabPageSettings.Controls.Add(this.panel1);
            this.tabPageSettings.Controls.Add(this.label7);
            this.tabPageSettings.Controls.Add(this.tbSensorIP4);
            this.tabPageSettings.Controls.Add(this.label6);
            this.tabPageSettings.Controls.Add(this.tbSensorIP3);
            this.tabPageSettings.Controls.Add(this.tbSensorIP2);
            this.tabPageSettings.Controls.Add(this.label5);
            this.tabPageSettings.Controls.Add(this.tbSensorIP1);
            this.tabPageSettings.Controls.Add(this.label4);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(576, 259);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbTDSOffset);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbLowPH);
            this.panel1.Controls.Add(this.tbHighPH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPHOffset);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbOffsetNegative);
            this.panel1.Location = new System.Drawing.Point(175, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 106);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Low PH";
            // 
            // tbTDSOffset
            // 
            this.tbTDSOffset.Location = new System.Drawing.Point(69, 73);
            this.tbTDSOffset.Mask = "0000";
            this.tbTDSOffset.Name = "tbTDSOffset";
            this.tbTDSOffset.Size = new System.Drawing.Size(36, 20);
            this.tbTDSOffset.TabIndex = 15;
            this.tbTDSOffset.Leave += new System.EventHandler(this.tbTDSOffset_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "TDS Offset";
            // 
            // tbLowPH
            // 
            this.tbLowPH.Location = new System.Drawing.Point(69, 13);
            this.tbLowPH.Mask = "0.0";
            this.tbLowPH.Name = "tbLowPH";
            this.tbLowPH.Size = new System.Drawing.Size(27, 20);
            this.tbLowPH.TabIndex = 6;
            this.tbLowPH.Leave += new System.EventHandler(this.tbLowPH_TextChanged);
            // 
            // tbHighPH
            // 
            this.tbHighPH.Location = new System.Drawing.Point(170, 13);
            this.tbHighPH.Mask = "0.0";
            this.tbHighPH.Name = "tbHighPH";
            this.tbHighPH.Size = new System.Drawing.Size(27, 20);
            this.tbHighPH.TabIndex = 8;
            this.tbHighPH.Leave += new System.EventHandler(this.tbHighPH_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "High PH";
            // 
            // tbPHOffset
            // 
            this.tbPHOffset.Location = new System.Drawing.Point(69, 44);
            this.tbPHOffset.Mask = "0.0";
            this.tbPHOffset.Name = "tbPHOffset";
            this.tbPHOffset.Size = new System.Drawing.Size(27, 20);
            this.tbPHOffset.TabIndex = 10;
            this.tbPHOffset.Leave += new System.EventHandler(this.tbOffset_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "PH Offset";
            // 
            // cbOffsetNegative
            // 
            this.cbOffsetNegative.AutoSize = true;
            this.cbOffsetNegative.Location = new System.Drawing.Point(130, 47);
            this.cbOffsetNegative.Name = "cbOffsetNegative";
            this.cbOffsetNegative.Size = new System.Drawing.Size(67, 17);
            this.cbOffsetNegative.TabIndex = 11;
            this.cbOffsetNegative.Text = "negative";
            this.cbOffsetNegative.UseVisualStyleBackColor = true;
            this.cbOffsetNegative.CheckedChanged += new System.EventHandler(this.cbOffsetNegative_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(192, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = ".";
            // 
            // tbSensorIP4
            // 
            this.tbSensorIP4.Location = new System.Drawing.Point(208, 12);
            this.tbSensorIP4.MaxLength = 3;
            this.tbSensorIP4.Name = "tbSensorIP4";
            this.tbSensorIP4.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP4.TabIndex = 10;
            this.tbSensorIP4.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(148, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = ".";
            // 
            // tbSensorIP3
            // 
            this.tbSensorIP3.Location = new System.Drawing.Point(164, 12);
            this.tbSensorIP3.MaxLength = 3;
            this.tbSensorIP3.Name = "tbSensorIP3";
            this.tbSensorIP3.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP3.TabIndex = 8;
            this.tbSensorIP3.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // tbSensorIP2
            // 
            this.tbSensorIP2.Location = new System.Drawing.Point(119, 12);
            this.tbSensorIP2.MaxLength = 3;
            this.tbSensorIP2.Name = "tbSensorIP2";
            this.tbSensorIP2.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP2.TabIndex = 7;
            this.tbSensorIP2.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = ".";
            // 
            // tbSensorIP1
            // 
            this.tbSensorIP1.Location = new System.Drawing.Point(73, 12);
            this.tbSensorIP1.MaxLength = 3;
            this.tbSensorIP1.Name = "tbSensorIP1";
            this.tbSensorIP1.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP1.TabIndex = 5;
            this.tbSensorIP1.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sensor IP: ";
            // 
            // timerGetSensorData
            // 
            this.timerGetSensorData.Interval = 30000;
            this.timerGetSensorData.Tick += new System.EventHandler(this.timerGetSensorData_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus,
            this.lblStatusMsg});
            this.statusBar.Location = new System.Drawing.Point(0, 288);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(584, 24);
            this.statusBar.TabIndex = 16;
            this.statusBar.Text = "statusBar";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(104, 19);
            this.lblConnectionStatus.Text = "Connection Status";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(69, 19);
            this.lblStatusMsg.Text = "Status Msg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Get Sensor Vals Every (Min): ";
            // 
            // tbGetSenValsEvery
            // 
            this.tbGetSenValsEvery.Location = new System.Drawing.Point(152, 46);
            this.tbGetSenValsEvery.Mask = "00";
            this.tbGetSenValsEvery.Name = "tbGetSenValsEvery";
            this.tbGetSenValsEvery.Size = new System.Drawing.Size(36, 20);
            this.tbGetSenValsEvery.TabIndex = 19;
            this.tbGetSenValsEvery.Leave += new System.EventHandler(this.tbGetSenValsEvery_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Aquarium Arduino Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabSettings.ResumeLayout(false);
            this.tbReadings.ResumeLayout(false);
            this.tbReadings.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tbReadings;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Label lblTDS;
        private System.Windows.Forms.Timer timerGetSensorData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSensorIP1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSensorIP3;
        private System.Windows.Forms.TextBox tbSensorIP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSensorIP4;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbCmdLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbTDSOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbLowPH;
        private System.Windows.Forms.MaskedTextBox tbHighPH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbPHOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbOffsetNegative;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
        private System.Windows.Forms.MaskedTextBox tbGetSenValsEvery;
        private System.Windows.Forms.Label label9;
    }
}

