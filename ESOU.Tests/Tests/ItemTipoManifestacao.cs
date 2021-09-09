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
    class ItemTipoManifestacao : TestBase
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
        public void incluirItemTipoManifestacao()
        {

            ItemTipoManifestacaoPage itemTipoManifestacao = new ItemTipoManifestacaoPage(driver);
            itemTipoManifestacao.incluirItemTipoManifestacao("testeSelenium","sigla");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarItemTipoManifestacao()
        {

            ItemTipoManifestacaoPage itemTipoManifestacao = new ItemTipoManifestacaoPage(driver);
            itemTipoManifestacao.alterarItemTipoManifestacao("alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirItemTipoManifestacao()
        {

            ItemTipoManifestacaoPage itemTipoManifestacao = new ItemTipoManifestacaoPage(driver);
            itemTipoManifestacao.excluirItemTipoManifestacao();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        }

        [Test, Order(4)]
        public void excluirItemTipoManifestacaoVinculado()
        {

            ItemTipoManifestacaoPage itemTipoManifestacao = new ItemTipoManifestacaoPage(driver);
            itemTipoManifestacao.excluirItemTipoManifestacaoVinculado();
            Assert.IsTrue(driver.FindElement(By.Id("btnGridExcluir")).Enabled);


        }


        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }



    }




}
