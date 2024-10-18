using OpenQA.Selenium.Edge;

namespace ZeroBaseWebCrawling.Chapter4.Part2
{
    public class ExecuteSelenium
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            driver.Url = "https://www.naver.com/";

            Console.ReadLine();

            driver.Quit();
        }
    }
}
