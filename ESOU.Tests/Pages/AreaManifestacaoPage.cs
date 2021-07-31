using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class AreaManifestacaoPage
    {
        private IWebDriver driver;
        public AreaManifestacaoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page factory
        [FindsBy(How = How.Id, Using = "btnIncluir")]
        private IWebElement btnIncluir;

        [FindsBy(How = How.Id, Using = "inputDescr")]
        private IWebElement inputDescr;

        [FindsBy(How = How.Id, Using = "btnSalvar")]
        private IWebElement btnSalvar;

        [FindsBy(How = How.XPath, Using = "//*[@id='tableTipoAreaManif']/thead/tr/th[1]")]
        private IWebElement tabelaTipoAreaManif;

        [FindsBy(How = How.Id, Using = "btnGridEdit")]
        private IWebElement gridEdit;

        [FindsBy(How = How.Id, Using = "btnGridDelete")]
        private IWebElement gridDelete;


        [FindsBy(How = How.Id, Using = "btnAlterar")]
        private IWebElement btnAlterar;

        [FindsBy(How = How.Id, Using = "btnBuscar")]
        private IWebElement btnBuscar;

        [FindsBy(How = How.Id, Using = "btnConfirmar")]
        private IWebElement btnConfirmar;



        public void incluirAreaManifestacao(string descricao)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            selecionarMenuAreaManifestacao();


            btnIncluir.Click();
            inputDescr.SendKeys(descricao);


            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            btnSalvar.Click();
            Thread.Sleep(1000);



        }


        public void alterarAreaManifestacao(string descricao)
        {
            selecionarMenuAreaManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);

            pesquisarAreaManifestacao("teste selenium areaManif");
            tabelaTipoAreaManif.Click();
            gridEdit.Click();
            inputDescr.Click();
            inputDescr.SendKeys(Keys.Control + "a");
            inputDescr.SendKeys(Keys.Delete);
            inputDescr.SendKeys(descricao);

            btnAlterar.Click();

            Thread.Sleep(1000);



        }

        public void excluirAreaManifestacao()
        {
            selecionarMenuAreaManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//*[@id='tableTipoAreaManif']/thead/tr/th[1]")).Click();

            pesquisarAreaManifestacao("teste selenium alt");
            tabelaTipoAreaManif.Click();
            gridDelete.Click();
            Thread.Sleep(1000);
            btnBuscar.Click();
            Thread.Sleep(1000);



        }
        public void selecionarMenuAreaManifestacao()
        {
            driver.FindElement(By.XPath("//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#iniciodomenu > div > ul > li.open > ul > li:nth-child(1) > a")).Click();

        }

        public void pesquisarAreaManifestacao(String descricao)
        {
            inputDescr.SendKeys(descricao);
            btnBuscar.Click();

        }

    }
}
