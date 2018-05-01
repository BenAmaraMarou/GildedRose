namespace GildedRoseKata.QualityControl
{
    public class BackStagePassQuality : Quality
    {
        private const int MaxQuality = 50;
        private const int TwoWeeks = 11;
        private const int OneWeek = 6;

        public override void Control(Item item)
        {
            if (IsMaxQualityNotReached(item))
            {
                WinQuality(item);
                if (item.SellIn < TwoWeeks)
                {
                    if (IsMaxQualityNotReached(item))
                    {
                        WinQuality(item);
                    }
                }
                if (item.SellIn < OneWeek)
                {
                    if (IsMaxQualityNotReached(item))
                    {
                        WinQuality(item);
                    }
                }
            }
            if (item.SellIn < 0)
            {
                item.Quality = 0;
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
    }

}
