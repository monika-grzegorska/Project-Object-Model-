using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace PAGE_OBJECT_MODEL_TESTS.Pages
{
    public class WishlistPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement wishlistName;
        [FindsBy(How = How.Id, Using = "submitWishlist")]
        private IWebElement saveWishlistButton;

        public void addWishlistName()
        {

            excel.Application excelapp = new excel.Application();
            excel.Workbook excelworkbook = excelapp.Workbooks.Open(@"D:\Monika\Tests\Project-Object-Model-\PAGE_OBJECT_MODEL_TESTS\PAGE_OBJECT_MODEL_TESTS"); // gdzie jest nasz plik
            excel._Worksheet excelworksheet = excelworkbook.Sheets[1]; // numer zakładki z excela w której są dane 

            wishlistName.SendKeys(excelworksheet.Cells[1][1]);
            saveWishlistButton.Click();

        }
    }
}
