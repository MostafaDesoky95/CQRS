using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("CategoryEvent", Schema = "dbo")]
    public class CategoryEvent
    {
        public int CategoriesID { get; set; }
        public int EventsID { get; set; }

    }
}
