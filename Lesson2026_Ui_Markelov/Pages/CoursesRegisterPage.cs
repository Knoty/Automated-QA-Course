using Lesson2026_Ui_Markelov.Base;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lesson2026_Ui_Markelov.Pages
{
    public class CoursesRegisterPage : BasePage
    {
        private readonly By _testCheckMsg = By.XPath("//p[.='Алё че с тестами?']");
        private readonly By _nameFieldTrigger = By.XPath("//div[.='Имя']/..//div[@class='first-name-trigger']");
        private CoursesPage _coursesnPage;
        private PositionPage _postionPage;

        public CoursesRegisterPage(BaseDriver baseDriver) : base(baseDriver, "courses/register")
        {
            _postionPage = new PositionPage(baseDriver);
            _coursesnPage = new CoursesPage(baseDriver);
        }

        public bool RegisterToCourseAndPostition(
            string course,
            string position,
            string surname,
            string name,
            int saveAttempts)
        {
            _coursesnPage.AddRecord(course);
            _postionPage.AddRecord(position);
            this.OpenPage();
            this.ChooseComboboxValue("Вид курса", course);
            this.ChooseComboboxValue("Должность", position);
            this.FillField("Фамилия", surname);
            this.BaseDriver.DoubleClick(_nameFieldTrigger);
            this.FillField("Имя", name);
            return SaveWithRetry(saveAttempts);
        }

        private bool SaveWithRetry(int maxAttempts)
        {
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                if (!this.IsButtonExistAndClickable("Сохранить"))
                {
                    return this.WaitForSuccessSaveMsg();
                }

                this.PressButton("Сохранить");

                string? msgType = WaitForAnyMsg();
                if (msgType == "success")
                    return true;
                if (msgType == "testCheck")
                {
                    this.BaseDriver.WaitUntilElementDisappears(_testCheckMsg);
                    continue;
                }

                if (!this.IsButtonExistAndClickable("Сохранить"))
                {
                    return this.WaitForSuccessSaveMsg();
                }
                else
                {
                    throw new Exception("После нажатия 'Сохранить' не появилось ни одного сообщения");
                }
            }

            throw new Exception($"Не удалось успешно сохранить после {maxAttempts} попыток");
        }

        private string? WaitForAnyMsg()
        {
            try
            {
                return this.BaseDriver.Wait.Until(d =>
                {
                    if (d.FindElements(SuccessfulySaveMsg).Any())
                        return "success";
                    if (d.FindElements(_testCheckMsg).Any())
                        return "testCheck";
                    return null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}
