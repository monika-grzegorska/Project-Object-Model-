using Ocaramba.Tests.NUnit.DataDriven;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAGE_OBJECT_MODEL_TESTS.Pages
{
    public class SignIn
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement signInEmail;
        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement createAnAccountButton;
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement logInEmail;
        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement logInPassword;
        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement signInButton;


        public CreateAnAccount addEmailAddressAndGoToCreateAnAccountPage()
        {
            signInEmail.SendKeys("bubu@bobo.com");
            createAnAccountButton.Click();
            return new CreateAnAccount(driver);
        }

        public AccountPage logInIntoAccountPage()
        {
            logInEmail.SendKeys("bubu@bobo.com");
            logInPassword.SendKeys("bestharryever");
            signInButton.Click();
            return new AccountPage(driver);
        }

    }
}
