using System;

namespace GildedRoseCS
{
    public class BackstagePassUpdate : UpdateType
    {
        public void Apply(Item item)
        {
            item.SellIn--;
            if (item.SellIn < 11) item.Quality++;
            if (item.SellIn < 6) item.Quality++;
            if (item.SellIn <= 0) item.Quality = 0;
        }

        public bool CanApplyTo(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}
