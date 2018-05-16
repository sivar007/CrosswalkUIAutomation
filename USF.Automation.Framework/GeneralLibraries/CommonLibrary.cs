using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace USFAutomationFramework.GeneralLibraries
{
    public class CommonLibrary
    {
        //public static bool Login(IWebDriver driver)
        //{

        //    bool ResultStatus = false;
        //    driver.Navigate().GoToUrl("https://cftest.hsc.usf.edu/dwdeptassignment/index.cfm");
        //    SetOperationsOnControls(driver, "set", "Id", "hitComp_msLogin_id", "sivaravula");
        //    SetOperationsOnControls(driver, "set", "Id", "hitComp_msLogin_password", "Bahubali2");
        //    SetOperationsOnControls(driver, "click", "XPath", "//*[@id='hitComp_msLogin_form']/table/tbody/tr[3]/td/input", "");
        //    System.Threading.Thread.Sleep(3000);

        //    string oVal = GetValuesFromControls(driver, "Label", "Id", "global_dept_title");
        //    if (oVal == "Global Departments") ResultStatus = true;
        //    return ResultStatus;
        //}


        public static string GetValuesFromControls(IWebDriver driver, string ControlType, string PropertyType, string PropertyValue)
        {
            string Val = string.Empty;
            switch (ControlType)
            {

                case "Textbox":
                    if (PropertyType == "Id")
                    {
                        Val = driver.FindElement(By.Id(PropertyValue)).GetAttribute("value");
                    }
                    if (PropertyType == "Name")
                    {
                        Val = driver.FindElement(By.Name(PropertyValue)).GetAttribute("value");
                    }
                    else
                    {
                        Val = string.Empty;
                    }

                    break;

                case "Label":
                    if (PropertyType == "Id")
                    {
                        Val = driver.FindElement(By.Id(PropertyValue)).Text;
                    }
                    else if (PropertyType == "Name")
                    {
                        Val = driver.FindElement(By.Name(PropertyValue)).Text;
                    }
                    else
                    {
                        Val = string.Empty;
                    }

                    break;

                case "Dropdownlist":
                    if (PropertyType == "Id")
                    {
                        Val = new SelectElement(driver.FindElement(By.Id(PropertyValue))).AllSelectedOptions.SingleOrDefault().Text;

                    }
                    if (PropertyType == "Name")
                    {
                        Val = new SelectElement(driver.FindElement(By.Name(PropertyValue))).AllSelectedOptions.SingleOrDefault().Text;

                    }

                    else
                    {
                        Val = string.Empty;
                    }

                    break;

            }
            return Val;

        }

        public static void SelectRecordInTableByRowNo(IWebDriver driver, string XPath, int column, int row)
        {
           
            string FinalXPath = XPath + "/tbody/tr";
            driver.FindElement(By.XPath(FinalXPath + "[" + row + "]" + "/td[" + column + "]"), 10).Click();
      
        }

 

    public static void SetOperationsOnControls(IWebDriver driver, string ControlType, string PropertyType, string PropertyValue, string ValueToSet)
        {
            switch (ControlType)
            {

                case "set":
                    if (ValueToSet != "")
                    {

                        if (PropertyType == "Id")
                            driver.FindElement(By.Id(PropertyValue),5).SendKeys(ValueToSet);
                        if (PropertyType == "Name")
                            driver.FindElement(By.Name(PropertyValue),5).SendKeys(ValueToSet);
                    }

                    break;

                case "select":
                    if (ValueToSet != "")
                    {

                        if (PropertyType == "Id")
                            new SelectElement(driver.FindElement(By.Id(PropertyValue))).SelectByText(ValueToSet);
                        if (PropertyType == "Name")
                            new SelectElement(driver.FindElement(By.Name(PropertyValue))).SelectByText(ValueToSet);
                    }

                    break;

                case "click":
                    if (PropertyType == "Id")
                        driver.FindElement(By.Id(PropertyValue), 5).Click();
                    if (PropertyType == "Name")
                        driver.FindElement(By.Name(PropertyValue), 5).Click();
                    if (PropertyType == "LinkText")
                        driver.FindElement(By.LinkText(PropertyValue), 5).Click();
                    if (PropertyType == "XPath")
                        driver.FindElement(By.XPath(PropertyValue)).Click();
                    break;

                case "checkbox":
                    IWebElement checkbox1;
                    checkbox1 = driver.FindElement(By.Id(PropertyValue), 5);

                    if (ValueToSet == "Yes" && !checkbox1.Selected)
                    {
                        checkbox1.Click();
                    }

                    if (ValueToSet == "No" && checkbox1.Selected)
                    {
                        checkbox1.Click();
                    }
                    break;

            }

        }

    }

    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
