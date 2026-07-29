using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class AuthorizationPage : BasePage
    {
        private const string _path = "login";
        private readonly By _logInButton = By.XPath("//button[contains(., \"Войти\")]");
        private readonly By _errorMessagePath = By.XPath("//p[normalize-space()='Неверный логин или пароль']");

        public AuthorizationPage(BaseDriver driver) : base(driver, _path) { }

        public void Login(string login, string pass)
        {
            BaseDriver.FindElement(LoginInput).SendKeys(login);
            BaseDriver.FindElement(PasswordInput).SendKeys(pass);
            BaseDriver.FindElement(_logInButton).Click();
        }

        public bool IsInvalidLoginErrorDisplayed(string login = "WrongLogin", string pass = "WrongPass")
        {
            this.Login(login, pass);
            try
            {
                return BaseDriver.Wait.Until(d => d.FindElement(_errorMessagePath).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool NavigateToCreateUserPage()
        {
            BaseDriver.Wait.Until(d => d.FindElement(CreateUserButton).Displayed);
            BaseDriver.FindElement(CreateUserButton).Click();            
            try
            {
                return BaseDriver.Wait.Until(d => d.FindElement(RegisterPageHeaderPath).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}