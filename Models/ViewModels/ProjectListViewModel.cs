using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<BLP> BLPs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
