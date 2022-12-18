namespace INStock
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class ProductStock : IProductStock
    {
        private readonly IList<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public int Count => products.Count;

        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                return products[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                products[index] = value;
            }
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(IProduct product)
            => products.Contains(product);

        public void Add(IProduct product)
        {
            if (products.Any(p => p.Label == product.Label))
                throw new InvalidOperationException($"Product {product.Label} already exists!");

            products.Add(product);
        }

        public IProduct Find(int index)
            => this[index];

        public IProduct FindByLabel(string label)
        {
            IProduct product = products.SingleOrDefault(p => p.Label == label);

            if (product == null)
                throw new ArgumentException($"Product with label {label} does not exist!");

            return product;
        }

        public IProduct FindMostExpensiveProduct() 
            => products.OrderByDescending(p => p.Price).First();

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi) 
            => products.Where(p => p.Price >= lo && p.Price <= hi).OrderByDescending(p => p.Price);

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
            => products.Where(p => p.Price == price);

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => products.Where(p => p.Quantity == quantity);
    }
}