using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverTask1.Pages;

namespace WebDriverTask1.Tests
{
    [TestFixture]
    public class PastebinPageTests
    {
        ChromeDriver driver;
        PastebinPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://pastebin.com/";

            page = new PastebinPage(driver);
        }

        [Test]
        public void TestMethod_PutValues_DisplayesPutValues()
        {
            page.TypeNewPaste("Hello from WebDriver");

            page.SetPasteExpiration("#postform-expiration", "10M");

            page.TypePasteName("helloweb");

            driver.FindElement(By.XPath("//*[@class='btn -big']")).Click();

            Assert.That(page.GetFilledTextAreaValue(), Is.EqualTo("Hello from WebDriver"));
            Assert.That(page.GetExpirationTimeAreaValue(), Is.EqualTo("10 MIN"));
            Assert.That(page.GetFilledTitleAreaValue(), Is.EqualTo("helloweb"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}