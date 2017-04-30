using AcuCafe.DataModels;

namespace AcuCafe
{
    /// <summary>
    /// Interface for a factory resposible for creating drinks
    /// </summary>
    public interface IDrinkFactory
    {
        IDrink BuildDrink(EDrinks type, bool hasSugar, bool hasMilk=false, bool hasChocolate = false);
    }
}
