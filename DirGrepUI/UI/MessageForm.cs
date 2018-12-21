using System;
using System.Drawing;
using System.Windows.Forms;

namespace DirGrepUI
{
    public partial class MessageForm : Form
    {
        /// <summary>
        /// 表示するアイコン
        /// </summary>
        private Icon _icon;

        /// <summary>
        /// buttonTextは、OK, OKCancel, YesNoが有効
        /// </summary>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="rightText"></param>
        /// <param name="icon"></param>
        public MessageForm(string content, string title, MessageBoxButtons buttonText, Icon icon)
        {
            InitializeComponent();

            _label_Message.Text = content;
            this.Text = title;
            _icon = icon;

            switch ((int)buttonText)
            {
                case 0:
                    _button1.Text = buttonText.ToString();
                    _button2.Visible = false;
                    break;

                case 1:
                    _button1.Text = "OK";
                    _button2.DialogResult = DialogResult.OK;
                    _button2.Text = "Cancel";
                    _button2.DialogResult = DialogResult.Cancel;
                    break;

                case 4:
                    _button1.Text = "No";
                    _button1.DialogResult = DialogResult.No;
                    _button2.Text = "Yes";
                    _button2.DialogResult = DialogResult.Yes;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Load(object sender, EventArgs e)
        {
            using (DirGrepForm parentForm = new DirGrepForm())
            {
                Bitmap canvas = new Bitmap(_pictureBox.Width, _pictureBox.Height);

                using (Graphics graphics = Graphics.FromImage(canvas))
                {
                    graphics.DrawIcon(_icon, 0, 0);
                    _pictureBox.Image = canvas;
                }
            }
        }

        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_Right_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_Left_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
