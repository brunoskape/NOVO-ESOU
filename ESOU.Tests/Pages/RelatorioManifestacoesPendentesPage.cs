using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class RelatorioManifestacoesPendentesPage
    {
        private IWebDriver driver;
        public RelatorioManifestacoesPendentesPage(IWebDriver driver)
        {
            this.driver = driver;

        } 


        public void consultarRelatorioSintetico()
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuAreaManifestacao();
           
            var combobox = driver.FindElement(By.Id("dropNur"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            Thread.Sleep(1000);
            selectElement.SelectByText("1º NUR");

            driver.FindElement(By.Id("inputNumDias")).SendKeys("1");
            
            driver.FindElement(By.Id("btnImprimir")).Click();
            Thread.Sleep(1000);

        }

      
        public void consultarRelatorioAnalitico()
        {
            selecionarMenuAreaManifestacao();

            var combobox = driver.FindElement(By.Id("dropNur"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            Thread.Sleep(1000);
            selectElement.SelectByText("1º NUR");

            var comboboxTipoRelatorio = driver.FindElement(By.Id("dropTipoRelatorio"));
            var selectElementTipo = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoRelatorio);
            Thread.Sleep(1000);
            selectElementTipo.SelectByText("Analítico");


           


            driver.FindElement(By.Id("inputNumDias")).SendKeys("1");

            driver.FindElement(By.Id("btnImprimir")).Click();
            Thread.Sleep(1000);



        }

       
        public void selecionarMenuAreaManifestacao()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[7]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(9) > a")).Click();

        }


    }
}
