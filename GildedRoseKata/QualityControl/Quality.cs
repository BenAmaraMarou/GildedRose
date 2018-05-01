namespace GildedRoseKata.QualityControl
{
    public abstract class Quality
    {
        protected const int QualityMin = 0;

        public abstract void Control(Item item);
    }
}
