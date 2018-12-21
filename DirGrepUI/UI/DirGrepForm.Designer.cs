namespace DirGrepUI
{
    partial class DirGrepForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirGrepForm));
            this._label_SearchPlace = new System.Windows.Forms.Label();
            this._label_SearchTarget = new System.Windows.Forms.Label();
            this._label_SearchText = new System.Windows.Forms.Label();
            this._label_SearchCondition = new System.Windows.Forms.Label();
            this._label_SearchStatus = new System.Windows.Forms.Label();
            this._textBox_SearchPlace = new System.Windows.Forms.TextBox();
            this._checkBox_IgnoreCase = new System.Windows.Forms.CheckBox();
            this._checkBox_SearchByWord = new System.Windows.Forms.CheckBox();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._checkBox_SearchSubDir = new System.Windows.Forms.CheckBox();
            this._radioButton_AND = new System.Windows.Forms.RadioButton();
            this._radioButton_OR = new System.Windows.Forms.RadioButton();
            this._listView_Result = new System.Windows.Forms.ListView();
            this.FileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LineHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlaceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.previewTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._button_Browse = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.日本語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._comboBox_SearchTarget = new System.Windows.Forms.ComboBox();
            this._comboBox_SearchText = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this._label_Progress = new System.Windows.Forms.Label();
            this._panel = new System.Windows.Forms.Panel();
            this._checkBox_Search = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this._panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _label_SearchPlace
            // 
            resources.ApplyResources(this._label_SearchPlace, "_label_SearchPlace");
            this._label_SearchPlace.Name = "_label_SearchPlace";
            // 
            // _label_SearchTarget
            // 
            resources.ApplyResources(this._label_SearchTarget, "_label_SearchTarget");
            this._label_SearchTarget.Name = "_label_SearchTarget";
            // 
            // _label_SearchText
            // 
            resources.ApplyResources(this._label_SearchText, "_label_SearchText");
            this._label_SearchText.Name = "_label_SearchText";
            // 
            // _label_SearchCondition
            // 
            resources.ApplyResources(this._label_SearchCondition, "_label_SearchCondition");
            this._label_SearchCondition.Name = "_label_SearchCondition";
            // 
            // _label_SearchStatus
            // 
            resources.ApplyResources(this._label_SearchStatus, "_label_SearchStatus");
            this._label_SearchStatus.Name = "_label_SearchStatus";
            // 
            // _textBox_SearchPlace
            // 
            this._textBox_SearchPlace.AllowDrop = true;
            resources.ApplyResources(this._textBox_SearchPlace, "_textBox_SearchPlace");
            this._textBox_SearchPlace.Name = "_textBox_SearchPlace";
            this._textBox_SearchPlace.TextChanged += new System.EventHandler(this._textBox_SearchPlace_TextChanged);
            this._textBox_SearchPlace.DragDrop += new System.Windows.Forms.DragEventHandler(this.SearchPlaceBox_DragDrop);
            this._textBox_SearchPlace.DragEnter += new System.Windows.Forms.DragEventHandler(this.SearchPlaceBox_DragEnter);
            // 
            // _checkBox_IgnoreCase
            // 
            resources.ApplyResources(this._checkBox_IgnoreCase, "_checkBox_IgnoreCase");
            this._checkBox_IgnoreCase.Name = "_checkBox_IgnoreCase";
            this._checkBox_IgnoreCase.UseVisualStyleBackColor = true;
            // 
            // _checkBox_SearchByWord
            // 
            resources.ApplyResources(this._checkBox_SearchByWord, "_checkBox_SearchByWord");
            this._checkBox_SearchByWord.Name = "_checkBox_SearchByWord";
            this._checkBox_SearchByWord.UseVisualStyleBackColor = true;
            // 
            // _progressBar
            // 
            resources.ApplyResources(this._progressBar, "_progressBar");
            this._progressBar.Name = "_progressBar";
            // 
            // _checkBox_SearchSubDir
            // 
            resources.ApplyResources(this._checkBox_SearchSubDir, "_checkBox_SearchSubDir");
            this._checkBox_SearchSubDir.Name = "_checkBox_SearchSubDir";
            this._checkBox_SearchSubDir.UseVisualStyleBackColor = true;
            // 
            // _radioButton_AND
            // 
            this._radioButton_AND.AutoCheck = false;
            resources.ApplyResources(this._radioButton_AND, "_radioButton_AND");
            this._radioButton_AND.Name = "_radioButton_AND";
            this._radioButton_AND.TabStop = true;
            this._radioButton_AND.UseVisualStyleBackColor = true;
            this._radioButton_AND.Click += new System.EventHandler(this.AndButton_Click);
            // 
            // _radioButton_OR
            // 
            this._radioButton_OR.AutoCheck = false;
            resources.ApplyResources(this._radioButton_OR, "_radioButton_OR");
            this._radioButton_OR.Checked = true;
            this._radioButton_OR.Name = "_radioButton_OR";
            this._radioButton_OR.TabStop = true;
            this._radioButton_OR.UseVisualStyleBackColor = true;
            this._radioButton_OR.Click += new System.EventHandler(this.OrButton_Click);
            // 
            // _listView_Result
            // 
            resources.ApplyResources(this._listView_Result, "_listView_Result");
            this._listView_Result.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileNameHeader,
            this.LineHeader,
            this.PlaceHeader});
            this._listView_Result.FullRowSelect = true;
            this._listView_Result.GridLines = true;
            this._listView_Result.Name = "_listView_Result";
            this._listView_Result.TabStop = false;
            this._listView_Result.UseCompatibleStateImageBehavior = false;
            this._listView_Result.View = System.Windows.Forms.View.Details;
            this._listView_Result.SelectedIndexChanged += new System.EventHandler(this.ResultView_SelectedIndexChanged);
            this._listView_Result.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ResultView_MouseDoubleClick);
            // 
            // FileNameHeader
            // 
            resources.ApplyResources(this.FileNameHeader, "FileNameHeader");
            // 
            // LineHeader
            // 
            resources.ApplyResources(this.LineHeader, "LineHeader");
            // 
            // PlaceHeader
            // 
            resources.ApplyResources(this.PlaceHeader, "PlaceHeader");
            // 
            // previewTextBox
            // 
            resources.ApplyResources(this.previewTextBox, "previewTextBox");
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.ReadOnly = true;
            this.previewTextBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // _button_Browse
            // 
            resources.ApplyResources(this._button_Browse, "_button_Browse");
            this._button_Browse.Name = "_button_Browse";
            this._button_Browse.UseVisualStyleBackColor = true;
            this._button_Browse.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.日本語ToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // 日本語ToolStripMenuItem
            // 
            this.日本語ToolStripMenuItem.Name = "日本語ToolStripMenuItem";
            resources.ApplyResources(this.日本語ToolStripMenuItem, "日本語ToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            // 
            // _comboBox_SearchTarget
            // 
            this._comboBox_SearchTarget.FormattingEnabled = true;
            resources.ApplyResources(this._comboBox_SearchTarget, "_comboBox_SearchTarget");
            this._comboBox_SearchTarget.Name = "_comboBox_SearchTarget";
            // 
            // _comboBox_SearchText
            // 
            this._comboBox_SearchText.FormattingEnabled = true;
            resources.ApplyResources(this._comboBox_SearchText, "_comboBox_SearchText");
            this._comboBox_SearchText.Name = "_comboBox_SearchText";
            this._comboBox_SearchText.TextUpdate += new System.EventHandler(this._comboBoc_SearchText_TextUpdate);
            // 
            // _label_Progress
            // 
            resources.ApplyResources(this._label_Progress, "_label_Progress");
            this._label_Progress.Name = "_label_Progress";
            // 
            // _panel
            // 
            this._panel.Controls.Add(this._radioButton_OR);
            this._panel.Controls.Add(this._radioButton_AND);
            resources.ApplyResources(this._panel, "_panel");
            this._panel.Name = "_panel";
            this._panel.TabStop = true;
            // 
            // _checkBox_Search
            // 
            resources.ApplyResources(this._checkBox_Search, "_checkBox_Search");
            this._checkBox_Search.Name = "_checkBox_Search";
            this._checkBox_Search.UseVisualStyleBackColor = true;
            this._checkBox_Search.Click += new System.EventHandler(this._checkBox_Search_Click);
            // 
            // DirGrepForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._checkBox_Search);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._label_Progress);
            this.Controls.Add(this._comboBox_SearchText);
            this.Controls.Add(this._comboBox_SearchTarget);
            this.Controls.Add(this._button_Browse);
            this.Controls.Add(this.previewTextBox);
            this.Controls.Add(this._listView_Result);
            this.Controls.Add(this._checkBox_SearchSubDir);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._checkBox_SearchByWord);
            this.Controls.Add(this._checkBox_IgnoreCase);
            this.Controls.Add(this._textBox_SearchPlace);
            this.Controls.Add(this._label_SearchStatus);
            this.Controls.Add(this._label_SearchCondition);
            this.Controls.Add(this._label_SearchText);
            this.Controls.Add(this._label_SearchTarget);
            this.Controls.Add(this._label_SearchPlace);
            this.KeyPreview = true;
            this.Name = "DirGrepForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirGrepForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirGrepForm_FormClosed);
            this.Load += new System.EventHandler(this.DirGrepForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DirGrepForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label_SearchPlace;
        private System.Windows.Forms.Label _label_SearchTarget;
        private System.Windows.Forms.Label _label_SearchText;
        private System.Windows.Forms.Label _label_SearchCondition;
        private System.Windows.Forms.Label _label_SearchStatus;
        private System.Windows.Forms.TextBox _textBox_SearchPlace;
        private System.Windows.Forms.CheckBox _checkBox_IgnoreCase;
        private System.Windows.Forms.CheckBox _checkBox_SearchByWord;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.CheckBox _checkBox_SearchSubDir;
        private System.Windows.Forms.RadioButton _radioButton_AND;
        private System.Windows.Forms.RadioButton _radioButton_OR;
        private System.Windows.Forms.ListView _listView_Result;
        private System.Windows.Forms.TextBox previewTextBox;
        private System.Windows.Forms.ColumnHeader FileNameHeader;
        private System.Windows.Forms.ColumnHeader LineHeader;
        private System.Windows.Forms.ColumnHeader PlaceHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button _button_Browse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 日本語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ComboBox _comboBox_SearchTarget;
        private System.Windows.Forms.ComboBox _comboBox_SearchText;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label _label_Progress;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.CheckBox _checkBox_Search;
    }
}

