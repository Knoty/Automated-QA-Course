using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class NewUserPage : BasePage
    {
        private const string _path = "users";
        private readonly By _nameInput = By.XPath("//label[.=\"Имя\"]/following::input");
        private readonly By _emailInput = By.XPath("//label[.=\"Email\"]/following::input");
        private readonly By _passConfirmationInput = By.XPath("//label[.=\"Подтверждение пароля\"]/following::input");
        private readonly By _saveButton = By.XPath("//button[contains(., \"Сохранить\")]");

        public NewUserPage(BaseDriver driver) : base(driver, _path) { }

        public void CreateUser(string name, string login, string email, string password)
        {
            this.BaseDriver.FindElement(_nameInput).SendKeys(name);
            this.BaseDriver.FindElement(LoginInput).SendKeys(login);
            this.BaseDriver.FindElement(_emailInput).SendKeys(email);
            this.BaseDriver.FindElement(PasswordInput).SendKeys(password);
            this.BaseDriver.FindElement(_passConfirmationInput).SendKeys(password);

            this.BaseDriver.FindElement(_saveButton).Click();
        }
    }
}