using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class ReiteracaoEmLotePage
    {
        private IWebDriver driver;
        public ReiteracaoEmLotePage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void consultarReiteracaoLote()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuAreaManifestacao();
           
            

            driver.FindElement(By.Id("btnIncluir")).Click();

           

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);



        }

      
        public void selecionarMenuAreaManifestacao()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(3) > a")).Click();

        }


    }
}
