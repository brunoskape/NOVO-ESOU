using NUnit.Framework;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
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
            Logar("brunobispo", "260769");
            HomePage homePage = new HomePage(driver);
            homePage.selecionarSistema();
            Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
        
            
            [Test, Order(1)]
        public void incluirManifestacao()
        {

            

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.incluirManifestacao();
            
            
           // string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            //Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }

        //[Test, Order(2)]
        //public void alterarManifestacao()
        //{

        //    CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
        //    canalDeAcesso.alterarCanalAcesso("teste selenium alteracao");

        //    string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
        //    Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        //}


        //[Test, Order(3)]
        //public void excluirManifestacao ()
        //{

        //    CanalDeAcessoPage canalDeAcesso = new CanalDeAcessoPage(driver);
        //    canalDeAcesso.excluirCanalAcesso();

        //    string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
        //    Assert.AreEqual("   Excluído com sucesso.", textoValidacao);

        //}


        [Test, Order(4)]
        public void consultarManifestacaoPorNumero()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.consultarManifestacaoPorNumero("202079");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableManifest']/tbody/tr/td[1]")).Text;
            Assert.AreEqual("2020.000079", textoValidacao);

        }

        [Test, Order(5)]
        public void consultarManifestacaoPorData()
        {

            ManifestacaoPage manifestacao = new ManifestacaoPage(driver);
            manifestacao.consultarManifestacaoPorData("01/01/2020","20/10/2021");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='tableManifest']/tbody/tr[4]/td[1]")).Text;
            Assert.AreEqual("2020.000079", textoValidacao);

        }




        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }

    }

}
