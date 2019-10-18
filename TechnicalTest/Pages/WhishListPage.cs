using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Resources;
using TechnicalTest.Global;
using TechnicalTest.Utils;
using System.IO;
using TechnicalTest.Pages;
using System.Reflection;

namespace TechnicalTest.Pages
{
    class WhishListPage
    {
        public WhishListPage()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }
        // object for addedproduct
        [FindsBy(How = How.XPath, Using = "//tbody[1]/tr/td[2]")]
        private IWebElement ListOfWishList { get; set; }


        public void wishListPage()
        {

            //Reading Excel
           
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string Excelpath = Path.Combine(directory, Resource1.ExcelPath);
            Console.WriteLine(Excelpath);
             Global.ExcelConfiguration.PopulateInCollection(Excelpath, "SearchPaint");
            //Implict wait to load the page
            CommonUtilities.implicitWait(20);
            
            //Navigate to wishlistpage though url provided
            Global.Base.driver.Navigate().GoToUrl("https://www.bunnings.com.au/wish-lists");
           
            //getting list of all items from list
            IList<IWebElement> ItemsList = ListOfWishList.FindElements(By.TagName("small"));
            for (int i = 0; i < ItemsList.Count; i++)
            {
                try {
                    string Exceldata=ExcelConfiguration.ReadData(2, "PaintID");
                    Console.WriteLine(Exceldata);
                    if (ItemsList[i].Text.Contains(ExcelConfiguration.ReadData(2,"PaintID")));
                    {
                        Console.WriteLine(ItemsList[i].Text);
                        
                        // Validating with Id from excel
                        string ExpectedCondition = ExcelConfiguration.ReadData(2, "PaintID");
                        string ActualCondition = Global.Base.driver.FindElement(By.XPath("//tbody[1]/tr/td[2]/small")).Text;
                        Assert.IsTrue(ActualCondition.Contains(ExpectedCondition));
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Pass Paint Addeded to the whishlist");

                    }
                }
               catch(Exception e)
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, e.Message);
              
                }
            }
        }
    }
}