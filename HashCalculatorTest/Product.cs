using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HashCalculator;

namespace HashCalculatorTest
{
    public class Product
    {
        public string SKU { get; set; }
        public KnownColor Color { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.CalculateHash(() => SKU, () => Color);
        }
    }

    
}
