namespace GildedRoseKata.QualityControl
{
    public class DefaultQuality : Quality
    {
        public override void Control(Item item)
        {
            if (item.Quality > QualityMin)
            {
                DecreaseQuality(item);
            }
            if (item.SellIn < 0)
            {
                if (item.Quality > QualityMin)
                {
                    DecreaseQuality(item);
                }
            }
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
