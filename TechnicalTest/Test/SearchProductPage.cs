using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Global;
using TechnicalTest.Pages;
using TechnicalTest.Utils;

namespace TechnicalTest.Test
{
    [TestFixture]
    class SearchProductTest:Global.Base
    {
            [Test]
            public void searchProductTest()
            {
             //Starting reports
             Base.test  = extent.StartTest("searchProductTest");
            
            //Initializing Objectfor SearchProductPage
            SearchProductPage search = new SearchProductPage();
                    search.searchProductPage();
                    search.selectItem();
              
            //Initializing for WhishListPage
                 WhishListPage wishlist = new WhishListPage();
                 wishlist.wishListPage();

            }    
    }
       
}

