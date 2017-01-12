using System.Collections.Generic;

namespace GildedRoseCS
{
    public class ItemUpdate
    {
        IList<UpdateType> UpdateTypes;

        public ItemUpdate(IList<UpdateType> updateTypes)
        {
            UpdateTypes = updateTypes;
        }

        private void DecreaseItemQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }

        public void Run(Item item)
        {
            foreach (UpdateType update in UpdateTypes)
            {
                if (update.CanApplyTo(item)) update.Apply(item);
            }
        }
    }
}