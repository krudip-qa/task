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
    class SignUpPage
    {
        [Obsolete]
        public SignUpPage()
        {
            PageFactory.InitElements(CommomDriver.driver, this);
        }

        #region Initialize Web Elements

        //FindOut Join Button
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/button")]
        private IWebElement Joinbtn { set; get; }

        //Find Out First Name TextField
        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName { set; get; }

        //Find Out Last Name TextField
        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName { set; get; }

        //Find Out Email Address TextField
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { set; get; }

        //Find Out Email Address TextField
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { set; get; }

        //Find Out Email Address TextField
        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement ConformPsw { set; get; }

        //Check on Check-box of I Agree
        [FindsBy(How = How.Name, Using = "terms")]
        private IWebElement CheckBox { set; get; }

        //Find Out Join Button
        [FindsBy(How = How.Id, Using = "submit-btn")]
        private IWebElement JoinBtn { set; get; }


        //Find the Hi Krupa Text after Login
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement LoginText { set; get; }

        #endregion

        [Obsolete]
        internal void Register(IWebDriver driver)
        {
            // hit URL
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
            driver.Manage().Window.Maximize();

            CommomDriver.Wait(2);

            //Click on Join Button 
            Joinbtn.Click();


            //populate login page data collection
            ExcelLibHelpers.PopulateInCollection(MarsResource.ExcelPath, "SignUp");
          
            //Give FirstName 
            FirstName.SendKeys(ExcelLibHelpers.ReadData(2, "First Name"));

            //Give LastName
            LastName.SendKeys(ExcelLibHelpers.ReadData(2, "Last Name"));

            //Give an Email 
            Email.SendKeys(ExcelLibHelpers.ReadData(2, "Email"));

            //Give password
            Password.SendKeys(ExcelLibHelpers.ReadData(2, "Password"));

            //Give Conform Password
            ConformPsw.SendKeys(ExcelLibHelpers.ReadData(2, "Conform Password"));

            //Click on Check-Box
            CheckBox.Click();

            //Click on Join button
            JoinBtn.Click();
            try
            {
                //Wait untill 
                CommomDriver.WaitForVisibility(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 20);
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
