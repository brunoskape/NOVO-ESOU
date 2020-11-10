using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;

namespace ESOU.TestsUI

{
    class RelatorioReclamacoes : TestBase
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            Inicializar(WebBrowser.Chrome);
            driver = GetDriver();
            Logar("brunobispo", "260769");
            HomePage homePage = new HomePage(driver);
            homePage.selecionarSistema();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());

        }
        
            
            [Test, Order(1)]
        public void imprimirRelatorioAnalitico()
        {

            RelatorioManifestacaoRemetidaPage relatorio = new RelatorioManifestacaoRemetidaPage(driver);
            relatorio.imprimirAnalitico("012020","09/2020");
            
           
        }


        [Test, Order(2)]
        public void imprimirRelatorioSintetico()
        {

            RelatorioManifestacaoRemetidaPage relatorio = new RelatorioManifestacaoRemetidaPage(driver);
            relatorio.imprimirSintetico("012020", "09/2020");



        }




        [TearDown]
        public void tearDown()
        {
         //   driver.Quit();
        }

    }

}
