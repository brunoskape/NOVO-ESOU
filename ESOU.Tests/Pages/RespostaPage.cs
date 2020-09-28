using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class RespostaPage  
    {
        private IWebDriver driver;
        public RespostaPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirResposta(string descricao)
        {
            selecionarMenuResposta();
           
            

            driver.FindElement(By.Id("btnIncluir")).Click();
           

            driver.FindElement(By.Id("inputDescrTipoResposta")).SendKeys(descricao);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);



        }


        public void alterarResposta(string descricao)
        {
            selecionarMenuResposta();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoResposta']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();
            driver.FindElement(By.Id("inputDescrTipoResposta")).Clear();
            driver.FindElement(By.Id("inputDescrTipoResposta")).SendKeys(descricao);

            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);



        }

        public void excluirResposta()
        {
            selecionarMenuResposta();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoResposta']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridExcluir")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);

        }

        public void consultarResposta(string titulo)
        {
            selecionarMenuResposta();

            driver.FindElement(By.Id("inputDescr")).SendKeys(titulo);
            driver.FindElement(By.Id("btnBuscar")).Click();


            Thread.Sleep(1000);



        }


        public void selecionarMenuResposta()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(5) > a")).Click();

        }

    }
}
