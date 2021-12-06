using CinemaProject.Data;
using System.Collections.Generic;

namespace CinemaProject.Models.AdminModels
{
    public class CreateRoleVIewModel
    {
        public string RoleName { get; set; }

        public List<Role> Roles { get; set; }
    }
}
