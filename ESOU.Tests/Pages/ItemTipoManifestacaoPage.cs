using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;
using NUnit.Framework;

namespace ESOU.Pages
{
    class ItemTipoManifestacaoPage
    {
        private IWebDriver driver;
        public ItemTipoManifestacaoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirItemTipoManifestacao(string nome, string sigla)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarTipoManifestante();

            driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("btnGridItens")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("btnIncluir")).Click();

            driver.FindElement(By.Id("inputNome")).SendKeys(nome);

            var comboboxStatus = driver.FindElement(By.Id("dropStatus"));
            var selectElementStatus = new OpenQA.Selenium.Support.UI.SelectElement(comboboxStatus);
            selectElementStatus.SelectByText("Ativo");

            driver.FindElement(By.Id("inputSigla")).SendKeys(sigla);




            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);


        }


        public void alterarItemTipoManifestacao(string titulo)
        {
            selecionarTipoManifestante();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridItens")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnGridEdit")).Click();


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            Thread.Sleep(1000);
            selectElement.SelectByText("Inativo");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);

        }

        public void excluirItemTipoManifestacao()
        {
            selecionarTipoManifestante();
           
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridItens")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnGridExcluir")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);


        }

        public void excluirItemTipoManifestacaoVinculado()
        {
            selecionarTipoManifestante();

            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/thead/tr/th[1]")).Click();
            
            var button = driver.FindElement(By.Id("btnGridExcluir")).Enabled;

            
            
  
        }



        public void consultarItemTipoManifestacao(string titulo)
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
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(6) > a")).Click();

        }


    }
}
