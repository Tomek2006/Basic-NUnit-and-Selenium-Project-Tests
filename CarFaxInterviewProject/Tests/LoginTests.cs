using CarFaxInterviewProject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFaxInterviewProject.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage productsPage;


        [SetUp]
        public void SetUp()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Navigate
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Initialize page objects
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
        }

        [Test]
        [Category("Login")]
        public void Login_WithValidCreditials_ShouldSucceed()
        {
            // Arrange
            string username = "standard_user";
            string password = "secret_sauce";

            // Act
            loginPage.Login(username, password);

            // Assert
            Assert.IsTrue(productsPage.IsOnProductPage(), "Should be on products page after valid login.");
            Assert.AreEqual("Products", productsPage.GetPageTitle(), "Page title should be 'Products'.");
        }


        [Test]
        [Category("Login")]
        public void Login_WithInvalidUsername_ShouldShowError()
        {
            // Arrange
            string username = "invalid_user";
            string password = "secret_sauce";

            // Act
            loginPage.Login(username, password);

            // Assert
            Assert.IsTrue(loginPage.IsErrorDisplayed(), "Error message should be displayed");
        }


        [Test]
        [Category("Login")]
        public void Login_WithEmptyCredentials_ShouldShowError()
        {
            // Act
            loginPage.ClickLoginButton();

            // Assert
            Assert.IsTrue(loginPage.IsErrorDisplayed(), "Error should show for empty credentials");
        }

        [TearDown]
        public void TearDown()
        {
            
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
