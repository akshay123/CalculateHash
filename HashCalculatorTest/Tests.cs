using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace HashCalculatorTest
{
    public class Tests
    {
        [Fact]
        public void Compare_Same_SKU_Same_Color()
        {
            var bluepill      = new Product {SKU = "AV331x41", Color = KnownColor.Blue, Name = "Viagra", Price = 10.52};
            var bluepillInBox = new Product { SKU = "AV331x41", Color = KnownColor.Blue, Name = "Viagra in a box", Price = 32.12 };

            Assert.Equal(bluepill, bluepillInBox);
        }

        [Fact]
        public void Compare_Same_SKU_Different_Color()
        {
            var bluepill = new Product { SKU = "AV331x41", Color = KnownColor.Blue, Name = "Viagra", Price = 10.52 };
            var pinkpill = new Product { SKU = "AV331x41", Color = KnownColor.Pink, Name = "Viagra", Price = 10.52 };

            Assert.NotEqual(bluepill, pinkpill);
        }

        [Fact]
        public void DistinctOfList()
        {
            var bluepill      = new Product { SKU = "AV331x41", Color = KnownColor.Blue, Name = "Viagra", Price = 10.52 };
            var pinkpill      = new Product { SKU = "AV331x41", Color = KnownColor.Pink, Name = "Viagra", Price = 10.52 };
            var bluepillInBox = new Product { SKU = "AV331x41", Color = KnownColor.Blue, Name = "Viagra in a box", Price = 32.12 };

            var list = new List<Product> {bluepill, pinkpill, bluepillInBox};

            Assert.Equal(3, list.Count);
            Assert.Equal(2, list.Distinct().Count());

        }
    }
}
