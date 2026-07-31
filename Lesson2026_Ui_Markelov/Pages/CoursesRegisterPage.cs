using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class CoursesRegisterPage : BasePage
    {
        private CoursesPage _coursesnPage;
        private PositionPage _postionPage;


        protected By SuccessfulyAddedMsg => By.XPath("//p[contains(., 'успешно сохранена')]");



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
            this.ChooseComboboxValue("Вид курса", course);
            this.ChooseComboboxValue("Должность", position);
            this.FillField("Фамилия", surname);
            this.BaseDriver.DoubleClick(By.XPath("//div[.='Имя']/..//div[@class='first-name-trigger']"));
            this.FillField("Имя", name);
            this.PressButton("Сохранить");
            this.BaseDriver.WaitUntilLoading();
            this.PressButton("Сохранить");
            this.BaseDriver.WaitUntilElementExist(SuccessfulyAddedMsg);
        }
    }
}
