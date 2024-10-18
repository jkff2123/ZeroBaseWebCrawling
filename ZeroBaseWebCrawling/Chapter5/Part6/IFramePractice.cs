using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZeroBaseWebCrawling.Chapter5.Part2;

namespace ZeroBaseWebCrawling.Chapter5.Part6
{
    public class IFramePractice
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Url = "https://www.w3schools.com/jsref/tryit.asp?filename=tryjsref_alert";

            var innerFrame = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"iframeResult\"]")));
            driver.SwitchTo().Frame(innerFrame);
            // 메인 프레임으로 전환
            // driver.SwitchTo().DefaultContent();
            // 상위 프레임으로 전환
            // driver.SwitchTo().ParentFrame();
            wait.Until(CustomConditions.ClickElementIfClickable(By.XPath("/html/body/button")));

            var alert = wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }
    }
}
