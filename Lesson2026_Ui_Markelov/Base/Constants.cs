using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Base
{
    public class Constants
    {
        public static By LoginInput => By.XPath("//label[.='Логин']/following::input");
        public static By PasswordInput => By.XPath("//label[.='Пароль']/following::input");
        public static string Username => "name";
        public static string Password => "testpass";
    }
}
