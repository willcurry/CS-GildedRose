using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseCS;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTests
    {
        IList<Item> Items;
        IList<UpdateType> UpdateTypes;
        ItemUpdate ItemUpdate;
        GildedRose GildedRose;

        public void SetUp(IList<Item> Items)
        {
            UpdateTypes = new List<UpdateType> {new DefaultUpdate(), new BackstagePassUpdate(), new AgedBrieUpdate(), new SulfarusUpdateType()};
            ItemUpdate = new ItemUpdate(UpdateTypes);
            GildedRose = new GildedRose(Items, ItemUpdate);
        }

        [Test]
        public void ItemQualityDecreasesAfterOneDay()
        {
            Items = new List<Item> { new Item { Name = "item", SellIn = 10, Quality = 10 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void ItemQualityNeverGoesIntoNegative()
        {
            Items = new List<Item> { new Item { Name = "item", SellIn = 0, Quality = 0 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void ItemSellInDecreasesAfterOneDay()
        {
            Items = new List<Item> { new Item { Name = "item", SellIn = 10, Quality = 10 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }


        [Test]
        public void BackstagePassQualityIncreasesByTwoWhenSellInIsLessThan11Days()
        {
            Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 48 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void BackstagePassQualityDropsTo0PastSellInData()
        {
            Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotGoAbove50()
        {
            Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void OncePassedSellDataQualityDecreasesTwiceAsFast()
        {
            Items = new List<Item> { new Item { Name = "item", SellIn = 0, Quality = 10 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void AgedBrieQualityIncreasesOverTime()
        {
            Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 } };
            SetUp(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }
    }
}