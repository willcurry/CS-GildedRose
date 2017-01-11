namespace GildedRoseCS
{
    public class ItemUpdate
    {
        private bool ItemIsBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool ItemIsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool ItemIsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool ItemIsNotRecognised(Item item)
        {
            return !ItemIsBrie(item) && !ItemIsBackstagePass(item) && !ItemIsSulfuras(item);
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }

        private void IncreaseItemQuality(Item item)
        {
            if (item.Quality < 50) item.Quality++;
        }

        public void Run(Item item)
        {
            if (ItemIsNotRecognised(item))
            {
                DecreaseItemQuality(item);
            }
            else
            {
                IncreaseItemQuality(item);
                if (ItemIsBackstagePass(item)) IncreaseBackstagePassQuality(item);
            }
            if (!ItemIsSulfuras(item))
            {
                item.SellIn--;
            }
            if (item.SellIn < 0)
            {
                ItemPastSellDate(item);
            }
        }

        private void IncreaseBackstagePassQuality(Item item)
        {
            if (item.SellIn < 11)
            {
                IncreaseItemQuality(item);
            }
            if (item.SellIn < 6)
            {
                IncreaseItemQuality(item);
            }
        }

        private void ItemPastSellDate(Item item)
        {
            if (ItemIsNotRecognised(item)) DecreaseItemQuality(item);
            else if (ItemIsBackstagePass(item)) item.Quality = item.Quality - item.Quality;
            else if (ItemIsBrie(item)) IncreaseItemQuality(item);
        }
    }
}
