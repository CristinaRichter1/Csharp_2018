namespace temaCsharp
{
    partial class StatsForm
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
            this.pieChartControl1 = new temaCsharp.Library.PieChartControl();
            this.SuspendLayout();
            // 
            // pieChartControl1
            // 
            this.pieChartControl1.BackColor = System.Drawing.Color.White;
            this.pieChartControl1.Location = new System.Drawing.Point(1, -1);
            this.pieChartControl1.Name = "pieChartControl1";
            this.pieChartControl1.Size = new System.Drawing.Size(458, 363);
            this.pieChartControl1.TabIndex = 0;
            this.pieChartControl1.Load += new System.EventHandler(this.pieChartControl1_Load);
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 362);
            this.Controls.Add(this.pieChartControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatsForm";
            this.ShowIcon = false;
            this.Text = "Hardware platform usage";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Library.PieChartControl pieChartControl1;
    }
}