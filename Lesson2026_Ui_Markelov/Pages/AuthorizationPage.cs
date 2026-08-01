using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class AuthorizationPage : BasePage
    {
        private const string Url = "login";
        private readonly By _registerPageHeaderPath = By.XPath("//h1[.='Создание пользователя']");

        public AuthorizationPage(BaseDriver driver) : base(driver, Url) { }

        public void Login(string login, string pass)
        {
            this.FillField("Логин", login);
            this.FillField("Пароль", pass);
            this.PressButton("Войти");
        }

        public bool IsInvalidLoginErrorDisplayed(string login, string pass)
        {
            this.OpenPage();
            this.Login(login, pass);
            try
            {
                return this.WaitForMsg("Неверный логин или пароль");
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool NavigateToCreateUserPage()
        {
            this.PressButton("Создать пользователя");
            try
            {
                return this.BaseDriver.WaitUntilElementVisible(_registerPageHeaderPath);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}