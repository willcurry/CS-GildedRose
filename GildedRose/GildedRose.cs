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
		
		public void UpdateQuality()
		{
			foreach (Item item in Items)
			{
				if (ItemIsNotBrie(item) && ItemIsNotBackstagePass(item))
				{
					if (item.Quality > 0)
					{
						if (item.Name != "Sulfuras, Hand of Ragnaros")
						{
							item.Quality = item.Quality - 1;
						}
					}
				}
				else
				{
					if (item.Quality < 50)
					{
						item.Quality = item.Quality + 1;
						
						if (!ItemIsNotBackstagePass(item))
						{
							if (item.SellIn < 11)
							{
								if (item.Quality < 50)
								{
									item.Quality = item.Quality + 1;
								}
							}
							if (item.SellIn < 6)
							{
								if (item.Quality < 50)
								{
									item.Quality = item.Quality + 1;
								}
							}
						}
					}
				}
				if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					item.SellIn = item.SellIn - 1;
				}
				
				if (item.SellIn < 0)
				{
					if (ItemIsNotBrie(item))
					{
						if (ItemIsNotBackstagePass(item))
						{
							if (item.Quality > 0)
							{
								if (item.Name != "Sulfuras, Hand of Ragnaros")
								{
									item.Quality = item.Quality - 1;
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
						if (item.Quality < 50)
						{
							item.Quality = item.Quality + 1;
						}
					}
				}
			}
		}
	}
}
