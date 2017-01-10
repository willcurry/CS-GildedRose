using System.Collections.Generic;

namespace GildedRoseCS
{
	public class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items) 
		{
			this.Items = Items;
		}

        private bool ItemIsNotBrie(Item item)
        {
            return item.Name != "Aged Brie";
        }

        private bool ItemIsNotBackstagePass(Item item)
        {
            return item.Name != "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool ItemIsNotSulfuras(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private bool ItemIsNotRecognised(Item item)
        {
            return ItemIsNotBrie(item) && ItemIsNotBackstagePass(item) && ItemIsNotSulfuras(item);
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }

        private void IncreaseItemQuality(Item item)
        {
            if (item.Quality < 50) item.Quality++;
        }
		
		public void UpdateQuality()
		{
			foreach (Item item in Items)
			{
				if (ItemIsNotRecognised(item))
				{
                    DecreaseItemQuality(item);
				}
				else
				{
                    IncreaseItemQuality(item);
                    if (!ItemIsNotBackstagePass(item))
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
				}
				if (ItemIsNotSulfuras(item))
				{
                    DecreaseItemQuality(item);
				}
				if (item.SellIn < 0)
				{
					if (ItemIsNotBrie(item))
					{
						if (ItemIsNotBackstagePass(item))
						{
							if (item.Quality > 0)
							{
								if (ItemIsNotSulfuras(item))
								{
                                    DecreaseItemQuality(item);
								}
							}
						}
						else
						{
						    item.Quality = item.Quality - item.Quality;
						}
					}
					else
					{
                        DecreaseItemQuality(item);
					}
				}
			}
		}
    }
}
