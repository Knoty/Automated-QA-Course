using System;
using System.Collections.Generic;
using System.Text;

using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class CoursesPage : BasePage
    {
        public CoursesPage(BaseDriver baseDriver) : base(baseDriver, "directories/courses") { }

        public void AddRecord(string name)
        {
            this.OpenPage();
            this.PressButton("Добавить");
            this.FillField("Наименование", name);
            this.PressButton("Сохранить");
        }
    }
}
