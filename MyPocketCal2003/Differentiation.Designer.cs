namespace MyPocketCal2003
{
    partial class Differentiation
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 176);
            // 
            // basicButtonsPanel
            // 
            this.basicButtonsPanel.Location = new System.Drawing.Point(0, 244);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 21);
            this.button1.TabIndex = 24;
            this.button1.Text = "Calculate";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(34, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 21);
            this.textBox2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.Text = "  x:";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(0, 28);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(231, 21);
            this.inputBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.Text = "f(x)=";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.Text = "f \'(x)=";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(0, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(231, 21);
            this.textBox3.TabIndex = 38;
            // 
            // Differentiation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.label1);
            this.Name = "Differentiation";
            this.Text = "Differentiation";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.inputBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.basicButtonsPanel, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
    }
}