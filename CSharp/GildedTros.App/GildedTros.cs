using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private readonly IList<Item> _items;

        public GildedTros(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var isItemGoodWine = item.Name == "Good Wine";
                var isItemBackstagePass = item.Name.Contains("Backstage pass");
                var isItemLegendary = item.Name == "B-DAWG Keychain";

                if (isItemLegendary) continue;

                item.SellIn--;

                if (isItemGoodWine)
                {
                    IncrementQuality(item);
                }
                else if (isItemBackstagePass)
                {
                    HandleBackstagePassQuality(item);
                }
                else
                {
                    HandleNormalQuality(item);
                }
            }
        }

        private void IncrementQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void HandleBackstagePassQuality(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            IncrementQuality(item);

            if (item.SellIn < 10)
            {
                IncrementQuality(item);
            }

            if (item.SellIn < 5)
            {
                IncrementQuality(item);
            }
        }

        private void HandleNormalQuality(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality--;
            }

            item.Quality--;

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
