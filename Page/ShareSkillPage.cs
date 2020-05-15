using InternProject2.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;
using NUnit.Framework;

namespace InternProject2.Page
{
    class ShareSkillPage 
    {
        [Obsolete]
        public ShareSkillPage()
        {
            PageFactory.InitElements(CommomDriver.driver, this);
        }

        #region Initialize Web Elements

        //find the SignIn button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillBtn { set; get; }

        //find Out Title textField
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { set; get; }

        //find Out Description  textField
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { set; get; }

        //find Out Category droupdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement Category { set; get; }

        //find Out  Sub Category droupdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategory { set; get; }

        //find Out  Tag 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input")]
        private IWebElement Tag { set; get; }

        //find Out  Service Type - Radio Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div")]
        private IWebElement ServiceType { set; get; }

        //find Out  Location Type - Radio Button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Location { set; get; }

        //Available Days table
        //Click on Start Date DropDown 
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { set; get; }

        //Click on End Date DropDown 
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { set; get; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement AvailableDaysAndTimes { get; set; }

        ////Click on StartTime dropdown
        //[FindsBy(How = How.Name, Using = "StartTime")]
        //private IWebElement StartTime { get; set; }


        ////Click on EndTime dropdown
        //[FindsBy(How = How.Name, Using = "EndTime")]
        //private IWebElement EndTime { get; set; }

        //find Out Skill Trade radio button 
        [FindsBy(How = How.XPath, Using = ".//*[@name='skillTrades' and @value='true']")]
        private IWebElement SkillTrade { get; set; }

        //Find out Skill Exchange Text-Field
        [FindsBy(How = How.XPath,Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Find Out + "Work Sample" button to upload file
        [FindsBy(How = How.XPath, Using = ".//*[@class='ui grid']/span/i")]
        private IWebElement WorkSample { get; set; }

        //Select File 
        [FindsBy(How = How.Id, Using = "selectFile")]
        private IWebElement File { get; set; }

        //Find Out Active radio button 
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[1]/input[@value='true']")]

        private IWebElement Active { set; get; }

        //find SAVE button
        [FindsBy(How =How.XPath, Using = ".//*[@value='Save' and @type='button']")]
        private IWebElement savebtn { set; get; }

        //For Assertion - After click on save button skill saved in manage list page
        //need to go Manage Listing Tab first and get category and titlt text 
        
        //Find manage Listing Tab
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageList { set; get; }

        [FindsBy(How = How.XPath,Using = ".//table[@class='ui striped table']/tbody/tr[1]/td[2]")]
        private IWebElement CategoryofManage { set; get; }

        [FindsBy(How = How.XPath, Using = ".//table[@class='ui striped table']/tbody/tr[1]/td[3] ")]
        private IWebElement TitleofManage { set; get; }

        #endregion

        [Obsolete]
        internal void navigateToShareSkill(IWebDriver driver)
        {
            CommomDriver.WaitForVisibility(driver, "LinkText", "Share Skill", 5);

            //Click on ShareSkill Button
            ShareSkillBtn.Click();
        }

        [Obsolete]
        internal void EnterShareSkill(IWebDriver driver)
        {
            CommomDriver.Wait(2000);

            //populate login page data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "EnterShareSkill");

            //Wait untill driver find title text Field
            CommomDriver.WaitForVisibility(driver, "Name", "title", 2);
          
            //Give a Title
            Title.SendKeys(ExcelLibHelpers.ReadData(2, "Title"));

            //Give a Description
            Description.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //select one of the option from Category
            Category.SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            ////Select SubCategory Option
            SubCategory.SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //give input in Tag TextField
            Tag.SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter);

            //choose Radio button option
            ServiceType.Click();

            //Choose Location
            Location.Click();

            //Give StartDate 
            StartDate.SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Give EndDate
            EndDate.SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));


            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                    IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                    if (i == 2 && j == 2)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(2, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(2, "End Time"));
                    }
                    if (i == 3 && j == 3)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(3, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(3, "End Time"));
                    }
                    if (i == 4 && j == 4)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(4, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(4, "End Time"));
                    }
                    if (i == 5 && j == 5)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(5, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(5, "End Time"));
                    }
                    if (i == 6 && j == 6)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(6, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(6, "End Time"));
                    }
                    if (i == 7 && j == 7)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(7, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(7, "End Time"));
                    }
                    if (i == 8 && j == 8)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(8, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(8, "End Time"));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //Click on Share Trade Radio Button 
            SkillTrade.Click();

            //give inpute Skill Exchange
            SkillExchange.SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter);

            //Click on Work Sample 
            WorkSample.Click();

            //Handle the window that not belongs to Browser -AutoIt - see blog for more info
            //below line execute the AutoIT script
            //Create an object for AutoIt 
            AutoItX3 autoIt = new AutoItX3();
            //This statement Active the window and perform set of auctions 
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            //set the path to open the file on browser 
            autoIt.Send(@"D:\InternPro\InternProject2\AutoIt\scrummeeting.png");
            Thread.Sleep(1000);
            //It will click on "Open" button 
            autoIt.Send("{ENTER}");

            //click on active radio button
            Active.Click();

            //click on save button
            savebtn.Click();

            //For Assertion- Go to manage list 
            ManageList.Click();
           //Get the text from manage list of Title and Category
            String ManageTitle = TitleofManage.Text;
            String ManageListCategory = CategoryofManage.Text;
                       
            try
            {            
            //For Assertion - After Save Skills For varification,
            //Goto manage list page and match Title and Cetegory with Excel Enter Skill 
            Assert.AreEqual(ManageTitle, ExcelLibHelpers.ReadData(2, "Title"));
            Assert.AreEqual(ManageListCategory, ExcelLibHelpers.ReadData(2, "Category"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Obsolete]
        internal void EditShareSkill(IWebDriver driver)
        {
            CommomDriver.Wait(2000);

            //Click on ShareSkill Button
            ShareSkillBtn.Click();

            //Wait untill driver find title text Field
            CommomDriver.WaitForVisibility(driver, "Name", "title", 2);

            //populate login page data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "EditShareSkill");
            
            //Give a Title
            Title.SendKeys(ExcelLibHelpers.ReadData(2,"Title"));

            //Give a Description
            Description.SendKeys(ExcelLibHelpers.ReadData(2, "Description"));

            //select one of the option from Category
            Category.SendKeys(ExcelLibHelpers.ReadData(2, "Category"));

            ////Select SubCategory Option
            SubCategory.SendKeys(ExcelLibHelpers.ReadData(2, "Sub Category"));

            //give input in Tag TextField
            Tag.SendKeys(ExcelLibHelpers.ReadData(2, "Tag") + Keys.Enter);
            Tag.SendKeys(ExcelLibHelpers.ReadData(3, "Tag") + Keys.Enter);

            //choose Radio button option
            ServiceType.Click();

            //Choose Location
            Location.Click();

            //Give StartDate 
            StartDate.SendKeys(ExcelLibHelpers.ReadData(2, "Start Date"));

            //Give EndDate
            EndDate.SendKeys(ExcelLibHelpers.ReadData(2, "End Date"));

            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                    IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                    if (i == 2 && j == 2)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(2, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(2, "End Time"));
                    }
                    if (i == 3 && j == 3)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(3, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(3, "End Time"));
                    }
                    if (i == 4 && j == 4)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(4, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(4, "End Time"));
                    }
                    if (i == 5 && j == 5)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(5, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(5, "End Time"));
                    }
                    if (i == 6 && j == 6)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(6, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(6, "End Time"));
                    }
                    if (i == 7 && j == 7)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(7, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(7, "End Time"));
                    }
                    if (i == 8 && j == 8)
                    {
                        SatrtTime.SendKeys(ExcelLibHelpers.ReadData(8, "Start Time"));
                        EndTime.SendKeys(ExcelLibHelpers.ReadData(8, "End Time"));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //Click on Share Trade Radio Button 
            SkillTrade.Click();

            //give inpute Skill Exchange
            SkillExchange.SendKeys(ExcelLibHelpers.ReadData(2, "Skill Exchange") + Keys.Enter + ExcelLibHelpers.ReadData(3, "Skill Exchange") + Keys.Enter);

            //Click on Work Sample 
            WorkSample.Click();

            //Handle the window that not belongs to Browser -AutoIt - see blog for more info
            //below line execute the AutoIT script
            //Create an object for AutoIt 
            AutoItX3 autoIt = new AutoItX3();
            //This statement Active the window and perform set of auctions 
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            //set the path to open the file on browser 
            autoIt.Send(@"D:\scrummeeting.png");
            Thread.Sleep(1000);
            //It will click on "Open" button 
            autoIt.Send("{ENTER}");

            //click on active radio button
            Active.Click();

            //click on save button
            savebtn.Click();

            CommomDriver.Wait(2);
            //For Assertion- Go to manage list 
            ManageList.Click();
            //Get the text from manage list of Title and Category
            String ManageTitle = TitleofManage.Text;
            String ManageListCategory = CategoryofManage.Text;

            try
            {
             //For Assertion - After Save Skills For varification,
             //Goto manage list page and match Title and Cetegory with Excel Enter Skill 
             Assert.AreEqual(ManageTitle, ExcelLibHelpers.ReadData(2, "Title"));
             Assert.AreEqual(ManageListCategory, ExcelLibHelpers.ReadData(2, "Category"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




        }
   
    
    
    }
}
