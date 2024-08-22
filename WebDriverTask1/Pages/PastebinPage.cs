using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace WebDriverTask1.Pages
{
    public class PastebinPage
    {
        private readonly WebDriver driver;

        public PastebinPage(WebDriver driver)
        {
            this.driver = driver;
        }

        readonly By textArea = By.XPath("//*[@id='postform-text']");
        readonly By pasteNameArea = By.XPath("//*[@id='postform-name']");
        readonly By filledTextArea = By.XPath("//div[@class='source text']/ol/li/div");
        readonly By filledTitleArea = By.XPath("//div[@class='info-top']/h1");
        readonly By expirationTimeArea = By.XPath("//div[@class='expire']");

        public void TypeNewPaste(string input)
        {
            driver.FindElement(textArea).SendKeys(input);
        }

        public void SetPasteExpiration(string pasteExpirationSelector, string selectedValue)
        {
            driver.ExecuteJavaScript($"document.querySelector('{pasteExpirationSelector}').value = '{selectedValue}'");
        }

        public void TypePasteName(string pasteName)
        {
            driver.FindElement(pasteNameArea).SendKeys(pasteName);
        }

        public string GetFilledTextAreaValue()
        {
            return driver.FindElement(filledTextArea).Text;
        }

        public string GetFilledTitleAreaValue()
        {
            return driver.FindElement(filledTitleArea).Text;

        }

        public string GetExpirationTimeAreaValue()
        {
            return driver.FindElement(expirationTimeArea).Text;

        }
    }
}