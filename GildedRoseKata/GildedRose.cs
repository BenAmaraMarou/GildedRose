using GildedRoseKata.QualityControl;
using GildedRoseKata.SellInControl;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly SellIn _sellIn;
        private readonly QualityFactory _qualityFactory;
        IList<Item> Items;

        public GildedRose(IList<Item> Items, SellIn sellIn, QualityFactory qualityFactory)
        {
            this.Items = Items;
            _sellIn = sellIn;
            _qualityFactory = qualityFactory;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateSingle(item);
            }
        }

        public void UpdateSingle(Item item)
        {
            _sellIn.Control(item);
            Quality quality = _qualityFactory.Create(item.Name);
            quality.Control(item);
        }
    }
}