using AcuCafe.DataModels;
using System;

namespace AcuCafe
{
    /// <summary>
    /// This class has barely any logic in it, outsourcing that to other classes and calling their methods as required.
    /// Input parameters are more easily linked via Injector packages such as Ninject
    /// </summary>
    public class AcuCafe
    {
        private IDrinkFactory DrinkFactory;
        private IPreparer Preparer;
        private IOutputter Logger;

        /// <summary>
        /// Constructor. Any service required by class is passed in to avoid dependencies
        /// </summary>
        /// <param name="drinkFactory">
        /// Factory which processes the drink's parameters
        /// </param>
        /// <param name="preparer">
        /// Responsible for processing the drink
        /// </param>
        /// <param name="logger">
        /// Responsible for IO
        /// </param>
        public AcuCafe(IDrinkFactory drinkFactory, IPreparer preparer, IOutputter logger)
        {
            DrinkFactory = drinkFactory;
            Preparer = preparer;
            Logger = logger;
        }

        /// <summary>
        /// OrderDrink functions by calling other classes' methods to create an
        /// IDrink object and process it.
        /// </summary>
        /// <param name="type">
        /// Type of the drink to be created
        /// </param>
        /// <param name="hasSugar">
        /// Does the drink have sugar?
        /// </param>
        /// <param name="hasMilk">
        /// Does the drink have Milk? Defaults to false
        /// </param>
        /// <param name="hasChocolate">
        /// Does the drink have Chocolate? Defaults to false
        /// </param>
        /// <returns>
        /// The Drink created, null if an error occurs
        /// </returns>
        public IDrink OrderDrink(EDrinks type, bool hasSugar, bool hasMilk = false, bool hasChocolate = false)
        {
            try
            {
                IDrink drink = DrinkFactory.BuildDrink(type, hasMilk, hasSugar, hasChocolate);
                Prepare(drink);
                return drink;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        /// <summary>
        /// Calls method to write out drink to console
        /// </summary>
        /// <param name="drink">
        /// Drink to be written out
        /// </param>
        public void Prepare(IDrink drink)
        {
            Preparer.Prepare(drink);            
        }
    }
}