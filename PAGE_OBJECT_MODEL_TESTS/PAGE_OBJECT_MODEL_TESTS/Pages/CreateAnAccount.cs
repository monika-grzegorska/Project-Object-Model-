using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAGE_OBJECT_MODEL_TESTS.Pages
{
    public class CreateAnAccount
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CreateAnAccount(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

        //PERSONAL INFORMATION
        [FindsBy(How = How.Id, Using = "id_gender1")]
        private IWebElement personalTitleMr;
        [FindsBy(How = How.Id, Using = "id_gender2")]
        private IWebElement personalTitleMrs;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement personalFirstName;
        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement personalLastName;

        [FindsBy(How = How.Id, Using = "email")]   // TODO ASSER
        private IWebElement personalEmail;
        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement personalPassword;

        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement personalDateOfBirthDay;
        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement personalDateOfBirthMonth;
        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement personalDateOfBirthYear;

        //ADDRESS

        [FindsBy(How = How.Id, Using = "firstname")]  // TODO ASSER
        private IWebElement addressFirstName;
        [FindsBy(How = How.Id, Using = "lastname")]    // TODO ASSER
        private IWebElement addressLastName;

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement addressAddressFirstLine;
        [FindsBy(How = How.Id, Using = "address2")]
        private IWebElement addressAddressSecondLine;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement addressCity;
        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement addressState;
        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement addressPostCode;

        [FindsBy(How = How.Id, Using = "other")]
        private IWebElement addressAdditionalInformation;
        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement addressHomePhone;
        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement addressMobilePhone;
        [FindsBy(How = How.Id, Using = "alias")]
        private IWebElement addressAlias;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        private IWebElement registerButton;

        public void addAllInformationsToForm()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(personalTitleMrs)).Click();
            personalFirstName.SendKeys("Harry");
            personalLastName.SendKeys("Potter");
            personalPassword.SendKeys("bestharryever");

            new SelectElement(personalDateOfBirthDay).SelectByValue("4");
            new SelectElement(personalDateOfBirthMonth).SelectByValue("9");
            new SelectElement(personalDateOfBirthYear).SelectByValue("1989");

            addressAddressFirstLine.SendKeys("Basment 66");
            addressCity.SendKeys("Hollyshiet");
            addressState.SendKeys("Pomorian");
            addressPostCode.SendKeys("66666");

            addressAdditionalInformation.SendKeys("Im a wizard! No Harry, You are a junky!");
            addressMobilePhone.SendKeys("666-666-666");
            addressAlias.SendKeys("dont know");
            registerButton.Click();


        }
    }
}
