using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;
using System.Threading;

namespace ESOU.Base
{
    class TestBase
    {

        public string screenshotsPasta;

        public IWebDriver driver;
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static FileInfo fileInfo = new FileInfo(dir);
        public static DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
        public static string parentDirName = currentDir.FullName;
        public ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(parentDirName + "./tests.html");
        public ExtentReports extent = new ExtentReports();



        public IWebDriver GetDriver()
        {
            return driver;

        }


        public void Inicializar(WebBrowser browserType)
        {
            String url = "https://wwwh3.tjrj.jus.br/hsegweb/faces/login.jsp";
            switch (browserType)
            {
                case WebBrowser.Firefox:
                    //driver = new FirefoxDriver();
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments("headless");
                    options.AddArguments("disable-gpu");
                    options.AddArguments("window-size=1920,1080");
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);



                    break;
                case WebBrowser.Chrome:
                    //driver = new ChromeDriver();
                    ChromeOptions chromeOptions = new ChromeOptions();
                    // chromeOptions.AddArguments("headless");
                    //chromeOptions.AddArguments("disable-gpu");
                    // chromeOptions.AddArguments("window-size=1920,1080");
                    driver = new ChromeDriver(chromeOptions);
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();

                    break;
                case WebBrowser.IE:

                    driver = new InternetExplorerDriver();
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Window.Maximize();

                    break;
                default:
                    break;

            }


        }




        public enum WebBrowser
        {
            IE,
            Firefox,
            Chrome

        }


        public void Logar(string usuario, string senha)
        {
            driver.FindElement(By.Id("txtLogin")).SendKeys(usuario);
            driver.FindElement(By.Id("txtSenha")).SendKeys(senha);
            driver.FindElement(By.Id("btnEnviar")).Click();


            var comboboxSistema = driver.FindElement(By.Id("cmbSistemas"));
            var selectElementSistema = new OpenQA.Selenium.Support.UI.SelectElement(comboboxSistema);
            selectElementSistema.SelectByText("SISTEMA ELETRÔNICO DA OUVIDORIA");

            Thread.Sleep(1000);

            var comboboxOrgao = driver.FindElement(By.Id("cmbOrgaos"));
            var selectElementOrgao = new OpenQA.Selenium.Support.UI.SelectElement(comboboxOrgao);
            selectElementOrgao.SelectByText("OUVID OUVIDORIA GERAL DO PODER JUDICIARIO");

        }




        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }


    }


}



