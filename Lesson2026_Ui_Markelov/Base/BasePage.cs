using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BasePage
    {
        private string _url;
        public BaseDriver BaseDriver;
        protected By SuccessfulySaveMsg => By.XPath("//p[contains(., 'успешно сохранена')]");
        public By SuccessfulyAddedMsg => By.XPath("//p[contains(., 'успешно добавлен')]");

        public BasePage(BaseDriver baseDriver, string url = "")
        {
            _url = url;         
            BaseDriver = baseDriver;
        }

        public void OpenPage()
        {
            BaseDriver.GoToUrl(_url);
        }

        public bool IsButtonExistAndClickable(string button)
        {
            return BaseDriver.WaitUntilElementClickable(By.XPath($"//button//span[.='{button}']"));
        }

        public void PressButton(string button)
        {
            BaseDriver.Click(By.XPath($"//button//span[normalize-space()='{button}']"));
        }

        public void FillField(string fieldName, string text)
        {
            BaseDriver.FillField(By.XPath($"//label[.='{fieldName}']/..//input"), text);
        }

        public void ChooseComboboxValue(string combobox, string option)
        {
            BaseDriver.Click(By.XPath($"//label[.='{combobox}']/..//*[@class='el-select']"));
            BaseDriver.Click(By.XPath($"//div[@aria-hidden='false']//li/span[normalize-space()='{option}']"));
        }

        public bool WaitForMsg(string msg)
        {
            try
            {
                BaseDriver.Wait.Until(d => d.FindElements(By.XPath($"//p[normalize-space()='{msg}']")).Any());
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool WaitForSuccessSaveMsg()
        {
            try
            {
                BaseDriver.Wait.Until(d => d.FindElements(SuccessfulySaveMsg).Any());
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
