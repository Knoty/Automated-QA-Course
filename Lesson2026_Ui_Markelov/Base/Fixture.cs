using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Base
{
    public class Fixture
    {
        private const string LoginUrl = "login";
        private readonly By _welcomeHeader = By.XPath("//h1[.='Добро пожаловать']");
        private BasePage? _page;
        public required BaseDriver BaseDriver;
        private BasePage Page => _page ??= new BasePage(BaseDriver);


        [OneTimeSetUp]
        public virtual void SetUp()
        {
            this.BaseDriver = new BaseDriver();
        }

        [OneTimeTearDown]
        public virtual void TearDown()
        {
            this.BaseDriver?.Dispose();
        }

        public void LogIn()
        {
            this.BaseDriver.GoToUrl(LoginUrl);
            this.Page.FillField("Логин", Constants.Username);
            this.Page.FillField("Пароль", Constants.Password);
            this.Page.PressButton("Войти");
            this.BaseDriver.WaitUntilElementVisible(_welcomeHeader);
        }
    }
}
