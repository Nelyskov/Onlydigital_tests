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
    public class CrossBrowserFooterTests : BaseTest
    {
        BasePage basePage;
        
        protected override string Url => "https://only.digital/"; // Url для тестирования футера
        public CrossBrowserFooterTests(string browserType) : base(browserType) { }


        [Test, TestCaseSource(typeof(FooterTestData), nameof(FooterTestData.GetFooterElements))] // Использование TestCaseSource для получения данных из FooterTestData
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

        [Test, TestCaseSource(typeof(FooterTestData), nameof(FooterTestData.GetFooterElements))] // Использование TestCaseSource для получения данных из FooterTestData
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

        [Test, TestCaseSource(typeof(FooterTestData), nameof(FooterTestData.GetSocialButtons))] 
        public void SocialButtons_ShouldOpenSocialPage(By locator, string elementName, string expectedUrl)
        {
            basePage = new BasePage(Driver);
            basePage.NavigateTo(Url);

            Assert.That(basePage.IsPageLoaded(), Is.True, "Страница не загрузилась.");
            
            var element = basePage.FindElement(locator);
            basePage.ScrollToElement(element);

            basePage.ClickElement(element);
            basePage.SwithToNewTab();
            Assert.That(Driver.Url, Is.EqualTo(expectedUrl), $"Ожидался URL: {expectedUrl}, но был: {Driver.Url}");
            
        }
        


    }
}