using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class TipoAndamentoPage
    {
        private IWebDriver driver;
        public TipoAndamentoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirTipoAndamento(string descricao)
        {
            selecionarTipoAndamento();

            driver.FindElement(By.Id("btnIncluir")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);


            var comboboxTipoManifestacao = driver.FindElement(By.Id("dropManifestacao"));
            var selectElementTipoManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoManifestacao);
            selectElementTipoManifestacao.SelectByText("Ativo");


            var comboboxOpniao = driver.FindElement(By.Id("dropOpiniao"));
            var selectElementOpniao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxOpniao);
            selectElementOpniao.SelectByText("Ativo");


            var comboboxStatus = driver.FindElement(By.Id("dropStatus"));
            var selectElementStatus = new OpenQA.Selenium.Support.UI.SelectElement(comboboxStatus);
            selectElementStatus.SelectByText("Ativo");

            var comboboxAbertura = driver.FindElement(By.Id("dropAbertura"));
            var selectElementAbertura = new OpenQA.Selenium.Support.UI.SelectElement(comboboxAbertura);
            selectElementAbertura.SelectByText("Ativo");


            var comboboxFechamento = driver.FindElement(By.Id("dropFechamento"));
            var selectElementFechamento = new OpenQA.Selenium.Support.UI.SelectElement(comboboxFechamento);
            selectElementFechamento.SelectByText("Ativo");

            


            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);


        }


        public void alterarTipoManifestacao(string titulo)
        {
            selecionarTipoAndamento();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Inativo");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);

        }

        public void excluirTipoManifestacao()
        {
            selecionarTipoAndamento();
           
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridExcluir")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);


        }


        public void consultarTipoManifestacao(string titulo)
        {
            selecionarTipoAndamento();

            driver.FindElement(By.Id("inputDescr")).SendKeys(titulo);
            driver.FindElement(By.Id("btnBuscar")).Click();


            Thread.Sleep(1000);


        }

        public void selecionarTipoAndamento()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(7) > a")).Click();

        }


    }
}
