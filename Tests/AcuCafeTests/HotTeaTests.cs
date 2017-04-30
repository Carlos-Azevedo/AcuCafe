using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    /// <summary>
    /// Tests for HotTea class
    /// </summary>
    [TestClass]
    public class HotTeaTest
    {
        [TestMethod]
        public void HotTeaWithToppingsCostTest()
        {
            //Arrange
            var hotTea = new HotTea(true);
            hotTea.HasMilk = true;

            //Act
            var cost = hotTea.Cost();

            //Assert
            Assert.AreEqual(2.0, cost, nameof(hotTea.Cost));
        }

        [TestMethod]
        public void IceTeaNoToppingsCostTest()
        {
            //Arrange
            var hotTea = new HotTea(false);

            //Act
            var cost = hotTea.Cost();

            //Assert
            Assert.AreEqual(1.0, cost, nameof(hotTea.Cost));
        }
    }
}
