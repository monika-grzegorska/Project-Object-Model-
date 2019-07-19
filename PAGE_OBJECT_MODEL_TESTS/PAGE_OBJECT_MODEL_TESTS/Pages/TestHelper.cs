using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace PAGE_OBJECT_MODEL_TESTS
{
    public class TestHelper
    {
        public string ExcelSetup(int x)
        {

            excel.Application excelapp = new excel.Application();
            excel.Workbook excelworkbook = excelapp.Workbooks.Open(@"C:\Users\Y700\Desktop\wishlist.xlsx"); // gdzie jest nasz plik
            excel._Worksheet excelworksheet = excelworkbook.Sheets[1]; // numer zakładki z excela w której są dane 
            excel.Range excelRange = excelworksheet.UsedRange;

            return excelRange.Cells[x][1].value2;

        }
    }
}
