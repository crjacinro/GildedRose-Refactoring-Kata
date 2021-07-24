using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest_UpdateQuality
    {
        [Fact]
        public void NormalItem_EndOfDay_QualityAndSellInValuesShouldDecrementByOne()
        {
            var items = new List<Item> {
                new Item { Name = "bag", SellIn = 1, Quality = 1 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);
        }

        [Fact]
        public void NormalItem_SellInIsZero_QualityShouldDecrementByTwo()
        {
            var items = new List<Item> {
                new Item { Name = "bag", SellIn = 0, Quality = 2 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void NormalItem_QualityIsZero_QualityShouldNotDecrement()
        {
            var items = new List<Item> {
                new Item { Name = "bag", Quality = 0 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_QualityShouldIncrease()
        {
            var items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(2, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_QualityValueIsFifty_QualityShouldNotIncrement()
        {
            var items = new List<Item> {
                new Item { Name = "Aged Brie", Quality = 50 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_QualityShouldNotDecrement()
        {
            var items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_SellInValueIsGreaterThanTen_QualityShouldIncreaseBy1()
        {
            var items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_SellInValueIsTenOrLess_QualityShouldIncreaseBy2()
        {
            var items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(2, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_SellInValueIsFiveOrLess_QualityShouldIncreaseBy3()
        {
            var items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(3, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_SellInValueIsZero_QualityShouldBeZero()
        {
            var items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Conjured_QualityShouldDecrementByTwo()
        {
            var items = new List<Item> {
                new Item { Name = "Conjured", SellIn = 1, Quality = 2 }
            };

            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }
    }
}