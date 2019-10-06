using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Resources;
using static TechnicalTest.Global.Base;


namespace TechnicalTest.Utils
{
   public static  class CommonUtilities
    {
        #region waits
        public static void implicitWait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(time);
        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
            return (wait.Until(ExpectedConditions.ElementToBeClickable(by)));
        }
       
    }
}
    #endregion