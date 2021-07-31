using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using ESOU.Base;
using System;
using System.Threading;
using System.Linq;

namespace ESOU.Pages
{
    class ManifestacaoPage
    {
        private IWebDriver driver;
        public ManifestacaoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //page factory
        [FindsBy(How = How.Id, Using = "inputNome")]
        private IWebElement nome { get; set; }

        [FindsBy(How = How.Id, Using = "inputCpfCnpj")]
        private IWebElement cpfCNPJ { get; set; }

        [FindsBy(How = How.Id, Using = "inputEmail")]
        private IWebElement email { get; set; }

        [FindsBy(How = How.Id, Using = "inputTelefone_1")]
        private IWebElement tel1 { get; set; }

        [FindsBy(How = How.Id, Using = "inputTelefone_2")]
        private IWebElement tel2 { get; set; }

        [FindsBy(How = How.Id, Using = "inputCEP")]
        private IWebElement cep { get; set; }

        [FindsBy(How = How.Id, Using = "inputUF")]
        private IWebElement uf { get; set; }

        [FindsBy(How = How.Id, Using = "inputRg")]
        private IWebElement rg { get; set; }

        [FindsBy(How = How.Id, Using = "inputCidade")]
        private IWebElement cidade { get; set; }

        [FindsBy(How = How.Id, Using = "inputEndereco")]
        private IWebElement endereco { get; set; }

        [FindsBy(How = How.Id, Using = "inputNumeroEndereco")]
        private IWebElement numeroEndereco { get; set; }

        [FindsBy(How = How.Id, Using = "inputComplemento")]
        private IWebElement complemento { get; set; }

        [FindsBy(How = How.Id, Using = "inputBairro")]
        private IWebElement bairro { get; set; }

        [FindsBy(How = How.Id, Using = "btnSalvar")]
        private IWebElement btnSalvar { get; set; }

        [FindsBy(How = How.Id, Using = "btnBuscar")]
        private IWebElement btnBuscar { get; set; }

        [FindsBy(How = How.Id, Using = "inputFaleConosco")]
        private IWebElement faleConosco { get; set; }

        [FindsBy(How = How.Id, Using = "inputNumManifest")]
        private IWebElement numeroManif { get; set; }

        [FindsBy(How = How.Id, Using = "inputDtInicio")]
        private IWebElement dataInicio { get; set; }

        [FindsBy(How = How.Id, Using = "inputDtFim")]
        private IWebElement dataFim { get; set; }

        [FindsBy(How = How.Id, Using = "fileInput")]
        private IWebElement fileInput { get; set; }

        [FindsBy(How = How.Id, Using = "fileSubmit")]
        private IWebElement fileSubmit { get; set; }

        [FindsBy(How = How.Id, Using = "btnGridExcluir")]
        private IWebElement gridExcluir;


        public void incluirManifestacao()

        {

            var name = Faker.Name.FullName();
            var email = Faker.InternetFaker.Email();
            var telefone = Faker.Phone.Number();

            selecionarMenuManifestacao();
            incluirDadosPessoais(name,
                                  "14075299783",
                                  "234242424",
                                  email,
                                  telefone,
                                  telefone,
                                  "24412000",
                                   "2822",
                                   "ap 501",
                                   "Centro");
            faleConosco.SendKeys("teste faleConosco");
            //incluirDadosManifestacao("01010", "a","a","b");
        }


        public void salvar()
        {

            btnSalvar.Click();

        }



        public void incluirUmAnexo()

        {

            fileInput.SendKeys("C:/Users/brunobispo/Downloads/Email.pdf");
            fileSubmit.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnGridExcluir")));

        }

