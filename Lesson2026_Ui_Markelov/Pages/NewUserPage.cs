using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class NewUserPage : BasePage
    {
        private readonly By _nameInput = By.XPath("//label[.=\"Имя\"]/following::input");
        private readonly By _emailInput = By.XPath("//label[.=\"Email\"]/following::input");
        private readonly By _passConfirmationInput = By.XPath("//label[.=\"Подтверждение пароля\"]/following::input");
        private readonly By _saveButton = By.XPath("//button[contains(., \"Сохранить\")]");
        private readonly By _createUserErrorMessagePath = By.XPath(
            "//p[normalize-space()='Пользователь с таким логином уже существует']");
        private readonly By _createUserSuccessMessagePath = By.XPath(
            "//p[contains(normalize-space(), 'Пользователь') and contains(normalize-space(), 'создан')]");

        public NewUserPage(IWebDriver driver) : base(driver) { }

        private bool WaitForAnyElementVisible(By locator1, By locator2)
        {
            return _wait.Until(driver =>
            {
                var elements1 = driver.FindElements(locator1);
                var elements2 = driver.FindElements(locator2);
                return elements1.Any(e => e.Displayed) || elements2.Any(e => e.Displayed);
            });
        }

        public bool CreateUser(string name, string login, string email, string password)
        {
            _driver.FindElement(_nameInput).SendKeys(name);
            _driver.FindElement(LoginInput).SendKeys(login);
            _driver.FindElement(_emailInput).SendKeys(email);
            _driver.FindElement(PasswordInput).SendKeys(password);
            _driver.FindElement(_passConfirmationInput).SendKeys(password);

            _driver.FindElement(_saveButton).Click();

            return this.WaitForAnyElementVisible(_createUserErrorMessagePath, _createUserSuccessMessagePath);            
        }
    }
}