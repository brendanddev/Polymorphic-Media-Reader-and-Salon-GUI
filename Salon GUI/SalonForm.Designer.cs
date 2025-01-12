namespace Assignment3B
{
    partial class SalonForm
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
            this.hairdresserComboBox = new System.Windows.Forms.ComboBox();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.addServiceButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.chargesListBox = new System.Windows.Forms.ListBox();
            this.chargedLabel = new System.Windows.Forms.Label();
            this.pricesListBox = new System.Windows.Forms.ListBox();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.hairdresserGroupBox = new System.Windows.Forms.GroupBox();
            this.servicesGroupBox = new System.Windows.Forms.GroupBox();
            this.chargesGroupBox = new System.Windows.Forms.GroupBox();
            this.pricesGroupBox = new System.Windows.Forms.GroupBox();
            this.hairdresserGroupBox.SuspendLayout();
            this.servicesGroupBox.SuspendLayout();
            this.chargesGroupBox.SuspendLayout();
            this.pricesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // hairdresserComboBox
            // 
            this.hairdresserComboBox.DisplayMember = "(none)";
            this.hairdresserComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hairdresserComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.hairdresserComboBox.FormattingEnabled = true;
            this.hairdresserComboBox.Items.AddRange(new object[] {
            "Jane Samley",
            "Pat Johnson",
            "Ron Chambers",
            "Sue Pallon",
            "Laura Renkins"});
            this.hairdresserComboBox.Location = new System.Drawing.Point(16, 35);
            this.hairdresserComboBox.Name = "hairdresserComboBox";
            this.hairdresserComboBox.Size = new System.Drawing.Size(169, 26);
            this.hairdresserComboBox.TabIndex = 0;
            this.hairdresserComboBox.SelectedIndexChanged += new System.EventHandler(this.hairdresserComboBox_SelectedIndexChanged);
            // 
            // servicesListBox
            // 
            this.servicesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.servicesListBox.FormattingEnabled = true;
            this.servicesListBox.ItemHeight = 18;
            this.servicesListBox.Items.AddRange(new object[] {
            "Cut",
            "Wash, blow-dry, and style",
            "Colour",
            "Highlights",
            "Extension",
            "Up-do"});
            this.servicesListBox.Location = new System.Drawing.Point(6, 25);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.servicesListBox.Size = new System.Drawing.Size(245, 148);
            this.servicesListBox.TabIndex = 3;
            // 
            // addServiceButton
            // 
            this.addServiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.addServiceButton.Location = new System.Drawing.Point(110, 256);
            this.addServiceButton.Name = "addServiceButton";
            this.addServiceButton.Size = new System.Drawing.Size(188, 35);
            this.addServiceButton.TabIndex = 4;
            this.addServiceButton.Text = "Add Service";
            this.addServiceButton.UseVisualStyleBackColor = true;
            this.addServiceButton.Click += new System.EventHandler(this.addServiceButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateButton.Location = new System.Drawing.Point(304, 256);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(178, 35);
            this.calculateButton.TabIndex = 5;
            this.calculateButton.Text = "Calculate Total Price";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(488, 256);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(178, 35);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(672, 256);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(178, 35);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // chargesListBox
            // 
            this.chargesListBox.Enabled = false;
            this.chargesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.chargesListBox.FormattingEnabled = true;
            this.chargesListBox.ItemHeight = 18;
            this.chargesListBox.Location = new System.Drawing.Point(10, 25);
            this.chargesListBox.Name = "chargesListBox";
            this.chargesListBox.Size = new System.Drawing.Size(225, 148);
            this.chargesListBox.TabIndex = 8;
            // 
            // chargedLabel
            // 
            this.chargedLabel.AutoSize = true;
            this.chargedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargedLabel.Location = new System.Drawing.Point(513, 52);
            this.chargedLabel.Name = "chargedLabel";
            this.chargedLabel.Size = new System.Drawing.Size(132, 20);
            this.chargedLabel.TabIndex = 9;
            this.chargedLabel.Text = "Charged Items:";
            // 
            // pricesListBox
            // 
            this.pricesListBox.Enabled = false;
            this.pricesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.pricesListBox.FormattingEnabled = true;
            this.pricesListBox.ItemHeight = 18;
            this.pricesListBox.Location = new System.Drawing.Point(6, 25);
            this.pricesListBox.Name = "pricesListBox";
            this.pricesListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pricesListBox.Size = new System.Drawing.Size(138, 148);
            this.pricesListBox.TabIndex = 11;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(642, 213);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(95, 18);
            this.totalPriceLabel.TabIndex = 12;
            this.totalPriceLabel.Text = "Total Price:";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.totalPriceTextBox.Location = new System.Drawing.Point(750, 213);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.Size = new System.Drawing.Size(138, 24);
            this.totalPriceTextBox.TabIndex = 13;
            // 
            // hairdresserGroupBox
            // 
            this.hairdresserGroupBox.Controls.Add(this.hairdresserComboBox);
            this.hairdresserGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hairdresserGroupBox.Location = new System.Drawing.Point(12, 12);
            this.hairdresserGroupBox.Name = "hairdresserGroupBox";
            this.hairdresserGroupBox.Size = new System.Drawing.Size(215, 184);
            this.hairdresserGroupBox.TabIndex = 14;
            this.hairdresserGroupBox.TabStop = false;
            this.hairdresserGroupBox.Text = "Select a Hairdresser:";
            // 
            // servicesGroupBox
            // 
            this.servicesGroupBox.Controls.Add(this.servicesListBox);
            this.servicesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servicesGroupBox.Location = new System.Drawing.Point(233, 12);
            this.servicesGroupBox.Name = "servicesGroupBox";
            this.servicesGroupBox.Size = new System.Drawing.Size(257, 184);
            this.servicesGroupBox.TabIndex = 15;
            this.servicesGroupBox.TabStop = false;
            this.servicesGroupBox.Text = "Select a Service:";
            // 
            // chargesGroupBox
            // 
            this.chargesGroupBox.Controls.Add(this.chargesListBox);
            this.chargesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargesGroupBox.Location = new System.Drawing.Point(496, 12);
            this.chargesGroupBox.Name = "chargesGroupBox";
            this.chargesGroupBox.Size = new System.Drawing.Size(241, 184);
            this.chargesGroupBox.TabIndex = 16;
            this.chargesGroupBox.TabStop = false;
            this.chargesGroupBox.Text = "Charged Items:";
            // 
            // pricesGroupBox
            // 
            this.pricesGroupBox.Controls.Add(this.pricesListBox);
            this.pricesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricesGroupBox.Location = new System.Drawing.Point(744, 13);
            this.pricesGroupBox.Name = "pricesGroupBox";
            this.pricesGroupBox.Size = new System.Drawing.Size(150, 183);
            this.pricesGroupBox.TabIndex = 17;
            this.pricesGroupBox.TabStop = false;
            this.pricesGroupBox.Text = "Price:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 302);
            this.Controls.Add(this.pricesGroupBox);
            this.Controls.Add(this.chargesGroupBox);
            this.Controls.Add(this.servicesGroupBox);
            this.Controls.Add(this.hairdresserGroupBox);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.chargedLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.addServiceButton);
            this.Name = "Form1";
            this.Text = "Perfect Cut Hair Salon";
            this.hairdresserGroupBox.ResumeLayout(false);
            this.servicesGroupBox.ResumeLayout(false);
            this.chargesGroupBox.ResumeLayout(false);
            this.pricesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hairdresserComboBox;
        private System.Windows.Forms.ListBox servicesListBox;
        private System.Windows.Forms.Button addServiceButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ListBox chargesListBox;
        private System.Windows.Forms.Label chargedLabel;
        private System.Windows.Forms.ListBox pricesListBox;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.GroupBox hairdresserGroupBox;
        private System.Windows.Forms.GroupBox servicesGroupBox;
        private System.Windows.Forms.GroupBox chargesGroupBox;
        private System.Windows.Forms.GroupBox pricesGroupBox;
    }
}

