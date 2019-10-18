using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechnicalTest.Global;
using TechnicalTest.Resources;
using TechnicalTest.Utils;
using TechnicalTest.Global;
using System.IO;
using System.Reflection;

namespace TechnicalTest.Pages
{
    class SearchProductPage
    {
        public SearchProductPage()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }
        //SearchBox webelement object
        [FindsBy(How = How.XPath, Using = "//div[@class='search-container_container']/input[1]")]
        private IWebElement ProductSearchBox { get; set; }
        // Unique PaintObject
        [FindsBy(How = How.XPath, Using = "//article[@data-product-id='0093344']")]
        private IWebElement PaintObject { get; set; }
        //Adding to wishlist
        [FindsBy(How = How.XPath, Using = "//span[text()='Add to Wish List']")]
        private IWebElement ButtonWishList { get; set; }


        public void searchProductPage()
        {
            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string Excelpath = Path.Combine(directory, Resource1.ExcelPath);
            Console.WriteLine(Excelpath);
            Global.ExcelConfiguration.PopulateInCollection(Excelpath, "SearchPaint");
           
            //Navigate to Url
            Global.Base.driver.Navigate().GoToUrl(Resource1.SearchProductUrl);
           
            //Reading data from Excel
            ProductSearchBox.SendKeys(Global.ExcelConfiguration.ReadData(2,"TextInput"));
            
            //Using Actions class to click enter inorder to search paint
            Actions action = new Actions(Global.Base.driver);
            action.SendKeys(Keys.Enter).Build().Perform();
           
            //Using Wait to load page
            Utils.CommonUtilities.implicitWait(1000);
            
            //Valiadting with page Title
            String ExpectedCondition = "Search - Our range | Bunnings Warehouse";
            String ActualCondition = Global.Base.driver.Title;
            NUnit.Framework.Assert.AreEqual(ExpectedCondition, ActualCondition);
            Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, ExpectedCondition);

        }
       
        //select paint from list
        public void selectItem()
        {  
            //Clicking on chossen Paint id
            PaintObject.Click();

            //Clicks on WhishList Button
            CommonUtilities.WaitForElement(Global.Base.driver,By.XPath("//span[text()='Add to Wish List']"), 20);
             ButtonWishList.Click();
           
            //For page down
            Actions action1 = new Actions(Global.Base.driver);
            action1.SendKeys(Keys.PageDown).Build().Perform();

            //let product add to cart 
            Thread.Sleep(5000);
        
       


            //IList<IWebElement> listOfPaints= PaintObjects.FindElements(By.TagName("article"));
            // for(int i=0; i< listOfPaints.Count; i++)
            // {
            //     Console.WriteLine(listOfPaints[i].Text);
            //     if(listOfPaints[i].Text== Resource1.PaintID)
            //     {
            //         listOfPaints[i].Click();
            //         break;
            //     }
            //}
        }
    }
}
