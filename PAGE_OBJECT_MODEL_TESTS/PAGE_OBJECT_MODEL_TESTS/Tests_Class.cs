using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using PAGE_OBJECT_MODEL_TESTS.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void AP_Given_AddNewWishlist_When_WishlistNameAdded_Then_NewWishlistAdded()
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
        public void AP_Given_AddNewWishlistUsingTestCase_When_WishlistNameAdded_Then_NewWishlistAdded(int x)
        {
            //ARRANGE

            HomePage home = new HomePage(driver);
            home.goToPage();
            SignIn signIn = home.goToSignInPage();
            AccountPage logInIntoAccountPage = signIn.logInIntoAccountPage();
            WishlistPage openWishlistPage = logInIntoAccountPage.goToWishlist();
            openWishlistPage.addWishlistNameTestCase(x);
        }
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                var allLines = File.ReadAllLines(@"C:\Users\Y700\Desktop\login.csv");
                for(var i = 1; i < allLines.Length; i++)
                {
                    string line = allLines[i];
                    string[] split = line.Split(new char[] { ';' }, StringSplitOptions.None);

                    string user = Convert.ToString(split[0]);
                    string password = Convert.ToString(split[1]);

                    var testCase = new TestCaseData(user, password);
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
        [TestCaseSource("TestCases")]
        public void AP_Given_LogInIntoUserPanel_When_ValidAndInvalidEmailAndPasswordUsed_Then_UserLogedIn(string user, string password)
        {
            //ARRANGE

            HomePage home = new HomePage(driver);
            home.goToPage();
            SignIn signIn = home.goToSignInPage();

            driver.FindElement(By.Id("email")).SendKeys(user);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
            driver.FindElement(By.Id("SubmitLogin")).Click();

        }
    [TearDown]
    public void TearDown()
    {
        //driver.Close();
    }

}
}