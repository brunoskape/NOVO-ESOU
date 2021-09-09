using NUnit.Framework;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
using System.Threading;
using System.Linq;
using System;

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
            Logar("brunobispo", "260769");
            HomePage homePage = new HomePage(driver);
            homePage.selecionarSistema();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }


        [Test, Order(1)]
        public void incluirManifestacaoDuvidas()
        {
            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);

            manifestacao.incluirManifestacao();
            manifestacao.incluirDadosManifestacao("Duvidas");
            manifestacao.salvar();
            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;

            Assert.That(textoValidacao.Contains("Sua manifestação foi enviada com sucesso"));
        }

        [Test, Order(2)]
        public void incluirManifestacaoReclamacao()
        {
            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);

            manifestacao.incluirManifestacao();
            manifestacao.incluirDadosManifestacao("Reclamacao");
            manifestacao.salvar();
            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;

            Assert.That(textoValidacao.Contains("Sua manifestação foi enviada com sucesso"));
        }



        [Test, Order(3)]
        public void incluirManifestacaoDuvidasComAnexo()
        {
            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.incluirManifestacao();
            manifestacao.incluirDadosManifestacao("Duvidas");
            manifestacao.incluirUmAnexo();
            manifestacao.salvar();
            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;

            Assert.That(textoValidacao.Contains("Sua manifestação foi enviada com sucesso"));
        }

        [Test, Order(4)]
        public void incluirManifestacaoLGPD()
        {
            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.incluirManifestacao();
            manifestacao.incluirDadosManifestacao("Lei Geral de Proteção de Dados - LGPD");
            manifestacao.incluirDiversosAnexos();
            manifestacao.salvar();
            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;

            Assert.That(textoValidacao.Contains("Sua manifestação foi enviada com sucesso"));
        }



        [Test, Order(5)]
        public void consultarManifestacaoPorNumero()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.selecionarMenuConsultarManifestacao();
            manifestacao.consultarManifestacaoPorNumero("2021.000321");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableManifest']/tbody/tr/td[1]")).Text;
            Assert.AreEqual("2021.000321", textoValidacao);

        }

        [Test, Order(6)]
        public void consultarManifestacaoPorData()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.selecionarMenuConsultarManifestacao();
            manifestacao.consultarManifestacaoPorData("01/07/2021", "30/07/2021");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableManifest']/tbody/tr[1]/td[5]")).Text;
            Assert.That(textoValidacao.Contains("26/07/2021"));

        }


        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }

    }

}
