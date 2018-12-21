namespace DirGrepUI
{
    partial class ExportSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportSettingForm));
            this._label_ChooseEditor = new System.Windows.Forms.Label();
            this._label_Parameter = new System.Windows.Forms.Label();
            this._textBox_Editor = new System.Windows.Forms.TextBox();
            this._textBox_Parameter = new System.Windows.Forms.TextBox();
            this._button_Choose = new System.Windows.Forms.Button();
            this._button_Clear = new System.Windows.Forms.Button();
            this._button_Cancel = new System.Windows.Forms.Button();
            this._button_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _label_ChooseEditor
            // 
            resources.ApplyResources(this._label_ChooseEditor, "_label_ChooseEditor");
            this._label_ChooseEditor.Name = "_label_ChooseEditor";
            // 
            // _label_Parameter
            // 
            resources.ApplyResources(this._label_Parameter, "_label_Parameter");
            this._label_Parameter.Name = "_label_Parameter";
            // 
            // _textBox_Editor
            // 
            resources.ApplyResources(this._textBox_Editor, "_textBox_Editor");
            this._textBox_Editor.Name = "_textBox_Editor";
            this._textBox_Editor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_Editor_KeyPress);
            // 
            // _textBox_Parameter
            // 
            resources.ApplyResources(this._textBox_Parameter, "_textBox_Parameter");
            this._textBox_Parameter.Name = "_textBox_Parameter";
            this._textBox_Parameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_Parameter_KeyPress);
            // 
            // _button_Choose
            // 
            resources.ApplyResources(this._button_Choose, "_button_Choose");
            this._button_Choose.Name = "_button_Choose";
            this._button_Choose.UseVisualStyleBackColor = true;
            this._button_Choose.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // _button_Clear
            // 
            resources.ApplyResources(this._button_Clear, "_button_Clear");
            this._button_Clear.Name = "_button_Clear";
            this._button_Clear.UseVisualStyleBackColor = true;
            this._button_Clear.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // _button_Cancel
            // 
            resources.ApplyResources(this._button_Cancel, "_button_Cancel");
            this._button_Cancel.Name = "_button_Cancel";
            this._button_Cancel.UseVisualStyleBackColor = true;
            this._button_Cancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _button_OK
            // 
            resources.ApplyResources(this._button_OK, "_button_OK");
            this._button_OK.Name = "_button_OK";
            this._button_OK.UseVisualStyleBackColor = true;
            this._button_OK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ExportSettingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._button_OK);
            this.Controls.Add(this._button_Cancel);
            this.Controls.Add(this._button_Clear);
            this.Controls.Add(this._button_Choose);
            this.Controls.Add(this._textBox_Parameter);
            this.Controls.Add(this._textBox_Editor);
            this.Controls.Add(this._label_Parameter);
            this.Controls.Add(this._label_ChooseEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "ExportSettingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportSettingForm_FormClosing);
            this.Load += new System.EventHandler(this.ExportSettingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExportSettingForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label_ChooseEditor;
        private System.Windows.Forms.Label _label_Parameter;
        private System.Windows.Forms.TextBox _textBox_Editor;
        private System.Windows.Forms.TextBox _textBox_Parameter;
        private System.Windows.Forms.Button _button_Choose;
        private System.Windows.Forms.Button _button_Clear;
        private System.Windows.Forms.Button _button_Cancel;
        private System.Windows.Forms.Button _button_OK;
    }
}