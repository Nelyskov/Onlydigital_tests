using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Helpers;
using Data;

namespace Test
{
    // Тесты для браузеров GOogle Chrome и Mozilla Firefox
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    // [Parallelizable(ParallelScope.All)] - Тест выполняются последовательно, а не параллельно
    public class MainPageFooterTests : BaseTest
    {
        BasePage basePage;
        protected override string Url => "https://only.digital/"; // Url для тестирования футера
        public MainPageFooterTests(string browserType) : base(browserType) { }

        [Test]
        [TestCaseSource(typeof(MainPageFooterTestData), nameof(MainPageFooterTestData.GetFooterElements))] // Использование TestCaseSource для получения данных из FooterTestData
        public void FooterElements_ShouldBeExist(By locator, string elementName) // Данный тест проверяет существование всех элементов определенных в TestData
        {
            basePage = new BasePage(Driver);
            basePage.NavigateTo(Url);
            Assert.That(basePage.IsPageLoaded(), Is.True, "Страница не загрузилась.");

            var element = basePage.FindElement(locator);
            basePage.ScrollToElement(element);
            bool isDisplayed = basePage.IsElementExist(locator);
            Assert.That(isDisplayed, Is.True, $"Элемент '{elementName}' не ceotcndetn на странице в футере.");
        }
        [Test]
        [TestCaseSource(typeof(MainPageFooterTestData), nameof(MainPageFooterTestData.GetFooterElements))] // Использование TestCaseSource для получения данных из FooterTestData
        public void FooterElements_ShouldBeDisplayed(By locator, string elementName) // Данный тест проверяет видимость всех элементов определенных в TestData
        {
            basePage = new BasePage(Driver);
            basePage.NavigateTo(Url);
            Assert.That(basePage.IsPageLoaded(), Is.True, "Страница не загрузилась.");

            var element = basePage.FindElement(locator);
            basePage.ScrollToElement(element);
            bool isDisplayed = basePage.IsElementDisplayed(locator);
            Assert.That(isDisplayed, Is.True, $"Элемент '{elementName}' не отображается на странице в футере.");
        }

        // Данный тест проверяет открытие страниц социальных сетей по клику на иконки в футер
        // В TestCaseSource передается набор локаторов иконок для перехода на страницы соцсетей и ожидаемые URL
        [Test]
        [TestCaseSource(typeof(MainPageFooterTestData), nameof(MainPageFooterTestData.GetSocialButtons))]
        public void SocialButtons_ShouldOpenSocialPage(By locator, string elementName, string expectedUrl) 
        {
            basePage = new BasePage(Driver);
            basePage.NavigateTo(Url);
            Assert.That(basePage.IsPageLoaded(), Is.True, "Страница не загрузилась.");
            
            var element = basePage.FindElement(locator);
            basePage.ScrollToElement(element);
            basePage.ClickElement(element);
            basePage.SwithToNewTab();
            if(browserType == "firefox")
            {
                System.Threading.Thread.Sleep(2000); // Ждем 2 секунды для firefox, так как некоторые браузеры сначала открывают вкладку и в url about:blank - тест падает
            }
            Assert.That(Driver.Url, Is.EqualTo(expectedUrl), $"Ожидался URL: {expectedUrl}, но был: {Driver.Url}");
        }
    }
}
