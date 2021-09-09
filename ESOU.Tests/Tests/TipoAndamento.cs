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
    class TipoAndamento : TestBase
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
        public void incluirAndamento()
        {

            TipoAndamentoPage tipoAndamento = new TipoAndamentoPage(driver);
            tipoAndamento.incluirTipoAndamento("testeSelenium");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarTipoManifestacao()
        {
            
            TipoManifestacaoPage tipoManifestacao = new TipoManifestacaoPage(driver);
            tipoManifestacao.alterarTipoManifestacao("alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirTipoManifestacao()
        {

            TipoManifestacaoPage tipoManifestacao = new TipoManifestacaoPage(driver);
            tipoManifestacao.excluirTipoManifestacao();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        }


        [Test, Order(4)]
        public void consultarTipoManifestacao()
        {

            TipoManifestacaoPage tipoManifestacao = new TipoManifestacaoPage(driver);
            tipoManifestacao.consultarTipoManifestacao("Duvidas");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableTipoManifestacao']/tbody/tr[1]/td[2]")).Text;
            Assert.IsTrue(textoValidacao.Contains("Duvidas"));

        }

             
        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }



    }




}
