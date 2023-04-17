using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace space_helper_bot.TranslateSelenium
{
    public class SeleniumTranslate
    {
        public async Task<string> GetTranslate(string inputData)
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            await Task.Delay(1000);
            var driver = new FirefoxDriver();
            await Task.Delay(3000);

            driver.Navigate().GoToUrl($"https://translate.yandex.ru/?source_lang=en&target_lang=ru&text={inputData}");
            await Task.Delay(2000);
            try
            {
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/div[2]/div/div/div[1]")).Click();
            }
            catch (Exception)
            {


            }

            await Task.Delay(3000);

            string rezult = driver.FindElement(By.XPath("//pre[@id='translation']")).Text;
            await Task.Delay(1000);

            driver.Quit();
            return rezult;

        }
    }
}
