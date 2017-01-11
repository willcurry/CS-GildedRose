namespace GildedRoseCS
{
    public class SulfarusUpdateType : UpdateType
    {
        public void Apply(Item item)
        {

        }

        public bool CanApplyTo(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
