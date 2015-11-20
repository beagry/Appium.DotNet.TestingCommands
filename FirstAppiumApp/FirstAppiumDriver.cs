using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace FirstAppiumApp
{
    [TestFixture()]
    public class ProgramTest
    {
        private AppiumDriver<AppiumWebElement> driver;

        public void beforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities.SetCapability("deviceName","");
            capabilities.SetCapability("platformName","Android");
            capabilities.SetCapability("app",PATH);

            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wh/hub"), capabilities);
        }

        [TestFixtureDown]
        public void afterAll()
        {
            driver.Quit();
        }

        public void AppiumDriverMethodsTestCase()
        {
            AppiumWebElement el = driver.FindElementsByAndroidUIAutomator("new UiSelector().enables(true)");

            el.SendKeys("abc");
            Assert.
        }
    }

}
