using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcuCafe.DataModels;

namespace AcuCafeTests
{
    /// <summary>
    /// Tests for IceTea class
    /// </summary>
    [TestClass]
    public class IceTeaTests
    {
        [TestMethod]
        public void IceTeaWithToppingsCostTest()
        {
            //Arrange
            var iceTea = new IceTea(true);

            //Act
            var cost = iceTea.Cost();

            //Assert
            Assert.AreEqual(2.0, cost, nameof(iceTea.Cost));
        }

        [TestMethod]
        public void IceTeaNoToppingsCostTest()
        {
            //Arrange
            var iceTea = new IceTea(false);

            //Act
            var cost = iceTea.Cost();

            //Assert
            Assert.AreEqual(1.5, cost, nameof(iceTea.Cost));
        }
    }
}
