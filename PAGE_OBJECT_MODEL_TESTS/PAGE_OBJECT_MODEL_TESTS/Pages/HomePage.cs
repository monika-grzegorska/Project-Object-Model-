using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAGE_OBJECT_MODEL_TESTS.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //-------------
        [FindsBy(How = How.ClassName, Using = "login")]
        private IWebElement signIn;

        [FindsBy(How = How.LinkText, Using = "Woman")]
        private IWebElement categoryWoman;
        //-------------
        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        public SignIn goToSignInPage()
        {
            signIn.Click();
            return new SignIn(driver);
        }
    }
}
