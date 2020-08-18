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
    class Acesso : TestBase
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
        public void incluirCanalAcesso()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.incluirCanalAcesso("teste selenium");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }

        [Test, Order(2)]
        public void alterarCanalAcesso()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.alterarCanalAcesso("teste selenium alteracao");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }


        [Test, Order(3)]
        public void excluirCanalAcesso()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.excluirCanalAcesso();

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
