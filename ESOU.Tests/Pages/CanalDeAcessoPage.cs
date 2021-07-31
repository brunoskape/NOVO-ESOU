using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{

    class CanalDeAcessoPage
    {
        private IWebDriver driver;
        public CanalDeAcessoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        //page factory
        [FindsBy(How = How.Id, Using = "btnIncluir")]
        private IWebElement btnIncluir;

        [FindsBy(How = How.Id, Using = "inputDescr")]
        private IWebElement inputDescricao;

        [FindsBy(How = How.Id, Using = "btnSalvar")]
        private IWebElement btnSalvar;

        [FindsBy(How = How.XPath, Using = "//*[@id='tableTipoCanalAcesso']/thead/tr/th[1]")]
        private IWebElement tableCanalAcesso;

        [FindsBy(How = How.Id, Using = "btnGridEdit")]
        private IWebElement gridEdit;

        [FindsBy(How = How.Id, Using = "btnAlterar")]
        private IWebElement btnAlterar;

        [FindsBy(How = How.Id, Using = "btnGridDelete")]
        private IWebElement gridDelete;

        [FindsBy(How = How.Id, Using = "btnConfirmar")]
        private IWebElement btnConfirmar;

        [FindsBy(How = How.Id, Using = "btnBuscar")]
        private IWebElement btnBuscar;

        [FindsBy(How = How.CssSelector, Using = "#iniciodomenu > div > ul > li.open > ul > li:nth-child(2) > a")]
        private IWebElement menuCanalAcesso;

        [FindsBy(How = How.XPath, Using = "//*[@id='iniciodomenu']/div/ul/li[4]/a/span[1]")]
        private IWebElement menuCadastroBasico;

        [FindsBy(How = How.XPath, Using = "//tr[1]/td[3]/div/div/button[2]")]
        private IWebElement penultimoGridEdit;


        public void incluirCanalAcesso(string descricao)
        {

            selecionarMenuCanalAcesso();

            btnIncluir.Click();
            inputDescricao.SendKeys(descricao);

            var combobox = driver.FindElement(By.Id("dropStatus"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(combobox);
            selectElement.SelectByText("Ativo");

            btnSalvar.Click();
            Thread.Sleep(1000);

        }



        public void alterarCanalAcesso(string descricao)
        {
            selecionarMenuCanalAcesso();

            Thread.Sleep(1000);
            tableCanalAcesso.Click();
            gridEdit.Click();
            inputDescricao.Click();
            inputDescricao.SendKeys(Keys.Control + "a");
            inputDescricao.SendKeys(Keys.Delete);
            inputDescricao.SendKeys(descricao);
            btnAlterar.Click();

            Thread.Sleep(1000);

        }

        public void alterarCanalAcessoNomeRepetido(string descricao)
        {
            selecionarMenuCanalAcesso();

            Thread.Sleep(1000);
            tableCanalAcesso.Click();

            if (gridDelete.Enabled)
            {

                gridEdit.Click();
                inputDescricao.Click();
                inputDescricao.SendKeys(Keys.Control + "a");
                inputDescricao.SendKeys(Keys.Delete);
                inputDescricao.SendKeys(descricao);
                btnAlterar.Click();


            }
            else
            {
                gridEdit.Click();
                inputDescricao.Click();
                inputDescricao.SendKeys(Keys.Control + "a");
                inputDescricao.SendKeys(Keys.Delete);
                inputDescricao.SendKeys(descricao);
                btnAlterar.Click();


            }
        }



        public void excluirCanalAcesso()
        {
            selecionarMenuCanalAcesso();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            pesquisarCanalAcesso("teste selenium alteracao");
            gridDelete.Click();
            btnConfirmar.Click();
            Thread.Sleep(1000);


            Thread.Sleep(1000);



        }

        public void selecionarMenuCanalAcesso()
        {
            menuCadastroBasico.Click();

            //   WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            //  wait.Until(ExpectedConditions.ElementToBeClickable(menuCanalAcesso));
            Thread.Sleep(2000); //refatorar o sleep
            menuCanalAcesso.Click();


        }
        public void pesquisarCanalAcesso(String descricao)
        {
            inputDescricao.SendKeys(descricao);
            btnBuscar.Click();

        }


    }
}
