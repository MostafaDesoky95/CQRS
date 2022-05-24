using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("Photo", Schema = "dbo")]
    public class Photo
    {
        public int ID { get; set; }
        public string URL { get; set; }

    }
}