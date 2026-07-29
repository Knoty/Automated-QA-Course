using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BaseDriver
    {
        private WebDriver _webDriver;
        public WebDriverWait Wait;

        public BaseDriver()
        {
            this._webDriver = this.StartBrowser();
            this.Wait = new WebDriverWait(this._webDriver, TimeSpan.FromSeconds(15));
        }

        public WebDriver StartBrowser()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }

        public void Dispose()
        {
            this._webDriver?.Quit();
            this._webDriver?.Dispose();
        }

        public void GoToUrl(string url = "")
        {
            this._webDriver.Url = Config.BaseUrl + url;
            this._webDriver.Navigate();
        }

        public void WaitUntilElementExist(By xpath)
        {
            try
            {
                this.Wait.Until(d => d.FindElement(xpath));
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
                this.Wait.Until(d =>
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
                this.Wait.Until(d =>
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
            return this._webDriver.FindElement(xpath);
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
