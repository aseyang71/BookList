using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(BLP proj, int qty)
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

        public virtual void RemoveLine(BLP proj) =>
            Lines.RemoveAll(x => x.Project.BookId == proj.BookId);

        // This method calculate the total price and covert the result to decimal type 
        public decimal ComputeTotalSum() =>
            (decimal)Lines.Sum(e => e.Project.Price * e.Quantity);

        // Clear method
        public virtual void Clear() => Lines.Clear();


        public class CartLine
        {
            // The Cart class uses the CartLine class, defined in the same file, to represent a product selected by the customer and the qty the user wants to buy.
            public int CartLineID { get; set; }
            public BLP Project { get; set; }
            public int Quantity { get; set; }
/*            public long BookId { get; internal set; }
*/        }
    }
}
