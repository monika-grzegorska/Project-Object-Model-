using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var excelFile = File.OpenRead(@"D:\Monika\Tests\Project - Object - Model -\PAGE_OBJECT_MODEL_TESTS\PAGE_OBJECT_MODEL_TESTS\login.csv"))
                using (var streamreader = new StreamReader(excelFile))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = streamreader.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' }, StringSplitOptions.None);

                            string user = Convert.ToString(split[0]);
                            string password = Convert.ToString(split[1]);

                            var testCase = new TestCaseData(user, password);
                            testCases.Add(testCase);
                        }
                    }
                }
                return testCases;
            }
        }

    }
}
