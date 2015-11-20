using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

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


//        [FindsBy(How = How.ClassName, Using = "theClassOfAnElement")]
//        IWebElement targetElement;

        [TestMethod]
        public void AppiumDriverPressMethod()
        {

            var elements = _driver.FindElementsByAndroidUIAutomator("new UiSelector().enabled(true)");
            var button = elements[11];

            TouchAction a1 = new TouchAction(_driver);
                a1
                  .Press(button)
                  .Wait(1000)
                  .Release();
                a1.Perform();

            elements = _driver.FindElementsByAndroidUIAutomator("new UiSelector().enabled(true)");
            var textV = elements[19];
            textV.SendKeys("495");

            Assert.AreEqual(textV.Text,495.ToString());
        }
    }

}

