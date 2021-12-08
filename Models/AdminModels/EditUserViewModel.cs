using CinemaProject.Data;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPhone { get; set; }

        public string UserPhotoPath { get; set; }

        public string Page { get; set; }
        public List<User> Users { get; set; } 
    }
}
