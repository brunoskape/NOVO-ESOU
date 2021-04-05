using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class PermissaoPage
    {
        private IWebDriver driver;
        public PermissaoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirPermissao(string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuAreaManifestacao();
           
            

            driver.FindElement(By.Id("btnIncluir")).Click();

            driver.FindElement(By.Id("inputCodUsu")).SendKeys(descricao);
            driver.FindElement(By.Id("dropIndCancelamento")).Click();
            

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);



        }

      
        public void alterarPermissao(string descricao)
        {
            selecionarMenuAreaManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tablePermissao']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();

            var combobox = driver.FindElement(By.Id("dropIndCancelamento"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Sim");

            driver.FindElement(By.Id("fnAlterar")).Click();

            Thread.Sleep(1000);



        }

        public void consultarPermissao()
        {
            selecionarMenuAreaManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("inputNomeUsu")).SendKeys("BRUNO");
            
            driver.FindElement(By.Id("btnBuscar")).Click();
            Thread.Sleep(1000);



        }


        public void excluirAreaManifestacao()
        {
            selecionarMenuAreaManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoAreaManif']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridDelete")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);



        }
        public void selecionarMenuAreaManifestacao()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[5]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(1) > a")).Click();

        }


    }
}
