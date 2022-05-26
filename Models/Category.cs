using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryEvent> CategoryEvents { get; set; }
    }
}