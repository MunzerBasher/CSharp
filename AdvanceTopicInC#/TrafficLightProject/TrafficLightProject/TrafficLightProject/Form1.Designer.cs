﻿namespace TrafficLightProject
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
            this.ucTrafficLightProject1 = new TrafficLightProject.UCTrafficLightProject();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucTrafficLightProject1
            // 
            this.ucTrafficLightProject1.Location = new System.Drawing.Point(12, 10);
            this.ucTrafficLightProject1.Name = "ucTrafficLightProject1";
            this.ucTrafficLightProject1.Size = new System.Drawing.Size(915, 664);
            this.ucTrafficLightProject1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button1.Location = new System.Drawing.Point(1058, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 62);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 671);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucTrafficLightProject1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCTrafficLightProject ucTrafficLightProject1;
        private System.Windows.Forms.Button button1;
    }
}

