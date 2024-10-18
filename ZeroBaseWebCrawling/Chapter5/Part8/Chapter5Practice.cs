using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZeroBaseWebCrawling.Chapter5.Part2;

namespace ZeroBaseWebCrawling.Chapter5.Part8
{
    public class Chapter5Practice
    {
        public static void Run()
        {
            var webdriverFileName = Directory.GetFiles(".\\driver", "msedgedriver-*").FirstOrDefault();
            var driver = new EdgeDriver(webdriverFileName);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "https://www.nate.com/";
            var idBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"ID\"]")));
            idBox.SendKeys("[id]");
            var pwBox = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"PASSDM\"]")));
            pwBox.SendKeys("[password]");
            wait.Until(CustomConditions.ClickElementIfClickable(By.XPath("//*[@id=\"btnLOGIN\"]")));
            wait.Until(CustomConditions.ClickElementIfClickable(By.XPath("//*[@id=\"liMyInfoSelectedMail\"]")));
            var mailList = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[@id=\"list_body\"]/li")));
            var mailNo = 1;
            foreach (var mail in mailList)
            {
                var from = mail.FindElement(By.XPath("./div[2]/p[3]/a"));
                var fromText = from.Text;
                var title = mail.FindElement(By.XPath("./div[2]/p[4]/span/a[1]"));
                var titleText = title.Text;
                var date = mail.FindElement(By.XPath("./div[3]/p[1]"));
                var dateText = date.Text;
                Console.WriteLine($"no. {mailNo++} | from : {fromText} | title : {titleText} | date : {dateText}\n");
            }
        }
    }
}
