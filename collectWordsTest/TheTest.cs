using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace collectWordsTest
{
    [TestClass]
    public sealed class TheTest
    {
        private static readonly string DriverDirectory = "c:\\WebDrivers";
        private static IWebDriver driver;

        [ClassInitialize]
        public static void setup(TestContext context)
        {
            driver = new EdgeDriver(DriverDirectory);
        }


        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://127.0.0.1:5501/index.html";
            driver.Navigate().GoToUrl(url);

            Assert.AreEqual("collectWords", driver.Title);

            IWebElement inputElement = driver.FindElement(By.Id("nameTextInput"));
            inputElement.SendKeys("Test string");

            IWebElement buttonElement = driver.FindElement(By.Id("saveButton"));
            buttonElement.Click();

            IWebElement buttonElementTwo = driver.FindElement(By.Id("showButton"));
            buttonElementTwo.Click();


            IList<IWebElement> rowElement = driver.FindElements(By.TagName("tr"));
            string rowText = rowElement[1].Text;


            Assert.AreEqual("0 Test string", rowText);
        }
    }
}
