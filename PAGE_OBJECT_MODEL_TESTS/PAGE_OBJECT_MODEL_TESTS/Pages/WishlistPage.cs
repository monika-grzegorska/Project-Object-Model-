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
    public class WishlistPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        TestHelper testhelper = new TestHelper();

        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement wishlistName;
        [FindsBy(How = How.Id, Using = "submitWishlist")]
        private IWebElement saveWishlistButton;

        public void addWishlistName()
        {
            for (int i = 1; i <= 6; i++)
            {
                wishlistName.SendKeys(testhelper.ExcelSetup(i));
                saveWishlistButton.Click();
            }


        }
        public void addWishlistNameTestCase(int x)
        {
            wishlistName.SendKeys(testhelper.ExcelSetup(x));
            saveWishlistButton.Click();
        }
       
    }


}
