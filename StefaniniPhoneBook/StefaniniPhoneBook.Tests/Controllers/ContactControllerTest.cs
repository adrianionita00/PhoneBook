using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StefaniniPhoneBook;
using StefaniniPhoneBook.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace StefaniniPhoneBook.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void ViewContacts()
        {
            ContactController controller =
                new ContactController();

            ViewResult result = controller.Index("","") as ViewResult;

            Assert.IsNotNull(result);

        }
    }
}
