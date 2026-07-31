using Lesson2026_Ui_Markelov.Base;
using Lesson2026_Ui_Markelov.Pages;

using NUnit.Framework;

namespace Lesson2026_Ui_Markelov.Tests
{
    public class PositionsTests : BaseTest
    {
        private PositionPage? _page;
        private PositionPage Page => _page ??= new PositionPage(BaseDriver);

        public override void SetUp()
        {
            base.SetUp();
            this.LogIn();
        }

        [TestCase(TestName = "Добавление новой должности")]
        public void AddRecord()
        {
            string uniqueId = Guid.NewGuid().ToString("N").Substring(0, 8);
            string name = "position_" + uniqueId;

            this.Page.AddRecord(name);

            var successfulyAddedMsg = BaseDriver.FindElement(this.SuccessfulyAddedMsg).Displayed;
            Assert.IsTrue(successfulyAddedMsg, Constants.IsAnyAddRecMsg);
        }
    }
}
