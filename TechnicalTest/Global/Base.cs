using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  TechnicalTest.Resources;
using TechnicalTest.Utils;
using System.IO;
using System.Reflection;

namespace TechnicalTest.Global
{
    internal class Base
    {
        public static IWebDriver driver { get; set; }
        public static string Browser = Resource1.Browser;


        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void initializeBowser()
        {
            //initialize browser according to resourcefile
            if (Browser == "Chrome")
            {
                driver = new ChromeDriver();

            }
            else if (Browser == "FireFox")
            {
                driver = new FirefoxDriver();
            }

            //Maximizing the browser
            driver.Manage().Window.Maximize();

            #region Initialise Reports

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string Reportspath = Path.Combine(directory, Resource1.HtmlPath);
            string Reportsconfig = Path.Combine(directory, Resource1.ConfigPath);
            Console.WriteLine(Reportspath);

            extent = new ExtentReports(Reportspath, true, DisplayOrder.NewestFirst);
            extent.LoadConfig(Reportsconfig);
            #endregion
        }

        [TearDown]
        public void CloseBrowser()
        {
           // ending test
            extent.EndTest(test);
            extent.Flush();
            Global.Base.driver.Close();
        }
    }
}
#endregion
