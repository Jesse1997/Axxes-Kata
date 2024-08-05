using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private readonly IList<Item> _items;
        private const string GOOD_WINE = "Good Wine";
        private const string BACKSTAGE_PASS = "Backstage pass";
        private const string LEGENDARY_ITEM = "B-DAWG Keychain";
        private static readonly HashSet<string> SmellyItems = new HashSet<string> { "Duplicate Code", "Long Methods", "Ugly Variable Names" };

        public GildedTros(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (IsLegendaryItem(item)) continue;

                item.SellIn--;

                if (IsGoodWine(item))
                {
                    IncrementQuality(item);
                }
                else if (IsBackstagePass(item))
                {
                    HandleBackstagePassQuality(item);
                }
                else
                {
                    if (IsSmellyItem(item)) DecrementQuality(item);
                    DecrementQuality(item);
                }
            }
        }

        private bool IsGoodWine(Item item) => item.Name == GOOD_WINE;

        private bool IsBackstagePass(Item item) => item.Name.Contains(BACKSTAGE_PASS);

        private bool IsLegendaryItem(Item item) => item.Name == LEGENDARY_ITEM;

        private bool IsSmellyItem(Item item) => SmellyItems.Contains(item.Name);

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

        private void DecrementQuality(Item item)
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
