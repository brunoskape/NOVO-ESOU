using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class RelatorioLeiDeAcessoPage
    {
        private IWebDriver driver;
        public RelatorioLeiDeAcessoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void imprimirAnalitico(string dataInicio, string dataFim)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuEstatistica();
           
            

            driver.FindElement(By.Id("inputDataInicio")).SendKeys(dataInicio);
            driver.FindElement(By.Id("inputDataFim")).SendKeys(dataFim);


            driver.FindElement(By.Id("inputDataInicioReclassificacao")).SendKeys(dataInicio);
            driver.FindElement(By.Id("inputDataFimReclassificacao")).SendKeys(dataFim);

            

            var combobox = driver.FindElement(By.Id("dropTipoRelatorio"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Analitico");

            driver.FindElement(By.Id("btnImprimir")).Click();
            Thread.Sleep(1000);



        }

        public void imprimirSintetico(string dataInicio, string dataFim)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuEstatistica();



            driver.FindElement(By.Id("inputDataInicio")).SendKeys(dataInicio);
            driver.FindElement(By.Id("inputDataFim")).SendKeys(dataFim);

            driver.FindElement(By.Id("inputDataInicioReclassificacao")).SendKeys(dataInicio);
            driver.FindElement(By.Id("inputDataFimReclassificacao")).SendKeys(dataFim);


            driver.FindElement(By.Id("btnImprimir")).Click();
            Thread.Sleep(1000);



        }






        public void selecionarMenuEstatistica()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[7]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(5) > a")).Click();


        }


    }
}
