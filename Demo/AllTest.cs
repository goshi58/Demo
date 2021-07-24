using Demo.PageObject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class AllTest : BaseClass
    {
        private LoginPage login;
        private InventoryPage inventory;
        private CartPage cartPage;
        private CheckOutPage checkout;
        private OverviewPage overview;


        [SetUp]
        public void Setup()
        {
            Initialize(config["browser"]);
            login = new LoginPage(driver);
        
        }

        [Test]
        /// <summary>
        /// Validate the user navigates to the products page when logged in.
        /// </summary>
        public void Valid_Login()
        {
            login.Login(config["userName"], config["password"]);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [Test]
        /// <summary>
        /// Validate error message is displayed
        /// </summary>
        public void Invalid_Login()
        {
            login.Login("WrongUser", "WrongPassword");
            Assert.IsTrue(login.ErrorMessageDisplay());
        }

        [Test]
        /// <summary>
        /// Validate the user navigates to the login page
        /// </summary>
        public void Logout()
        {
            inventory = new InventoryPage(driver);
            login.Login(config["userName"], config["password"]);
            inventory.Logout();
            Assert.AreEqual("https://www.saucedemo.com/", driver.Url);
        }

        [Test]
        /// <summary>
        /// Validate the products have been sorted by price correctly
        /// </summary>
        public void ProductByPrice()
        {
            inventory = new InventoryPage(driver);
            login.Login(config["userName"], config["password"]);
            inventory.SelectFilter(config["filter"]);
            List<string> filterList = inventory.GetProductListPrice();
            var firstProduct = filterList.FirstOrDefault();
            var lastProduct = filterList.LastOrDefault();
            Assert.AreEqual("$7.99" , firstProduct);
            Assert.AreEqual("$49.99", lastProduct);
        }


        [Test]
        /// <summary>
        ///  Validate all the items that have been added to the shopping cart.
        /// </summary>
        public void MultipleItems()
        {
            inventory = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            login.Login(config["userName"], config["password"]);
            inventory.ChoosCartItems();
            List<string> cartList = cartPage.GetCartList();
            Assert.Contains(config["item1"], cartList);
            Assert.Contains(config["item2"], cartList);
            Assert.Contains(config["item3"], cartList);
        }

        [Test]
        /// <summary>
        ///  Validate the correct product was added to the cart.
        /// </summary>
        public void ChooseOneItem()
        {
            inventory = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            login.Login(config["userName"], config["password"]);
            inventory.ChooseOsen();
            List<string> cartList = cartPage.GetCartList();
            Assert.Contains(config["item4"], cartList);
        }

        [Test]
        /// <summary>
        ///  Validate the user navigates to the order confirmation page.
        /// </summary>
        public void CompletePurchase()
        {
            inventory = new InventoryPage(driver);
            cartPage = new CartPage(driver);
            checkout = new CheckOutPage(driver);
            overview = new OverviewPage(driver);

            login.Login(config["userName"], config["password"]);
            inventory.ChoosCartItems();
            cartPage.Checkout_Cart();
            checkout.FillCheckoutInformation(config["firstName"], config["lastName"], config["zip"]);
            overview.FinishOverview();
            Assert.AreEqual("https://www.saucedemo.com/checkout-complete.html", driver.Url);            
        }


        [TearDown]
        public void Exit()
        {
            Quit();
        }
    }
}
