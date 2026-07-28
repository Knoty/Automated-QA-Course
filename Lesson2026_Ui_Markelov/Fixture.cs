using Lesson2026_Ui_Markelov.Base;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov
{
    public class Fixture
    {
        private readonly By _logInButton = By.XPath("//button[contains(., \"Войти\")]");
        public required BaseDriver Driver;

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            Driver = new BaseDriver();
            this.LogIn();
        }

        [OneTimeTearDown]
        public virtual void TearDown()
        {
            Driver?.Dispose();
        }

        public void LogIn()
        {
            Driver.GoToUrl();
            Driver.FillField(Constants.loginInput, Constants.username);
            Driver.FillField(Constants.passwordInput, Constants.password);
            Driver.Click(_logInButton);
        }
    }
}
