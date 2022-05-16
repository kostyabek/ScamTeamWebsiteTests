using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ScamTeamWebsiteTests
{
    using System;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class Tests
    {
        private IWebDriver _driver;
        private INavigation _navigation;
        private IOptions _driverOptions;

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeDriverPath = new DriverManager()
                .SetUpDriver(new ChromeConfig());

            _driver = new ChromeDriver(chromeDriverPath);
            _navigation = _driver.Navigate();
            _driverOptions = _driver.Manage();

            _navigation.GoToUrl(new Uri("https://sihalex.github.io/PandorasTeam/"));
            _driverOptions.Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var squareElementQuery = By.XPath(@"//div[contains(@class, 'sc-dkPtRN cDggTJ')]");
            Assert.That(squareElementQuery is not null);

            var squareElement = _driver.FindElement(squareElementQuery);
            squareElement.Click();

            var greetingDiv = By.XPath("//div[text()=\"You have opened the Pandora's Box\"]");
            Assert.That(greetingDiv is not null);
        }

        [Test]
        public void Test2()
        {
            Thread.Sleep(6000);

            var contactsElementQuery = By.XPath("//a[contains(@href, '#/contacts')]");
            Assert.That(contactsElementQuery is not null);
            var contactsElement = _driver.FindElement(contactsElementQuery);
            contactsElement.Click();

            var fakeEmailElementQuery = By.XPath("//div[text()=\"kostyabek2@gmail.com\"]");
            Assert.That(fakeEmailElementQuery is not null);
            var fakeEmailElement = _driver.FindElement(fakeEmailElementQuery);
            Assert.That(fakeEmailElement is not null);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

