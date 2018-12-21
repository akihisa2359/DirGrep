using System;
using System.Windows.Forms;
using System.Drawing;

namespace DirGrepUI
{
    static class Program
    {
        static private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            _logger.Info("Applicatoin is starting");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // 2重起動防止
                if (!PrevInstance())
                {
                    Application.Run(new DirGrepForm());
                }
            }
            catch (Exception e)
            {
                _logger.Error(e.StackTrace);
                MessageForm messageForm = new MessageForm(Resources.language.ErrorMessage, "DirGrep", MessageBoxButtons.OK, SystemIcons.Error);
                messageForm.ShowDialog();
            }
            finally
            {
                _logger.Info("ProcessFinished");
            }
        }

        /// <summary>
        /// When UI already running, not open new one
        /// </summary>
        /// <returns></returns>
        private static bool PrevInstance()
        {
            // このアプリケーションのプロセス名を取得
            string stThisProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            if (System.Diagnostics.Process.GetProcessesByName(stThisProcess).Length > 1)
            {
                return true;
            }

            // 存在しない場合
            return false;
        }
    }
}
