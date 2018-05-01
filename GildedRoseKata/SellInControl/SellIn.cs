namespace GildedRoseKata.SellInControl
{
    public class SellIn
    {
        private const int Decrease = 1;
        private const int NoDecrease = 0;
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        public void Control(Item item)
        {
            item.SellIn = item.SellIn - DecreaseStep(item);
        }

        private static int DecreaseStep(Item item)
        {
            return Sulfuras.Equals(item.Name) ? NoDecrease : Decrease;
        }   
    }
}
