using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace ESOU.Pages
{
    class AndamentoPage
    {
        private IWebDriver driver;
        public AndamentoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //page factory
        [FindsBy(How = How.Id, Using = "inputDtInicio")]
        private IWebElement inputDtInicio { get; set; }

        [FindsBy(How = How.Id, Using = "inputDtFim")]
        private IWebElement inputDtFim { get; set; }

        [FindsBy(How = How.Id, Using = "btnGridAndamento")]
        private IWebElement btnGridAndamento { get; set; }

        [FindsBy(How = How.Id, Using = "btnIncluir")]
        private IWebElement btnIncluir { get; set; }

        [FindsBy(How = How.Id, Using = "inputDescr")]
        private IWebElement inputDescr { get; set; }

        [FindsBy(How = How.Id, Using = "inputTexto")]
        private IWebElement texto { get; set; }

        [FindsBy(How = How.Id, Using = "btnBuscar")]
        private IWebElement btnBuscar;

      
        public void incluirAndamento()
        {
                  
            btnBuscar.Click();
            btnGridAndamento.Click();


             texto.SendKeys("Texto andamento");
                    //dropTipoAndamento

        }

             
        public void selecionarMenuConsultarManifestacao()
        {
        
                driver.FindElement(By.PartialLinkText("Manifestações")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.PartialLinkText("Consultar")).Click();

        }
      
    }
}
