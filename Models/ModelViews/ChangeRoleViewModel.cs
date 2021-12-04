using CinemaProject.Data;
using System.Collections.Generic;

namespace CinemaProject.Models.ModelViews
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<Role> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }

        public ChangeRoleViewModel()
        {
            AllRoles = new List<Role>();
            UserRoles = new List<string>();
        }
    }
}
