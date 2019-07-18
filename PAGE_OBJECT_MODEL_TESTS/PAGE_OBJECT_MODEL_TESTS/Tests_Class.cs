using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PAGE_OBJECT_MODEL_TESTS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAGE_OBJECT_MODEL_TESTS.Pages
{
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void AP_Given_GoSignInPage_When_ValidInformationIsUsed_Then_OpenSignInPage()
        {
            //ARRANGE
            HomePage home = new HomePage(driver);
            home.goToPage();

            //ACT
            SignIn signIn = home.goToSignInPage();
        }
        [Test]
        public void AP_Given_CreateNewAccount_When_ValidInformationIsUsed_Then_NewUserAccountCreated()
        {
            //ARRANGE
            HomePage home = new HomePage(driver);
            home.goToPage();

            //ACT
            SignIn signIn = home.goToSignInPage();
            CreateAnAccount createAnAccount = signIn.addEmailAddressAndGoToCreateAnAccountPage();
            createAnAccount.addAllInformationsToForm();

            //ASSERT

        }
        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }

    }
}