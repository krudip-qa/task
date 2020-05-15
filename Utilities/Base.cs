using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using InternProject2.Page;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProject2.Utilities
{
    class Base : CommomDriver
    {
        #region To access Path from resource file
        //public static int Browser = Int32.Parse(MarsResource.Browser);
        public static string ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenshotPath;
        public static string ExtentReportPath = MarsResource.ExtentReportPath;
        #endregion

        #region Report
        //By using  class we could generate the logs in the report.
        public static ExtentTest test;
        // By using this class we set the path where our reports need to generate.
        public static ExtentReports extent;
        //Build new reports using html templets
        public static ExtentHtmlReporter htmlReporter;
        #endregion

        #region Initialise report 
        [OneTimeSetUp, Description("Report document for test cases pass or fail")]
        public void StartReport()
        {
            htmlReporter = new ExtentHtmlReporter(ExtentReportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Report | Krupa Parekh";
            htmlReporter.Config.ReportName = "Test Report | Krupa Parekh";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        #endregion


        #region setUp and TearDown
        [SetUp, Description("Open browser and Sign In")]
        [Obsolete]
        public void StartUpSteps()
        {
            driver = new ChromeDriver(@"C:\Users\krupa\Downloads\chromedriver_win32_sele\");
            // hit URL
            driver.Navigate().GoToUrl("http://192.168.99.100:5000/");
            driver.Manage().Window.Maximize();
                     
            // extent = new ExtentReports();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            
            //page object for SignIn page 
            SignInPage loginObj = new SignInPage();
            loginObj.LoginSteps(driver);

        }

        [TearDown, Description("Take Scrrenshot and Close the driver ")]
        public void FinishTestRun()
        { 
            CommomDriver.Wait(2);
            //Screenshot
            String img = SaveScreenshotClass.SaveScreenshot(CommomDriver.driver, "Report");

            //Report
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
            driver.Close();
            
        }
    }
    #endregion  
}

