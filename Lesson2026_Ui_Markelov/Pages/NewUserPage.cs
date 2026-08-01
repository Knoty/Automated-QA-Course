using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class NewUserPage : BasePage
    {
        private const string Url = "users";

        public NewUserPage(BaseDriver driver) : base(driver, Url) { }

        public void CreateUser(string name, string login, string email, string password)
        {
            this.FillField("Имя", name);
            this.FillField("Логин", login);
            this.FillField("Email", email);
            this.FillField("Пароль", password);
            this.FillField("Подтверждение пароля", password);
            this.PressButton("Сохранить");
        }
    }
}