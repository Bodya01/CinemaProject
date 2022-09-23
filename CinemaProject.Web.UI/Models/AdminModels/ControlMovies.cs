using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class ControlMovies
    {
        public long Id { get; set; }
        public string NameMovie { get; set; }
        public int AgeRestriction { get; set; }
        public string MovieDescription { get; set; }
        public string CreateAt { get; set; }
        public string MoviePhotoPath { get; set; }
        public string MoviePreviewPath { get; set; }
        public string MovieTrailerPath { get; set; }
        public int SubcategoryId { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
