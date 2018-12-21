using System;
using System.Windows.Forms;

namespace DirGrepUI
{
    public partial class VersionInfoForm : Form
    {
        /// <summary>
        /// ログを出力するための変数
        /// </summary>
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// InitializeComponent
        /// </summary>
        public VersionInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When Opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoForm_Load(object sender, EventArgs e)
        {
            _logger.Info("OpenVersionInfo");
        }

        /// <summary>
        ///  Link Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _label_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                _label_Link.LinkVisited = true;
                System.Diagnostics.Process.Start("https://www.acty-sys.com/jp/ja/");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.StackTrace);
                MessageBox.Show(Resources.language.ErrorMessage, "DirGerp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// OK Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_OK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Enter or Escape clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        /// <summary>
        /// Mail Cliicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _label_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:a.makimoto@acty-sys.co.jp");
            }
            catch(Exception ex)
            {
                _logger.Error(ex.StackTrace);
                MessageBox.Show(Resources.language.ErrorMessage);
            }
        }

        /// <summary>
        /// When Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _logger.Info("CloseVersionInfo");
        }
    }
}
