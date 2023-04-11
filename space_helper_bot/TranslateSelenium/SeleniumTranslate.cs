﻿using OpenQA.Selenium.Firefox;
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

            driver.Navigate().GoToUrl($"https://translate.google.com/?hl=ru&sl=en&tl=ru&text={inputData}&op=translate");
            await Task.Delay(2000);
            string rezult = driver.FindElement(By.XPath("//div[@class='lRu31']")).Text;
            driver.Quit();
            return rezult;

        }
    }
}
