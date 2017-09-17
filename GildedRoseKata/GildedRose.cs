using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const int MaxQuality = 50;

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
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
            if (item.Name == AgedBrie)
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == BackstagePass)
            {
                UpdateBackStagePass(item);
            }
            else if (item.Name == Sulfuras)
            {
            }
            else//Other
            {
                UpdateOthers(item);
            }
        }

        private static void UpdateOthers(Item item)
        {
            if (item.Quality > 0)
            {
                DecreaseQuality(item);
            }
            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    DecreaseQuality(item);
                }
            }
        }

        private static void UpdateBackStagePass(Item item)
        {
            if (IsMaxQualityNotReached(item))
            {
                WinQuality(item);
                if (item.SellIn < 11)
                {
                    if (IsMaxQualityNotReached(item))
                    {
                        WinQuality(item);
                    }
                }
                if (item.SellIn < 6)
                {
                    if (IsMaxQualityNotReached(item))
                    {
                        WinQuality(item);
                    }
                }
            }
            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private static void UpdateAgedBrie(Item item)
        {
            if (IsMaxQualityNotReached(item))
            {
                WinQuality(item);
            }
            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                if (IsMaxQualityNotReached(item))
                {
                    WinQuality(item);
                }
            }
        }

        private static bool IsMaxQualityNotReached(Item item)
        {
            return item.Quality < MaxQuality;
        }

        private static void WinQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
