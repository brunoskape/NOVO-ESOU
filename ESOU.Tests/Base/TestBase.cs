using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;


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
            switch (browserType)
            {
                case WebBrowser.Firefox:
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl("cc");
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //FirefoxOptions options = new FirefoxOptions();
                   // options.AddArguments("headless");
                    break;
                case WebBrowser.Chrome:
                    //driver = new ChromeDriver();
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArguments("headless");
                    //chromeOptions.AddArguments("disable-gpu");
                    driver = new ChromeDriver(chromeOptions);
                    driver.Navigate().GoToUrl("https://wwwh3.tjrj.jus.br/hsegweb/faces/login.jsp");
                    driver.Manage().Window.Maximize();

                    break;
                case WebBrowser.IE:

                    driver = new InternetExplorerDriver();
                    driver.Navigate().GoToUrl("https://wwwh3.tjrj.jus.br/hsegweb/faces/login.jsp");
                    driver.Manage().Window.Maximize();
                    //FirefoxOptions options = new FirefoxOptions();
                    //options.AddArguments("--headless");
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
           





        }
                    
          
        

        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }
        //public void capturaImagem()
        //{
        //    Screenshot(driver, screenshotsPasta + TestContext.CurrentContext.Test.Name + ".png");
        //    Thread.Sleep(500);
        //}

       

    }

}



