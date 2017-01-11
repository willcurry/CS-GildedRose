using System;
using System.Collections.Generic;

namespace GildedRoseCS
{
	public class GildedRose
	{
		IList<Item> Items;
        ItemUpdate ItemUpdate;

        public GildedRose(IList<Item> Items, ItemUpdate ItemUpdate) 
		{
			this.Items = Items;
            this.ItemUpdate = ItemUpdate;
		}
		
		public void UpdateQuality()
		{
			foreach (Item item in Items)
			{
                UpdateItem(item);
			}
		}

        private void UpdateItem(Item item)
        {
            ItemUpdate.Run(item);
        }
    }
}