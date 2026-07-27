using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class AuthorizationTests
    {
        public IWebDriver? _driver;
        public AuthorizationPage? _authorizationPage;
        public CreateUserPage? _createUserPage;

        [SetUp]
        protected void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = Config.BaseUrl;
            _authorizationPage = new AuthorizationPage(_driver);
            _createUserPage = new CreateUserPage(_driver);
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                try
                {
                    if (_driver is ITakesScreenshot screenshotTaker)
                    {
                        var screenshot = screenshotTaker.GetScreenshot();
                        string fileName = 
                            $"screenshot_{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                        screenshot.SaveAsFile(fileName);
                        TestContext.AddTestAttachment(fileName);
                    }
                    else
                    {
                        TestContext.WriteLine("Драйвер не поддерживает создание скриншотов");
                    }
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine($"Ошибка создания скриншота: {ex.Message}");
                }
            }

            _driver?.Quit();
            _driver?.Dispose();
        }

        [TestCase("invalid", "invalid", TestName = "Попытка авторизации несуществующего аккаунта")]
        public void WrongAuthorization_ShowsErrorMessage(string login, string password)
        {
            bool errorMsg = _authorizationPage!.IsInvalidLoginErrorDisplayed(login, password);
            Assert.IsTrue(errorMsg, "Некорректная авторизация не выдала сообщение об ошибке");
        }

        [TestCase(TestName = "Переход на страницу создания аккаунта")]
        public void OpenCreateUserPage_Success()
        {
            bool registerPageHeader = _authorizationPage!.NavigateToCreateUserPage();
            Assert.IsTrue(registerPageHeader, "Страница создания пользователя не отобразилась после клика");
        }

        [TestCase("Имя", "password", TestName = "Создание аккаунта")]
        public void CreateNewUser_Success(string name, string password)
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string login = "login_" + uniqueId;
            string email = $"{login}@test.test";

            _authorizationPage!.NavigateToCreateUserPage();
            bool anyCreateUserMessage = _createUserPage!.CreateUser(name, login, email, password);
            Assert.IsTrue(anyCreateUserMessage, "Сообщений о регистрации не появлялалось");
        }
    }
}
