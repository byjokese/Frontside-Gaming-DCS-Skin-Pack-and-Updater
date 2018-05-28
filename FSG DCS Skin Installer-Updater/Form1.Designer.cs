namespace FSG_DCS_Skin_Installer_Updater
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.UpdateBtn = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pathText = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.a10cKneeboardCheck = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.m2000KneeboardCheck = new System.Windows.Forms.CheckBox();
			this.f18cKneeboardCheck = new System.Windows.Forms.CheckBox();
			this.ProgressText = new System.Windows.Forms.Label();
			this.ProgressText_lbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(253, 16);
			this.label1.TabIndex = 10;
			this.label1.Text = "Selecciona la carpera raiz de DCS World";
			// 
			// UpdateBtn
			// 
			this.UpdateBtn.Location = new System.Drawing.Point(371, 120);
			this.UpdateBtn.Name = "UpdateBtn";
			this.UpdateBtn.Size = new System.Drawing.Size(86, 23);
			this.UpdateBtn.TabIndex = 9;
			this.UpdateBtn.Text = "Install/Update";
			this.UpdateBtn.UseVisualStyleBackColor = true;
			this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 78);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(448, 23);
			this.progressBar1.TabIndex = 15;
			this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// pathText
			// 
			this.pathText.Location = new System.Drawing.Point(15, 28);
			this.pathText.Name = "pathText";
			this.pathText.Size = new System.Drawing.Size(356, 20);
			this.pathText.TabIndex = 14;
			this.pathText.Text = global::FSG_DCS_Skin_Installer_Updater.Properties.Settings.Default.DCSRootFolder;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(377, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 23);
			this.button1.TabIndex = 13;
			this.button1.Text = "Browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// CloseBtn
			// 
			this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.CloseBtn.Location = new System.Drawing.Point(371, 149);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(86, 23);
			this.CloseBtn.TabIndex = 12;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.ForeColor = System.Drawing.SystemColors.InfoText;
			this.richTextBox1.Location = new System.Drawing.Point(9, 225);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.richTextBox1.Size = new System.Drawing.Size(439, 15);
			this.richTextBox1.TabIndex = 16;
			this.richTextBox1.Text = "Application designed by By-Jokese for Frontside Gaming (https://frontsidegaming.c" +
    "om/)";
			// 
			// a10cKneeboardCheck
			// 
			this.a10cKneeboardCheck.AutoSize = true;
			this.a10cKneeboardCheck.Location = new System.Drawing.Point(117, 55);
			this.a10cKneeboardCheck.Name = "a10cKneeboardCheck";
			this.a10cKneeboardCheck.Size = new System.Drawing.Size(110, 17);
			this.a10cKneeboardCheck.TabIndex = 17;
			this.a10cKneeboardCheck.Text = "A-10C Kneeboard";
			this.a10cKneeboardCheck.UseVisualStyleBackColor = true;
			this.a10cKneeboardCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Optional Downloads:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// logTextBox
			// 
			this.logTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.logTextBox.Location = new System.Drawing.Point(12, 122);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logTextBox.Size = new System.Drawing.Size(356, 99);
			this.logTextBox.TabIndex = 19;
			// 
			// m2000KneeboardCheck
			// 
			this.m2000KneeboardCheck.AutoSize = true;
			this.m2000KneeboardCheck.Location = new System.Drawing.Point(226, 55);
			this.m2000KneeboardCheck.Name = "m2000KneeboardCheck";
			this.m2000KneeboardCheck.Size = new System.Drawing.Size(124, 17);
			this.m2000KneeboardCheck.TabIndex = 21;
			this.m2000KneeboardCheck.Text = "M-2000C Kneeboard";
			this.m2000KneeboardCheck.UseVisualStyleBackColor = true;
			// 
			// f18cKneeboardCheck
			// 
			this.f18cKneeboardCheck.AutoSize = true;
			this.f18cKneeboardCheck.Enabled = false;
			this.f18cKneeboardCheck.Location = new System.Drawing.Point(346, 55);
			this.f18cKneeboardCheck.Name = "f18cKneeboardCheck";
			this.f18cKneeboardCheck.Size = new System.Drawing.Size(121, 17);
			this.f18cKneeboardCheck.TabIndex = 22;
			this.f18cKneeboardCheck.Text = "F/A-18C Kneeboard";
			this.f18cKneeboardCheck.UseVisualStyleBackColor = true;
			// 
			// ProgressText
			// 
			this.ProgressText.AutoSize = true;
			this.ProgressText.BackColor = System.Drawing.Color.Transparent;
			this.ProgressText.Location = new System.Drawing.Point(197, 83);
			this.ProgressText.Name = "ProgressText";
			this.ProgressText.Size = new System.Drawing.Size(0, 13);
			this.ProgressText.TabIndex = 23;
			this.ProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProgressText_lbl
			// 
			this.ProgressText_lbl.AutoSize = true;
			this.ProgressText_lbl.Location = new System.Drawing.Point(9, 106);
			this.ProgressText_lbl.Name = "ProgressText_lbl";
			this.ProgressText_lbl.Size = new System.Drawing.Size(129, 13);
			this.ProgressText_lbl.TabIndex = 24;
			this.ProgressText_lbl.Text = "Downloaded: -- of -- Bytes";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 242);
			this.Controls.Add(this.ProgressText_lbl);
			this.Controls.Add(this.ProgressText);
			this.Controls.Add(this.f18cKneeboardCheck);
			this.Controls.Add(this.m2000KneeboardCheck);
			this.Controls.Add(this.logTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.a10cKneeboardCheck);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.UpdateBtn);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.pathText);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.CloseBtn);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Frontside Gaming DCS Skin Installer/Updater";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button UpdateBtn;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox pathText;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.CheckBox a10cKneeboardCheck;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.CheckBox m2000KneeboardCheck;
		private System.Windows.Forms.CheckBox f18cKneeboardCheck;
		private System.Windows.Forms.Label ProgressText;
		private System.Windows.Forms.Label ProgressText_lbl;
	}
}