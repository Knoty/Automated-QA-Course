using Lesson2026_Ui_Markelov.Base;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class AuthorizedTests : BaseTest
    {
        private BasePage _page;

        [OneTimeSetUp]
        public override void SetUp()
        {
            base.SetUp();
            base.LogIn();
            _page = new BasePage(BaseDriver, "directories/courses");
        }

        [Test]
        public void Test()
        {
            _page.OpenPage();
            _page.PressButton("Добавить");
        }
    }
}
