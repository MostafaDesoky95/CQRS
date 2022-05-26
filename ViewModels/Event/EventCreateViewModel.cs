﻿using AutoMapper;

namespace CQRS.ViewModels.Event
{
    public class EventCreateViewModel : Profile
    {
        public int ID { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string Content { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CoverPhotoID { get; set; }
        public int SourceID { get; set; }
        public int PhotoAlbumID { get; set; }
        public List<int> Categories { get; set; }
    }
}