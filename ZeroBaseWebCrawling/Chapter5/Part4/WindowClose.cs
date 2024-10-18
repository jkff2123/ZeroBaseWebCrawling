using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using ZeroBaseWebCrawling.Chapter5.Part2;

namespace ZeroBaseWebCrawling.Chapter5.Part4
{
    public class WindowClose
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
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

            Console.WriteLine(driver.Title);
            Console.ReadLine();
            driver.Quit();
        }
    }
}
