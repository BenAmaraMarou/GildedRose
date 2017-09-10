
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
        public void OtherItem_Should_Keep_Same_Quality_When_Quality_Is_0()
        {
            var item = new Item { Name = OtherItem, Quality = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void OtherItem_Should_Decrease_Quality_When_Quality_Is_Greater_Than_0_And_SellIn_Is_Not_Reached()
        {
            var item = new Item { Name = OtherItem, Quality = 10, SellIn = 1 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(9, item.Quality);
        }

        [Test]
        public void OtherItem_Should_Double_Decrease_Quality_When_SellIn_Is_Reached()
        {
            var item = new Item { Name = OtherItem, SellIn = 0, Quality = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        public void OtherItem_Should_Decrease_SellIn()
        {
            var item = new Item { Name = OtherItem, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(9, item.SellIn);
        }
        
        [Test]
        public void Sulfuras_Should_Keep_Same_Quality()
        {
            var item = new Item { Name = Sulfuras, Quality = 10};
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(10, item.Quality);
        }

        [Test]
        public void Sulfuras_Should_Keep_Same_SellIn()
        {
            var item = new Item { Name = Sulfuras, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(10, item.SellIn);
        }

        [Test]
        public void AgedBrie_Should_Win_1_Quality_When_SellIn_Is_Not_Reached()
        {
            var item = new Item { Name = AgedBrie, Quality = 10, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(11, item.Quality);
        }

        [Test]
        public void AgedBrie_Should_Win_2_Quality_When_SellIn_Is_Reached()
        {
            var item = new Item { Name = AgedBrie, Quality = 10, SellIn = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(12, item.Quality);
        }
        
        [Test]
        public void AgedBrie_Quality_Should_Not_Exceed_MaxQuality()
        {
            var item = new Item { Name = AgedBrie, Quality = MaxQuality};
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(MaxQuality, item.Quality);
        }

        [Test]
        public void AgedBrie_Should_Decrease_SellIn()
        {
            var item = new Item { Name = AgedBrie, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(9, item.SellIn);
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
