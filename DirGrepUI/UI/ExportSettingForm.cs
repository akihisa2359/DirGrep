using System;
using System.Windows.Forms;
using System.IO;
using DirGrepUI.Data;
using System.Threading;
using System.Globalization;
using System.Drawing;

namespace DirGrepUI
{
    public partial class ExportSettingForm : Form
    {
        const string MessageTitle = "DirGrep";

        /// <summary>
        /// ログを出力するための変数
        /// </summary>
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// キャンセルボタンが押されたときのフラグ
        /// </summary>
        private bool IsCancelButton = false;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        public ExportSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load : Deserialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportSettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                XmlHandler xmlHandler = new XmlHandler();

                _logger.Info("OpenExportSetting");
                FormData formData = xmlHandler.Deserialize();
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(formData.Language);
                _textBox_Editor.Text = formData.ExportSetting.Path;
                _textBox_Parameter.Text = formData.ExportSetting.Parameter;
                this.MaximizeBox = !this.MaximizeBox;
                this.MinimizeBox = !this.MinimizeBox;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                MessageForm messageForm = new MessageForm(Resources.language.ErrorMessage, MessageTitle, MessageBoxButtons.OK, SystemIcons.Error);
                messageForm.ShowDialog();
                Close();
            }
        }

        /// <summary>
        /// Form_Closed : Serialize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportSettingForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            try
            {
                // Cancel以外の場合、現データをSerialize
                if (IsCancelButton == false)
                {
                    ExportSetting exportSetting = new ExportSetting(_textBox_Editor.Text, _textBox_Parameter.Text);
                    XmlHandler xmlHandler = new XmlHandler(exportSetting);
                    xmlHandler.Serialize();
                }

                _logger.Info("CloseExportSettins");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                MessageForm messageForm = new MessageForm(Resources.language.ErrorMessage, MessageTitle, MessageBoxButtons.OK, SystemIcons.Error);
                messageForm.ShowDialog();
                Close();
            }
        }

        /// <summary>
        /// ChooseButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();

                if (System.IO.File.Exists(_textBox_Editor.Text))
                {
                    dlg.InitialDirectory = _textBox_Editor.Text;
                }
                else
                {
                    dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _textBox_Editor.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                MessageForm messageForm = new MessageForm(Resources.language.ErrorMessage, MessageTitle, MessageBoxButtons.OK, SystemIcons.Error);
                messageForm.ShowDialog();
            }
        }

        /// <summary>
        /// ClearButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _textBox_Parameter.Clear();
        }

        /// <summary>
        /// OKButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// CancelButton_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            IsCancelButton = true;
            Close();
        }

        #region KeyPress
        /// <summary>
        /// _textBox_Editor_KeyPress : Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_Editor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// _textBox_Parameter_KeyPress : Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_Parameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Enter or Escape Press : Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportSettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }
        #endregion
    }
}
