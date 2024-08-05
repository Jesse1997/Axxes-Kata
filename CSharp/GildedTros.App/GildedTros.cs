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

                if (!isItemGoodWine && !isItemBackstagePass)
                {
                    if (item.Quality > 0)
                    {
                        if (!isItemLegendary)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (isItemBackstagePass)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!isItemLegendary)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!isItemGoodWine)
                    {
                        if (!isItemBackstagePass)
                        {
                            if (item.Quality > 0)
                            {
                                if (!isItemLegendary)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
