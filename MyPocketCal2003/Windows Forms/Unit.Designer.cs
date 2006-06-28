namespace MyPocketCal2003
{
    partial class CUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CUnit));
            this.label1 = new System.Windows.Forms.Label();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.quantitiesListBox = new System.Windows.Forms.ListBox();
            this.unitListbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.convertToComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.basicButtonsPanel = new System.Windows.Forms.Panel();
            this.undoButton = new System.Windows.Forms.PictureBox();
            this.EButton = new System.Windows.Forms.PictureBox();
            this.rightBracketButton = new System.Windows.Forms.PictureBox();
            this.nineButton = new System.Windows.Forms.PictureBox();
            this.CButton = new System.Windows.Forms.PictureBox();
            this.eightButton = new System.Windows.Forms.PictureBox();
            this.sevenButton = new System.Windows.Forms.PictureBox();
            this.FButton = new System.Windows.Forms.PictureBox();
            this.DButton = new System.Windows.Forms.PictureBox();
            this.BButton = new System.Windows.Forms.PictureBox();
            this.AButton = new System.Windows.Forms.PictureBox();
            this.fourButton = new System.Windows.Forms.PictureBox();
            this.fiveButton = new System.Windows.Forms.PictureBox();
            this.sixButton = new System.Windows.Forms.PictureBox();
            this.oneButton = new System.Windows.Forms.PictureBox();
            this.twoButton = new System.Windows.Forms.PictureBox();
            this.threeButton = new System.Windows.Forms.PictureBox();
            this.equalButton = new System.Windows.Forms.PictureBox();
            this.decimalButton = new System.Windows.Forms.PictureBox();
            this.zeroButton = new System.Windows.Forms.PictureBox();
            this.basicButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.Text = "Quantity:";
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(4, 217);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(233, 21);
            this.outputBox.TabIndex = 9;
            this.outputBox.Text = "=";
            // 
            // quantitiesListBox
            // 
            this.quantitiesListBox.Location = new System.Drawing.Point(1, 19);
            this.quantitiesListBox.Name = "quantitiesListBox";
            this.quantitiesListBox.Size = new System.Drawing.Size(135, 128);
            this.quantitiesListBox.TabIndex = 16;
            this.quantitiesListBox.SelectedIndexChanged += new System.EventHandler(this.quantitiesListBox_SelectedIndexChanged);
            // 
            // unitListbox
            // 
            this.unitListbox.Location = new System.Drawing.Point(137, 19);
            this.unitListbox.Name = "unitListbox";
            this.unitListbox.Size = new System.Drawing.Size(100, 128);
            this.unitListbox.TabIndex = 18;
            this.unitListbox.SelectedIndexChanged += new System.EventHandler(this.unitListbox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(137, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.Text = "Input Unit:";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(4, 153);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(233, 21);
            this.inputBox.TabIndex = 21;
            // 
            // convertToComboBox
            // 
            this.convertToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.convertToComboBox.Location = new System.Drawing.Point(72, 186);
            this.convertToComboBox.Name = "convertToComboBox";
            this.convertToComboBox.Size = new System.Drawing.Size(165, 22);
            this.convertToComboBox.TabIndex = 22;
            this.convertToComboBox.SelectedIndexChanged += new System.EventHandler(this.convertToComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.Text = "Convert To:";
            // 
            // basicButtonsPanel
            // 
            this.basicButtonsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.basicButtonsPanel.Controls.Add(this.undoButton);
            this.basicButtonsPanel.Controls.Add(this.EButton);
            this.basicButtonsPanel.Controls.Add(this.rightBracketButton);
            this.basicButtonsPanel.Controls.Add(this.nineButton);
            this.basicButtonsPanel.Controls.Add(this.CButton);
            this.basicButtonsPanel.Controls.Add(this.eightButton);
            this.basicButtonsPanel.Controls.Add(this.sevenButton);
            this.basicButtonsPanel.Controls.Add(this.FButton);
            this.basicButtonsPanel.Controls.Add(this.DButton);
            this.basicButtonsPanel.Controls.Add(this.BButton);
            this.basicButtonsPanel.Controls.Add(this.AButton);
            this.basicButtonsPanel.Controls.Add(this.fourButton);
            this.basicButtonsPanel.Controls.Add(this.fiveButton);
            this.basicButtonsPanel.Controls.Add(this.sixButton);
            this.basicButtonsPanel.Controls.Add(this.oneButton);
            this.basicButtonsPanel.Controls.Add(this.twoButton);
            this.basicButtonsPanel.Controls.Add(this.threeButton);
            this.basicButtonsPanel.Controls.Add(this.equalButton);
            this.basicButtonsPanel.Controls.Add(this.decimalButton);
            this.basicButtonsPanel.Controls.Add(this.zeroButton);
            this.basicButtonsPanel.Location = new System.Drawing.Point(0, 244);
            this.basicButtonsPanel.Name = "basicButtonsPanel";
            this.basicButtonsPanel.Size = new System.Drawing.Size(240, 50);
            // 
            // undoButton
            // 
            this.undoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.Location = new System.Drawing.Point(187, 3);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(21, 21);
            // 
            // EButton
            // 
            this.EButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EButton.Enabled = false;
            this.EButton.Image = ((System.Drawing.Image)(resources.GetObject("EButton.Image")));
            this.EButton.Location = new System.Drawing.Point(118, 3);
            this.EButton.Name = "EButton";
            this.EButton.Size = new System.Drawing.Size(21, 21);
            // 
            // rightBracketButton
            // 
            this.rightBracketButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rightBracketButton.Image = ((System.Drawing.Image)(resources.GetObject("rightBracketButton.Image")));
            this.rightBracketButton.Location = new System.Drawing.Point(164, 3);
            this.rightBracketButton.Name = "rightBracketButton";
            this.rightBracketButton.Size = new System.Drawing.Size(21, 21);
            // 
            // nineButton
            // 
            this.nineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nineButton.Image = ((System.Drawing.Image)(resources.GetObject("nineButton.Image")));
            this.nineButton.Location = new System.Drawing.Point(210, 26);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(21, 21);
            this.nineButton.Click += new System.EventHandler(this.nineButton_Click);
            // 
            // CButton
            // 
            this.CButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CButton.Enabled = false;
            this.CButton.Image = ((System.Drawing.Image)(resources.GetObject("CButton.Image")));
            this.CButton.Location = new System.Drawing.Point(72, 3);
            this.CButton.Name = "CButton";
            this.CButton.Size = new System.Drawing.Size(21, 21);
            // 
            // eightButton
            // 
            this.eightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.eightButton.Image = ((System.Drawing.Image)(resources.GetObject("eightButton.Image")));
            this.eightButton.Location = new System.Drawing.Point(187, 26);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(21, 21);
            this.eightButton.Click += new System.EventHandler(this.eightButton_Click);
            // 
            // sevenButton
            // 
            this.sevenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sevenButton.Image = ((System.Drawing.Image)(resources.GetObject("sevenButton.Image")));
            this.sevenButton.Location = new System.Drawing.Point(164, 26);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(21, 21);
            this.sevenButton.Click += new System.EventHandler(this.sevenButton_Click);
            // 
            // FButton
            // 
            this.FButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FButton.Enabled = false;
            this.FButton.Image = ((System.Drawing.Image)(resources.GetObject("FButton.Image")));
            this.FButton.Location = new System.Drawing.Point(141, 3);
            this.FButton.Name = "FButton";
            this.FButton.Size = new System.Drawing.Size(21, 21);
            // 
            // DButton
            // 
            this.DButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DButton.Enabled = false;
            this.DButton.Image = ((System.Drawing.Image)(resources.GetObject("DButton.Image")));
            this.DButton.Location = new System.Drawing.Point(95, 3);
            this.DButton.Name = "DButton";
            this.DButton.Size = new System.Drawing.Size(21, 21);
            // 
            // BButton
            // 
            this.BButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BButton.Enabled = false;
            this.BButton.Image = ((System.Drawing.Image)(resources.GetObject("BButton.Image")));
            this.BButton.Location = new System.Drawing.Point(48, 3);
            this.BButton.Name = "BButton";
            this.BButton.Size = new System.Drawing.Size(21, 21);
            // 
            // AButton
            // 
            this.AButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AButton.Enabled = false;
            this.AButton.Image = ((System.Drawing.Image)(resources.GetObject("AButton.Image")));
            this.AButton.Location = new System.Drawing.Point(25, 3);
            this.AButton.Name = "AButton";
            this.AButton.Size = new System.Drawing.Size(21, 21);
            // 
            // fourButton
            // 
            this.fourButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fourButton.Image = ((System.Drawing.Image)(resources.GetObject("fourButton.Image")));
            this.fourButton.Location = new System.Drawing.Point(95, 26);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(21, 21);
            this.fourButton.Click += new System.EventHandler(this.fourButton_Click);
            // 
            // fiveButton
            // 
            this.fiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fiveButton.Image = ((System.Drawing.Image)(resources.GetObject("fiveButton.Image")));
            this.fiveButton.Location = new System.Drawing.Point(118, 26);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(21, 21);
            this.fiveButton.Click += new System.EventHandler(this.fiveButton_Click);
            // 
            // sixButton
            // 
            this.sixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sixButton.Image = ((System.Drawing.Image)(resources.GetObject("sixButton.Image")));
            this.sixButton.Location = new System.Drawing.Point(141, 26);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(21, 21);
            this.sixButton.Click += new System.EventHandler(this.sixButton_Click);
            // 
            // oneButton
            // 
            this.oneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oneButton.Image = ((System.Drawing.Image)(resources.GetObject("oneButton.Image")));
            this.oneButton.Location = new System.Drawing.Point(26, 26);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(21, 21);
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // twoButton
            // 
            this.twoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.twoButton.Image = ((System.Drawing.Image)(resources.GetObject("twoButton.Image")));
            this.twoButton.Location = new System.Drawing.Point(49, 26);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(21, 21);
            this.twoButton.Click += new System.EventHandler(this.twoButton_Click);
            // 
            // threeButton
            // 
            this.threeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.threeButton.Image = ((System.Drawing.Image)(resources.GetObject("threeButton.Image")));
            this.threeButton.Location = new System.Drawing.Point(72, 26);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(21, 21);
            this.threeButton.Click += new System.EventHandler(this.threeButton_Click);
            // 
            // equalButton
            // 
            this.equalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.equalButton.Image = ((System.Drawing.Image)(resources.GetObject("equalButton.Image")));
            this.equalButton.Location = new System.Drawing.Point(210, 3);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(21, 21);
            this.equalButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // decimalButton
            // 
            this.decimalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.decimalButton.Image = ((System.Drawing.Image)(resources.GetObject("decimalButton.Image")));
            this.decimalButton.Location = new System.Drawing.Point(3, 3);
            this.decimalButton.Name = "decimalButton";
            this.decimalButton.Size = new System.Drawing.Size(21, 21);
            this.decimalButton.Click += new System.EventHandler(this.decimalButton_Click);
            // 
            // zeroButton
            // 
            this.zeroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zeroButton.Image = ((System.Drawing.Image)(resources.GetObject("zeroButton.Image")));
            this.zeroButton.Location = new System.Drawing.Point(3, 26);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(21, 21);
            this.zeroButton.Click += new System.EventHandler(this.zeroButton_Click);
            // 
            // CUnit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.basicButtonsPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.convertToComboBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unitListbox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.quantitiesListBox);
            this.Controls.Add(this.label1);
            this.Name = "CUnit";
            this.Text = "MyPocketCal - Unit & Conversion";
            this.basicButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.ListBox quantitiesListBox;
        private System.Windows.Forms.ListBox unitListbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.ComboBox convertToComboBox;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Panel basicButtonsPanel;
        protected System.Windows.Forms.PictureBox undoButton;
        protected System.Windows.Forms.PictureBox EButton;
        protected System.Windows.Forms.PictureBox rightBracketButton;
        protected System.Windows.Forms.PictureBox nineButton;
        protected System.Windows.Forms.PictureBox CButton;
        protected System.Windows.Forms.PictureBox eightButton;
        protected System.Windows.Forms.PictureBox sevenButton;
        protected System.Windows.Forms.PictureBox FButton;
        protected System.Windows.Forms.PictureBox DButton;
        protected System.Windows.Forms.PictureBox BButton;
        protected System.Windows.Forms.PictureBox AButton;
        protected System.Windows.Forms.PictureBox fourButton;
        protected System.Windows.Forms.PictureBox fiveButton;
        protected System.Windows.Forms.PictureBox sixButton;
        protected System.Windows.Forms.PictureBox oneButton;
        protected System.Windows.Forms.PictureBox twoButton;
        protected System.Windows.Forms.PictureBox threeButton;
        protected System.Windows.Forms.PictureBox equalButton;
        protected System.Windows.Forms.PictureBox decimalButton;
        protected System.Windows.Forms.PictureBox zeroButton;
    }
}