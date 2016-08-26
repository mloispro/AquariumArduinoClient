namespace AquariumArduinoClient
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
            this.btnDetectComPort = new System.Windows.Forms.Button();
            this.lblComPort = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbCmdLog = new System.Windows.Forms.TextBox();
            this.lblPH = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLowPH = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHighPH = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnDetectComPort
            // 
            this.btnDetectComPort.Location = new System.Drawing.Point(12, 30);
            this.btnDetectComPort.Name = "btnDetectComPort";
            this.btnDetectComPort.Size = new System.Drawing.Size(143, 23);
            this.btnDetectComPort.TabIndex = 0;
            this.btnDetectComPort.Text = "Start";
            this.btnDetectComPort.UseVisualStyleBackColor = true;
            this.btnDetectComPort.Click += new System.EventHandler(this.btnDetectComPort_Click);
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(173, 35);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(68, 13);
            this.lblComPort.TabIndex = 1;
            this.lblComPort.Text = "Arduino Port:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 73);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(143, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbCmdLog
            // 
            this.tbCmdLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCmdLog.Location = new System.Drawing.Point(12, 122);
            this.tbCmdLog.Multiline = true;
            this.tbCmdLog.Name = "tbCmdLog";
            this.tbCmdLog.ReadOnly = true;
            this.tbCmdLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCmdLog.Size = new System.Drawing.Size(560, 178);
            this.tbCmdLog.TabIndex = 3;
            this.tbCmdLog.TextChanged += new System.EventHandler(this.tbCmdLog_TextChanged);
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(388, 35);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(25, 13);
            this.lblPH.TabIndex = 4;
            this.lblPH.Text = "PH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Low PH";
            // 
            // tbLowPH
            // 
            this.tbLowPH.Location = new System.Drawing.Point(439, 67);
            this.tbLowPH.Mask = "0.0";
            this.tbLowPH.Name = "tbLowPH";
            this.tbLowPH.Size = new System.Drawing.Size(27, 20);
            this.tbLowPH.TabIndex = 6;
            this.tbLowPH.TextChanged += new System.EventHandler(this.tbLowPH_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "High PH";
            // 
            // tbHighPH
            // 
            this.tbHighPH.Location = new System.Drawing.Point(527, 67);
            this.tbHighPH.Mask = "0.0";
            this.tbHighPH.Name = "tbHighPH";
            this.tbHighPH.Size = new System.Drawing.Size(27, 20);
            this.tbHighPH.TabIndex = 8;
            this.tbHighPH.TextChanged += new System.EventHandler(this.tbHighPH_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 312);
            this.Controls.Add(this.tbHighPH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLowPH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPH);
            this.Controls.Add(this.tbCmdLog);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblComPort);
            this.Controls.Add(this.btnDetectComPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetectComPort;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox tbCmdLog;
        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbLowPH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbHighPH;
    }
}

