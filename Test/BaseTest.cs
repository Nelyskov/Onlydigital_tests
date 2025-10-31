using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Helpers;  
using Data;

namespace Test
{

    // Настройка для каждого теста
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected string browserType;
        
        // В каждом новом тесте необходимо переопределить, чтобы открывалась нужная страница
        protected abstract string Url { get; }

        public BaseTest(string browserType)
        {
            this.browserType = browserType;
        }

        [SetUp]
        public void SetUp()
        {
            Driver = BrowserFactory.CreateDriver(browserType);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
            Driver.Quit();
        }
    }
}