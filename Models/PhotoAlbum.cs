using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("PhotoAlbum", Schema = "dbo")]
    public class PhotoAlbum
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}