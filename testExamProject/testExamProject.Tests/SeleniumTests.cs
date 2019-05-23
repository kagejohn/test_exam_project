using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace testExamProject.Tests
{
    class SeleniumTests
    {
        ChromeDriver driver;
        WebDriverWait wait;

        [TestMethod]
        public void TestConnectCourse()
        {
            string url = "http://localhost:51025/Home/ConnectCourseToSubject";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("CourseID")).SendKeys("2");
            driver.FindElement(By.Id("SubjectID")).SendKeys("3");
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestCreateCourse()
        {
            string url = "http://localhost:51025/Home/CreateCourse";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Name")).SendKeys("Bob");
            driver.FindElement(By.Id("Duration")).SendKeys("42");
            driver.FindElement(By.Id("AddedDate")).SendKeys("1-1-1996");
            driver.FindElement(By.Id("TeacherId")).SendKeys("5");
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestCreateSubject()
        {
            string url = "http://localhost:51025/Home/CreateSubject";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Name")).SendKeys("Benglish");
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestCreateStudent()
        {
            string url = "http://localhost:51025/Home/CreateStudent";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Name")).SendKeys("Bobbob");
            driver.FindElement(By.Id("Age")).SendKeys("23");
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestCreateTeacher()
        {
            string url = "http://localhost:51025/Home/CreateTeacher";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("Name")).SendKeys("Trevor");
            driver.FindElement(By.Id("Education")).SendKeys("Benglish");
            driver.FindElement(By.Id("Teaching")).Click();
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }

        [TestMethod]
        public void TestJoinCourse()
        {
            string url = "http://localhost:51025/Home/JoinCourse";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("StudentID")).SendKeys("14");
            driver.FindElement(By.Id("CourseID")).SendKeys("24");
            driver.FindElement(By.Id("Paid")).Click();
            driver.FindElement(By.ClassName("Button")).Click();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            driver.Close();
            driver.Dispose();
        }
    }
}
