using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class TextoPadraoPage
    {
        private IWebDriver driver;
        public TextoPadraoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirTextoPadrao(string titulo, string sigla, string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarFormaDeContato();

            driver.FindElement(By.Id("btnIncluir")).Click();

            driver.FindElement(By.Id("inputTitulo")).SendKeys(titulo);
            driver.FindElement(By.Id("inputSigla")).SendKeys(sigla);
            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            Thread.Sleep(2000);
            var comboboxTipoManifestacao = driver.FindElement(By.Id("dropManif"));
            var selectElementTipoManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoManifestacao);
            selectElementTipoManifestacao.SelectByText("1 - Duvidas");

            Thread.Sleep(2000);
            var comboboxTipoItemManifestacao = driver.FindElement(By.Id("dropItemManif"));
            var selectElementTipoItemManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoItemManifestacao);
            selectElementTipoItemManifestacao.SelectByText("1 - DUVIDAS SOBRE ADVOGADO DATIVO");


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

         
           
            driver.FindElement(By.Id("btnAlterar")).Click();
            Thread.Sleep(1000);


        }


        public void alterarTextoPadrao(string titulo)
        {
            selecionarFormaDeContato();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tableTipoTextoPadrao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();

            driver.FindElement(By.Id("inputTitulo")).SendKeys(Keys.Backspace);
            
            Thread.Sleep(1000);
            driver.FindElement(By.Id("inputTitulo")).SendKeys(titulo);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);

        }

        public void excluirTextoPadrao()
        {
            selecionarFormaDeContato();
           
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tableTipoTextoPadrao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridDelete")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);


        }


        public void consultarTextoPadrao(string titulo)
        {
            selecionarFormaDeContato();

            driver.FindElement(By.Id("inputTitulo")).SendKeys(titulo);
            driver.FindElement(By.Id("btnBuscar")).Click();


            Thread.Sleep(1000);


        }

        public void selecionarFormaDeContato()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(6) > a")).Click();

        }


    }
}
