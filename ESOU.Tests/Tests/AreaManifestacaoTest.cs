﻿using NUnit.Framework;
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
    class AreaManifestacao : TestBase
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
        public void incluirManifestacao()
        {

            AreaManifestacaoPage areaManifestacao = new AreaManifestacaoPage(driver);
            areaManifestacao.incluirAreaManifestacao("teste selenium areaManif");

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
