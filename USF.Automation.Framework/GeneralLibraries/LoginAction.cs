using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using USFAutomationFramework.GeneralLibraries;

namespace USFAutomation
{
    public class LoginAction
    {

        public static void Login(IWebDriver driver, string Url, string UserId, string Password)
        {
            
            driver.Navigate().GoToUrl(Url);
            CommonLibrary.SetOperationsOnControls(driver, "set", "Id", "hitComp_msLogin_id", UserId);
            CommonLibrary.SetOperationsOnControls(driver, "set", "Id", "hitComp_msLogin_password", Password);
            CommonLibrary.SetOperationsOnControls(driver, "click", "XPath", "//*[@id='hitComp_msLogin_form']/table/tbody/tr[3]/td/input", "");
            System.Threading.Thread.Sleep(3000);

           
 
        }


    }
}
