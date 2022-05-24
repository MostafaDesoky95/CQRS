using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("Source", Schema = "dbo")]
    public class Source
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}