using NUnit.Framework;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
using System.Threading;
using System.Linq;
using System;

namespace ESOU.TestsUI

{
    class AndamentoTest: TestBase
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
        public void incluirAndamento()
        {
            AndamentoPage andamento = new AndamentoPage(driver);

            andamento.selecionarMenuConsultarManifestacao();

            ManifestacaoPage manifestacaoPage = new ManifestacaoPage(driver);
            manifestacaoPage.consultarManifestacaoPorData("01/07/2021", "30/07/2021");

            andamento.incluirAndamento();

            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;
            Assert.That(textoValidacao.Contains("Sua manifestação foi enviada com sucesso"));
        }

 

    



        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }

}
