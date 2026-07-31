using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BaseTest
    {
        private const string _loginUrl = "login";
        private readonly By _logInButton = By.XPath("//button[contains(., \"Войти\")]");
        private readonly By _welcomeHeader = By.XPath("//h1[.='Добро пожаловать']");
        protected By AlreadyExistError => By.XPath("//p[contains(., 'уже существует')]");
        protected By SuccessfulyAddedMsg => By.XPath("//p[contains(., 'успешно добавлен')]");
        public required BaseDriver BaseDriver;

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
            this.BaseDriver.GoToUrl(_loginUrl);
            this.BaseDriver.FillField(Constants.LoginInput, Constants.Username);
            this.BaseDriver.FillField(Constants.PasswordInput, Constants.Password);
            this.BaseDriver.Click(_logInButton);
            this.BaseDriver.WaitUntilElementExist(_welcomeHeader);
        }
    }
}
