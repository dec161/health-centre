namespace HealthCentre.UI
{
    partial class LoginForm
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
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.GuestButton = new System.Windows.Forms.Button();
            this.OrLabel = new System.Windows.Forms.Label();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(10, 14);
            this.LoginLabel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(47, 13);
            this.LoginLabel.TabIndex = 1;
            this.LoginLabel.Text = "Логин";
            this.LoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(10, 56);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(47, 13);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "Пароль";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.AutoSize = true;
            this.TableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableLayoutPanel.ColumnCount = 2;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Controls.Add(this.LoginLabel, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.PasswordLabel, 0, 1);
            this.TableLayoutPanel.Controls.Add(this.LoginTextBox, 1, 0);
            this.TableLayoutPanel.Controls.Add(this.PasswordTextBox, 1, 1);
            this.TableLayoutPanel.Controls.Add(this.LoginButton, 0, 2);
            this.TableLayoutPanel.Controls.Add(this.GuestButton, 0, 4);
            this.TableLayoutPanel.Controls.Add(this.OrLabel, 0, 3);
            this.TableLayoutPanel.Location = new System.Drawing.Point(5, 89);
            this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.TableLayoutPanel.RowCount = 5;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel.Size = new System.Drawing.Size(264, 182);
            this.TableLayoutPanel.TabIndex = 3;
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginTextBox.Location = new System.Drawing.Point(70, 10);
            this.LoginTextBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 10);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(184, 22);
            this.LoginTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(70, 52);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 10, 0, 10);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(184, 22);
            this.PasswordTextBox.TabIndex = 4;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableLayoutPanel.SetColumnSpan(this.LoginButton, 2);
            this.LoginButton.Location = new System.Drawing.Point(94, 87);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Войти";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // GuestButton
            // 
            this.GuestButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableLayoutPanel.SetColumnSpan(this.GuestButton, 2);
            this.GuestButton.Location = new System.Drawing.Point(76, 149);
            this.GuestButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.GuestButton.Name = "GuestButton";
            this.GuestButton.Size = new System.Drawing.Size(111, 23);
            this.GuestButton.TabIndex = 6;
            this.GuestButton.Text = "Войти как гость";
            this.GuestButton.UseVisualStyleBackColor = true;
            this.GuestButton.Click += new System.EventHandler(this.GuestButton_Click);
            // 
            // OrLabel
            // 
            this.OrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OrLabel.AutoSize = true;
            this.TableLayoutPanel.SetColumnSpan(this.OrLabel, 2);
            this.OrLabel.Location = new System.Drawing.Point(13, 123);
            this.OrLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.OrLabel.Name = "OrLabel";
            this.OrLabel.Size = new System.Drawing.Size(238, 13);
            this.OrLabel.TabIndex = 7;
            this.OrLabel.Text = "или";
            this.OrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 276);
            this.Controls.Add(this.TableLayoutPanel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Controls.SetChildIndex(this.TableLayoutPanel, 0);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button GuestButton;
        private System.Windows.Forms.Label OrLabel;
    }
}