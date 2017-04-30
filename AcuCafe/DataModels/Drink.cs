namespace AcuCafe.DataModels
{
    /// <summary>
    /// An abstract class to store core common features of all Drink types
    /// </summary>
    public abstract class Drink : IDrink
    {        
        public virtual double Price => 0;

        public double SugarCost => 0.5;

        //Since all drinks share the extra ingredient's cost,
        //it is simpler to declare it here at the root of Drink types.
        public double MilkCost => 0.5;
        public double ChocolateCost => 0.5;

        public virtual bool HasSugar { get;}

        public virtual string Description { get; }

        public Drink( bool hasSugar)
        {
            HasSugar = hasSugar;
        }

        //I considered moving this out of the IDrink interface, but wasn't sure if it was required to be in Drink.
        public virtual double Cost()
        {
            var cost = Price;
            cost += HasSugar ? SugarCost : 0;
            return cost;
        }
    }
}
