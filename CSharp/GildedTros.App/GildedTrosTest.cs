using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void UpdateQuality_NormalItem_ReturnsItemWithSellInAndQualityLoweredByOne()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "normal item", SellIn = 1, Quality = 1 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItemWithQualityZero_ReturnsItemWithQualityZero()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "normal item", SellIn = 5, Quality = 0 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItemWithSellInZeroOrLess_ReturnsItemWithQualityLoweredByTwo()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "normal item", SellIn = 0, Quality = 2 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GoodWineItem_ReturnsItemWithQualityIncreasedByOne()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Good Wine", SellIn = 4, Quality = 6 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(7, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_GoodWineItemWithQualityFifty_ReturnsItemWithQualityFifty()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Good Wine", SellIn = 4, Quality = 50 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_LegendaryItem_ReturnsItemWithSameSellInAndQuality()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 4, Quality = 80 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassItemWithSellInMoreThanTen_ReturnsItemWithQualityIncreasedByOne()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 11, Quality = 5 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassItemWithSellInLessThanElevenAndMoreThanFive_ReturnsItemWithQualityIncreasedByTwo()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 5 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(7, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassItemWithSellInLessThanSixAndMoreThanZero_ReturnsItemWithQualityIncreasedByTwo()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 1, Quality = 5 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassItemWithSellInLessThanOne_ReturnsItemWithQualityZero()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 5 } };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(0, items[0].Quality);
        }
    }
}