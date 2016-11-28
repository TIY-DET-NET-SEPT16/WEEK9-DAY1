using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWithAuth.Models
{
    public class MoviePartialViewObject
    {
        public MoviePartialViewSmallerObject MPVS { get; set; }
        public int Id { get; set; }
        public string SomeOtherStuff { get; set; }
    }
}