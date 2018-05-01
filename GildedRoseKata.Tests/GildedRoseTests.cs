using NUnit.Framework;
using GildedRoseKata.SellInControl;
using GildedRoseKata.QualityControl;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private const string Default = "Default";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private GildedRose _gildedRose;

        [SetUp]
        public void Setup()
        {
            _gildedRose = new GildedRose(null, new SellIn(), new QualityFactory());
        }

        [Test]
        public void Should_never_decrease_quality_less_than_zero_for_default_item()
        {
            Item item = new Item { Name = Default, Quality = MinQuality };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(MinQuality, item.Quality);
        }

        [Test]
        public void Should_decrease_quality_once()
        {
            int inputQuality = 1;
            Item item = new Item { Name = Default, Quality = inputQuality, SellIn = 0 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality - 1, item.Quality);
        }

        [Test]
        public void Should_decrease_quality_twice()
        {
            var inputQuality = 2;
            var item = new Item { Name = Default, Quality = inputQuality, SellIn = 0 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality - 2, item.Quality);
        }
                
        [Test]
        public void Sulfuras_Should_Keep_Same_Quality()
        {
            var inputQuality = 10;
            var item = new Item { Name = Sulfuras, Quality = inputQuality};

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality, item.Quality);
        }
        
        [Test]
        public void AgedBrie_Should_Win_Single_Quality_When_SellIn_Is_Not_Reached()
        {
            var inputQuality = 10;
            var item = new Item { Name = AgedBrie, Quality = inputQuality, SellIn = 10 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality + 1, item.Quality);
        }

        [Test]
        public void AgedBrie_Should_Win_Twice_Quality_When_SellIn_Is_Reached()
        {
            var inputQuality = 10;
            var item = new Item { Name = AgedBrie, Quality = inputQuality, SellIn = 0 };
            
            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality + 2, item.Quality);
        }
        
        [Test]
        public void AgedBrie_Quality_Should_Not_Exceed_MaxQuality()
        {
            var item = new Item { Name = AgedBrie, Quality = MaxQuality};

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(MaxQuality, item.Quality);
        }

        [Test]
        public void AgedBrie_Should_Decrease_SellIn()
        {
            var inputSellIn = 10;
            var item = new Item { Name = AgedBrie, SellIn = inputSellIn };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputSellIn - 1, item.SellIn);
        }

        [Test]
        public void BackStagePass_Should_Decrease_SellIn()
        {
            var inputSellIn = 1;
            var item = new Item { Name = BackstagePass, SellIn = inputSellIn };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputSellIn - 1, item.SellIn);
        }

        [Test]
        public void BackStagePass_Should_Loose_All_Quality_When_MaxQuality_And_SellIn_Are_Reached()
        {
            var item = new Item { Name = BackstagePass, Quality = MaxQuality, SellIn = 0 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Single_Quality_When_SellIn_Is_More_Than_Two_Weeks()
        {
            var inputQuality = 1;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 12 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality + 1, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Twice_Quality_When_SellIn_Is_Two_Weeks_Before()
        {
            var inputQuality = 10;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 10 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality + 2, item.Quality);
        }

        [Test]
        public void BackStagePass_Should_Win_Triple_Quality_When_SellIn_Is_One_Week_Before()
        {
            var inputQuality = 10;
            var item = new Item { Name = BackstagePass, Quality = inputQuality, SellIn = 5 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(inputQuality + 3, item.Quality);
        }

        [Test]
        public void BackStagePass_Quality_Should_Not_Exceeed_MaxQuality()
        {
            var item = new Item { Name = BackstagePass, Quality = MaxQuality -1 , SellIn = 5 };

            _gildedRose.UpdateSingle(item);

            Assert.AreEqual(MaxQuality, item.Quality);
        }
    }
}
