namespace TrafficLightUserControl
{
    partial class UserControl1
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
            this.PBGreen = new System.Windows.Forms.PictureBox();
            this.PBOrang = new System.Windows.Forms.PictureBox();
            this.PBRed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRed)).BeginInit();
            this.SuspendLayout();
            // 
            // PBGreen
            // 
            this.PBGreen.Image = global::TrafficLightUserControl.Properties.Resources.Green;
            this.PBGreen.Location = new System.Drawing.Point(15, 16);
            this.PBGreen.Name = "PBGreen";
            this.PBGreen.Size = new System.Drawing.Size(269, 467);
            this.PBGreen.TabIndex = 2;
            this.PBGreen.TabStop = false;
            // 
            // PBOrang
            // 
            this.PBOrang.Image = global::TrafficLightUserControl.Properties.Resources.Orange;
            this.PBOrang.Location = new System.Drawing.Point(15, 16);
            this.PBOrang.Name = "PBOrang";
            this.PBOrang.Size = new System.Drawing.Size(269, 467);
            this.PBOrang.TabIndex = 1;
            this.PBOrang.TabStop = false;
            // 
            // PBRed
            // 
            this.PBRed.Image = global::TrafficLightUserControl.Properties.Resources.Red;
            this.PBRed.Location = new System.Drawing.Point(15, 16);
            this.PBRed.Name = "PBRed";
            this.PBRed.Size = new System.Drawing.Size(269, 467);
            this.PBRed.TabIndex = 0;
            this.PBRed.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PBGreen);
            this.Controls.Add(this.PBOrang);
            this.Controls.Add(this.PBRed);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(301, 502);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBRed;
        private System.Windows.Forms.PictureBox PBOrang;
        private System.Windows.Forms.PictureBox PBGreen;
    }
}
