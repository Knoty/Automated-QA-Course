using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class CoursesTests : Fixture
    {
        private CoursesPage? _page;
        private CoursesPage Page => _page ??= new CoursesPage(BaseDriver);

        public override void SetUp()
        {
            base.SetUp();
            this.LogIn();
        }

        [TestCase(TestName = "Добавление нового курса")]
        public void AddRecord()
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string name = "course_" + uniqueId;

            this.Page.AddRecord(name);

            var successfulyAddedMsg = BaseDriver.FindElement(this.Page.SuccessfulyAddedMsg).Displayed;
            Assert.IsTrue(successfulyAddedMsg, Constants.NoAddRecMsg);

        }
    }
}
