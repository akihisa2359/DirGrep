using System.Drawing;
using System.Windows.Forms;

namespace DirGrepUI.Data
{
    public class WindowsState
    {
        /// <summary>
        /// X, Y Coordination
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Window Size
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Maximized, Minimized, or Normal
        /// </summary>
        public FormWindowState WindowState { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public WindowsState() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="size"></param>
        /// <param name="windowsState"></param>
        public WindowsState(int locationX, int locationY, Size size, FormWindowState windowsState)
        {
            Size = size;
            WindowState = windowsState;
            Position = new Point(locationX, locationY);
        }
    }
}
