using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Demo.PageObject
{
    public class InventoryPage
    {
        private IWebDriver driver;

        public InventoryPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }
        #region Elements
        public List<IWebElement> ProductList => driver.FindElements(By.ClassName("inventory_item_price")).ToList();

        public IWebElement BurgerControl => driver.FindElement(By.Id("react-burger-menu-btn"));

        public IWebElement ShoppingCart => driver.FindElement(By.Id("shopping_cart_container"));

        public IWebElement LogOut => driver.FindElement(By.Id("logout_sidebar_link"));

        public IWebElement Filter => driver.FindElement(By.ClassName("product_sort_container"));

        public IWebElement BackPackItem => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

        public IWebElement LabsBikeItem => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));

        public IWebElement LabsShirtItem => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));

        public IWebElement OsenShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));


        #endregion

        #region Actions
        public void Logout()
        {
            BurgerControl.Click();
            LogOut.Click();
        }

        public void ChoosCartItems()
        {
            BackPackItem.Click();
            LabsBikeItem.Click();
            LabsShirtItem.Click();
            ShoppingCart.Click();
        }

        public void ChooseOsen()
        {
            OsenShirt.Click();
            ShoppingCart.Click();
        }

        public List<string> GetProductListPrice()
        {
            List<string> prod = new List<string>();
            foreach (var item in ProductList)
            {
                prod.Add(item.Text);
            }
            return prod;
        }


        public void SelectFilter(string value)
        {
            var selectElement = new SelectElement(Filter);
            selectElement.SelectByValue(value);
        }

        #endregion

    }
}
