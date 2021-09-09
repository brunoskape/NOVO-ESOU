using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class AnalisarManifestacaoPage
    {
        private IWebDriver driver;
        public AnalisarManifestacaoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page factory
        [FindsBy(How = How.Id, Using = "inputDtInicio")]
        private IWebElement inputDtInicio;

        [FindsBy(How = How.Id, Using = "inputDtFim")]
        private IWebElement inputDtFim;

        [FindsBy(How = How.Id, Using = "btnSalvar")]
        private IWebElement btnSalvar;

        
        [FindsBy(How = How.Id, Using = "btnIncluir")]
        private IWebElement btnIncluir;

        [FindsBy(How = How.Id, Using = "inputDescr")]
        private IWebElement inputDescr;

        [FindsBy(How = How.Id, Using = "inputTexto")]
        private IWebElement texto;
        


        [FindsBy(How = How.Id, Using = "btnGridAnalisar")]
        private IWebElement btnGridAnalisar;

      

        public void incluirAnaliseManifestacao()
        {

            btnGridAnalisar.Click();

            var comboboxAreaManifestacao = driver.FindElement(By.Id("dropAreaManifestacao"));
            var selectElementCanalAcesso = new OpenQA.Selenium.Support.UI.SelectElement(comboboxAreaManifestacao);
            selectElementCanalAcesso.SelectByText("AREA ADMINISTRATIVA");


            var comboboxItemManifestacao = driver.FindElement(By.Id("dropTipoItemManifestacao"));
            var selectElementTipoDocumento = new OpenQA.Selenium.Support.UI.SelectElement(comboboxItemManifestacao);
            selectElementTipoDocumento.SelectByIndex(1);

            texto.SendKeys("Texto Andamento");
            btnSalvar.Click();

        }

             
        public void selecionarMenuAnalisarManifestacao()
        {
        
                driver.FindElement(By.PartialLinkText("Manifestações")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.PartialLinkText("Analisar")).Click();

        }
      
    }
}
