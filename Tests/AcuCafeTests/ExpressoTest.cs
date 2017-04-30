using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    [TestClass]
    public class ExpressoTest
    {
        [TestMethod]
        public void ExpressoWithToppingsCostTest()
        {
            //Arrange
            var expresso = new Expresso(true);
            expresso.HasChocolate = true;
            expresso.HasMilk = true;

            //Act
            var cost = expresso.Cost();

            //Assert
            Assert.AreEqual(2.5, cost, nameof(expresso.Cost));
        }

        [TestMethod]
        public void ExpressoNoToppingsCostTest()
        {
            //Arrange
            var expresso = new Expresso(false);
            expresso.HasChocolate = false;
            expresso.HasMilk = false;

            //Act
            var cost = expresso.Cost();

            //Assert
            Assert.AreEqual(1.0, cost, nameof(expresso.Cost));
        }
    }
}
