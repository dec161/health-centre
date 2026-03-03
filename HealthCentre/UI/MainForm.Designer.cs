namespace HealthCentre.UI
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
            this.PatientsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SortCheckBox = new System.Windows.Forms.CheckBox();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.AddPatientButton = new System.Windows.Forms.Button();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatientsTableLayoutPanel
            // 
            this.PatientsTableLayoutPanel.AutoSize = true;
            this.PatientsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PatientsTableLayoutPanel.ColumnCount = 2;
            this.PatientsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PatientsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PatientsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PatientsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PatientsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PatientsTableLayoutPanel.Name = "PatientsTableLayoutPanel";
            this.PatientsTableLayoutPanel.RowCount = 1;
            this.PatientsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PatientsTableLayoutPanel.Size = new System.Drawing.Size(790, 0);
            this.PatientsTableLayoutPanel.TabIndex = 1;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(5, 83);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(182, 22);
            this.SearchTextBox.TabIndex = 2;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.FilterChanged);
            // 
            // SortCheckBox
            // 
            this.SortCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.SortCheckBox.Location = new System.Drawing.Point(193, 83);
            this.SortCheckBox.Name = "SortCheckBox";
            this.SortCheckBox.Size = new System.Drawing.Size(110, 23);
            this.SortCheckBox.TabIndex = 3;
            this.SortCheckBox.Text = "– Дата рождения";
            this.SortCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SortCheckBox.ThreeState = true;
            this.SortCheckBox.UseVisualStyleBackColor = true;
            this.SortCheckBox.CheckStateChanged += new System.EventHandler(this.SortCheckBox_CheckStateChanged);
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.ItemHeight = 13;
            this.GenderComboBox.Location = new System.Drawing.Point(309, 84);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(48, 21);
            this.GenderComboBox.TabIndex = 4;
            this.GenderComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);
            // 
            // Panel
            // 
            this.Panel.AutoScroll = true;
            this.Panel.Controls.Add(this.PatientsTableLayoutPanel);
            this.Panel.Location = new System.Drawing.Point(5, 108);
            this.Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(790, 337);
            this.Panel.TabIndex = 5;
            // 
            // AddPatientButton
            // 
            this.AddPatientButton.Location = new System.Drawing.Point(363, 83);
            this.AddPatientButton.Name = "AddPatientButton";
            this.AddPatientButton.Size = new System.Drawing.Size(121, 23);
            this.AddPatientButton.TabIndex = 6;
            this.AddPatientButton.Text = "Добавить пациента";
            this.AddPatientButton.UseVisualStyleBackColor = true;
            this.AddPatientButton.Click += new System.EventHandler(this.AddPatientButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddPatientButton);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.GenderComboBox);
            this.Controls.Add(this.SortCheckBox);
            this.Controls.Add(this.SearchTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Controls.SetChildIndex(this.SearchTextBox, 0);
            this.Controls.SetChildIndex(this.SortCheckBox, 0);
            this.Controls.SetChildIndex(this.GenderComboBox, 0);
            this.Controls.SetChildIndex(this.Panel, 0);
            this.Controls.SetChildIndex(this.AddPatientButton, 0);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PatientsTableLayoutPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.CheckBox SortCheckBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button AddPatientButton;
    }
}