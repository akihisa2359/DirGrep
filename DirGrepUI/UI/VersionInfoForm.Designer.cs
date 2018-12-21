namespace DirGrepUI
{
    partial class VersionInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInfoForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._label_Mail = new System.Windows.Forms.LinkLabel();
            this._label_Link = new System.Windows.Forms.LinkLabel();
            this._button_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DirGrepUI.Properties.Resources.アイコン改;
            this.pictureBox1.Location = new System.Drawing.Point(26, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(169, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "DirGrep (C#) Version1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(169, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copyright (C) 2018";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "By";
            // 
            // _label_Mail
            // 
            this._label_Mail.AutoSize = true;
            this._label_Mail.Location = new System.Drawing.Point(13, 150);
            this._label_Mail.Name = "_label_Mail";
            this._label_Mail.Size = new System.Drawing.Size(178, 12);
            this._label_Mail.TabIndex = 2;
            this._label_Mail.TabStop = true;
            this._label_Mail.Text = "email : a.makimoto@acty-sys.co.jp";
            this._label_Mail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._label_LinkClicked);
            // 
            // _label_Link
            // 
            this._label_Link.AutoSize = true;
            this._label_Link.Location = new System.Drawing.Point(13, 176);
            this._label_Link.Name = "_label_Link";
            this._label_Link.Size = new System.Drawing.Size(152, 12);
            this._label_Link.TabIndex = 3;
            this._label_Link.TabStop = true;
            this._label_Link.Text = "home : http:/www.acty.com.jp";
            this._label_Link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._label_Link_LinkClicked);
            // 
            // _button_OK
            // 
            this._button_OK.Location = new System.Drawing.Point(246, 161);
            this._button_OK.Name = "_button_OK";
            this._button_OK.Size = new System.Drawing.Size(78, 27);
            this._button_OK.TabIndex = 1;
            this._button_OK.Text = "OK";
            this._button_OK.UseVisualStyleBackColor = true;
            this._button_OK.Click += new System.EventHandler(this._button_OK_Click);
            // 
            // VersionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 210);
            this.Controls.Add(this._button_OK);
            this.Controls.Add(this._label_Link);
            this.Controls.Add(this._label_Mail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Version Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VersionInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.VersionInfoForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VersionInfoForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel _label_Mail;
        private System.Windows.Forms.LinkLabel _label_Link;
        private System.Windows.Forms.Button _button_OK;
    }
}