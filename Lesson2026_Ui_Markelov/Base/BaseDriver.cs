using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BaseDriver
    {
        public WebDriver _driver;

        public BaseDriver()
        {
            _driver = this.StartBrowser();
        }

        public WebDriver StartBrowser()
        {
            WebDriver _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        public void GoToUrl()
        {
            _driver.Url = Config.BaseUrl;
            _driver.Navigate();
        }

        public void WaitUntilElementExist(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(d => d.FindElement(xpath));
            }
            catch
            {
                throw new Exception($"{xpath} не существует на странице");
            }
        }

        public void WaitUntilElementVisible(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(d =>
                { 
                    var elem = d.FindElement(xpath);
                    return elem.Displayed ? elem : null;
                });
            }
            catch
            {
                throw new Exception($"{xpath} не виден на странице");
            }
        }

        public void WaitUntilElementClickable(By xpath)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(d =>
                {
                    var elem = d.FindElement(xpath);
                    return (elem.Displayed && elem.Enabled) ? elem : null;
                });
            }
            catch
            {
                throw new Exception($"{xpath} не кликабелен на странице");
            }
        }

        public IWebElement FindElement(By xpath)
        {
            this.WaitUntilElementExist(xpath);
            return _driver.FindElement(xpath);
        }

        public void Click(By xpath)
        {
            var el = this.FindElement(xpath);
            this.WaitUntilElementVisible(xpath);
            this.WaitUntilElementClickable(xpath);

            el.Click();
        }

        public void FillField(By xpath, string text)
        {
            var el = this.FindElement(xpath);
            this.WaitUntilElementVisible(xpath);
            this.WaitUntilElementClickable(xpath);

            el.SendKeys(text);
        }
    }
}
