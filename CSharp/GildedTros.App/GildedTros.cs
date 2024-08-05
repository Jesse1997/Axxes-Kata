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
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
                else if (isItemBackstagePass)
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality = 0;
                        continue;
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 10)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 5)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
                else
                {
                    if (item.SellIn < 0)
                    {
                        item.Quality -= 2;
                    }
                    else
                    {
                        item.Quality--;
                    }

                    if (item.Quality < 0)
                    {
                        item.Quality = 0;
                    }
                }
            }
        }
    }
}
