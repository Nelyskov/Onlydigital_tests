using OpenQA.Selenium;
using System.Collections;

namespace Data
{
    public static class FooterTestData
    {
        // Метод возвращающий все локаторы для TestCaseSource
        public static IEnumerable GetFooterElements()
        {
            yield return new object[] { FooterLocators.FooterButton, "Кнопка 'Начать проект'" };
            yield return new object[] { FooterLocators.FooterLogo, "Логотип футера" };
            yield return new object[] { FooterLocators.BeLogo, "Логотип Be" };
            yield return new object[] { FooterLocators.dpLogo, "Логотип dp" };
            yield return new object[] { FooterLocators.tgLogo, "Логотип tg" };
            yield return new object[] { FooterLocators.vkLogo, "Логотип vk" };
            yield return new object[] { FooterLocators.FooterTelegram, "tg ссылка" };
            yield return new object[] { FooterLocators.FooterContacts, "Контакты" };
            yield return new object[] { FooterLocators.FooterText, "Текст футера" };
            yield return new object[] { FooterLocators.pdfButton, "Кнопка pdf" };
            yield return new object[] { FooterLocators.pitchButton, "Кнопка pitch" };
            yield return new object[] { FooterLocators.FooterYear, "Год в футере" };
        }
        
        public static IEnumerable GetSocialButtons()
        {
            yield return new object[] { FooterLocators.BeLogo, "Логотип Be", "https://www.behance.net/onlydigitalagency" };
            yield return new object[] { FooterLocators.dpLogo, "Логотип dp", "https://dprofile.ru/only" };
            yield return new object[] { FooterLocators.tgLogo, "Логотип tg", "https://t.me/onlycreativedigitalagency" };
            yield return new object[] { FooterLocators.vkLogo, "Логотип vk", "https://vk.com/onlydigitalagency"};
        }
    }

    // Все возможные локаторы в футере
    public static class FooterLocators
    {
        public static string FooterxPath = "/html/body/main/footer";
        public static By FooterButton = By.XPath($"{FooterxPath}//button[contains(text(),'Начать проект')]");
        public static By FooterLogo = By.XPath($"{FooterxPath}//*[contains(@class, 'Footer_logo')]");
        public static By BeLogo = By.XPath($"{FooterxPath}/div[1]/div[1]/a[1]");
        public static By dpLogo = By.XPath($"{FooterxPath}/div[1]/div[1]/a[2]");
        public static By tgLogo = By.XPath($"{FooterxPath}/div[1]/div[1]/a[3]");
        public static By vkLogo = By.XPath($"{FooterxPath}/div[1]/div[1]/a[4]");
        public static By FooterTelegram = By.XPath($"{FooterxPath}//*[contains(@class, 'Footer_telegram')]");
        public static By FooterContacts = By.XPath($"{FooterxPath}//*[contains(@class, 'Footer_contacts')]");
        public static By FooterText = By.XPath($"{FooterxPath}//*[contains(@class, 'Footer_text')]");

        // Это кнопки, но помечены тегом <a><a/>
        // public static By pdfButton = By.XPath($"{FooterxPath}//button[contains(text(),'pdf')]");
        // public static By pitchButton = By.XPath($"{FooterxPath}//button[contains(text(),'pitch')]");

        public static By pdfButton = By.XPath($"{FooterxPath}//a[contains(text(),'pdf')]");
        public static By pitchButton = By.XPath($"{FooterxPath}//a[contains(text(),'pitch')]");
        public static By FooterYear = By.XPath($"{FooterxPath}//*[contains(@class, 'Footer_year')]");
    }
}