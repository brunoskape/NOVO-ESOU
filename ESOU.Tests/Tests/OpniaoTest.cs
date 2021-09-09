using NUnit.Framework;
using OpenQA.Selenium;
using ESOU.Base;
using ESOU.Pages;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;

namespace ESOU.TestsUI

{
    class OpiniaoTest : TestBase
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
        public void incluirOpiniao()
        {

            OpiniaoPage opiniao = new OpiniaoPage(driver);
            opiniao.incluirOpiniao("teste selenium Manif");
            
            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Cadastrado com sucesso.", textoValidacao);
         
        }



        [Test, Order(2)]
        public void alterarManifestacao()
        {

            AreaManifestacaoPage areaManifestacao = new AreaManifestacaoPage(driver);
            areaManifestacao.alterarAreaManifestacao("teste selenium alt");

            string textoValidacao = driver.FindElement(By.XPath("//*[@id='divAlerta']/div")).Text;
            Assert.AreEqual("   Alterado com sucesso.", textoValidacao);

        }



        [Test, Order(3)]
        public void excluirManifestacao()
        {

            AreaManifestacaoPage areaManifestacao = new AreaManifestacaoPage(driver);
            areaManifestacao.excluirAreaManifestacao();

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
