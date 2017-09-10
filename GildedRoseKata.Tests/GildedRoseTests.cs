
using NUnit.Framework;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private const string OtherItem = "OtherItem";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        [Test]
        public void Should_Remain_Same_Quality_When_Other_Item_And_Quality_Is_0()
        {
            var item = new Item { Name = OtherItem, Quality = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void Should_Decrease_Quality_When_Other_Item_And_Quality_Is_Greater_Than_0()
        {
            var item = new Item { Name = OtherItem, Quality = 1 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void Should_Decrease_SellIn_When_Other_Item()
        {
            var item = new Item { Name = OtherItem, SellIn = 1 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void Sulfuras_Remain_Same()
        {
            var item = new Item { Name = Sulfuras, Quality = 1, SellIn = 1 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(1, item.Quality);
            Assert.AreEqual(1, item.SellIn);
        }


    }
}
