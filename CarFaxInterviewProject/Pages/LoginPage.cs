using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFaxInterviewProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Elements
        private IWebElement UsernameField => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        // Error 
        private IWebElement ErrorMessage
        {
            get
            {
                try
                {
                    return driver.FindElement(By.CssSelector("[data-test='error']"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        // Methods 
        public void EnterUsername(string username)
        {
            UsernameField.Clear();
            UsernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        // Verification methods
        public bool IsErrorDisplayed()
        {
            return ErrorMessage != null && ErrorMessage.Displayed;
        }

        public string GetErrorMessageText()
        {
            return ErrorMessage?.Text ?? string.Empty;
        }
    }
}
