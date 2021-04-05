using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        }


        public void incluirManifestacao()

        {

            selecionarMenuManifestacao();
            incluirDadosPessoais("Bruno selenium", "14075299783", "teste @selenium.com","2127200745","2127200745","24412000",
                                        "RJ", "São Gonçalo", "Rua x", "2822", "ap 501", "Centro");
            incluirDadosManifestacao("01010", "a","a","b");


        }


        public void incluirDadosPessoais(string nome, string cpfCnpj, string email, string telefone1, string telefone2, string cep, string UF,
                                        string cidade, string endereco, string numeroEndereco, string complemento, string bairro)
        {
            //dados pessoais 


            var comboboxManifestacao = driver.FindElement(By.Id("dropManifacao"));
            var selectElementManifestacao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxManifestacao);
            selectElementManifestacao.SelectByText("1 - Duvidas");


            driver.FindElement(By.Id("inputNome")).SendKeys(nome);

            Thread.Sleep(3000);

            var comboboxCanalAcesso = driver.FindElement(By.Id("dropCanalAcesso"));
            var selectElementCanalAcesso = new OpenQA.Selenium.Support.UI.SelectElement(comboboxCanalAcesso);
            selectElementCanalAcesso.SelectByText("1 - Formulario Eletronico");


            var comboboxTipoDocumento = driver.FindElement(By.Id("dropTipoDocumento"));
            var selectElementTipoDocumento = new OpenQA.Selenium.Support.UI.SelectElement(comboboxTipoDocumento);
            selectElementTipoDocumento.SelectByText("CPF");

            driver.FindElement(By.Id("inputCpfCnpj")).SendKeys(cpfCnpj);

            driver.FindElement(By.Id("inputEmail")).SendKeys(email);

            driver.FindElement(By.Id("inputTelefone_1")).SendKeys(telefone1);
            driver.FindElement(By.Id("inputTelefone_2")).SendKeys(telefone2);
            driver.FindElement(By.Id("inputCEP")).SendKeys(cep);
            driver.FindElement(By.Id("inputUF")).SendKeys(UF);
            driver.FindElement(By.Id("inputCidade")).SendKeys(cidade);
            driver.FindElement(By.Id("inputEndereco")).SendKeys(endereco);
            driver.FindElement(By.Id("inputNumeroEndereco")).SendKeys(numeroEndereco);
            driver.FindElement(By.Id("inputComplemento")).SendKeys(complemento);
            driver.FindElement(By.Id("inputBairro")).SendKeys(bairro);

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
                driver.FindElement(By.Id("inputFaleConosco")).SendKeys(faleConosco);

            
                driver.FindElement(By.Id("btnSalvar")).Click();


                Thread.Sleep(1000);

            }

            
         
            
            




      
        public void alterarManifestacao(string descricao)
        {
            selecionarMenuManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoAreaManif']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridEdit")).Click();
            driver.FindElement(By.Id("inputDescr")).Clear();
            driver.FindElement(By.Id("inputDescr")).SendKeys(descricao);

            driver.FindElement(By.Id("btnAlterar")).Click();

            Thread.Sleep(1000);



        }

        public void excluirManifestacao()
        {
            selecionarMenuManifestacao();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='tableTipoAreaManif']/thead/tr/th[1]")).Click();
            driver.FindElement(By.Id("btnGridDelete")).Click();
            Thread.Sleep(1000);
          
            driver.FindElement(By.Id("btnConfirmar")).Click();
            Thread.Sleep(1000);



        }

        public void consultarManifestacaoPorNumero(string numeroManifestacao)
        {
            selecionarMenuManifestacao();

            driver.FindElement(By.Id("inputNumManifest")).SendKeys(numeroManifestacao);



            driver.FindElement(By.Id("btnBuscar")).Click();
            Thread.Sleep(1000);

        }


        public void consultarManifestacaoPorData(string dataInicio,string dataFim)
        {
            selecionarMenuManifestacao();

            driver.FindElement(By.Id("inputDtInicio")).SendKeys(dataInicio);

            driver.FindElement(By.Id("inputDtFim")).SendKeys(dataFim);



            driver.FindElement(By.Id("btnBuscar")).Click();
            Thread.Sleep(9000);

        }


        public void selecionarMenuManifestacao()
        {
            driver.FindElement(By.PartialLinkText("Manifestações")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.PartialLinkText("Consultar")).Click();

        }


    }
}

