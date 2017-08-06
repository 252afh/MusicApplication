namespace MusicApplication
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HomePageButton = new System.Windows.Forms.Button();
            this.LocalButton = new System.Windows.Forms.Button();
            this.APIButton = new System.Windows.Forms.Button();
            this.OptionButton = new System.Windows.Forms.Button();
            this.AddToLocalLibBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 360);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.96124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.03876F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 622F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 360);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // HomePageButton
            // 
            this.HomePageButton.AutoSize = true;
            this.HomePageButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.HomePageButton.Location = new System.Drawing.Point(12, 31);
            this.HomePageButton.Name = "HomePageButton";
            this.HomePageButton.Size = new System.Drawing.Size(136, 41);
            this.HomePageButton.TabIndex = 1;
            this.HomePageButton.UseVisualStyleBackColor = true;
            this.HomePageButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.HomePageButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.HomePageButton.MouseLeave += new System.EventHandler(this.MouseExit);
            this.HomePageButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnClicked);
            // 
            // LocalButton
            // 
            this.LocalButton.AutoSize = true;
            this.LocalButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.LocalButton.Location = new System.Drawing.Point(322, 31);
            this.LocalButton.Name = "LocalButton";
            this.LocalButton.Size = new System.Drawing.Size(136, 41);
            this.LocalButton.TabIndex = 2;
            this.LocalButton.UseVisualStyleBackColor = true;
            this.LocalButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.LocalButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.LocalButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // APIButton
            // 
            this.APIButton.AutoSize = true;
            this.APIButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.APIButton.Location = new System.Drawing.Point(683, 31);
            this.APIButton.Name = "APIButton";
            this.APIButton.Size = new System.Drawing.Size(136, 41);
            this.APIButton.TabIndex = 3;
            this.APIButton.UseVisualStyleBackColor = true;
            this.APIButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.APIButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.APIButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // OptionButton
            // 
            this.OptionButton.AutoSize = true;
            this.OptionButton.Image = global::MusicApplication.Properties.Resources.homepage_red;
            this.OptionButton.Location = new System.Drawing.Point(1018, 31);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(136, 41);
            this.OptionButton.TabIndex = 4;
            this.OptionButton.UseVisualStyleBackColor = true;
            this.OptionButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.OptionButton.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.OptionButton.MouseLeave += new System.EventHandler(this.MouseExit);
            // 
            // AddToLocalLibBtn
            // 
            this.AddToLocalLibBtn.Location = new System.Drawing.Point(12, 2);
            this.AddToLocalLibBtn.Name = "AddToLocalLibBtn";
            this.AddToLocalLibBtn.Size = new System.Drawing.Size(75, 23);
            this.AddToLocalLibBtn.TabIndex = 5;
            this.AddToLocalLibBtn.Text = "Add to local library";
            this.AddToLocalLibBtn.UseVisualStyleBackColor = true;
            this.AddToLocalLibBtn.Click += new System.EventHandler(this.AddToLocalLibBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 461);
            this.Controls.Add(this.AddToLocalLibBtn);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.APIButton);
            this.Controls.Add(this.LocalButton);
            this.Controls.Add(this.HomePageButton);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button HomePageButton;
        private System.Windows.Forms.Button LocalButton;
        private System.Windows.Forms.Button APIButton;
        private System.Windows.Forms.Button OptionButton;
        private System.Windows.Forms.Button AddToLocalLibBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

