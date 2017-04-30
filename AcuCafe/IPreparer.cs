using AcuCafe.DataModels;

namespace AcuCafe
{
    /// <summary>
    /// Interface to process a drink.
    /// </summary>
    public interface IPreparer
    {
        /// <summary>
        /// Drink is processed and written to console
        /// </summary>
        /// <param name="drink">
        /// Drink to be processed
        /// </param>
        void Prepare(IDrink drink);
    }
}
