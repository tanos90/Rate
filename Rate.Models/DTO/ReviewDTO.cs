using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rate.Models
{
    public class ReviewDTO
    {
        public string ReviewText { get; set; }
        public FlickDTO Flick { get; set; }
        public string ID { get; set; }
        public string Flick_Id { get; set; }

    }

}