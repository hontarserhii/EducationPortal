using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationPortal.Web.Models
{
    public class PaginationModel
    {
        public int CountOfItemsOnPage { get; set; }

        public int CountOfPages{ get; set; }

        public int CurrentPage { get; set; }

        public int CountOfItems { get; set; }
    }
}