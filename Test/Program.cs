using InternProject2.Page;
using InternProject2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject2
{
    class Program 
    {
        [Obsolete]
        static void Main(string[] args)
        {
            //CommomDriver.driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application");

            ////page object for SignIn page 
            //SignInPage loginObj = new SignInPage();
            //loginObj.LoginSteps(CommomDriver.driver);

            //////page object for SignUp Page
            ////SignUpPage joinObj = new SignUpPage();
            ////joinObj.Register(CommomDriver.driver);

            ////page object for ShareSkill page
            //ShareSkillPage shareSkillObj = new ShareSkillPage();
            //shareSkillObj.EnterShareSkill(CommomDriver.driver);
            //shareSkillObj.EditShareSkill(CommomDriver.driver);
        }
    }
    [TestFixture, Description("Share Skill with Add, Edit test cases")]
    class ShareSkillTestSuit : Base
    {
        [Test,Order(1), Description("Enter skills in Share Skill page")]
        [Obsolete]
        public void EnterShareSkillTest()
        {
            try
            {
                test = extent.CreateTest("Enter Share Skill Test Passed");
                //page object for ShareSkill page
                ShareSkillPage shareSkillObj = new ShareSkillPage();
                //navigate to ShareSKill
                shareSkillObj.navigateToShareSkill(driver);
                //Create Share Skill
                shareSkillObj.EnterShareSkill(driver);
            }
            catch(NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }
        [Test, Order(2), Description("Edit details that entered into Share Skill page")]
        [Obsolete]
        public void EditShareSkillTest()
        {
            try
            {
                test = extent.CreateTest("Edit Share Skill Test Passed");

                //page object for ShareSkill page
                ShareSkillPage shareSkillObj = new ShareSkillPage();
                //navigate to ShareSKill
                shareSkillObj.navigateToShareSkill(driver);
                //Edit Share Skill
                shareSkillObj.EditShareSkill(driver);
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }
    }

    [TestFixture, Description("Manage Listing with view, Edit and Delete")]
    class ManageListingTestSuit : Base
    {
        [Obsolete]
        [Test,Order(3), Description("View Skills on manage Listing")]
        public void ManageViewListTest()
        {
            try
            {
                test = extent.CreateTest("Manage View listing test passed");
                //Create object for ManageListPage
                ManageListPage managelistObj = new ManageListPage();
                //View listing 
                managelistObj.ViewListing(driver);
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }

        }

        [Obsolete]
        [Test, Order(4), Description("Edit Skills on manage Listing")]
        public void manageEditListTest()
        {
            try
            {
                test = extent.CreateTest("Manage Edit listing test passed");
                //Create object for ManageListPage
                ManageListPage managelistObj = new ManageListPage();
                //Edit Listing test 
                managelistObj.EditListing(driver);
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }

        [Obsolete]
        [Test, Order(5), Description("Delete Skills on manage Listing")]
        public void manageDeleteListTest()
        {
            try
            {
                test = extent.CreateTest("Manage delete listing test passed");
                //Create object for ManageListPage
                ManageListPage managelistObj = new ManageListPage();
                //Edit Listing test 
                managelistObj.DeleteListing(driver);
            }
            catch (NoSuchElementException e)
            {
                test.Fail(e.StackTrace);
            }
        }
    }
}
