using ESOU.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ESOU.Pages
{
    class HomePage 
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void selecionarSistema()
        {
            
            var combobox = driver.FindElement(By.Id("cmbSistemas"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("SISTEMA ELETRÔNICO DA OUVIDORIA");

            Thread.Sleep(500);

            driver.FindElement(By.Id("cmdEnviar")).Click();

      

        }
        
    }
}
