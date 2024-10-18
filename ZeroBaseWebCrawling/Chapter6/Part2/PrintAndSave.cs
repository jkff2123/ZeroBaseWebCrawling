using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ZeroBaseWebCrawling.Chapter6.Part2
{
    public class PrintAndSave
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            driver.Url = "https://www.naver.com/";
            var title = driver.Title;

            var script = (IJavaScriptExecutor)driver;
            script.ExecuteScript("setTimeout(function(){window.print();},0);");

            Task.Delay(3000).Wait();
            PrintController.SelectPDFPrint(title);

            Task.Delay(1000).Wait();
            WindowController.AutoHandleOpenDialog("다른 이름으로 저장");
        }
    }
}
