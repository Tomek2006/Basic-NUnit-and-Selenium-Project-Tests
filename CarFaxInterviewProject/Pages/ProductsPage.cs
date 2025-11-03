using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFaxInterviewProject.Pages
{
    public class ProductsPage
    {
        private readonly IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Elements
        private IWebElement PageTitle => driver.FindElement(By.ClassName("title"));

        private IWebElement CartBadge
        {
            get
            {
                try
                {
                    return driver.FindElement(By.ClassName("shopping_cart_badge"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        private IWebElement FirstAddToCartButton => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement FirstRemoveItemButton => driver.FindElement(By.Id("remove-sauce-labs-backpack"));

        // Verification methods

        public bool IsRemoveButtonDisplayed()
        {
            try
            {
                return FirstRemoveItemButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsOnProductPage()
        {
            return driver.Url.Contains("inventory.html");
        }
        public string GetPageTitle()
        {
            return PageTitle.Text;
        }

        public int GetCartItemCount()
        {
            if (CartBadge == null)
                return 0;

            return int.Parse(CartBadge.Text);
        }

        // Action
        public void AddFirstProductToCart()
        {
            FirstAddToCartButton.Click();
        }

        public void RemoveFirstProductFromCart()
        {
            FirstRemoveItemButton.Click();
        }
    }
}
