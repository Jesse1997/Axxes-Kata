using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>{
                new() {Name = "Ring of Cleansening Code", SellIn = 10, Quality = 20},
                new() {Name = "Good Wine", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the SOLID", SellIn = 5, Quality = 7},
                new() {Name = "B-DAWG Keychain", SellIn = 0, Quality = 80},
                new() {Name = "B-DAWG Keychain", SellIn = -1, Quality = 80},
                new() {Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20},
                new() {Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 49},
                new() {Name = "Backstage passes for HAXX", SellIn = 5, Quality = 49},
                // these smelly items do not work properly yet
                new() {Name = "Duplicate Code", SellIn = 3, Quality = 6},
                new() {Name = "Long Methods", SellIn = 3, Quality = 6},
                new() {Name = "Ugly Variable Names", SellIn = 3, Quality = 6}
            };

            var app = new GildedTros(items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
