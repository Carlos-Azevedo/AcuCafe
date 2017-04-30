namespace AcuCafe.DataModels
{
    public interface IMilkDrink : IDrink
    {

        /// <summary>
        /// How much it costs to add milk
        /// </summary>
        double MilkCost { get; }

        /// <summary>
        /// Defines whether this drink has milk
        /// </summary>
        bool HasMilk { get; set; }
    }
}
