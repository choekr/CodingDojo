using System.ComponentModel.DataAnnotations;

namespace quotingdojoRedux.Models
{
    public abstract class BaseEntity {}
    public class QuoteItem : BaseEntity
    {
        [Key]
        public string id { get; set; }
        [Required]
        [MinLength(1)]
        public string Quote { get; set; }
        public string Updated_at { get; set; }
        public string user_id { get; set; }
        public User user { get; set; } 
    }
}