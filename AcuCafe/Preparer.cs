using AcuCafe.DataModels;

namespace AcuCafe
{
    /// <summary>
    /// Responsible for converting IDrink objects into readable strings
    /// </summary>
    public class Preparer : IPreparer
    {
        private IOutputter Outputter;

        public Preparer(IOutputter outputter)
        {
            Outputter = outputter;
        }

        /// <summary>
        /// Check <paramref name="drink"/> for possible interfaces and take their values for the toppings
        /// Uses <see cref="IOutputter"/> to write to console
        /// </summary>
        /// <param name="drink">
        /// Drink being read for prepare
        /// </param>
        public void Prepare(IDrink drink)
        {
            string message = $"We are preparing the following drink for you: {drink.Description}";

            var milk = drink as IMilkDrink;
            if (milk == null || !milk.HasMilk)
                message += " without milk";
            else
                message += " with milk";

            if (drink.HasSugar)
                message += " with sugar";
            else
                message += " without sugar";

            var chocolate = drink as IChocolateDrink;
            if (chocolate == null || !chocolate.HasChocolate)
                message += " without chocolate";
            else
                message += " with chocolate";

            Outputter.WriteToConsole(message);
        }        
    }
}
