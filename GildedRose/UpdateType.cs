namespace GildedRoseCS
{
    public interface UpdateType
    {
        void Apply(Item item);
        bool CanApplyTo(Item item);
    }
}
