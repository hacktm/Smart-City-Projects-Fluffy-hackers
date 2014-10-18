using System.Runtime.InteropServices;

namespace HackProject.Model
{
    public class MouseCursor
    {
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        public static void MoveCursor(int x, int y)
        {
            SetCursorPos(x, y);
        }

    }
}