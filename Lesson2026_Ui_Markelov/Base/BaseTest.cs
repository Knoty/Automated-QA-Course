using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Base
{
    public class BaseTest
    {
        private readonly By _logInButton = By.XPath("//button[contains(., \"Войти\")]");
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
            this.BaseDriver.GoToUrl("login");
            this.BaseDriver.FillField(Constants.LoginInput, Constants.Username);
            this.BaseDriver.FillField(Constants.PasswordInput, Constants.Password);
            this.BaseDriver.Click(_logInButton);
        }
    }
}
