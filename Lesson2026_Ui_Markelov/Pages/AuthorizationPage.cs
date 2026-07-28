using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class AuthorizationPage : BasePage
    {
        private readonly By _logInButton = By.XPath("//button[contains(., \"Войти\")]");
        private readonly By _errorMessagePath = By.XPath("//p[normalize-space()='Неверный логин или пароль']");

        public AuthorizationPage(IWebDriver driver) : base(driver) { }

        public void Login(string login, string pass)
        {
            _driver.FindElement(LoginInput).SendKeys(login);
            _driver.FindElement(PasswordInput).SendKeys(pass);
            _driver.FindElement(_logInButton).Click();
        }

        public bool IsInvalidLoginErrorDisplayed(string login = "WrongLogin", string pass = "WrongPass")
        {
            this.Login(login, pass);
            try
            {
                return _wait.Until(d => d.FindElement(_errorMessagePath).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool NavigateToCreateUserPage()
        {
            _wait.Until(d => d.FindElement(CreateUserButton).Displayed);
            _driver.FindElement(CreateUserButton).Click();            
            try
            {
                return _wait.Until(d => d.FindElement(RegisterPageHeaderPath).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}