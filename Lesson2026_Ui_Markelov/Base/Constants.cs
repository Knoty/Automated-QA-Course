using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Base
{
    public class Constants
    {
        public static By loginInput => By.XPath("//label[.='Логин']/following::input");
        public static By passwordInput => By.XPath("//label[.='Пароль']/following::input");
        public static string username = "name";
        public static string password = "testpass";
    }
}
