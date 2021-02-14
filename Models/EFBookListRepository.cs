using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class EFBookListRepository : IBookListRepository
    {
        public BookListDbContext _context; 

        //Constructor
        public EFBookListRepository (BookListDbContext context)
        {
            _context = context;
        }

        // Past the query content to context 
        public IQueryable<BLP> BLPs => _context.BLPs; 

    }
}
