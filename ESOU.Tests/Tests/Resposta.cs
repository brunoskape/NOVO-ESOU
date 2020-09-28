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
    class Resposta : TestBase
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
        public void incluirResposta()
        {

            RespostaPage resposta = new RespostaPage(driver);
            resposta.incluirResposta("teste selenium");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }

        [Test, Order(2)]
        public void alterarResposta()
        {

            RespostaPage resposta = new RespostaPage(driver);
            resposta.alterarResposta("teste selenium alteracao");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }


        [Test, Order(3)]
        public void excluirResposta()
        {

            RespostaPage resposta = new RespostaPage(driver);
            resposta.excluirResposta();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluída com sucesso.", textoValidacao);

        }


        [Test, Order(4)]
        public void consultarResposta()
        {

            RespostaPage resposta = new RespostaPage(driver);
            resposta.consultarResposta("Sim");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableTipoResposta']/tbody/tr[1]/td[2]")).Text;
            Assert.IsTrue(textoValidacao.Contains("sim"));

        }



        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

    }

}
