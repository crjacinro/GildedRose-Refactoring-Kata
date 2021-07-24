using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_WhenTheDayEnds_QualityValueShouldDecrementsByOne()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "bag", SellIn = 1, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenTheDayEnds_SellInValueShouldDecrementByOne()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "bag", SellIn = 1, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(0, Items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_SellInIsZero_QualityShouldDecrementByTwo()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "bag", SellIn = 0, Quality = 4 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityIsZero_QualityValueShouldNeverBeNegative()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "bag", SellIn = 1, Quality = 0 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_QualityShouldIncrease()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityIs50_QualityShouldNotIncrement()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_QualityShouldNotDecrement()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesSellInGreaterThan10Days_QualityShouldIncreaseBy1()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesSellInValueIs10OrLess_QualityShouldIncreaseBy2()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesSellInValueIs5OrLess_QualityShouldIncreaseBy3()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(4, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePassesSellInValueIsZero_QualityShouldBeZero()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal(0, Items[0].Quality);
        }
    }
}