using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace Pages
{
    // В классе определено множество методов для взаимодействия со страницей и элементами на ней (Selenium + JavaScript )
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        
        // Стандартные методы Selenium для взаимодействия со страницей и элементами на ней
        public IWebElement FindElement(By by)   // Поиск элемента на странице с ожиданием его появления
        {
            return Wait.Until(driver => driver.FindElement(by));
        }
        
        public void InputText(By by, string text)   // Ввод текста в поле ввода
        {
            var element = FindElement(by);
            element.Clear();
            element.SendKeys(text);
        }

        public void Click(By by)     // Клик по элементу
        {
            var element = FindElement(by);
            element.Click();
        }
        public bool IsElementExist(By by) // Проверка, существует ли элемент на странице
        {
            try
            {
                FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementDisplayed(By by)   // Проверка, отображается ли элемент на странице
        {
            try
            {
                return FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SwithToNewTab() // Переключение на новую вкладку браузера
        {
            Wait.Until(d => d.Url != "about:blank");
            var tabs = Driver.WindowHandles;
            Driver.SwitchTo().Window(tabs[tabs.Count - 1]);
        }


        // Далее перечислены JavaScript методы для взаимодействия со страницей, так как Selenium не реализовывает их, а также они могут быть полезны в неокторых тестах
        public void ScrollToElement(IWebElement element)    // Скролл к конкретному элементу
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void ScrollToBottom()    // Скролл в конец страницы
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }

        public void ClickElement(IWebElement element)  // Клик по элементу через JavaScript
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SetInputValue(IWebElement element, string value) // Изменение значения поля ввода
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].value = arguments[1];", element, value);
        }

        public bool IsPageLoaded() // Проверка, загружена ли страница полностью
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState;").ToString() == "complete";
        }


    }
}