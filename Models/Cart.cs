using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem(BLP proj, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Project.BookId == proj.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty; 
            }
        }

        public void RemoveLine(BLP proj) =>
            Lines.RemoveAll(x => x.Project.BookId == proj.BookId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum()
        {
            return (decimal)Lines.Sum(e => e.Project.Price * e.Quantity);
        }

        public class CartLine
        {
            public int CartLineID { get; set; }
            public BLP Project { get; set; }
            public int Quantity { get; set; }
            public long BookId { get; internal set; }
        }
    }
}
