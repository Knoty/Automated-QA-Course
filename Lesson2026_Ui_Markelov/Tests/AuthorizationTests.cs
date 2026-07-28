using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class AuthorizationTests : Fixture
    {
        private AuthorizationPage _authorizationPage;
        private NewUserPage _createUserPage;

        [OneTimeSetUp]
        public override void SetUp()
        {
            base.SetUp();
            _authorizationPage = new AuthorizationPage(Driver._driver);
            _createUserPage = new NewUserPage(Driver._driver);
        }

        [TestCase("invalid", "invalid", TestName = "Попытка авторизации несуществующего аккаунта")]
        public void WrongAuthorization_ShowsErrorMessage(string login, string password)
        {
            bool errorMsg = _authorizationPage.IsInvalidLoginErrorDisplayed(login, password);
            Assert.IsTrue(errorMsg, "Некорректная авторизация не выдала сообщение об ошибке");
        }

        [TestCase(TestName = "Переход на страницу создания аккаунта")]
        public void OpenCreateUserPage_Success()
        {
            bool registerPageHeader = _authorizationPage.NavigateToCreateUserPage();
            Assert.IsTrue(registerPageHeader, "Страница создания пользователя не отобразилась после клика");
        }

        [TestCase("Имя", "password", TestName = "Создание аккаунта")]
        public void CreateNewUser_Success(string name, string password)
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string login = "login_" + uniqueId;
            string email = $"{login}@test.test";

            _authorizationPage.NavigateToCreateUserPage();
            bool anyCreateUserMessage = _createUserPage!.CreateUser(name, login, email, password);
            Assert.IsTrue(anyCreateUserMessage, "Сообщений о регистрации не появлялалось");
        }
    }
}
