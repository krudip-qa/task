using InternProject2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Initialize elements through pageFactory design Model 
//

namespace InternProject2.Page
{
    class SignInPage
    {
     
        [Obsolete]
        public SignInPage()
        {
            PageFactory.InitElements(CommomDriver.driver, this);
        }

        #region Initialize Web Elements
       
        //find the SignIn button
        [FindsBy(How =How.XPath,Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement SignInTab { set; get; }

        //Finding the Email Address 
        [FindsBy(How = How.Name,Using = "email")]
        private IWebElement Email { set; get; }

        //Finding the Password 
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { set; get; }

        //check on Check-box
        [FindsBy(How = How.XPath, Using = "//input[@name='rememberDetails']")]
        private IWebElement CheckBox { set; get; }

        //click on Login button 
        [FindsBy(How = How.XPath, Using = "//button[@class='fluid ui teal button']")]
        private IWebElement Login { set; get; }

        //Find the Hi Krupa Text after Login
        [FindsBy(How =How.XPath,Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement LoginText { set; get; }

        #endregion

        [Obsolete]
        internal void LoginSteps(IWebDriver driver)
        {
            //After hiting URl 
           //Click in SignIn button
            SignInTab.Click();

            //populate login page data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SignIn");
            //Give Email Address
            Email.SendKeys(ExcelLibHelpers.ReadData(2, "Email"));

            //give password
            Password.SendKeys(ExcelLibHelpers.ReadData(2, "Password"));

            //check on check-box
            CheckBox.Click();

            //click on Login Button
            Login.Click();
            try
            {

                //Wait untill 
                CommomDriver.WaitForVisibility(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 5);
                //Assertion for checking condition
                Assert.That(LoginText.Text, Is.EqualTo(ExcelLibHelpers.ReadData(2,"Text")));
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
