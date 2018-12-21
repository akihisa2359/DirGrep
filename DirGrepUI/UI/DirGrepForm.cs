using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.IO;
using DirGrepUI.Process;
using DirGrepUI.Data;
using System.Drawing;
using System.Threading.Tasks;

namespace DirGrepUI
{
    public partial class DirGrepForm : Form
    {
        /// <summary>
        /// ログ用のメンバ変数
        /// </summary>
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Grepを行うクラス
        /// </summary>
        private SearchProcessor _searchProcessor;

        #region SystemMenu
        /// <summary>
        /// Add SystemMenu
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MENUITEMINFO
        {
            public uint cbSize;
            public uint fMask;
            public uint fType;
            public uint fState;
            public uint wID;
            private IntPtr hSubMenu;
            private IntPtr hbmpChecked;
            private IntPtr hbmpUnchecked;
            private IntPtr dwItemData;
            public string dwTypeData;
            public uint cch;
            private IntPtr hbmpItem;

            // return the size of the structure
            public static uint SizeOf
            {
                get { return (uint)Marshal.SizeOf(typeof(MENUITEMINFO)); }
            }
        }
        internal static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

            [DllImport("user32.dll")]
            public static extern bool InsertMenuItem(IntPtr hMenu, uint uItem, bool fByPosition,
              [In] ref MENUITEMINFO lpmii);
        }
        private const uint MENU_ID_01 = 0x0001;
        private const uint MENU_ID_02 = 0x0002;
        private const uint MENU_ID_03 = 0x0003;
        private const uint MENU_ID_04 = 0x0004;

        private const uint MFT_SEPARATOR = 0x00000800;
        private const uint MFT_STRING = 0x00000000;
        private const uint MIIM_FTYPE = 0x00000100;
        private const uint MIIM_STRING = 0x00000040;
        private const uint MIIM_ID = 0x00000002;

        private const uint WM_SYSCOMMAND = 0x0112;
        #endregion

        /// <summary>
        /// InitializeComponent
        /// </summary>
        public DirGrepForm()
        {
            InitializeComponent();

            AddSystemMenu();
        }

        /// <summary>
        /// AddSystemMenu
        /// </summary>
        private void AddSystemMenu()
        {
            IntPtr hSysMenu = NativeMethods.GetSystemMenu(this.Handle, false);

            MENUITEMINFO item1 = new MENUITEMINFO();
            item1.cbSize = (uint)Marshal.SizeOf(item1);
            item1.fMask = MIIM_FTYPE;
            item1.fType = MFT_SEPARATOR;
            NativeMethods.InsertMenuItem(hSysMenu, 7, true, ref item1);

            MENUITEMINFO item2 = new MENUITEMINFO();
            item2.cbSize = (uint)Marshal.SizeOf(item2);
            item2.fMask = MIIM_STRING | MIIM_ID;
            item2.wID = MENU_ID_01;
            item2.dwTypeData = "Export Setting";
            NativeMethods.InsertMenuItem(hSysMenu, 8, true, ref item2);

            MENUITEMINFO item3 = new MENUITEMINFO
            {
                cbSize = (uint)Marshal.SizeOf(item2),
                fMask = MIIM_STRING | MIIM_ID,
                wID = MENU_ID_02,
                dwTypeData = "Version Information"
            };
            NativeMethods.InsertMenuItem(hSysMenu, 9, true, ref item3);

            MENUITEMINFO item4 = new MENUITEMINFO
            {
                cbSize = (uint)Marshal.SizeOf(item1),
                fMask = MIIM_FTYPE,
                fType = MFT_SEPARATOR
            };
            NativeMethods.InsertMenuItem(hSysMenu, 10, true, ref item4);

            MENUITEMINFO item5 = new MENUITEMINFO
            {
                cbSize = (uint)Marshal.SizeOf(item2),
                fMask = MIIM_STRING | MIIM_ID,
                wID = MENU_ID_03,
                dwTypeData = "English"
            };
            NativeMethods.InsertMenuItem(hSysMenu, 11, true, ref item5);

            MENUITEMINFO item6 = new MENUITEMINFO
            {
                cbSize = (uint)Marshal.SizeOf(item2),
                fMask = MIIM_STRING | MIIM_ID,
                wID = MENU_ID_04,
                dwTypeData = "日本語(J)"
            };
            NativeMethods.InsertMenuItem(hSysMenu, 12, true, ref item6);
        }

