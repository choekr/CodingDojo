using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public abstract class BaseEntity {}
    public class QuoteList : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quote { get; set; }
        public string Updated_at { get; set; }
        public string Id { get; set; }
    }
}