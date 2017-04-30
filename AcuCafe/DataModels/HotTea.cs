namespace AcuCafe.DataModels
{
    public class HotTea : Drink, IMilkDrink
    {
        public override double Price => 1.0;

        public bool HasMilk {get; set;}

        public override string Description => "Hot Tea";

        public HotTea(bool hasSugar)
            :base (hasSugar)
        { }

        public override double Cost()
        {
            var cost = base.Cost();
            cost += HasMilk ? MilkCost : 0;
            return cost;
        }
    }
}