        /// <summary>
        /// SystemMenu_Clicked
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_SYSCOMMAND)
            {
                uint menuid = (uint)(m.WParam.ToInt32() & 0xffff);

                switch (menuid)
                {
                    case MENU_ID_01: // ExportSettingForm
                        ExportSettingForm myform1 = new ExportSettingForm();
                        myform1.Left = this.Left + (this.Width - myform1.Width) / 2;
                        myform1.Top = this.Top + (this.Height - myform1.Height) / 2;
                        ProcessSerialize();
                        myform1.Show();
                        break;

                    case MENU_ID_02: //VersionInfoForm
                        VersionInfoForm myform2 = new VersionInfoForm();
                        myform2.Left = this.Left + (this.Width - myform2.Width) / 2;
                        myform2.Top = this.Top + (this.Height - myform2.Height) / 2;
                        myform2.Show();
                        break;

                    case MENU_ID_03: // English
                        ChangeLanguage("en-US");
                        break;

                    case MENU_ID_04: // 日本語
                        ChangeLanguage("ja-JP");
                        break;
                }
            }
        }

        /// <summary>
        /// Load : Deserialize and assign data when opening
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirGrepForm_Load(object sender, EventArgs e)
        {
            try
            {
                _logger.Info("FormOpened");

                InitializeForm();

                SwitchEnabledProperty();

                _searchProcessor = new SearchProcessor(OnRunProgressBar, OnAddToListView);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                ShowDialog(Resources.language.ErrorMessage, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
                Close();
            }
        }

        /// <summary>
        /// Switch Enabled Property between True and False
        /// </summary>
        private void SwitchEnabledProperty()
        {
            if (string.IsNullOrEmpty(_textBox_SearchPlace.Text) || string.IsNullOrEmpty(_comboBox_SearchText.Text))
            {
                _checkBox_Search.Enabled = false;
            }
            else
            {
                _checkBox_Search.Enabled = true;
            }
        }

        /// <summary>
        /// Browse_clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            _logger.Info("BrowseButton Clicked");

            var dlg = new FolderBrowserDialog();

            if (Directory.Exists(_textBox_SearchPlace.Text))
            {
                dlg.SelectedPath = _textBox_SearchPlace.Text;
            }
            else
            {
                dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _textBox_SearchPlace.Text = dlg.SelectedPath;
            }
        }

        /// <summary>
        /// Search Start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void _checkBox_Search_Click(object sender, EventArgs e)
        {
            try
            {
                // 検索中にクリックされた場合、キャンセルをするかどうかの確認
                if (_searchProcessor.Task != null && !_searchProcessor.Task.IsCompleted)
                {
                    ConfirmCancel();
                    return;
                }

                // 検索中でない場合、検索開始
                else
                {
                    AddTextToComboBox(_comboBox_SearchTarget);
                    AddTextToComboBox(_comboBox_SearchText);

                    if (!Directory.Exists(_textBox_SearchPlace.Text))
                    {
                        _logger.Error("The directory is invalid");
                        ShowDialog(Resources.language.FolderPathError, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
                        return;
                    }

                    UpdateForm(true);

                    GrepData data = new GrepData(_textBox_SearchPlace.Text, _comboBox_SearchTarget.Text, _comboBox_SearchText.Text,
                        _checkBox_SearchSubDir.Checked, _checkBox_IgnoreCase.Checked, _checkBox_SearchByWord.Checked, _radioButton_AND.Checked);

                    // 検索文字列が含まれるファイルを探し、ListViewに追加する
                    await _searchProcessor.SearchFiles(data);

                    if (_searchProcessor.IsClose)
                    {
                        return;
                    }

                    // Grep中に起きたエラーを表示
                    if (!string.IsNullOrEmpty(_searchProcessor.Message))
                    {
                        ShowDialog(_searchProcessor.Message, this.Text, MessageBoxButtons.OK, SystemIcons.Information);
                    }
                    
                    UpdateForm(false);
                }
            }
            catch (Exception ex)
            {
                _checkBox_Search.Checked = false;
                _checkBox_Search.Text = Resources.language.searchButton;
                _logger.Error(ex);
                ShowDialog(Resources.language.ErrorMessage, "Information", MessageBoxButtons.OK, SystemIcons.Error);
            }
        }

        /// <summary>
        /// Confirm Cancel Search or Not
        /// </summary>
        /// <returns></returns>
        private void ConfirmCancel()
        {
            _checkBox_Search.Checked = true;
            MessageForm messageForm = new MessageForm(Resources.language.Stop, this.Text, MessageBoxButtons.YesNo, SystemIcons.Question);
            DialogResult result = messageForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                _logger.Info("Search canceled");
                _searchProcessor.TokenSource.Cancel();
            }
            else
            {
                _logger.Info("Search resumed");
            }
        }

        /// <summary>
        /// Update Form before and after Search
        /// </summary>
        /// <param name="isBfrSearch"></param>
        private void UpdateForm(bool isBfrSearch)
        {
            bool isEnabled;

            if (isBfrSearch)
            {
                _logger.Info("StartSearch");
                _listView_Result.Items.Clear();
                previewTextBox.Clear();
                _progressBar.Value = 0;
                _label_Progress.Text = "0";
                _checkBox_Search.Text = Resources.language.cancelButton;
                _checkBox_Search.Checked = true;
                isEnabled = false;
            }
            else
            {
                _checkBox_Search.Text = Resources.language.searchButton;
                _checkBox_Search.Checked = false;
                isEnabled = true;
            }

            _button_Browse.Enabled = isEnabled;
            _panel.Enabled = isEnabled;
            _textBox_SearchPlace.Enabled = isEnabled;
            _comboBox_SearchTarget.Enabled = isEnabled;
            _comboBox_SearchText.Enabled = isEnabled;
            _checkBox_SearchSubDir.Enabled = isEnabled;
            _checkBox_IgnoreCase.Enabled = isEnabled;
            _checkBox_SearchByWord.Enabled = isEnabled;
        }

        #region Delegation
        /// <summary>
        /// RunProgressBar
        /// </summary>
        /// <param name="fileCount"></param>
        /// <param name="totalFileNum"></param>
        private void OnRunProgressBar(int fileCount, int totalFileNum)
        {
            double progress = 0;

            progress = Math.Round((double)(fileCount) / totalFileNum * 100);

            Invoke(new Action(() =>
            {
                _progressBar.Value = (int)progress;
                _label_Progress.Text = string.Format("{0}%", _progressBar.Value);
                _label_Progress.Update();
            }));

        }

        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="arr"></param>
        private void OnAddToListView(List<ResultData> resultList)
        {
            Invoke(new Action(() =>
            {
                foreach (ResultData result in resultList)
                {
                    if (result != null)
                    {
                        string[] row = new string[] { result.FileName, result.LineNum, result.FilePath };
                        _listView_Result.Items.Add(new ListViewItem(row));
                    }
                }
            }));
        }
        #endregion

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="button"></param>
        /// <param name="icon"></param>
        private void ShowDialog(string message, string title, MessageBoxButtons button, Icon icon)
        {
            MessageForm messageForm = new MessageForm(message, title, button, icon);
            messageForm.ShowDialog();
        }

        /// <summary>
        /// Gather FormData to Get Ready for and Implement Serialize
        /// </summary>
        private void ProcessSerialize()
        {
            // searchState
            SearchState searchState = new SearchState(_textBox_SearchPlace.Text, _comboBox_SearchTarget.Items, _checkBox_SearchSubDir.Checked, _comboBox_SearchText.Items,
                _radioButton_AND.Checked, _radioButton_OR.Checked, _checkBox_IgnoreCase.Checked, _checkBox_SearchByWord.Checked);

            // windowsState
            WindowsState windowsState;

            // 最小化で終了した場合、最小化前の状態で表示。 最大化で終了した場合、最大化前の状態を記録し、最大化して表示
            if ((WindowState == FormWindowState.Minimized) || (WindowState == FormWindowState.Maximized))
            {
                windowsState = new WindowsState(RestoreBounds.X, RestoreBounds.Y, RestoreBounds.Size, this.WindowState);
            }
            else
            {
                windowsState = new WindowsState(Bounds.X, Bounds.Y, Bounds.Size, this.WindowState);
            }

            // language
            string language = Thread.CurrentThread.CurrentUICulture.ToString();

            // Serialize
            XmlHandler xmlHandler = new XmlHandler(searchState, windowsState, language);
            xmlHandler.Serialize();
        }

        /// <summary>
        /// Assign each data in each blank when opening
        /// </summary>
        /// <param name="settings"></param>
        private void InitializeForm()
        {
            XmlHandler xmlHandler = new XmlHandler();
            FormData formData = xmlHandler.Deserialize();

            ChangeLanguage(xmlHandler.Language);

            if (formData == null)
            {
                return;
            }

            _textBox_SearchPlace.Text = formData.SearchState.SearchPlace;

            foreach (string str in formData.SearchState.SearchTarget)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    _comboBox_SearchTarget.Items.Add(str);
                }
            }

            if (formData.SearchState.SearchTarget.Count > 0)
            {
                _comboBox_SearchTarget.Text = formData.SearchState.SearchTarget[0].ToString();
            }

            foreach (string str in formData.SearchState.SearchText)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    _comboBox_SearchText.Items.Add(str);
                }
            }

            if (formData.SearchState.SearchText.Count > 0)
            {
                _comboBox_SearchText.Text = formData.SearchState.SearchText[0];
            }

            _checkBox_SearchSubDir.Checked = formData.SearchState.IsSearchSubFolder;
            _radioButton_AND.Checked = formData.SearchState.IsAnd;
            _radioButton_OR.Checked = formData.SearchState.IsOr;
            _checkBox_IgnoreCase.Checked = formData.SearchState.IsIgnoreCase;
            _checkBox_SearchByWord.Checked = formData.SearchState.IsSearchByWord;
            Location = formData.WindowsState.Position;
            Size = formData.WindowsState.Size;

            // 前回が最大化で終了した場合、最大化して表示
            if (formData.WindowsState.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Form_Closing : Serialize data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DirGrepForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_searchProcessor.Task != null && !_searchProcessor.Task.IsCompleted)
                {
                    MessageForm messageForm = new MessageForm(Resources.language.ConfirmClose, this.Text, MessageBoxButtons.YesNo, SystemIcons.Information);
                    DialogResult result = messageForm.ShowDialog();
                    e.Cancel = true; // 検索中に閉じる場合、e.Cancelがfalseだと、別スレッドが終了する前にオブジェクトが破棄され、ObjectDisposedExceptionが発生する

                    if (result == DialogResult.Yes)
                    {
                        _searchProcessor.TokenSource.Cancel();
                        _searchProcessor.IsClose = true;
                        await WaitTaskEnd();
                        Close();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                ShowDialog(ex.Message, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
            }
        }

        /// <summary>
        /// Wait for Task to Finish
        /// </summary>
        private async Task WaitTaskEnd()
        {
            const int MaxWaitTime = 3000; // 3Seconds
            const int DelayTime = 100; // 0.1Second
            int timeCounter = 0;

            try
            {
                while (_searchProcessor.Task.IsCompleted == false)
                {
                    await Task.Delay(DelayTime);
                    timeCounter++;

                    // 3秒経過しても終わらなければ、スレッドを待たずに終了
                    if (timeCounter * DelayTime == MaxWaitTime)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        /// <summary>
        /// Add searchTarget to ComboBox
        /// </summary>
        /// <param name="Item"></param>
        private void AddTextToComboBox(ComboBox comboBox)
        {
            int i = 0;
            const int MaxComboBoxItem = 10;

            if (string.IsNullOrEmpty(comboBox.Text))
            {
                return;
            }

            foreach (string str in comboBox.Items)
            {
                // 履歴と同じ文字列が入力されていた場合、その文字列を履歴の一番上に表示
                if (str == comboBox.Text)
                {
                    comboBox.Items.RemoveAt(i);
                    comboBox.Items.Insert(0, str);
                    comboBox.Text = str;
                    return;
                }
                i++;
            }

            // 履歴が10を超えると古いものから更新
            if (_comboBox_SearchTarget.Items.Count == MaxComboBoxItem)
            {
                comboBox.Items.RemoveAt(MaxComboBoxItem - 1);
            }

            // 履歴の一番上に文字列を挿入.
            comboBox.Items.Insert(0, comboBox.Text);
        }

        /// <summary>
        /// When ListView clicked, show lines around the hitline.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = 0;
            int hitLineNum = 0;
            string path = null;
            previewTextBox.Text = string.Empty;

            if (_listView_Result.SelectedItems.Count <= 0)
            {
                return;
            }

            try
            {
                _logger.Info("ListView Clicked");

                idx = _listView_Result.SelectedItems[0].Index;
                hitLineNum = int.Parse(_listView_Result.Items[idx].SubItems[1].Text);
                path = _listView_Result.Items[idx].SubItems[2].Text;

                string text;
                int lineCount = 0;

                using (StreamReader sr = new StreamReader(path))
                {
                    while ((text = sr.ReadLine()) != null)
                    {
                        lineCount++;

                        // ヒットした行の前後2行を表示
                        if (lineCount >= hitLineNum - 2)
                        {
                            previewTextBox.Text += lineCount + " " + text + Environment.NewLine;
                        }
                        if (lineCount == hitLineNum + 2)
                        {
                            break;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                _logger.Error("File not opened");
                ShowDialog(Resources.language.FileNotOpen, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                ShowDialog(Resources.language.ErrorMessage, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
            }
        }

        #region And/OrButton_Click
        /// <summary>
        /// AndButton clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AndButton_Click(object sender, EventArgs e)
        {
            _radioButton_AND.Checked = true;
            if (_radioButton_OR.Checked)
            {
                _radioButton_OR.Checked = false;
            }
        }

        /// <summary>
        /// OrButton clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrButton_Click(object sender, EventArgs e)
        {
            _radioButton_OR.Checked = true;
            if (_radioButton_AND.Checked)
            {
                _radioButton_AND.Checked = false;
            }
        }
        #endregion

        /// <summary>
        /// ResultView_DoubleClick : Open with TextEditor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            const string signatureLine = "$L";
            const string signatureFile = "$F";
            const string defaultEditor = "notepad.exe";

            if (_listView_Result.SelectedItems.Count <= 0)
            {
                return;
            }

            try
            {
                XmlHandler xmlHandler = new XmlHandler();

                // ダブルクリックされた行の情報取得
                int index = _listView_Result.SelectedItems[0].Index;
                int lineNum = int.Parse(_listView_Result.Items[index].SubItems[1].Text);
                string filePath = _listView_Result.Items[index].SubItems[2].Text;

                // ExportSetting無の場合、notepad.exeを実行
                if (string.IsNullOrEmpty(xmlHandler.EditorPath))
                {
                    System.Diagnostics.Process.Start(defaultEditor, filePath);
                    _logger.Info("File opened with default editor");
                }
                else
                {
                    string param = xmlHandler.Parameter.Replace(signatureLine, lineNum.ToString());
                    param = param.Replace(signatureFile, filePath);
                    System.Diagnostics.Process.Start(xmlHandler.EditorPath, param);
                    _logger.Info("File opend with selected editor");
                }
            }
            catch (FileNotFoundException)
            {
                _logger.Error("File not found");
                ShowDialog(Resources.language.FileNotOpen, this.Text, MessageBoxButtons.OK, SystemIcons.Information);
            }
            catch (Win32Exception)
            {
                _logger.Error("Editor not found");
                ShowDialog(Resources.language.IncorrectTextEditor, this.Text, MessageBoxButtons.OK, SystemIcons.Information);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                ShowDialog(Resources.language.ErrorMessage, this.Text, MessageBoxButtons.OK, SystemIcons.Error);
            }
        }

        /// <summary>
        /// SearchPlaceBox_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPlaceBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// SearchPlaceBox_DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPlaceBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                return;
            }

            string[] dragFilePathArr = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            _textBox_SearchPlace.Text = dragFilePathArr[0];
        }

        /// <summary>
        /// DirGrepForm_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirGrepForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                VersionInfoForm myform2 = new VersionInfoForm();
                myform2.Left = this.Left + (this.Width - myform2.Width) / 2;
                myform2.Top = this.Top + (this.Height - myform2.Height) / 2;
                myform2.Show();
            }
            if (_checkBox_Search.Enabled == true && e.KeyCode == Keys.Enter)
            {
                if (_checkBox_Search.Checked == false)
                {
                    _checkBox_Search.Checked = true;
                }
                else
                {
                    _checkBox_Search.Checked = false;
                }

                // 検索実行
                _checkBox_Search_Click(sender, e);
            }
        }

        /// <summary>
        /// _textBox_SearchPlace_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_SearchPlace_TextChanged(object sender, EventArgs e)
        {
            SwitchEnabledProperty();
        }

        /// <summary>
        /// _comboBoc_SearchText_TextUpdate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _comboBoc_SearchText_TextUpdate(object sender, EventArgs e)
        {
            SwitchEnabledProperty();
        }

        /// <summary>
        /// When Form Closed : Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirGrepForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessSerialize();
            Application.Exit();
        }

        /// <summary>
        /// Change Language According to CurrentUICulture
        /// </summary>
        /// <param name="language"></param>
        private void ChangeLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);

            _button_Browse.Text = Resources.language._button_Browse;
            _checkBox_IgnoreCase.Text = Resources.language._checkBox_IgnoreCase;
            _checkBox_Search.Text = Resources.language._checkBox_Search;
            _checkBox_SearchByWord.Text = Resources.language._checkBox_SearchByWord;
            _checkBox_SearchSubDir.Text = Resources.language._checkBox_SearchSubDir;
            _label_Progress.Text = Resources.language._label_Progress;
            _label_SearchCondition.Text = Resources.language._label_SearchCondition;
            _label_SearchPlace.Text = Resources.language._label_SearchPlace;
            _label_SearchStatus.Text = Resources.language._label_SearchStatus;
            _label_SearchTarget.Text = Resources.language._label_SearchTarget;
            _label_SearchText.Text = Resources.language._label_SearchText;
        }
    }
}




