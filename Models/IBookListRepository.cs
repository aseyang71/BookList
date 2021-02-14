using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public interface IBookListRepository
    {
        IQueryable<BLP> BLPs { get; }
    }
}
