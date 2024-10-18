using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace ZeroBaseWebCrawling.Chapter4.Part6
{
    public class Chapter4Practice
    {
        public static void Run()
        {
            Console.WriteLine("회사명을 입력해주세요.");
            var target = Console.ReadLine();

            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            driver.Url = "https://finance.naver.com/";

            var searchBox = driver.FindElement(By.XPath("//*[@id=\"stock_items\"]"));
            searchBox.SendKeys(target);
            Task.Delay(100).Wait();
            var searchItem = driver.FindElement(By.XPath("//*[@id=\"atcmp\"]/div[1]/div/ul/li[1]/a"));
            searchItem.Click();
            Task.Delay(100).Wait();
            var priceText = driver.FindElement(By.XPath("//*[@id=\"chart_area\"]/div[1]/div/p[1]"));
            var price = priceText.Text;

            price = price.Replace("\r\n", "");

            Console.WriteLine(target + " 주가 : " + price);

            Console.ReadLine();

            driver.Quit();
        }
    }
}
