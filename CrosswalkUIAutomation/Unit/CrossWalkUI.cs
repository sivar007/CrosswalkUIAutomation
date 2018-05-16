using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USFAutomationFramework.GeneralLibraries;
using USFAutomation;
using OpenQA.Selenium; 
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;


namespace USFAutomation
{
    [TestClass]
    public class CrossWalkUI
    {
        public static IWebDriver driver;

        [TestMethod]
        public void ReassignDepartment()
        {
            System.Diagnostics.Debugger.Launch();
            string TestDataSheetPath = "D:\\selenium\\CrosswalkUIAutomation\\CrosswalkUIAutomation\\TestData\\TestData.xlsx",
                   TestDataSheetName = "TestData",
                   TestScriptId1 = "TS_01", 
                   TestScriptId2 = "TS_02";
             int TestDataRow1 = FrameworkLibrary.PopulateInCollection(TestDataSheetPath, TestDataSheetName, TestScriptId1),
                 TestDataRow2 = FrameworkLibrary.PopulateInCollection(TestDataSheetPath, TestDataSheetName, TestScriptId2);

            
            driver = new ChromeDriver(@"D:\selenium\CrosswalkUIAutomation\CrosswalkUIAutomation");
            LoginAction.Login(driver, "https://cftest.hsc.usf.edu/dwdeptassignment/index.cfm", "sivaravula", "Bahubali2");
            
            

            // reassign Fast departments from "ANCILLARY SUPPORT" to "AREA HEALTH EDUCATION CENTER"

            CommonLibrary.SetOperationsOnControls(driver, "click", "XPath", "//*[@id='openCloseIcon_1']", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1); 
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow1, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow1, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow1, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "XPath", "//*[@id='openCloseIcon_1']", "");
            System.Threading.Thread.Sleep(2000);

            // reassign Fast departments from  "AREA HEALTH EDUCATION CENTER" to "ANCILLARY SUPPORT" 

            CommonLibrary.SetOperationsOnControls(driver, "click", "XPath", "//*[@id='openCloseIcon_2']", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow2, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow2, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow2, "AssignDepartment"));
            System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            System.Threading.Thread.Sleep(2000);
            //CommonLibrary.SelectRecordInTableByRowNo(driver, "//*[@id='fast_table']", 1, 1);
            //System.Threading.Thread.Sleep(2000);
            //CommonLibrary.SetOperationsOnControls(driver, "select", "Id", "deptAssignSel", FrameworkLibrary.ReadData(TestDataRow2, "AssignDepartment"));
            //System.Threading.Thread.Sleep(2000);
            //CommonLibrary.SetOperationsOnControls(driver, "click", "Id", "reassignBut", "");
            //System.Threading.Thread.Sleep(2000);
            CommonLibrary.SetOperationsOnControls(driver, "click", "XPath", "//*[@id='openCloseIcon_2']", "");
            System.Threading.Thread.Sleep(2000);




        }
        //[TestMethod]
        //public void Verify_USF_HomePage()
        //{
        //    HomePageAction action = new HomePageAction();
        //    Assert.IsTrue(action.Verify_HomePage());

        //}




    }
}
