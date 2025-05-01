using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestingForAssignment;

namespace SeleniumTests
{
    public class SeleniumTestsForCode
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            Assert.That(driver, Is.Not.Null, "Driver initialization failed."); // Ensure driver is not null
        }

        [Test]
        public void CasualGamer_Age25_ShouldShowPremium5()
        {
            Assert.That(driver, Is.Not.Null, "Driver is null in test method."); // Ensure driver is not null before use
            driver!.Navigate().GoToUrl("https://localhost:5001"); // Adjust port if needed
            driver.FindElement(By.Name("age")).SendKeys("25");
            var dropdown = driver.FindElement(By.Name("gameMode"));
            dropdown.FindElement(By.CssSelector("option[value='casual']")).Click();
            driver.FindElement(By.CssSelector("button")).Click();
            var discountService = new DefaultDiscountService();
            var service = new GameService(discountService);

            var result = driver.FindElement(By.TagName("p")).Text;
            Assert.That(result.Contains("5"));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
