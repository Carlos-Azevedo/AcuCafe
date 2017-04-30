namespace AcuCafe.DataModels
{
    public class Expresso : Drink, IChocolateDrink, IMilkDrink
    {
        public override double Price => 1.0;

        public bool HasChocolate { get; set; }

        public bool HasMilk { get; set; }

        public override string Description => "Expresso";

        public Expresso(bool hasSugar)
            :base (hasSugar)
        {}

        public override double Cost()
        {
            var cost = base.Cost();
            cost += HasMilk ? MilkCost : 0;
            cost += HasChocolate ? ChocolateCost : 0;
            return cost;
        }
    }
}
