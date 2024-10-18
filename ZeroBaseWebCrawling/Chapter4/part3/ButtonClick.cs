using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ZeroBaseWebCrawling.Chapter4.part3
{
    public class ButtonClick
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            driver.Url = "https://www.naver.com/";

            var finance = driver.FindElement(By.XPath("//*[@id=\"shortcutArea\"]/ul/li[6]/a"));
            finance.Click();

            Console.ReadLine();

            driver.Quit();

        }
    }
}
