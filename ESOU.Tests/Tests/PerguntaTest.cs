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
    class Pergunta : TestBase
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
        public void incluirPergunta()
        {

            PerguntaPage pergunta = new PerguntaPage(driver);
            pergunta.incluirPergunta("teste selenium");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }

        [Test, Order(2)]
        public void alterarPergunta()
        {

            PerguntaPage pergunta = new PerguntaPage(driver);
            pergunta.alterarPergunta("teste selenium alteracao");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }


        [Test, Order(3)]
        public void excluirPergunta()
        {

            PerguntaPage pergunta = new PerguntaPage(driver);
            pergunta.excluirPergunta();

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Excluída com sucesso.", textoValidacao);

        }



        [Test, Order(4)]
        public void consultarPergunta()
        {
        

            PerguntaPage pergunta = new PerguntaPage(driver);
            pergunta.consultarPergunta("Sim");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.IsTrue(textoValidacao.Contains("sim"));

        }


        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }

}
