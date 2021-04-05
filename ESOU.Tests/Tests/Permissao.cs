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
    class Permissao : TestBase
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
        public void incluirPermissao()
        {

            PermissaoPage permissao = new PermissaoPage(driver);
            permissao.incluirPermissao("BRUNOBISPO");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);

        }

        [Test, Order(2)]
        public void alterarPermissao()
        {

            PermissaoPage permissao = new PermissaoPage(driver);
            permissao.alterarPermissao("teste selenium alteracao");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }


        [Test, Order(3)]
        public void consultarPermissao()
        {

            PermissaoPage permissao = new PermissaoPage(driver);
            permissao.consultarPermissao();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tablePermissao']/tbody/tr[1]/td[2]")).Text;
            Assert.AreEqual("BRUNO RODRIGUES BISPO", textoValidacao);

        }

        [Test, Order(4)]
        public void excluirPermissao()
        {

            PerguntaPage pergunta = new PerguntaPage(driver);
            pergunta.excluirPergunta();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluída com sucesso.", textoValidacao);

        }




        [TearDown]
        public void tearDown()
        {
          //  driver.Quit();
        }

    }

}
