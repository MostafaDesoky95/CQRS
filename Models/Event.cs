using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Models
{
    [Table("Event", Schema = "dbo")]
    public class Event
    {
        public int ID { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("CoverPhoto")]
        public int CoverPhotoID { get; set; }
        [ForeignKey("Source")]
        public int SourceID { get; set; }
        [ForeignKey("PhotoAlbum")]
        public int PhotoAlbumID { get; set; }



        public virtual Photo CoverPhoto { get; set; }
        public virtual Source Source { get; set; }
        public PhotoAlbum PhotoAlbum { get; set; }
        public ICollection<Category> Categories { get; set; }



    }
}
