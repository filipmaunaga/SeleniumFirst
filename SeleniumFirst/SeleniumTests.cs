using System; 
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace SeleniumFirst
{
    class SeleniumTests
    {
        IWebDriver driver;
        [Test]
        public void TestGoogleSearch()
        {
            Wait(3000);
            driver.Navigate().GoToUrl("https://www.google.com");
            System.Threading.Thread.Sleep(2000);
            IWebElement searchField = FindElementMethod(driver,By.Name("q"));
            if(searchField != null)
            {
                searchField.SendKeys("selenium tests");
                Wait(2000);
                searchField.SendKeys(Keys.Enter);
            }
            
            Wait(2000);
        }
        public IWebElement FindElementMethod(IWebDriver driver, By selector)
        {
            IWebElement elReturn = null;
            try
            {
                elReturn = driver.FindElement(selector);

            } catch (NoSuchElementException)
            {

            }
            catch (Exception e)
            {
                throw;
            }
            return elReturn; 
        }
        private static void Wait (int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void Destroy()
        {
            driver.Close();
        }
    }
}
