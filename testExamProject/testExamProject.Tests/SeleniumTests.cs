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
    [TestClass]
    class SeleniumTests
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [TestMethod]
        public void TestConnectCourse()
        {
            string url = "http://localhost:51025/Home/ConnectCourseToSubject";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("CourseID")).SendKeys("2");
            _driver.FindElement(By.Id("SubjectID")).SendKeys("3");
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }

        [TestMethod]
        public void TestCreateCourse()
        {
            string url = "http://localhost:51025/Home/CreateCourse";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("Name")).SendKeys("Bob");
            _driver.FindElement(By.Id("Duration")).SendKeys("42");
            _driver.FindElement(By.Id("AddedDate")).SendKeys("1-1-1996");
            _driver.FindElement(By.Id("TeacherId")).SendKeys("5");
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }

        [TestMethod]
        public void TestCreateSubject()
        {
            string url = "http://localhost:51025/Home/CreateSubject";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("Name")).SendKeys("Benglish");
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }

        [TestMethod]
        public void TestCreateStudent()
        {
            string url = "http://localhost:51025/Home/CreateStudent";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("Name")).SendKeys("Bobbob");
            _driver.FindElement(By.Id("Age")).SendKeys("23");
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }

        [TestMethod]
        public void TestCreateTeacher()
        {
            string url = "http://localhost:51025/Home/CreateTeacher";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("Name")).SendKeys("Trevor");
            _driver.FindElement(By.Id("Education")).SendKeys("Benglish");
            _driver.FindElement(By.Id("Teaching")).Click();
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }

        [TestMethod]
        public void TestJoinCourse()
        {
            string url = "http://localhost:51025/Home/JoinCourse";
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("StudentID")).SendKeys("14");
            _driver.FindElement(By.Id("CourseID")).SendKeys("24");
            _driver.FindElement(By.Id("Paid")).Click();
            _driver.FindElement(By.ClassName("Button")).Click();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            _wait.Until(wt => wt.FindElement(By.Id("Success:")).Equals("True"));
            _driver.Close();
            _driver.Dispose();
        }
    }
}
