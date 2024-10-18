using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ZeroBaseWebCrawling.Chapter4.Part4
{
    public class TextInput
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            driver.Url = "https://www.naver.com/";

            var searchBox = driver.FindElement(By.XPath("//*[@id=\"query\"]"));
            searchBox.SendKeys("셀레니움");
            var searchBtn = driver.FindElement(By.XPath("//*[@id=\"sform\"]/fieldset/button"));
            searchBtn.Click();

            Console.ReadLine();

            driver.Quit();
        }
    }
}
