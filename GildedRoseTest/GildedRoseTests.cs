using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseCS;
using System.Text;
using System;
using System.IO;

namespace GildedRoseTests
{
    [TestFixture]
    public class GildedRoseTests
    {
        [Test]
        public void TestMethod()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void ItemQualityDecreasesAfterOneDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 10, Quality = 10 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void ItemQualityNeverGoesIntoNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 0, Quality = 0 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void ItemSellInDecreasesAfterOneDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 10, Quality = 10 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }


        [Test]
        public void BackstagePassQualityIncreasesByTwoWhenSellInIsLessThan11Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 48 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void BackstagePassQualityDropsTo0PastSellInData()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void QualityDoesNotGoAbove50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void OncePassedSellDataQualityDecreasesTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 0, Quality = 10 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
        }

        [Test]
        public void AgedBrieQualityIncreasesOverTime()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 5 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
        }
    }
}