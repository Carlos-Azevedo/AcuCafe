namespace AcuCafe.DataModels
{
    public class IceTea : Drink
    {
        public override double Price => 1.5;

        public override string Description => "Ice tea";

        public IceTea(bool hasSugar)
            :base (hasSugar)
        {}
    }
}
