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
    class RelatorioLeiDeAcesso : TestBase
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

            RelatorioLeiDeAcessoPage relatorio = new RelatorioLeiDeAcessoPage(driver);
            relatorio.imprimirAnalitico("01012020","01112020");
            
           
        }


        [Test, Order(2)]
        public void imprimirRelatorioSintetico()
        {

            RelatorioLeiDeAcessoPage relatorio = new RelatorioLeiDeAcessoPage(driver);
            relatorio.imprimirSintetico("01012020", "01112020");



        }




        [TearDown]
        public void tearDown()
        {
         //   driver.Quit();
        }

    }

}
