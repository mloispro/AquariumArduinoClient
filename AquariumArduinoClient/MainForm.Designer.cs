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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblAccRunInfo = new System.Windows.Forms.Label();
            this.btnRunNow = new System.Windows.Forms.Button();
            this.cbContrAccInfo = new System.Windows.Forms.ComboBox();
            this.tbCmdLog = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblTDS = new System.Windows.Forms.Label();
            this.tabPageTankSettings = new System.Windows.Forms.TabPage();
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSensorIP4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSensorIP3 = new System.Windows.Forms.TextBox();
            this.tbSensorIP2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSensorIP1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGetSenValsEvery = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddTank = new System.Windows.Forms.Button();
            this.cbTankName = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.tbContIP4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbContIP3 = new System.Windows.Forms.TextBox();
            this.tbContIP2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbContIP1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbGetContValsEvery = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateAcc = new System.Windows.Forms.Button();
            this.dtpNextRun = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.cbRunEvery = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbRunDuration = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.cbContrAccUpdate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.tbROSensorIP4 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbROSensorIP3 = new System.Windows.Forms.TextBox();
            this.tbROSensorIP2 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbROSensorIP1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbGetROSenValsEvery = new System.Windows.Forms.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.timerGetSensorData = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerGetControllerData = new System.Windows.Forms.Timer(this.components);
            this.timerGetROSensorData = new System.Windows.Forms.Timer(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnRORead = new System.Windows.Forms.Button();
            this.lblRoTds = new System.Windows.Forms.Label();
            this.lblRoPH = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.tbReadings.SuspendLayout();
            this.tabPageTankSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(13, 32);
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
            this.tabSettings.Controls.Add(this.tabPageTankSettings);
            this.tabSettings.Controls.Add(this.tabPageSettings);
            this.tabSettings.Location = new System.Drawing.Point(0, 34);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(584, 261);
            this.tabSettings.TabIndex = 12;
            // 
            // tbReadings
            // 
            this.tbReadings.Controls.Add(this.label27);
            this.tbReadings.Controls.Add(this.btnRORead);
            this.tbReadings.Controls.Add(this.lblRoTds);
            this.tbReadings.Controls.Add(this.lblRoPH);
            this.tbReadings.Controls.Add(this.label26);
            this.tbReadings.Controls.Add(this.btnRefresh);
            this.tbReadings.Controls.Add(this.lblAccRunInfo);
            this.tbReadings.Controls.Add(this.btnRunNow);
            this.tbReadings.Controls.Add(this.cbContrAccInfo);
            this.tbReadings.Controls.Add(this.tbCmdLog);
            this.tbReadings.Controls.Add(this.btnRead);
            this.tbReadings.Controls.Add(this.lblTDS);
            this.tbReadings.Controls.Add(this.lblPH);
            this.tbReadings.Location = new System.Drawing.Point(4, 22);
            this.tbReadings.Name = "tbReadings";
            this.tbReadings.Padding = new System.Windows.Forms.Padding(3);
            this.tbReadings.Size = new System.Drawing.Size(576, 235);
            this.tbReadings.TabIndex = 0;
            this.tbReadings.Text = "Readings";
            this.tbReadings.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(440, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 23);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblAccRunInfo
            // 
            this.lblAccRunInfo.AutoSize = true;
            this.lblAccRunInfo.Location = new System.Drawing.Point(304, 40);
            this.lblAccRunInfo.Name = "lblAccRunInfo";
            this.lblAccRunInfo.Size = new System.Drawing.Size(45, 13);
            this.lblAccRunInfo.TabIndex = 17;
            this.lblAccRunInfo.Text = "acc info";
            // 
            // btnRunNow
            // 
            this.btnRunNow.Location = new System.Drawing.Point(507, 10);
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Size = new System.Drawing.Size(61, 23);
            this.btnRunNow.TabIndex = 16;
            this.btnRunNow.Text = "Run Now";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            // 
            // cbContrAccInfo
            // 
            this.cbContrAccInfo.FormattingEnabled = true;
            this.cbContrAccInfo.Location = new System.Drawing.Point(304, 12);
            this.cbContrAccInfo.Name = "cbContrAccInfo";
            this.cbContrAccInfo.Size = new System.Drawing.Size(121, 21);
            this.cbContrAccInfo.TabIndex = 15;
            this.cbContrAccInfo.SelectedIndexChanged += new System.EventHandler(this.cbContrAccInfo_SelectedIndexChanged);
            // 
            // tbCmdLog
            // 
            this.tbCmdLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbCmdLog.Location = new System.Drawing.Point(3, 78);
            this.tbCmdLog.Multiline = true;
            this.tbCmdLog.Name = "tbCmdLog";
            this.tbCmdLog.ReadOnly = true;
            this.tbCmdLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCmdLog.Size = new System.Drawing.Size(570, 154);
            this.tbCmdLog.TabIndex = 14;
            // 
            // btnRead
            // 
            this.btnRead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRead.BackgroundImage")));
            this.btnRead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRead.FlatAppearance.BorderSize = 0;
            this.btnRead.Location = new System.Drawing.Point(67, 6);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(20, 20);
            this.btnRead.TabIndex = 13;
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblTDS
            // 
            this.lblTDS.AutoSize = true;
            this.lblTDS.Location = new System.Drawing.Point(13, 52);
            this.lblTDS.Name = "lblTDS";
            this.lblTDS.Size = new System.Drawing.Size(32, 13);
            this.lblTDS.TabIndex = 12;
            this.lblTDS.Text = "TDS:";
            // 
            // tabPageTankSettings
            // 
            this.tabPageTankSettings.Controls.Add(this.panel1);
            this.tabPageTankSettings.Controls.Add(this.panel6);
            this.tabPageTankSettings.Controls.Add(this.panel3);
            this.tabPageTankSettings.Controls.Add(this.panel2);
            this.tabPageTankSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageTankSettings.Name = "tabPageTankSettings";
            this.tabPageTankSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTankSettings.Size = new System.Drawing.Size(576, 235);
            this.tabPageTankSettings.TabIndex = 2;
            this.tabPageTankSettings.Text = "Aquarium Settings";
            this.tabPageTankSettings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbTDSOffset);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbLowPH);
            this.panel1.Controls.Add(this.tbHighPH);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPHOffset);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbOffsetNegative);
            this.panel1.Location = new System.Drawing.Point(327, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 106);
            this.panel1.TabIndex = 34;
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
            this.tbLowPH.TextChanged += new System.EventHandler(this.tbLowPH_TextChanged);
            // 
            // tbHighPH
            // 
            this.tbHighPH.Location = new System.Drawing.Point(170, 13);
            this.tbHighPH.Mask = "0.0";
            this.tbHighPH.Name = "tbHighPH";
            this.tbHighPH.Size = new System.Drawing.Size(27, 20);
            this.tbHighPH.TabIndex = 8;
            this.tbHighPH.TextChanged += new System.EventHandler(this.tbHighPH_TextChanged);
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
            // panel6
            // 
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.tbGetSenValsEvery);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(327, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(243, 68);
            this.panel6.TabIndex = 33;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.tbSensorIP4);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.tbSensorIP3);
            this.panel5.Controls.Add(this.tbSensorIP2);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.tbSensorIP1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(234, 34);
            this.panel5.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(187, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = ".";
            // 
            // tbSensorIP4
            // 
            this.tbSensorIP4.Location = new System.Drawing.Point(203, 11);
            this.tbSensorIP4.MaxLength = 3;
            this.tbSensorIP4.Name = "tbSensorIP4";
            this.tbSensorIP4.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP4.TabIndex = 18;
            this.tbSensorIP4.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(143, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = ".";
            // 
            // tbSensorIP3
            // 
            this.tbSensorIP3.Location = new System.Drawing.Point(159, 11);
            this.tbSensorIP3.MaxLength = 3;
            this.tbSensorIP3.Name = "tbSensorIP3";
            this.tbSensorIP3.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP3.TabIndex = 16;
            this.tbSensorIP3.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // tbSensorIP2
            // 
            this.tbSensorIP2.Location = new System.Drawing.Point(114, 11);
            this.tbSensorIP2.MaxLength = 3;
            this.tbSensorIP2.Name = "tbSensorIP2";
            this.tbSensorIP2.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP2.TabIndex = 15;
            this.tbSensorIP2.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = ".";
            // 
            // tbSensorIP1
            // 
            this.tbSensorIP1.Location = new System.Drawing.Point(68, 11);
            this.tbSensorIP1.MaxLength = 3;
            this.tbSensorIP1.Name = "tbSensorIP1";
            this.tbSensorIP1.Size = new System.Drawing.Size(28, 20);
            this.tbSensorIP1.TabIndex = 13;
            this.tbSensorIP1.Leave += new System.EventHandler(this.tbSensorIP1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sensor IP: ";
            // 
            // tbGetSenValsEvery
            // 
            this.tbGetSenValsEvery.Location = new System.Drawing.Point(149, 44);
            this.tbGetSenValsEvery.Mask = "00";
            this.tbGetSenValsEvery.Name = "tbGetSenValsEvery";
            this.tbGetSenValsEvery.Size = new System.Drawing.Size(36, 20);
            this.tbGetSenValsEvery.TabIndex = 22;
            this.tbGetSenValsEvery.Leave += new System.EventHandler(this.tbGetSenValsEvery_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Get Sensor Vals Every (Min): ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.tbGetContValsEvery);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(6, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 65);
            this.panel3.TabIndex = 32;
            // 
            // btnAddTank
            // 
            this.btnAddTank.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddTank.Location = new System.Drawing.Point(220, 6);
            this.btnAddTank.Name = "btnAddTank";
            this.btnAddTank.Size = new System.Drawing.Size(22, 23);
            this.btnAddTank.TabIndex = 41;
            this.btnAddTank.Text = "+";
            this.btnAddTank.UseVisualStyleBackColor = true;
            this.btnAddTank.Click += new System.EventHandler(this.btnAddTank_Click);
            // 
            // cbTankName
            // 
            this.cbTankName.FormattingEnabled = true;
            this.cbTankName.Location = new System.Drawing.Point(71, 6);
            this.cbTankName.Name = "cbTankName";
            this.cbTankName.Size = new System.Drawing.Size(143, 21);
            this.cbTankName.TabIndex = 40;
            this.cbTankName.SelectedIndexChanged += new System.EventHandler(this.cbTankName_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 39;
            this.label19.Text = "Tank Name:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.tbContIP4);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.tbContIP3);
            this.panel4.Controls.Add(this.tbContIP2);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.tbContIP1);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 34);
            this.panel4.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(198, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 24);
            this.label10.TabIndex = 43;
            this.label10.Text = ".";
            // 
            // tbContIP4
            // 
            this.tbContIP4.Location = new System.Drawing.Point(214, 7);
            this.tbContIP4.MaxLength = 3;
            this.tbContIP4.Name = "tbContIP4";
            this.tbContIP4.Size = new System.Drawing.Size(28, 20);
            this.tbContIP4.TabIndex = 42;
            this.tbContIP4.Leave += new System.EventHandler(this.tbContIP1_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(154, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 24);
            this.label11.TabIndex = 41;
            this.label11.Text = ".";
            // 
            // tbContIP3
            // 
            this.tbContIP3.Location = new System.Drawing.Point(170, 7);
            this.tbContIP3.MaxLength = 3;
            this.tbContIP3.Name = "tbContIP3";
            this.tbContIP3.Size = new System.Drawing.Size(28, 20);
            this.tbContIP3.TabIndex = 40;
            this.tbContIP3.Leave += new System.EventHandler(this.tbContIP1_Leave);
            // 
            // tbContIP2
            // 
            this.tbContIP2.Location = new System.Drawing.Point(125, 7);
            this.tbContIP2.MaxLength = 3;
            this.tbContIP2.Name = "tbContIP2";
            this.tbContIP2.Size = new System.Drawing.Size(28, 20);
            this.tbContIP2.TabIndex = 39;
            this.tbContIP2.Leave += new System.EventHandler(this.tbContIP1_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(109, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 24);
            this.label12.TabIndex = 38;
            this.label12.Text = ".";
            // 
            // tbContIP1
            // 
            this.tbContIP1.Location = new System.Drawing.Point(79, 7);
            this.tbContIP1.MaxLength = 3;
            this.tbContIP1.Name = "tbContIP1";
            this.tbContIP1.Size = new System.Drawing.Size(28, 20);
            this.tbContIP1.TabIndex = 37;
            this.tbContIP1.Leave += new System.EventHandler(this.tbContIP1_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Controller IP: ";
            // 
            // tbGetContValsEvery
            // 
            this.tbGetContValsEvery.Location = new System.Drawing.Point(159, 40);
            this.tbGetContValsEvery.Mask = "00";
            this.tbGetContValsEvery.Name = "tbGetContValsEvery";
            this.tbGetContValsEvery.Size = new System.Drawing.Size(36, 20);
            this.tbGetContValsEvery.TabIndex = 37;
            this.tbGetContValsEvery.Leave += new System.EventHandler(this.tbGetContValsEvery_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Get Controller Vals Every (Min): ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnUpdateAcc);
            this.panel2.Controls.Add(this.dtpNextRun);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.cbRunEvery);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.cbRunDuration);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cbEnabled);
            this.panel2.Controls.Add(this.cbContrAccUpdate);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(6, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 153);
            this.panel2.TabIndex = 31;
            // 
            // btnUpdateAcc
            // 
            this.btnUpdateAcc.Location = new System.Drawing.Point(106, 122);
            this.btnUpdateAcc.Name = "btnUpdateAcc";
            this.btnUpdateAcc.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAcc.TabIndex = 25;
            this.btnUpdateAcc.Text = "Update";
            this.btnUpdateAcc.UseVisualStyleBackColor = true;
            this.btnUpdateAcc.Click += new System.EventHandler(this.btnUpdateAcc_Click);
            // 
            // dtpNextRun
            // 
            this.dtpNextRun.CustomFormat = "MM/dd/yyyy h:mm tt";
            this.dtpNextRun.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNextRun.Location = new System.Drawing.Point(79, 96);
            this.dtpNextRun.MinDate = new System.DateTime(2000, 10, 25, 0, 0, 0, 0);
            this.dtpNextRun.Name = "dtpNextRun";
            this.dtpNextRun.Size = new System.Drawing.Size(200, 20);
            this.dtpNextRun.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "Next Run: ";
            // 
            // cbRunEvery
            // 
            this.cbRunEvery.FormattingEnabled = true;
            this.cbRunEvery.Location = new System.Drawing.Point(79, 68);
            this.cbRunEvery.Name = "cbRunEvery";
            this.cbRunEvery.Size = new System.Drawing.Size(200, 21);
            this.cbRunEvery.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 71);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Run: ";
            // 
            // cbRunDuration
            // 
            this.cbRunDuration.FormattingEnabled = true;
            this.cbRunDuration.Location = new System.Drawing.Point(79, 41);
            this.cbRunDuration.Name = "cbRunDuration";
            this.cbRunDuration.Size = new System.Drawing.Size(79, 21);
            this.cbRunDuration.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(164, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Minutes";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Run Duration: ";
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(223, 15);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 16;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // cbContrAccUpdate
            // 
            this.cbContrAccUpdate.FormattingEnabled = true;
            this.cbContrAccUpdate.Location = new System.Drawing.Point(78, 13);
            this.cbContrAccUpdate.Name = "cbContrAccUpdate";
            this.cbContrAccUpdate.Size = new System.Drawing.Size(121, 21);
            this.cbContrAccUpdate.TabIndex = 7;
            this.cbContrAccUpdate.SelectedIndexChanged += new System.EventHandler(this.cbContrAccUpdate_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Accessory: ";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.panel7);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(576, 235);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "RO Tank Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.tbGetROSenValsEvery);
            this.panel7.Controls.Add(this.label25);
            this.panel7.Location = new System.Drawing.Point(8, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(254, 68);
            this.panel7.TabIndex = 34;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label21);
            this.panel8.Controls.Add(this.tbROSensorIP4);
            this.panel8.Controls.Add(this.label22);
            this.panel8.Controls.Add(this.tbROSensorIP3);
            this.panel8.Controls.Add(this.tbROSensorIP2);
            this.panel8.Controls.Add(this.label23);
            this.panel8.Controls.Add(this.tbROSensorIP1);
            this.panel8.Controls.Add(this.label24);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(248, 34);
            this.panel8.TabIndex = 23;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(201, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 24);
            this.label21.TabIndex = 19;
            this.label21.Text = ".";
            // 
            // tbROSensorIP4
            // 
            this.tbROSensorIP4.Location = new System.Drawing.Point(217, 11);
            this.tbROSensorIP4.MaxLength = 3;
            this.tbROSensorIP4.Name = "tbROSensorIP4";
            this.tbROSensorIP4.Size = new System.Drawing.Size(28, 20);
            this.tbROSensorIP4.TabIndex = 18;
            this.tbROSensorIP4.Leave += new System.EventHandler(this.tbROSensorIP1_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(157, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 24);
            this.label22.TabIndex = 17;
            this.label22.Text = ".";
            // 
            // tbROSensorIP3
            // 
            this.tbROSensorIP3.Location = new System.Drawing.Point(173, 11);
            this.tbROSensorIP3.MaxLength = 3;
            this.tbROSensorIP3.Name = "tbROSensorIP3";
            this.tbROSensorIP3.Size = new System.Drawing.Size(28, 20);
            this.tbROSensorIP3.TabIndex = 16;
            this.tbROSensorIP3.Leave += new System.EventHandler(this.tbROSensorIP1_Leave);
            // 
            // tbROSensorIP2
            // 
            this.tbROSensorIP2.Location = new System.Drawing.Point(128, 11);
            this.tbROSensorIP2.MaxLength = 3;
            this.tbROSensorIP2.Name = "tbROSensorIP2";
            this.tbROSensorIP2.Size = new System.Drawing.Size(28, 20);
            this.tbROSensorIP2.TabIndex = 15;
            this.tbROSensorIP2.Leave += new System.EventHandler(this.tbROSensorIP1_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(112, 11);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 24);
            this.label23.TabIndex = 14;
            this.label23.Text = ".";
            // 
            // tbROSensorIP1
            // 
            this.tbROSensorIP1.Location = new System.Drawing.Point(82, 11);
            this.tbROSensorIP1.MaxLength = 3;
            this.tbROSensorIP1.Name = "tbROSensorIP1";
            this.tbROSensorIP1.Size = new System.Drawing.Size(28, 20);
            this.tbROSensorIP1.TabIndex = 13;
            this.tbROSensorIP1.Leave += new System.EventHandler(this.tbROSensorIP1_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "RO Sensor IP: ";
            // 
            // tbGetROSenValsEvery
            // 
            this.tbGetROSenValsEvery.Location = new System.Drawing.Point(170, 43);
            this.tbGetROSenValsEvery.Mask = "00";
            this.tbGetROSenValsEvery.Name = "tbGetROSenValsEvery";
            this.tbGetROSenValsEvery.Size = new System.Drawing.Size(36, 20);
            this.tbGetROSenValsEvery.TabIndex = 22;
            this.tbGetROSenValsEvery.TextChanged += new System.EventHandler(this.tbGetROSenValsEvery_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(164, 13);
            this.label25.TabIndex = 21;
            this.label25.Text = "Get RO Sensor Vals Every (Min): ";
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
            this.statusBar.Location = new System.Drawing.Point(0, 298);
            this.statusBar.Name = "statusBar";
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusBar.Size = new System.Drawing.Size(584, 24);
            this.statusBar.SizingGrip = false;
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
            // timerGetControllerData
            // 
            this.timerGetControllerData.Interval = 2400000;
            this.timerGetControllerData.Tick += new System.EventHandler(this.timerGetControllerData_Tick);
            // 
            // timerGetROSensorData
            // 
            this.timerGetROSensorData.Interval = 30000;
            this.timerGetROSensorData.Tick += new System.EventHandler(this.timerGetROSensorData_Tick);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(8, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 19;
            this.label26.Text = "Aquarium";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(109, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 13);
            this.label27.TabIndex = 23;
            this.label27.Text = "RO Tank";
            // 
            // btnRORead
            // 
            this.btnRORead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRORead.BackgroundImage")));
            this.btnRORead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRORead.FlatAppearance.BorderSize = 0;
            this.btnRORead.Location = new System.Drawing.Point(168, 6);
            this.btnRORead.Name = "btnRORead";
            this.btnRORead.Size = new System.Drawing.Size(20, 20);
            this.btnRORead.TabIndex = 22;
            this.btnRORead.UseVisualStyleBackColor = true;
            this.btnRORead.Click += new System.EventHandler(this.btnRORead_Click);
            // 
            // lblRoTds
            // 
            this.lblRoTds.AutoSize = true;
            this.lblRoTds.Location = new System.Drawing.Point(114, 52);
            this.lblRoTds.Name = "lblRoTds";
            this.lblRoTds.Size = new System.Drawing.Size(32, 13);
            this.lblRoTds.TabIndex = 21;
            this.lblRoTds.Text = "TDS:";
            // 
            // lblRoPH
            // 
            this.lblRoPH.AutoSize = true;
            this.lblRoPH.Location = new System.Drawing.Point(114, 32);
            this.lblRoPH.Name = "lblRoPH";
            this.lblRoPH.Size = new System.Drawing.Size(25, 13);
            this.lblRoPH.TabIndex = 20;
            this.lblRoPH.Text = "PH:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 322);
            this.Controls.Add(this.btnAddTank);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.cbTankName);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Aquarium Arduino Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabSettings.ResumeLayout(false);
            this.tbReadings.ResumeLayout(false);
            this.tbReadings.PerformLayout();
            this.tabPageTankSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
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
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox tbCmdLog;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
        private System.Windows.Forms.Timer timerGetControllerData;
        private System.Windows.Forms.ComboBox cbContrAccInfo;
        private System.Windows.Forms.Button btnRunNow;
        private System.Windows.Forms.Label lblAccRunInfo;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Timer timerGetROSensorData;
        private System.Windows.Forms.TabPage tabPageTankSettings;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdateAcc;
        private System.Windows.Forms.DateTimePicker dtpNextRun;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbRunEvery;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbRunDuration;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.ComboBox cbContrAccUpdate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddTank;
        private System.Windows.Forms.ComboBox cbTankName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbContIP4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbContIP3;
        private System.Windows.Forms.TextBox tbContIP2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbContIP1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox tbGetContValsEvery;
        private System.Windows.Forms.Label label14;
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
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSensorIP4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSensorIP3;
        private System.Windows.Forms.TextBox tbSensorIP2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSensorIP1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbGetSenValsEvery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbROSensorIP4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbROSensorIP3;
        private System.Windows.Forms.TextBox tbROSensorIP2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tbROSensorIP1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.MaskedTextBox tbGetROSenValsEvery;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnRORead;
        private System.Windows.Forms.Label lblRoTds;
        private System.Windows.Forms.Label lblRoPH;
    }
}

