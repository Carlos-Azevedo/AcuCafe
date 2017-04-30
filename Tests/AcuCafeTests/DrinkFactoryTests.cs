using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AcuCafe;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    /// <summary>
    /// Tests for DrinkFactory class
    /// </summary>
    [TestClass]
    public class DrinkFactoryTests
    {
        MockRepository mockRepository = new MockRepository(MockBehavior.Strict);
        Mock<IOutputter> mockLogger;
        private DrinkFactory Factory;

        public DrinkFactoryTests()
        {
            mockLogger = mockRepository.Create<IOutputter>();
            Factory = new DrinkFactory(mockLogger.Object);
        }

        [TestMethod]
        public void ExpressoTest()
        {
            //Act
            var result = Factory.BuildDrink(EDrinks.Expresso, true, true, true);

            //Assert
            Assert.IsInstanceOfType(result, typeof(Expresso));
            Assert.IsTrue(result.HasSugar);
            var milk = result as IMilkDrink;
            Assert.IsNotNull(milk);
            Assert.IsTrue(milk.HasMilk);
            var chocolate = result as IChocolateDrink;
            Assert.IsNotNull(chocolate);
            Assert.IsTrue(chocolate.HasChocolate);
        }

        [TestMethod]
        public void HotTeaTest()
        {
            //Act
            var result = Factory.BuildDrink(EDrinks.HotTea, true, true);

            //Assert
            Assert.IsInstanceOfType(result, typeof(HotTea));
            Assert.IsTrue(result.HasSugar);
            var milk = result as IMilkDrink;
            Assert.IsNotNull(milk);
            Assert.IsTrue(milk.HasMilk);
            var chocolate = result as IChocolateDrink;
            Assert.IsNull(chocolate);
        }

        [TestMethod]
        public void IceTeaTest()
        {
            //Act
            var result = Factory.BuildDrink(EDrinks.IceTea, true);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IceTea));
            Assert.IsTrue(result.HasSugar);
            var milk = result as IMilkDrink;
            Assert.IsNull(milk);
            var chocolate = result as IChocolateDrink;
            Assert.IsNull(chocolate);
        }
    }
}
