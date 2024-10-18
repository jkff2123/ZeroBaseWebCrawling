using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ZeroBaseWebCrawling.Chapter5.Part2
{
    public class CustomConditionsExecute
    {
        public static void Run()
        {
            Console.WriteLine("회사명을 입력해주세요.");
            var target = Console.ReadLine();

            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Url = "https://finance.naver.com/";
            var searchBox = driver.FindElement(By.XPath("//*[@id=\"stock_items\"]"));
            searchBox.SendKeys(target);
            wait.Until(CustomConditions.ClickElementIfClickable(By.XPath("//*[@id=\"atcmp\"]/div[1]/div/ul/li[1]/a")));
            var priceText = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"chart_area\"]/div[1]/div/p[1]")));
            var price = priceText.Text;

            price = price.Replace("\r\n", "");

            Console.WriteLine(target + " 주가 : " + price);

            Console.ReadLine();
            driver.Quit();
        }
    }
}
