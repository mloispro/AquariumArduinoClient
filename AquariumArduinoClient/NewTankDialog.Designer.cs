namespace AquariumArduinoClient
{
    partial class NewTankDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTankDialog));
            this.btnNewTankOk = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewTankCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewTankOk
            // 
            this.btnNewTankOk.Location = new System.Drawing.Point(71, 72);
            this.btnNewTankOk.Name = "btnNewTankOk";
            this.btnNewTankOk.Size = new System.Drawing.Size(75, 23);
            this.btnNewTankOk.TabIndex = 0;
            this.btnNewTankOk.Text = "Ok";
            this.btnNewTankOk.UseVisualStyleBackColor = true;
            this.btnNewTankOk.Click += new System.EventHandler(this.btnNewTankOk_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // btnNewTankCancel
            // 
            this.btnNewTankCancel.Location = new System.Drawing.Point(163, 72);
            this.btnNewTankCancel.Name = "btnNewTankCancel";
            this.btnNewTankCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNewTankCancel.TabIndex = 3;
            this.btnNewTankCancel.Text = "Cancel";
            this.btnNewTankCancel.UseVisualStyleBackColor = true;
            this.btnNewTankCancel.Click += new System.EventHandler(this.btnNewTankCancel_Click);
            // 
            // NewTankDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(this.btnNewTankCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnNewTankOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTankDialog";
            this.Text = "Add New Tank";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewTankOk;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewTankCancel;
    }
}