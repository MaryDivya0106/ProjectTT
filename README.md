# ProjectTT
Environment : VisualStudio 2017 or 2019
Framework: .NetFrameWork
 Program Language: C#
AutomationTool: Selenium 3.14
AutomationFramework: NUnit with POM Approach
Browser: Chrome
Run test: Clone Repository from GitHub to Local Machine
Open solution by using VisualStudio 2017 
Change paths for Excel, Repors, Xml config in resource file according to your system.
choose Test-> windows-> TestExplorer->
Run the test 

-------------Test workflow----------
1. Openning a browser ---> Chrome 
2. Navigate to Url -----------> https://www.bunnings.com.au
3. Search Text in search bar as---> "Paint"
4. Selected  paint by using PaitID
5. Added paint to WishList by clicking on button ----> "Add To WishList"
6. Navigated to WishListPage by using url -------> https://www.bunnings.com.au/wish-lists
7. Grabed all Items present in WishList 
8.Stored in IList
9.Validation----->compared grabbed Text with Excel coloum Name "PaintID"
10.Run the Test
11. Generated the reports and logs..

----------------Framework----------------------
Nunit with POM
1. Folder: Global
   Classes: Base--> Setup---> webdriver initializing, reports intializing.
                     TearDown--->stop extent test, flush , close browser.
   C: ExcelConfiguration----> Excel retaed code
2. Folder: Pages
   Classes: Search Product page
    C:  WishListPage
3.Folder: Tests
          SearchProductTest --> initializes objects of pages and called methods.
4. Folder: Resources
              Contain all file path : excelpath, reporthtml path, reportxml config path, browser as chrome, url.
5. CommonUtilities
              Wits(Implicit and explicit)

----------------packages used------------------

1.ExcelDataReader" version="3.6.0"  
2. ExcelDataReader.DataSet" version="3.6.0" 
3. ExtentReports" version="2.41.0" 
4.NUnit" version="3.12.0" 
5.NUnit3TestAdapter" version="3.12.0" 
6.Selenium.Chrome.WebDriver" version="76.0.0" 
7.Selenium.Support" version="3.141.0" 
8.Selenium.WebDriver" version="3.141.0" 

