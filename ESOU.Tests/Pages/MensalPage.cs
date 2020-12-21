using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class MensalPage
    {
        private IWebDriver driver;
        public MensalPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void consultarRelatorioMensalSintetico(string dataInicio, string dataFim)
        {
            

            selecionarMenuEstatistica();
                       
            driver.FindElement(By.Id("inputDataInicio")).SendKeys(dataInicio);
            driver.FindElement(By.Id("inputDataFim")).SendKeys(dataFim);

            driver.FindElement(By.Id("btnImprimir")).Click();


        }

      
        public void alterarAreaManifestacao(string descricao)
        {
            selecionarMenuEstatistica();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);


        }

        public void selecionarMenuEstatistica()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[7]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(8) > a")).Click();

        }


    }
}
