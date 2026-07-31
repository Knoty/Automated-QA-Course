using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class CoursesRegisterTests : BaseTest
    {
        private CoursesRegisterPage? _page;
        private CoursesRegisterPage Page => _page ??= new CoursesRegisterPage(BaseDriver);

        public override void SetUp()
        {
            base.SetUp();
            this.LogIn();
        }

        [TestCase(TestName = "Регистрация новой должности на новый курс")]
        public void RegisterToNewCourseAndPostition()
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string course = "course_" + uniqueId;
            string position = "position_" + uniqueId;
            string surname = "surname_" + uniqueId;
            string name = "name_" + uniqueId;

            this.Page.RegisterToCourseAndPostition(course, position, surname, name);
        }
    }
}
