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
    public class AccountPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "lnk_wishlist")]
        private IWebElement wishlistButton;

        public WishlistPage goToWishlist()
        {
            wishlistButton.Click();
            return new WishlistPage(driver);
        }
    }
}
