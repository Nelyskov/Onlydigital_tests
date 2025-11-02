using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages;
using Helpers;  
using Data;

namespace Test
{

    // Настройка для каждого теста
    // Каждый тест наследуется от BaseTest и в конструктор должен передавать тип браузера (строковый тип)
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected string browserType;
        
        protected abstract string Url { get; }  // В каждом новом тесте необходимо переопределить Url (который будет реализовываться), чтобы открывалась нужная страница

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