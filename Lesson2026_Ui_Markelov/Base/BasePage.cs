using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BasePage
    {
        private string _path;
        public BaseDriver BaseDriver;

        public BasePage(BaseDriver baseDriver, string path = "")
        {
            _path = path;         
            BaseDriver = baseDriver;
        }

        protected By LoginInput => By.XPath("//label[.='Логин']/..//input");
        protected By PasswordInput => By.XPath("//label[.='Пароль']/..//input");
        protected By CreateUserButton => By.XPath("//button//span[.='Создать пользователя']");
        protected By RegisterPageHeaderPath => By.XPath("//h1[.='Создание пользователя']");
        protected By SuccessfulySaveMsg => By.XPath("//p[contains(., 'успешно сохранена')]");

        public void OpenPage()
        {
            BaseDriver.GoToUrl(_path);
        }

        public bool IsButtonExistAndClickable(string button)
        {
            return BaseDriver.WaitUntilElementClickable(By.XPath($"//button//span[.='{button}']"));
        }

        public void PressButton(string button)
        {
            BaseDriver.Click(By.XPath($"//button//span[.='{button}']"));
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
