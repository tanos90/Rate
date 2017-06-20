
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Review
    {
        public string ReviewText { get; set; }
        [ForeignKey("Flick_Id")]
        public virtual Flick Flick { get; set; }
        public string Id { get; set; }
        public string Flick_Id { get; set; }
    }
}
