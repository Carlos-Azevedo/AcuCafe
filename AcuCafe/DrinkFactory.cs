using AcuCafe.DataModels;
using System;

namespace AcuCafe
{
    public class DrinkFactory : IDrinkFactory
    {
        private IOutputter Logger;

        public DrinkFactory(IOutputter logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Creates the correct IDrink from EDrinks.
        /// Logs with <see cref="IOutputter"/> if an incomaptible topping is detected
        /// Throws an exception if <paramref name="type"/> value is not supported
        /// </summary>
        /// <param name="type">
        /// Drink type
        /// </param>
        /// <param name="hasSugar">
        /// Should drink have sugar?
        /// </param>
        /// <param name="hasMilk">
        /// Should drink have milk? Defaults to false
        /// </param>
        /// <param name="hasChocolate">
        /// Should drink have chocolate? Defaults to false
        /// </param>
        /// <returns></returns>
        public IDrink BuildDrink(EDrinks type, bool hasSugar, bool hasMilk=false, bool hasChocolate=false)
        {
            IDrink newDrink = null;
            switch(type)
            {
                case EDrinks.Expresso:
                    newDrink = new Expresso(hasSugar);
                    break;
                case EDrinks.HotTea:
                    newDrink = new HotTea(hasSugar);
                    break;
                case EDrinks.IceTea:
                    newDrink = new IceTea(hasSugar);
                    break;
                default:
                    throw new ArgumentException($"Unknown drink type: {type}");
            }

            //I tried to make it as simple as possible to add new interfaces, following the expected pattern
            if(hasChocolate)
            {
                IChocolateDrink chocoDrink = newDrink as IChocolateDrink;
                if(chocoDrink == null)
                {
                    Logger.WriteToConsole($"Drink type: {newDrink.Description} does not accept chocholate");
                }
                chocoDrink.HasChocolate = hasChocolate;
            }

            if (hasMilk)
            {
                IMilkDrink milkDrink = newDrink as IMilkDrink;
                if (milkDrink == null)
                {
                    Logger.WriteToConsole($"Drink type: {newDrink.Description} does not accept milk");
                }
                milkDrink.HasMilk = hasMilk;
            }

            return newDrink;
        }
    }
}
