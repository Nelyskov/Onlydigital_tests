using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;


namespace Helpers
{
    // Возвращает Selenium driver в соотвествии с трубемым (указывается в готовых тестах)
    public class BrowserFactory
    {
        public static IWebDriver CreateDriver(string browserType)
        {
            return browserType.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                "safari" => new SafariDriver(),
                "ie" => new InternetExplorerDriver(),
                _ => throw new ArgumentException($"Unsupported browser type: {browserType}"),
            };
        }
    }
}