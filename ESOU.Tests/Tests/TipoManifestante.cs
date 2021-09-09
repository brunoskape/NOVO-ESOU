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
    class TipoManifestante : TestBase
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
        public void incluirTipoManifestante()
        {

            TipoManifestantePage tipoManifestante = new TipoManifestantePage(driver);
            tipoManifestante.incluirTipoManifestante("teste Tipo Manifestante");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarTipoManifestante()
        {

            TipoManifestantePage tipoManifestante = new TipoManifestantePage(driver);
            tipoManifestante.alterarTipoManifestante("alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirTipoManifestante()
        {

            TipoManifestantePage tipoManifestante = new TipoManifestantePage(driver);
            tipoManifestante.excluirTipoManifestante();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        }


        [Test, Order(4)]
        public void consultarTipoManifestante()
        {

            TipoManifestantePage tipoManifestante = new TipoManifestantePage(driver);
            tipoManifestante.consultarTipoManifestante("Advogado");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableTipoManifestante']/tbody/tr[1]/td[2]")).Text;
            Assert.IsTrue(textoValidacao.Contains("Advogado"));

        }

             
        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }



    }




}
