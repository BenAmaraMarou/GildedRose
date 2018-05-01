namespace GildedRoseKata.QualityControl
{
    public class QualityFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public Quality Create(string name)
        {
            Quality quality;
            if (name == AgedBrie)
            {
                quality = new AgedBrieQuality();
            }
            else if (name == BackstagePass)
            {
                quality = new BackStagePassQuality();
            }
            else if (name == Sulfuras)
            {
                quality = new SulfurasQuality();
            }
            else
            {
                quality = new DefaultQuality();
            }
            return quality;
        }
    }
}