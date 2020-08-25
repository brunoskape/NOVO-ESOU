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
    class TextoPadrao : TestBase
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
        public void incluirTextoPadrao()
        {

            TextoPadraoPage textoPadrao = new TextoPadraoPage(driver);
            textoPadrao.incluirTextoPadrao("testeSelenium","BRU","teste descrição");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarTextoPadrao()
        {
            //verificar
            TextoPadraoPage textoPadrao = new TextoPadraoPage(driver);
            textoPadrao.alterarTextoPadrao("alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirTextoPadrao()
        {

            TextoPadraoPage textoPadrao = new TextoPadraoPage(driver);
            textoPadrao.excluirTextoPadrao();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        }


        [Test, Order(4)]
        public void consultarTextoPadrao()
        {

            TextoPadraoPage textoPadrao = new TextoPadraoPage(driver);
            textoPadrao.consultarTextoPadrao("teste");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableTipoTextoPadrao']/tbody/tr[1]/td[2]")).Text;
            Assert.IsTrue(textoValidacao.Contains("TESTE"));

        }



        [TearDown]
        public void tearDown()
        {
           // driver.Quit();
        }



    }




}
