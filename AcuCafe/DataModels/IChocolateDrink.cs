namespace AcuCafe.DataModels
{
    public interface IChocolateDrink : IDrink
    {

        /// <summary>
        /// How much it costs to add chocolate
        /// </summary>
        double ChocolateCost { get; }

        /// <summary>
        /// Defines whether this drink has chocolate
        /// </summary>
        bool HasChocolate { get; set; }
    }
}
