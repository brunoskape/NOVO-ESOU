using NUnit.Framework;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
using System.Threading;
using System.Linq;
using System;

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
            Logar("brunobispo", "260769");
            HomePage homePage = new HomePage(driver);
            homePage.selecionarSistema();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
        public void incluirCanalAcessoComNomeRepetido()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.incluirCanalAcesso("teste selenium");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Já existe um Canal de Acesso com essa descrição.", textoValidacao);

        }



        [Test, Order(3)]
        public void alterarCanalAcesso()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.alterarCanalAcesso("teste selenium alteracao");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }
        /* verificar
        [Test, Order(4)]
        public void alterarCanalAcessoComNomeRepetido()
        {

            CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
            canalDeAcesso.alterarCanalAcessoNomeRepetido("Formulario Eletronico");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Já existe um Canal de Acesso com essa descrição.", textoValidacao);
        
        }*/


        [Test, Order(4)]
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
            driver.Close();
            driver.Quit();
        }

    }

}
