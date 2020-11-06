using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class TipoManifestantePage
    {
        private IWebDriver driver;
        public TipoManifestantePage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirTipoManifestante(string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarTipoManifestante();

            driver.FindElement(By.Id("btnIncluir")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);


            var comboboxTipoManifestacao = driver.FindElement(By.Id("dropManifestacao"));
            var selectElementTipoManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoManifestacao);
            selectElementTipoManifestacao.SelectByText("Sim");


            var comboboxOpniao = driver.FindElement(By.Id("dropOpiniao"));
            var selectElementOpniao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxOpniao);
            selectElementOpniao.SelectByText("Sim");


            var comboboxStatus = driver.FindElement(By.Id("dropStatus"));
            var selectElementStatus = new OpenQA.Selenium.Support.UI.SelectElement(comboboxStatus);
            selectElementStatus.SelectByText("Ativo");

           
            var comboboxSatisfacao = driver.FindElement(By.Id("dropSatisfacao"));
            var selectElementSatisfacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxSatisfacao);
            selectElementSatisfacao.SelectByText("Sim");



            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);


        }


        public void alterarTipoManifestante(string titulo)
        {
            selecionarTipoManifestante();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestante']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Inativo");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);

        }

        public void excluirTipoManifestante()
        {
            selecionarTipoManifestante();
           
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestante']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridExcluir")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);


        }


        public void consultarTipoManifestante(string titulo)
        {
            selecionarTipoManifestante();

            driver.FindElement(By.Id("inputDescr")).SendKeys(titulo);
            driver.FindElement(By.Id("btnBuscar")).Click();


            Thread.Sleep(1000);


        }

        public void selecionarTipoManifestante()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(9) > a")).Click();

        }


    }
}
