using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Base
{
    public abstract class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected By LoginInput => By.XPath("//label[.='Логин']/following::input");
        protected By PasswordInput => By.XPath("//label[.='Пароль']/following::input");
        protected By CreateUserButton => By.XPath("//button[contains(., \"Создать пользователя\")]");

        protected By RegisterPageHeaderPath => By.XPath("//h1[text()='Создание пользователя']");
    }
}
