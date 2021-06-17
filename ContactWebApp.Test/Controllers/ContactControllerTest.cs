using ContactWebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactWebApp.Test.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void CheckEmail_WhenEmailNotModified_ShouldReturnTrue()
        {
            // Arrange
            var controller = new ContactController();
            string email = "Test@gmail.com";

            // Act
            var emailExist = controller.CheckEmail(email, email);

            // Assert
            Assert.IsTrue(emailExist);
        }
    }
}
