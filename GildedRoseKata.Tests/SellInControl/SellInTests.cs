using NUnit.Framework;
using GildedRoseKata.SellInControl;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class SellInTests
    {
        private const string Default = "Default";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private SellIn _sellIn;

        [SetUp]
        public void Setup()
        {
            _sellIn = new SellIn();
        }

        [TestCase(Default)]
        [TestCase(AgedBrie)]
        [TestCase(BackstagePass)]
        public void Should_decrease_sellIn(string name)
        {
            var inputSellIn = 1;
            var item = new Item { Name = name, SellIn = inputSellIn };

            _sellIn.Control(item);

            Assert.AreEqual(inputSellIn -1, item.SellIn);
        }
        
        [Test]
        public void Should_keep_same_sellIn_for_sulfuras()
        {
            var inputSellIn = 10;
            var item = new Item { Name = Sulfuras, SellIn = inputSellIn };

            _sellIn.Control(item);

            Assert.AreEqual(inputSellIn, item.SellIn);
        }
    }
}
