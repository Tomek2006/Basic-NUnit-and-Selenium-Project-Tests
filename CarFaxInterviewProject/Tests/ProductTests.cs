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
    public class ProductTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProductsPage productsPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);

            // Login Before
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        [Category("Product")]
        public void AddToCart_ShouldUpdateCartBadge()
        {
            // Arrange 
            int initialCartCount = productsPage.GetCartItemCount();

            // Act
            productsPage.AddFirstProductToCart();

            // Assert 
            Assert.AreEqual(initialCartCount + 1, productsPage.GetCartItemCount(), "Cart item count should increase by 1");
        }

        [Test]
        [Category("Product")]

        public void RemoveFromCart_ShouldUpdateCartBadge()
        {
            // Arrange
            productsPage.AddFirstProductToCart();
            int cartCountAfterFirstAdd = productsPage.GetCartItemCount();

            // Act
            productsPage.RemoveFirstProductFromCart();

            // Assert
            Assert.AreEqual(cartCountAfterFirstAdd - 1, productsPage.GetCartItemCount(), "Cart item count should decrease by 1");
        }


        [Test]
        [Category("Product")]
        public void AddToCart_ShouldShowRemoveButton()
        {
            // Arrange
            bool removeButtonVisibleBefore = productsPage.IsRemoveButtonDisplayed();

            // Act
            productsPage.AddFirstProductToCart();

            // Assert
            Assert.IsFalse(removeButtonVisibleBefore, "Remove button should not be visible before adding item");
            Assert.IsTrue(productsPage.IsRemoveButtonDisplayed(), "Remove button should appear after adding item to cart");
        }


        [TearDown]

        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
