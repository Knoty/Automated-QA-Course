using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class CoursesRegisterPage : BasePage
    {
        private CoursesPage _coursesnPage;
        private PositionPage _postionPage;

        public CoursesRegisterPage(BaseDriver baseDriver) : base(baseDriver, "courses/register")
        {
            _postionPage = new PositionPage(baseDriver);
            _coursesnPage = new CoursesPage(baseDriver);
        }

        public void RegisterToCourseAndPostition(string course, string position, string surname, string name)
        {
            _coursesnPage.AddRecord(course);
            _postionPage.AddRecord(position);
            this.OpenPage();
            Thread.Sleep(1000);
            this.FillField("Вид курса", course);
            Thread.Sleep(1000);
            this.ChooseComboboxValue("Должность", position);
            Thread.Sleep(1000);
            this.FillField("Фамилия", surname);
            Thread.Sleep(1000);
            this.BaseDriver.DoubleClick(By.XPath("//div[.='Имя']/..//div[.=' Дважды кликните для ввода имени ']"));
            Thread.Sleep(1000);
            this.FillField("Имя", name);
            Thread.Sleep(1000);
            this.PressButton("Сохранить");
        }
    }
}
