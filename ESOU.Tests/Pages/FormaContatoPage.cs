using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class FormatoContatoPage
    {
        private IWebDriver driver;
        public FormatoContatoPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirFormaDeContato(string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarFormaDeContato();

            driver.FindElement(By.Id("btnIncluir")).Click();

            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);


        }


        public void alterarFormaDeContato(string descricao)
        {
            selecionarFormaDeContato();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='tableFormaContato']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();
            driver.FindElement(By.Id("inputDescr")).Clear();
            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);

        }

        public void excluirFormaDeContato()
        {
            selecionarFormaDeContato();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='tableFormaContato']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridDelete")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);


        }

        public void selecionarFormaDeContato()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(3) > a")).Click();

        }


    }
}
