namespace AcuCafe.DataModels
{
    /// <summary>
    /// Public Interface for a Drink
    /// </summary>
    public interface IDrink
    {
        /// <summary>
        /// Base price for this drink
        /// </summary>
        double Price { get; }
        
        /// <summary>
        /// Added cost for sugar
        /// </summary>
        double SugarCost { get; }

        //Defines whether this drink has sugar
        bool HasSugar { get; }
        
        /// <summary>
        /// Description for this drink
        /// </summary>
        string Description { get; }

        /// <summary>
        /// How much this drink costs, takes into account if it has other ingredients
        /// </summary>
        /// <returns>
        /// Price for this drink.
        /// </returns>
        double Cost();

    }
}
