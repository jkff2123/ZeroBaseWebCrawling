using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZeroBaseWebCrawling.Chapter5.Part2;

namespace ZeroBaseWebCrawling.Chapter5.Part7
{
    public class BackgroundExecute
    {
        public static void Run()
        {
            Console.WriteLine("회사명을 입력해주세요.");
            var target = Console.ReadLine();
            var options = new EdgeOptions();
            options.AddArgument("headless=old");
            options.AddArgument("window-size=1920x1080");
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName, options);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Url = "https://www.naver.com/";
            wait.Until(CustomConditions.ClickElementIfClickable(By.XPath("//*[@id=\"shortcutArea\"]/ul/li[6]/a")));
            foreach (var e in driver.WindowHandles)
            {
                if (e == driver.CurrentWindowHandle) { continue; }
                driver.SwitchTo().Window(e);
                break;
            }
            var currentWindowHandle = driver.CurrentWindowHandle;
            foreach (var e in driver.WindowHandles)
            {
                if (e == driver.CurrentWindowHandle) { continue; }
                driver.SwitchTo().Window(e);
                driver.Close();
                break;
            }
            driver.SwitchTo().Window(currentWindowHandle);
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
