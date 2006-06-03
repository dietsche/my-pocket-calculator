namespace MyPocketCal2003
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FinanceTabPage = new System.Windows.Forms.TabPage();
            this.MathTabPage = new System.Windows.Forms.TabPage();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.MatrixTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MathTabPage);
            this.tabControl1.Controls.Add(this.StatisticsTabPage);
            this.tabControl1.Controls.Add(this.MatrixTabPage);
            this.tabControl1.Controls.Add(this.FinanceTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 291);
            this.tabControl1.TabIndex = 0;
            // 
            // FinanceTabPage
            // 
            this.FinanceTabPage.Location = new System.Drawing.Point(0, 0);
            this.FinanceTabPage.Name = "FinanceTabPage";
            this.FinanceTabPage.Size = new System.Drawing.Size(240, 268);
            this.FinanceTabPage.Text = "Finance";
            // 
            // MathTabPage
            // 
            this.MathTabPage.Location = new System.Drawing.Point(0, 0);
            this.MathTabPage.Name = "MathTabPage";
            this.MathTabPage.Size = new System.Drawing.Size(240, 268);
            this.MathTabPage.Text = "Math";
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Location = new System.Drawing.Point(0, 0);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Size = new System.Drawing.Size(240, 268);
            this.StatisticsTabPage.Text = "Statistics";
            // 
            // MatrixTabPage
            // 
            this.MatrixTabPage.Location = new System.Drawing.Point(0, 0);
            this.MatrixTabPage.Name = "MatrixTabPage";
            this.MatrixTabPage.Size = new System.Drawing.Size(240, 268);
            this.MatrixTabPage.Text = "Matrix";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "MyPocketCal";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage FinanceTabPage;
        private System.Windows.Forms.TabPage MathTabPage;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.TabPage MatrixTabPage;

    }
}

