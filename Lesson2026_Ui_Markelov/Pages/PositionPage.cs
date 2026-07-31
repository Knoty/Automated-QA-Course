using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class PositionPage : BasePage
    {
        public PositionPage(BaseDriver baseDriver) : base(baseDriver, "directories/positions") { }

        public void AddRecord(string name)
        {
            this.OpenPage();
            this.PressButton("Добавить");
            this.FillField("Наименование", name);
            this.PressButton("Сохранить");
        }
    }
}
