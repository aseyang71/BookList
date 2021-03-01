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

        // use CurCat property to display which category is currently selected in the HomeController.cs file
        public string CurCat { get; set; }
    }
}
