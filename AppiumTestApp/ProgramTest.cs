using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace AppiumTestApp
{
    [TestClass]
    public class ProgramTest
    {

        private const string AppPath = @"C:/files/Telegram_3.2.6.apk";
        private const string DeviceAddress = "http://127.0.0.1:4723/wd/hub";

        private AndroidDriver<AppiumWebElement> _driver;

        [TestInitialize]
        public void beforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("deviceName", "Google Nexus 6 - 5.0.0 - API 21 - 1400x2560");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("app", AppPath);

            _driver = new AndroidDriver<AppiumWebElement>(
                                                    new Uri(DeviceAddress),
                                                    capabilities);
        }

        [TestCleanup]
        public void afterAll()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void AppiumDriverMethodsTestCase()
        {
            AppiumWebElement el = _driver.FindElementByAndroidUIAutomator("new UiSelector().enabled(true)");

            el.SendKeys("abc");
            Assert.AreEqual(el.Text,"abc","Проверка не пройдена");
        }
    }

}

