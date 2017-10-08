
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
            var inputQuality = 0;
            var item = new Item { Name = OtherItem, Quality = inputQuality };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality, item.Quality);
        }

        [TestCase(10, 10)]
        [TestCase(1, 0)]
        public void OtherItem_Should_Decrease_Quality_When_Quality_And_SellIn_Are_Not_Reached(int inputQuality, int inputSellIn)
        {
            var item = new Item { Name = OtherItem, Quality = inputQuality, SellIn = inputSellIn };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality - 1, item.Quality);
        }

        [Test]
        public void OtherItem_Should_Double_Decrease_Quality_When_SellIn_Is_Reached_But_Not_Quality()
        {
            var inputQuality = 10;
            var item = new Item { Name = OtherItem, SellIn = 0, Quality = inputQuality };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality - 2, item.Quality);
        }

        [Test]
        public void OtherItem_Should_Decrease_SellIn()
        {
            var inputSellIn = 10;
            var item = new Item { Name = OtherItem, SellIn = inputSellIn };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputSellIn -1, item.SellIn);
        }
        
        [Test]
        public void Sulfuras_Should_Keep_Same_Quality()
        {
            var inputQuality = 10;
            var item = new Item { Name = Sulfuras, Quality = inputQuality};
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality, item.Quality);
        }

        [Test]
        public void Sulfuras_Should_Keep_Same_SellIn()
        {
            var inputSellIn = 10;
            var item = new Item { Name = Sulfuras, SellIn = inputSellIn };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputSellIn, item.SellIn);
        }

        [Test]
        public void AgedBrie_Should_Win_Single_Quality_When_SellIn_Is_Not_Reached()
        {
            var inputQuality = 10;
            var item = new Item { Name = AgedBrie, Quality = inputQuality, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality + 1, item.Quality);
        }

        [Test]
        public void AgedBrie_Should_Win_Twice_Quality_When_SellIn_Is_Reached()
        {
            var inputQuality = 10;
            var item = new Item { Name = AgedBrie, Quality = inputQuality, SellIn = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality + 2, item.Quality);
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
            var inputSellIn = 10;
            var item = new Item { Name = AgedBrie, SellIn = inputSellIn };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputSellIn - 1, item.SellIn);
        }

        [Test]
        public void BackStagePass_Should_Decrease_SellIn()
        {
            var inputSellIn = 10;
            var item = new Item { Name = BackstagePass, SellIn = inputSellIn };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputSellIn - 1, item.SellIn);
        }

        [Test]
        public void BackStagePass_Should_Loose_All_Quality_When_MaxQuality_And_SellIn_Are_Reached()
        {
            var item = new Item { Name = BackstagePass, Quality = MaxQuality, SellIn = 0 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Single_Quality_When_SellIn_Is_More_Than_Two_Weeks()
        {
            var inputQuality = 10;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 12 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality + 1, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Twice_Quality_When_SellIn_Is_Two_Weeks_Before()
        {
            var inputQuality = 10;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 10 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality + 2, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Triple_Quality_When_SellIn_Is_One_Week_Before()
        {
            var inputQuality = 10;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 5 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(inputQuality + 3, item.Quality);
        }

        [Test]
        public void BackStagePass_Quality_Should_Not_Exceeed_MaxQuality()
        {
            var item = new Item { Name = BackstagePass, Quality = MaxQuality -1 , SellIn = 5 };
            var gildedRose = new GildedRose(null);
            gildedRose.UpdateSingle(item);
            Assert.AreEqual(MaxQuality, item.Quality);
        }
    }
}
