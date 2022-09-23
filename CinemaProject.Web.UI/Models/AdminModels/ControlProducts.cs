using CinemaProject.Data;
using CinemaProject.Data.Models.Entities;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class ControlProducts
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPhotoPath { get; set; }
        public List<Product> Products { get; set; }
    }
}
