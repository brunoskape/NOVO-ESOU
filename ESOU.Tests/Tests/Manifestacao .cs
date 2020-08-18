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
    class Manifestacao : TestBase
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            Inicializar(WebBrowser.Chrome);
            driver = GetDriver();
            Logar("brunobispo", "875664");
            HomePage homePage = new HomePage(driver);
            homePage.selecionarSistema();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        
            
            [Test, Order(1)]
        public void incluirManifestacao()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.alterarManifestacao("teste selenium Manif");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarManifestacao()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.alterarManifestacao("teste selenium alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirManifestacao()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.excluirManifestacao();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        }



        [TearDown]
        public void tearDown()
        {
           // driver.Quit();
        }



    }




}
