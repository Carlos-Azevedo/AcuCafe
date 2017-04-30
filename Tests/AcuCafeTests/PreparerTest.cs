using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AcuCafe;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    /// <summary>
    /// Tests for OutPutter class
    /// </summary>
    [TestClass]
    public class PreparerTest
    {
        MockRepository mockRepository = new MockRepository(MockBehavior.Strict);
        
        Mock<IOutputter> mockLogger;

        private Preparer Preparer;

        public PreparerTest()
        {
            mockLogger = mockRepository.Create<IOutputter>();
            Preparer = new Preparer(mockLogger.Object);
        }

        /// <summary>
        /// Test for Prepare call with all toppings
        /// </summary>
        [TestMethod]
        public void TestAllToppings()
        {
            //Arrange
            string test = "test";
            string prepareString = $"We are preparing the following drink for you: {test} with milk with sugar with chocolate";

            var mockDrink = mockRepository.Create<IDrink>();
            mockDrink.SetupGet(m => m.HasSugar).Returns(true);
            mockDrink.SetupGet(m => m.Description).Returns(test);

            var mockMilk = mockDrink.As<IMilkDrink>();
            mockMilk.SetupGet(m => m.HasMilk).Returns(true);

            var mockChoco = mockMilk.As<IChocolateDrink>();
            mockChoco.SetupGet(m => m.HasChocolate).Returns(true);

            mockLogger.Setup(m => m.WriteToConsole(prepareString));

            //Act
            Preparer.Prepare(mockChoco.Object);

            //Assert
            mockLogger.Verify(m => m.WriteToConsole(prepareString), Times.Once);
        }

        /// <summary>
        /// Test for Prepare call with chocolate topping
        /// </summary>
        [TestMethod]
        public void TestChocoToppings()
        {
            //Arrange
            string test = "test";
            string prepareString = $"We are preparing the following drink for you: {test} without milk without sugar with chocolate";

            var mockDrink = mockRepository.Create<IDrink>();
            mockDrink.SetupGet(m => m.HasSugar).Returns(false);
            mockDrink.SetupGet(m => m.Description).Returns(test);
            
            var mockChoco = mockDrink.As<IChocolateDrink>();
            mockChoco.SetupGet(m => m.HasChocolate).Returns(true);

            mockLogger.Setup(m => m.WriteToConsole(prepareString));

            //Act
            Preparer.Prepare(mockChoco.Object);

            //Assert
            mockLogger.Verify(m => m.WriteToConsole(prepareString), Times.Once);
        }

        /// <summary>
        /// Test for Prepare call with milk
        /// </summary>
        [TestMethod]
        public void TestMilkToppings()
        {
            //Arrange
            string test = "test";
            string prepareString = $"We are preparing the following drink for you: {test} with milk without sugar without chocolate";

            var mockDrink = mockRepository.Create<IDrink>();
            mockDrink.SetupGet(m => m.HasSugar).Returns(false);
            mockDrink.SetupGet(m => m.Description).Returns(test);

            var mockMilk = mockDrink.As<IMilkDrink>();
            mockMilk.SetupGet(m => m.HasMilk).Returns(true);
            
            mockLogger.Setup(m => m.WriteToConsole(prepareString));

            //Act
            Preparer.Prepare(mockMilk.Object);

            //Assert
            mockLogger.Verify(m => m.WriteToConsole(prepareString), Times.Once);
        }


        /// <summary>
        /// Test for Prepare call with no toppings
        /// </summary>
        [TestMethod]
        public void TesNoToppings()
        {
            //Arrange
            string test = "test";
            string prepareString = $"We are preparing the following drink for you: {test} without milk without sugar without chocolate";

            var mockDrink = mockRepository.Create<IDrink>();
            mockDrink.SetupGet(m => m.HasSugar).Returns(false);
            mockDrink.SetupGet(m => m.Description).Returns(test);
            

            mockLogger.Setup(m => m.WriteToConsole(prepareString));

            //Act
            Preparer.Prepare(mockDrink.Object);

            //Assert
            mockLogger.Verify(m => m.WriteToConsole(prepareString), Times.Once);
        }
    }
}
