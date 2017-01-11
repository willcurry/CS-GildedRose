namespace GildedRoseCS
{
    public class AgedBrieUpdate : UpdateType
    {
        public void Apply(Item item)
        {
            item.SellIn--;
            item.Quality++;
        }

        public bool CanApplyTo(Item item)
        {
            return item.Name == "Aged Brie";
        }
    }
}
