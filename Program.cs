using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Vjezba5
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.anticorrupiks.com/registarZaposlenih";
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(url);
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath(".//select[@id='select']")));
            selectElement.SelectByText("100");
            Thread.Sleep(1000);
            List<Employee> data = new List<Employee>();
            int counter = 0;
            while (true)
            {
                
                List<IWebElement> tableRows = driver.FindElements(By.XPath(".//tbody/tr")).ToList();
                foreach (var row in tableRows)
                {
                    Employee employee = new Employee()
                    {
                        FirstName = row.FindElement(By.XPath(".//td[1]")).Text,
                        LastName = row.FindElement(By.XPath(".//td[2]")).Text,
                        CompanyName = row.FindElement(By.XPath(".//td[4]")).Text,
                        CompanyLocation = row.FindElement(By.XPath(".//td[5]")).Text,
                        JobName = row.FindElement(By.XPath(".//td[6]")).Text,
                        Qualification = row.FindElement(By.XPath(".//td[7]")).Text,
                        PersonQualification = row.FindElement(By.XPath(".//td[8]")).Text,
                        PersonProfession = row.FindElement(By.XPath(".//td[9]")).Text,
                        JobStartDate = row.FindElement(By.XPath(".//td[10]")).Text,
                        JobEndDate = row.FindElement(By.XPath(".//td[11]")).Text,
                        JobPeriodDate = row.FindElement(By.XPath(".//td[12]")).Text,
                        BasicSalary = row.FindElement(By.XPath(".//td[13]")).Text,

                    };
                    data.Add(employee);
                }
                
                IWebElement nextPageButton = driver.FindElement(By.XPath(".//a[@aria-label='Sljedeća page']"));
                if (counter == 2)
                {
                    break;
                }
                nextPageButton.Click();
                Thread.Sleep(1000);
                counter++;
            }

            StreamWriter sw = new StreamWriter(@"E:\scraping\publicEmployees.csv", true);

            for (int i = 0; i < data.Count; i++)
            {
                //for (int j = 0; j < data[i].Count; j++)
                //{
                //    sw.Write(data[i][j]);
                //}
                //sw.Flush();
            }
            sw.Close();
        }
    }
}
