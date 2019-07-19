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
            SignIn signIn = home.goToSignInPage();

            //ACT 
            CreateAnAccount createAnAccount = signIn.addEmailAddressAndGoToCreateAnAccountPage();
            createAnAccount.addAllInformationsToForm();
        }
        [Test]
        public void AP_Given_LogInIntoAccount_When_ValidInformationIsUsed_Then_UserIsNowLogIn()
        {
            //ARRANGE
            HomePage home = new HomePage(driver);
            home.goToPage();
            SignIn signIn = home.goToSignInPage();

            //ACT
            AccountPage logInIntoAccountPage = signIn.logInIntoAccountPage();
        }
        [Test]
        public void AP_Given_AddNewWishlist_When_Add_Then_NewWishlistAdded()
        {
            //ARRANGE
            HomePage home = new HomePage(driver);
            home.goToPage();
            SignIn signIn = home.goToSignInPage();
            AccountPage logInIntoAccountPage = signIn.logInIntoAccountPage();
            WishlistPage openWishlistPage = logInIntoAccountPage.goToWishlist();
            openWishlistPage.addWishlistName();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AP_Given_AddNewWishlistUsingTestCase_When_Add_Then_NewWishlistAdded(int x)
        {
            //ARRANGE

            HomePage home = new HomePage(driver);
            home.goToPage();
            SignIn signIn = home.goToSignInPage();
            AccountPage logInIntoAccountPage = signIn.logInIntoAccountPage();
            WishlistPage openWishlistPage = logInIntoAccountPage.goToWishlist();
            openWishlistPage.addWishlistNameTestCase(x);
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
        }

    }
}