using InternProject2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternProject2.Page
{
    class ManageListPage : ShareSkillPage
    {
        [Obsolete]
        public ManageListPage()
        {
            PageFactory.InitElements(CommomDriver.driver, this);
        }
        #region Initialize Web Elements
        //Find manage Listing Tab
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageList { set; get; }

        //View the details
        [FindsBy(How = How.XPath,Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement View { set; get; }

        //Edit details in manage listing 
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Edit { set; get; }
       
        //Delete Share Skill Details in 
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement Delete { set; get; }

        //click on Yes or No 
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button[2]")]
        private IWebElement ClickAuctionButton { set; get; }
       
        //For Assertion      
        //Get text from Category and Title and matched with edited Category and title
        [FindsBy(How = How.XPath, Using = ".//table[@class='ui striped table']/tbody/tr[1]/td[2]")]
        private IWebElement CategoryofManage { set; get; }
        //
        [FindsBy(How = How.XPath, Using = ".//table[@class='ui striped table']/tbody/tr[1]/td[3] ")]
        private IWebElement TitleofManage { set; get; }

        //ns-box-inner
        //Get the text from pop up and assert while delete row from manage list 
        [FindsBy(How = How.ClassName, Using = "ns-box-inner")]
        private IWebElement DeletePopUp { set; get; }
    #endregion
        
        [Obsolete]
        internal void ViewListing(IWebDriver driver)
        {
            //Wait untill driver find Manage listing tab 
            CommomDriver.WaitForVisibility(driver, "LinkText", "Manage Listings", 2);

            //click on Manage Listing tab
            ManageList.Click();

            //Wait untill driver find View button 
            CommomDriver.WaitForVisibility(driver, "XPath", "(//i[@class='eye icon'])[1]", 2);

            //click on view - (eye icon)
            View.Click();
            try
            {           
            //Assert that if View icon to be clicked than URl Contains "ServiceDetail" 
            String urlTitle = driver.Title;
            Console.WriteLine(urlTitle);
            //Assertion
            Assert.AreEqual("Service Detail", urlTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Obsolete]
        internal void EditListing(IWebDriver driver)
        {
            //Wait untill driver find Manage listing tab 
            CommomDriver.WaitForVisibility(driver, "LinkText", "Manage Listings", 2);

            //After Viewing Skills click on ManageList to go back to Manage Listing 
            ManageList.Click();

            //Wait untill driver finf Edit button 
            CommomDriver.WaitForVisibility(driver, "XPath", "(//i[@class='outline write icon'])[1]", 2);

            //Get Text from Category and Title from Manage list before Edit Aucketion
            String TitleBeforEdit = TitleofManage.Text;
            String CategoryBeforeEdit = CategoryofManage.Text;
            
            //Click on Edit icon
            Edit.Click();

            //Random Wait
            CommomDriver.Wait(2);
            //create page object of share skill and call EnterShareSkill function 
            //to perform Edit function in manage Listing Page
            ShareSkillPage ShareskillObj = new ShareSkillPage();
            ShareskillObj.EnterShareSkill(driver);

            //Get text from Category and Title from Manage list after Edit
            String TitleAfterEdit = TitleofManage.Text;
            String CategoryAfterEdit = CategoryofManage.Text;

            Console.WriteLine(TitleBeforEdit);
            Console.WriteLine(TitleAfterEdit);
            Console.WriteLine(CategoryBeforeEdit);
            Console.WriteLine(CategoryAfterEdit);


            try
            {
                //Assert that text from Befor Edit and After Edit dose not have to match
                Assert.AreNotEqual(TitleBeforEdit, TitleAfterEdit);
                Assert.AreNotEqual(CategoryBeforeEdit, CategoryAfterEdit);
                Console.WriteLine("pass");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fail");
            }
        }

        [Obsolete]
        internal void DeleteListing(IWebDriver driver)
        {
            //Wait untill driver find Manage listing tab 
            CommomDriver.WaitForVisibility(driver, "LinkText", "Manage Listings", 2);

            //click on manage list 
            ManageList.Click();

            //Wait untill Driver finds Delete button to click
            CommomDriver.WaitForVisibility(driver, "XPath", "(//i[@class='remove icon'])[1]", 2);
            //Click on Delete icon
            Delete.Click();

            //Wait untill Driver finds pop up YES or NO button to click
            CommomDriver.WaitForVisibility(driver, "XPath", "//div[@class='actions']/button[2]", 2);

            //Click on Yes or No button
            ClickAuctionButton.Click();
            CommomDriver.WaitForVisibility(driver, "ClassName", "ns-box-inner", 2);
            try
            {
                //Assert - Get the pop up text in PopUpMsg Variable.
                String PopUpMsg = DeletePopUp.Text;
               //Assert that popUp will open and has not to be null(or Emplty)
                Assert.NotNull(PopUpMsg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
