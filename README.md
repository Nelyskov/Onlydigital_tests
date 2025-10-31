## Простой набор тестов для footer`а сайта https://only.digital/ для кроссбраузерного тестирования

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

Конкретно в данном примере реализовано три метода, работающих на главной странице, а именно

* Проверка того, что элемент существует - FooterElements_ShouldBeExist()

* Проверка того, что элемент видим - FooterElements_ShouldBeDisplayed()

* Проверка того, что по клику на иконки социальных сетей открывается новая вкладка с социальной сетью - SocialButtons_ShouldOpenSocialPage()

### Все, реализованный тесты, прошли успешно

<img width="641" height="927" alt="image" src="https://github.com/user-attachments/assets/f609255c-fd13-433f-9a3b-58aa6c402f55" />