        public void incluirDiversosAnexos()
        {
            for (int i = 0; i < 3; i++)
            {
                fileInput.SendKeys("C:/Users/brunobispo/Downloads/Email.pdf");
                fileSubmit.Click();

            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#tableAnexoManifestacao > tbody > tr:nth-child(3)")));
        }


        public void incluirDadosPessoais(string nomeManifestante, string cpfCnpjManifestante, string rgManifestante, string emailManifestante, string telefone1, string telefone2, string cepManifestante
                                    , string numeroEnderecoManifestante, string complementoEndereco, string bairroEndereco)
        {

            var comboboxCanalAcesso = driver.FindElement(By.Id("dropCanalAcesso"));
            var selectElementCanalAcesso = new OpenQA.Selenium.Support.UI.SelectElement(comboboxCanalAcesso);
            selectElementCanalAcesso.SelectByText("Formulario Eletronico");


            var comboboxTipoDocumento = driver.FindElement(By.Id("dropTipoDocumento"));
            var selectElementTipoDocumento = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoDocumento);
            selectElementTipoDocumento.SelectByText("CPF");

            //dados pessoais 
            nome.SendKeys(nomeManifestante);
            cpfCNPJ.SendKeys(cpfCnpjManifestante);
            rg.SendKeys(rgManifestante);
            email.SendKeys(emailManifestante);
            tel1.SendKeys(telefone1);
            tel2.SendKeys(telefone2);
            cep.SendKeys(cepManifestante);
            numeroEndereco.SendKeys(numeroEnderecoManifestante);
            complemento.SendKeys(complementoEndereco);
            bairro.SendKeys(bairroEndereco);
            bairro.SendKeys(bairroEndereco);

        }

        public void incluirDadosManifestacao(string tipoManifestacao)
        {
            var comboboxManifestacao = driver.FindElement(By.Id("dropManifestacao"));
            var selectElementManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxManifestacao);
            selectElementManifestacao.SelectByText(tipoManifestacao);


        }


        public void sigiloSim()
        {
            var comboboxSigilo = driver.FindElement(By.Id("dropIndSigilo"));
            var selectElementSigilo = new OpenQA.Selenium.Support.UI.SelectElement(comboboxSigilo);
            selectElementSigilo.SelectByText("Sim");

        }

        public void incluirDadosManifestacao(string numeroProcesso, string numeroOAB, string nomeAdv, string faleConosco)
        {

            var comboboxTipoProcesso = driver.FindElement(By.Id("dropTipProc"));
            var selectElementTipoProcesso = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoProcesso);
            selectElementTipoProcesso.SelectByText("Judicial 1ª instância");


            // driver.FindElement(By.Id("inputNumProc")).SendKeys(numeroProcesso);


            //var comboboxManifestante = driver.FindElement(By.Id("dropManifestante"));
            //var selectElementManifestante = new OpenQA.Selenium.Support.UI.SelectElement(comboboxManifestante);
            //selectElementManifestante.SelectByValue("Ativo");

            //var comboboxUC = driver.FindElement(By.Id("dropUC"));
            //var selectElementUC = new OpenQA.Selenium.Support.UI.SelectElement(comboboxUC);
            //selectElementUC.SelectByText("RJ - Rio de Janeiro");

            // driver.FindElement(By.Id("inputNumAdv")).SendKeys(numeroOAB);
            // driver.FindElement(By.Id("inputNomeAdv")).SendKeys(nomeAdv);



            Thread.Sleep(1000);

        }



        public void consultarManifestacaoPorNumero(string numeroManifestacao)
        {
            selecionarMenuConsultarManifestacao();

            numeroManif.SendKeys(numeroManifestacao);
            btnBuscar.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#tableManifest > tbody > tr")));


        }


        public void consultarManifestacaoPorData(string dtInicio, string dtFim)
        {
            selecionarMenuConsultarManifestacao();

            dataInicio.SendKeys(dtInicio);
            dataFim.SendKeys(dtFim);

            btnBuscar.Click();
            Thread.Sleep(2000);

        }


        public void selecionarMenuManifestacao()
        {
            driver.FindElement(By.PartialLinkText("Manifestações")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.PartialLinkText("Incluir")).Click();

        }

        public void selecionarMenuConsultarManifestacao()
        {
            driver.FindElement(By.PartialLinkText("Manifestações")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.PartialLinkText("Consultar")).Click();

        }


    }
}

