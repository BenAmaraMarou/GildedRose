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
                if (item.Quality < MaxQuality)
                {
                    WinQuality(item);

                    if (item.Name == BackstagePass)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                WinQuality(item);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < MaxQuality)
                            {
                                WinQuality(item);
                            }
                        }
                    }
                }
            }
            else if (item.Name == BackstagePass)
                {
                    if (item.Quality < MaxQuality)
                    {
                        WinQuality(item);

                        if (item.Name == BackstagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    WinQuality(item);
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    WinQuality(item);
                                }
                            }
                        }
                    }
                }
            
            else
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Sulfuras)
                    {
                        DecreaseQuality(item);
                    }
                }
            }

            if (item.Name != Sulfuras)
            {
                DecreaseSellIn(item);
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePass)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != Sulfuras)
                            {
                                DecreaseQuality(item);
                            }
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        WinQuality(item);
                    }
                }
            }
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
