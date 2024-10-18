using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace ZeroBaseWebCrawling.Chapter6.Part2
{
    public class WindowController
    {
        static public IntPtr FocusWindow(string targetTitle)
        {
            var windowHandles = GetAllWindows();
            var handle = IntPtr.Zero;
            foreach (var windowHandle in windowHandles)
            {
                handle = (IntPtr)windowHandle;
                var length = GetWindowTextLength(handle);
                var title = new StringBuilder(length);
                GetWindowText(handle, title, length);
                var titleText = title.ToString();
                if (!titleText.Contains(targetTitle))
                {
                    continue;
                }
                SetForegroundWindow(handle);
                break;
            }

            return handle;
        }

        private static ArrayList GetAllWindows()
        {
            var windowHandles = new ArrayList();
            EnumedWindow callBackPtr = GetWindowHandle;
            EnumWindows(callBackPtr, windowHandles);

            foreach (IntPtr windowHandle in windowHandles.ToArray())
            {
                EnumChildWindows(windowHandle, callBackPtr, windowHandles);
            }

            return windowHandles;
        }

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }

        public static void AutoHandleOpenDialog(string title, string filePath = "")
        {
            var handle = FindWindow("#32770", title);
            if (filePath != "")
            {
                var iptrHWndControl = GetDlgItem(handle, 1148);
                var hrefHWndTarget = new HandleRef(null, iptrHWndControl);
                SendMessage(hrefHWndTarget.Handle, WM_SETTEXT, 0, $"{filePath}");
            }
            Task.Delay(1000).Wait();
            var button = GetDlgItem(handle, 1);
            SendMessage(button, BM_CLICKED, 0, IntPtr.Zero);

            Task.Delay(1000).Wait();
        }

        private delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);
        // 모든 윈도우 리스트 가져오기
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);
        // 모든 자식 윈도우 리스트 가져오기
        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumedWindow callback, ArrayList lParam);
        // 윈도우 포커스 설정
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        // 윈도우 이름 가져오기
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        // 윈도우 이름 길이 가져오기
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        // 윈도우 찾기
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        // 윈도우 내 아이템(요소) 찾기
        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
        // 메세지 보내기1
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);
        // 메세지 보내기2
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, nuint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        // 키설정
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;
        public const uint WM_SETTEXT = 0x000C;
        public const uint BM_CLICKED = 0x00f5;
        public const Int32 VK_RETURN = 0x0D;
        public const Int32 VK_TAB = 0x09;
        public const Int32 VK_UP = 0x26;
        public const Int32 VK_SPACE = 0x20;
    }
}
