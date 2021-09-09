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
    class AnalisarManifestacaoTest : TestBase
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
        public void incluirAnaliseManifestacao()
        {

            AnalisarManifestacaoPage analisarManifestacao = new AnalisarManifestacaoPage(driver);
            ManifestacaoPage manifestacaoPage = new ManifestacaoPage(driver);
            analisarManifestacao.selecionarMenuAnalisarManifestacao();
            manifestacaoPage.consultarManifestacaoPorData("01/07/2021", "30/07/2021");
            analisarManifestacao.incluirAnaliseManifestacao();

            String textoValidacao = driver.FindElement(By.XPath("//*[@class='well']")).Text;
           
            Assert.That(textoValidacao.Contains("foi atualizada com sucesso."));

        }




        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }



    }




}
