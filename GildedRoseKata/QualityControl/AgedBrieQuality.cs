namespace GildedRoseKata.QualityControl
{
    public class AgedBrieQuality : Quality
    {
        private const int MaxQuality = 50;
        
        public override void Control(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                WinQuality(item);
            }
            if (item.SellIn < 0)
            {
                if (item.Quality < MaxQuality)
                {
                    WinQuality(item);
                }
            }
        }
        
        private static void WinQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }
    }
}
