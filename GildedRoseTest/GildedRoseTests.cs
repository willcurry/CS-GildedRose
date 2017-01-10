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
            Assert.AreEqual("fixme", Items[0].Name);
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
    }
}