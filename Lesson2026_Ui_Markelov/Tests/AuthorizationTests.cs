using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class AuthorizationTests : BaseTest
    {
        private AuthorizationPage? _authorizationPage;
        private NewUserPage? _createUserPage;
        private readonly By _createUserSuccessMessagePath = By.XPath(
            "//p[contains(normalize-space(), 'Пользователь') and contains(normalize-space(), 'создан')]");

        private AuthorizationPage AuthorizationPage =>
            _authorizationPage ??= new AuthorizationPage(BaseDriver);
        private NewUserPage CreateUserPage =>
            _createUserPage ??= new NewUserPage(BaseDriver);

        [OneTimeSetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.AuthorizationPage.OpenPage();
        }

        [TestCase("invalid", "invalid", TestName = "Попытка авторизации несуществующего аккаунта")]
        public void WrongAuthorization_ShowsErrorMessage(string login, string password)
        {
            bool isErrorMsgDisplayed = this.AuthorizationPage.IsInvalidLoginErrorDisplayed(login, password);
            Assert.IsTrue(isErrorMsgDisplayed, "Некорректная авторизация не выдала сообщение об ошибке");
        }

        [TestCase(TestName = "Переход на страницу создания аккаунта")]
        public void OpenCreateUserPage_Success()
        {
            bool isRegisterPageHeaderDisplayed = this.AuthorizationPage.NavigateToCreateUserPage();
            Assert.IsTrue(isRegisterPageHeaderDisplayed, "Страница создания пользователя не отобразилась после клика");
        }

        [TestCase("Имя", "password", TestName = "Создание аккаунта")]
        public void CreateNewUser(string name, string password)
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string login = "login_" + uniqueId;
            string email = $"{login}@test.test";

            this.AuthorizationPage.NavigateToCreateUserPage();
            this.CreateUserPage.CreateUser(name, login, email, password);
            bool isAnyCreateUserMessage = this.BaseDriver.WaitForAnyElementDisplayed(this.AlreadyExistError, _createUserSuccessMessagePath);
            Assert.IsTrue(isAnyCreateUserMessage, "Сообщений о регистрации не появлялось");
        }
    }
}
