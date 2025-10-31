## Простой набор тестов для footer`а сайта https://only.digital/

Тесты реализованы на C#, с использованием Selenium WebDriver и NUnit.

Проект проверяет:

* наличие и отображение всех элементов футера (кнопок, логотипов, текста, ссылок);

* корректность переходов по социальным ссылкам (Behance, DProfile, Telegram, VK);

* кроссбраузерную совместимость (Chrome, Firefox и др.).

### Структура проекта
📂 Data

 ┗ FooterTestData.cs     → Тестовые данные и локаторы футера (By + TestCaseSource)
 
📂 Helpers

 ┗ BrowserFactory.cs     → Фабрика для инициализации нужного WebDriver
 
📂 Pages

 ┗ BasePage.cs           → Базовые методы взаимодействия со страницей (Selenium + JS)
 
📂 Test

 ┣ BaseTest.cs           → Общая настройка тестов (SetUp, TearDown)
 
 ┗ CrossBrowserFooterTests.cs → Кроссбраузерные тесты футера
