namespace ZeroBaseWebCrawling.Chapter6.Part2
{
    public class PrintController
    {
        public static void SelectPDFPrint(string title)
        {
            var handle = WindowController.FocusWindow(title);
            var keyList = new int[] {
                WindowController.VK_TAB
                , WindowController.VK_TAB
                , WindowController.VK_UP
                , WindowController.VK_UP
                , WindowController.VK_UP
                , WindowController.VK_UP
                , WindowController.VK_UP
                , WindowController.VK_TAB
                , WindowController.VK_TAB
                , WindowController.VK_TAB
                , WindowController.VK_TAB
                , WindowController.VK_TAB
                , WindowController.VK_SPACE };
            foreach (var key in keyList)
            {
                Task.Delay(500).Wait();
                WindowController.SendMessage(handle, WindowController.WM_KEYDOWN, key, IntPtr.Zero);
                WindowController.SendMessage(handle, WindowController.WM_KEYUP, key, IntPtr.Zero);
            }
        }
    }
}
