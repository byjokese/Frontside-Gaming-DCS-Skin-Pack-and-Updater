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
			this.components = new System.ComponentModel.Container();
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
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
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
			this.UpdateBtn.Location = new System.Drawing.Point(374, 107);
			this.UpdateBtn.Name = "UpdateBtn";
			this.UpdateBtn.Size = new System.Drawing.Size(83, 23);
			this.UpdateBtn.TabIndex = 9;
			this.UpdateBtn.Text = "Install/Update";
			this.UpdateBtn.UseVisualStyleBackColor = true;
			this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 78);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(443, 23);
			this.progressBar1.TabIndex = 15;
			// 
			// pathText
			// 
			this.pathText.Location = new System.Drawing.Point(15, 28);
			this.pathText.Name = "pathText";
			this.pathText.Size = new System.Drawing.Size(356, 20);
			this.pathText.TabIndex = 14;
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
			this.CloseBtn.Location = new System.Drawing.Point(374, 136);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(83, 23);
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
			this.richTextBox1.Location = new System.Drawing.Point(12, 212);
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
			this.logTextBox.Location = new System.Drawing.Point(15, 109);
			this.logTextBox.Multiline = true;
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.ReadOnly = true;
			this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logTextBox.Size = new System.Drawing.Size(356, 99);
			this.logTextBox.TabIndex = 19;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(226, 55);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(124, 17);
			this.checkBox1.TabIndex = 21;
			this.checkBox1.Text = "M-2000C Kneeboard";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(346, 55);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(121, 17);
			this.checkBox2.TabIndex = 22;
			this.checkBox2.Text = "F/A-18C Kneeboard";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 229);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
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
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
	}
}