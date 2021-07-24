using System.Collections.Generic;
using System;

namespace csharpcore
{
    public class GildedRose
    {
        private IList<Item> Items;
        public GildedRose(IList<Item> Items) => this.Items = Items;

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var quality = Items[i].Quality;
                var sellIn = Items[i].SellIn;
                var name = Items[i].Name;
                var isSulfuras = name == "Sulfuras, Hand of Ragnaros";

                if (name == "Aged Brie")
                {
                    quality++;
                }
                else if (name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    quality = GetBackstagePassesQualityValue(sellIn, quality);
                }
                else if(!isSulfuras)
                {
                    quality = sellIn <= 0 ? quality - 2 : --quality;
                }

                Items[i].Quality = GetCorrectQualityValue(quality);
                Items[i].SellIn = isSulfuras ? sellIn : sellIn - 1;
            }
        }

        private int GetCorrectQualityValue(int quality)
        {
            if (quality < 0)
                return 0;
            if (quality > 50)
                return 50;

            return quality;
        }

        private int GetBackstagePassesQualityValue(int sellIn, int quality)
        {
            if (sellIn <= 0)
                return 0;
            else if (sellIn <= 5)
                return (quality += 3);
            else if (sellIn <= 10)
                return (quality += 2);
            else
                return ++quality;
        }
    }
}
