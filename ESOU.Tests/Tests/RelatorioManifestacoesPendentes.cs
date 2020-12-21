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
    class RelatorioManifestacoesPendentes : TestBase
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
        public void consultarRelatorioSintetico()
        {

            RelatorioManifestacoesPendentesPage relatorioManifestacoes = new RelatorioManifestacoesPendentesPage(driver);
            relatorioManifestacoes.consultarRelatorioSintetico();
            
           // string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
           /// Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void consultarRelatorioAnalitico()
        {

            RelatorioManifestacoesPendentesPage relatorioManifestacoes = new RelatorioManifestacoesPendentesPage(driver);
            relatorioManifestacoes.consultarRelatorioAnalitico();

            //string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
           /// Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }




        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }



    }




}
