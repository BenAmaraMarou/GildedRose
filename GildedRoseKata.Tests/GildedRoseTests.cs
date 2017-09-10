
using NUnit.Framework;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private const string OtherItem = "OtherItem";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const int MaxQuality = 50;

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

        [Test]
        public void AgedBrie_Win_Quality_And_Decrease_SellIn()
        {
            var item = new Item { Name = AgedBrie, Quality = 1, SellIn = 1};
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void AgedBrie_Quality_Has_Max_Value()
        {
            var item = new Item { Name = AgedBrie, Quality = MaxQuality, SellIn = 1 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(MaxQuality, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }

        [Test]
        public void AgedBrie_Double_Win_Quality_When_SellIn_Is_Reached()
        {
            var item = new Item { Name = AgedBrie, Quality = 1, SellIn = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void BackStagePass_Loose_All_Quality_When_MaxQuality_And_SellIn_Are_Reached()
        {
            var item = new Item { Name = BackstagePass, Quality = MaxQuality, SellIn = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }



    }
}
