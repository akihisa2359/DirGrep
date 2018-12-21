namespace DirGrepUI
{
    partial class MessageForm
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
            this._label_Message = new System.Windows.Forms.Label();
            this._button1 = new System.Windows.Forms.Button();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _label_Message
            // 
            this._label_Message.Font = new System.Drawing.Font("HGSｺﾞｼｯｸM", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._label_Message.Location = new System.Drawing.Point(74, 23);
            this._label_Message.Name = "_label_Message";
            this._label_Message.Size = new System.Drawing.Size(164, 65);
            this._label_Message.TabIndex = 0;
            this._label_Message.Text = "label1";
            // 
            // _button1
            // 
            this._button1.Location = new System.Drawing.Point(164, 82);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(74, 28);
            this._button1.TabIndex = 1;
            this._button1.Text = "button1";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this._button_Right_Click);
            // 
            // _pictureBox
            // 
            this._pictureBox.Location = new System.Drawing.Point(24, 23);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(31, 31);
            this._pictureBox.TabIndex = 2;
            this._pictureBox.TabStop = false;
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(74, 82);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(74, 28);
            this._button2.TabIndex = 3;
            this._button2.Text = "Yes";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this._button_Left_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 124);
            this.ControlBox = false;
            this.Controls.Add(this._button2);
            this.Controls.Add(this._pictureBox);
            this.Controls.Add(this._button1);
            this.Controls.Add(this._label_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _label_Message;
        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Button _button2;
    }
}