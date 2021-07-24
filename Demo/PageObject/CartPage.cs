using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;



namespace Demo.PageObject
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver _driver)
        {
            this.driver = _driver;

        }
        #region Elements
        public List<IWebElement> CartList => driver.FindElements(By.ClassName("inventory_item_name")).ToList();
        public IWebElement Checkout => driver.FindElement(By.Id("checkout"));





        #endregion

        #region Actions

        public List<string> GetCartList()
        {
            List<string> cartList = new List<string>();
            foreach (var item in CartList)
            {
                cartList.Add(item.Text);
            }
            return cartList;
        }


        public void Checkout_Cart()
        {
            Checkout.Click();
        }


        #endregion

    }
}
