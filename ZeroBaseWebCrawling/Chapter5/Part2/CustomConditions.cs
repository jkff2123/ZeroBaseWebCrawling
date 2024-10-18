using OpenQA.Selenium;

namespace ZeroBaseWebCrawling.Chapter5.Part2
{
    public class CustomConditions
    {
        public static Func<IWebDriver, bool> ClickElementIfClickable(By locator)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    IWebElement webElement = driver.FindElement(locator);
                    if (webElement != null && webElement.Displayed && webElement.Enabled)
                    {
                        webElement.Click();
                        return true;
                    }
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

    }
}
