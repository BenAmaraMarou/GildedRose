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
            else if (item.Name == BackstagePass)
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
            else//Sulfuras Other
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Sulfuras)
                    {
                        DecreaseQuality(item);
                    }
                }
                if (item.Name != Sulfuras)
                {
                    DecreaseSellIn(item);
                }
            }

            if (item.SellIn < 0)
            {
                if (item.Name == AgedBrie)
                {
                }
                else if (item.Name == BackstagePass)
                {
                }
                else//Sulfuras and Other
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != Sulfuras)
                        {
                            DecreaseQuality(item);
                        }
                    }
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
