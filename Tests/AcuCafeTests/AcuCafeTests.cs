using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AcuCafe;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    /// <summary>
    /// Tests for AcuCafe Class
    /// </summary>
    [TestClass]
    public class AcuCafeTests
    {
        MockRepository mockRepository = new MockRepository(MockBehavior.Strict);

        Mock<IDrinkFactory> mockDrinkFactory;
        Mock<IPreparer> mockPreparer;
        Mock<IOutputter> mockLogger;

        private AcuCafe.AcuCafe AcuCafe;

        public AcuCafeTests()
        {
            mockDrinkFactory = mockRepository.Create<IDrinkFactory>();
            mockPreparer = mockRepository.Create<IPreparer>();
            mockLogger = mockRepository.Create<IOutputter>();

            AcuCafe = new AcuCafe.AcuCafe(mockDrinkFactory.Object, mockPreparer.Object, mockLogger.Object);
        }

        [TestMethod]
        public void PrepareTest()
        {
            //Arrange
            var mockDrink = mockRepository.Create<IDrink>();
            mockPreparer.Setup(m => m.Prepare(mockDrink.Object));

            //Act
            AcuCafe.Prepare(mockDrink.Object);

            //Assert
            mockPreparer.Verify(m => m.Prepare(mockDrink.Object), Times.Once);  
        }

        [TestMethod]
        public void OrderDrinkTest()
        {
            //Arrange
            var mockDrink = mockRepository.Create<IDrink>();
            mockDrinkFactory.Setup(m => m.BuildDrink(EDrinks.Expresso, true, true, true)).Returns(mockDrink.Object);
            mockPreparer.Setup(m => m.Prepare(mockDrink.Object));

            //Act
            AcuCafe.OrderDrink(EDrinks.Expresso, true, true, true);

            //Assert
            mockDrinkFactory.Verify(m => m.BuildDrink(EDrinks.Expresso, true, true, true), Times.Once);
            mockPreparer.Verify(m => m.Prepare(mockDrink.Object), Times.Once);
        }

        [TestMethod]
        public void OrderDrinkExceptionTest()
        {
            //Arrange
            Exception testEx = new Exception();
            mockDrinkFactory.Setup(m => m.BuildDrink(EDrinks.Expresso, true, true, true)).Throws(testEx);
            mockLogger.Setup(m => m.LogError(testEx));

            //Act
            AcuCafe.OrderDrink(EDrinks.Expresso, true, true, true);

            //Assert
            mockDrinkFactory.Verify(m => m.BuildDrink(EDrinks.Expresso, true, true, true), Times.Once);
            mockLogger.Verify(m => m.LogError(testEx), Times.Once);
        }
    }
}
