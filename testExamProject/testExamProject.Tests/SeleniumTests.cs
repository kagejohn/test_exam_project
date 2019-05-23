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

        [TestMethod]
        public void TestConnectCourse()
        {
            string url = "http://localhost:51025/Home/ConnectCourseToSubject";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestCreateCourse()
        {
            string url = "http://localhost:51025/Home/CreateCourse";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestCreateSubject()
        {
            string url = "http://localhost:51025/Home/CreateSubject";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestCreateStudent()
        {
            string url = "http://localhost:51025/Home/CreateStudent";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestCreateTeacher()
        {
            string url = "http://localhost:51025/Home/CreateTeacher";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestJoinCourse()
        {
            string url = "http://localhost:51025/Home/JoinCourse";
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
    }
}
