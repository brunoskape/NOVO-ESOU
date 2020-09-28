using OpenQA.Selenium;
using System.Threading;


namespace ESOU.Pages
{
    class PerguntaPage  
    {
        private IWebDriver driver;
        public PerguntaPage(IWebDriver driver)
        {
            this.driver = driver;

        }


        public void incluirPergunta(string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuPergunta();
           
            

            driver.FindElement(By.Id("btnIncluir")).Click();

            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            driver.FindElement(By.Id("btnSalvar")).Click();
            Thread.Sleep(1000);



        }

            public void alterarPergunta(string descricao)
        {
            selecionarMenuPergunta();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoCanalAcesso']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();
            driver.FindElement(By.Id("inputDescr")).Clear();
            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);



        }

        public void excluirPergunta()
        {
            selecionarMenuPergunta();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoCanalAcesso']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridDelete")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);



        }

        public void selecionarMenuPergunta()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(2) > a")).Click();

        }

    }
}
