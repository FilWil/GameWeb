using System;
using System.Collections.Generic;
using System.Text;
using GameWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GameWeb.UnitTests
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public void Index()
        {
            //Arrange
            var controller = new HomeController();

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


    }
}
