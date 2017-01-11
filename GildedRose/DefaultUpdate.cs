namespace GildedRoseCS
{
    public class DefaultUpdate : UpdateType
    {
        public void Apply(Item item)
        {
            item.SellIn--;
            DecreaseItemQuality(item);
            if (item.SellIn <= 0) DecreaseItemQuality(item);
        }

        public bool CanApplyTo(Item item)
        {
            return item.Name != "Aged Brie" && item.Name != "Sulfuras, Hand of Ragnaros" && item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }
    }
}
