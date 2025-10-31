using NUnit.Framework;
using OpenQA.Selenium;
using Pages;
using Helpers;
using Data;

namespace Test
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class CrossBrowserFooterTests : BaseTest
    {
        BasePage basePage;
        protected override string Url => "https://only.digital/";
        public CrossBrowserFooterTests(string browserType) : base(browserType) { }

        [Test, TestCaseSource(typeof(FooterTestData), nameof(FooterTestData.GetFooterElements))]
        public void FooterElements_ShouldBeDisplayed(By locator, string elementName)
        {
            basePage = new BasePage(Driver);
            basePage.NavigateTo(Url);
            
            Assert.That(basePage.IsPageLoaded(), Is.True, "Страница не загрузилась.");
            
            var element = basePage.FindElement(locator);
            basePage.ScrollToElement(element);

            bool isDisplayed = basePage.IsElementDisplayed(locator);

            Assert.That(isDisplayed, Is.True, $"Элемент '{elementName}' не отображается на странице футера.");  
        }
    }
}