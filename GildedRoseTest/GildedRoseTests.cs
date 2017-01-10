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
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();
            //Approvals.Verify(output); ?
        }

        [Test]
        public void ItemQualityDecreasesOneWhenNotRecognised()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "item", SellIn = 10, Quality = 10 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].Quality);
        }

        [Test]
        public void BackstagePassesThatHaveSellInLessThan11AndHigherThan50QualityDoNotChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 51 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(51, Items[0].Quality);
        }

        [Test]
        public void BackstagePassesThatHaveSellInLessThan11And45QualityIncreaseTwice()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 45 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(47, Items[0].Quality);
        }

        [Test]
        public void BackstagePassesThatHaveSellInLessThan11And49QualityIncreaseOnce()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void ItemSellInDecreasesByOneWhenNotRecognised()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Item", SellIn = 10, Quality = 0 } };
            GildedRose GildedRose = new GildedRose(Items);
            GildedRose.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
        }
    }
}