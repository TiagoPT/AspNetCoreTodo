using System.Collections.Generic;
using AspNetCoreTodo.Data;

namespace AspNetCoreTodo.Web.Models
{
    public class ManageUsersViewModel
    {
        public IEnumerable<ApplicationUser> Administrators { get; internal set; }
        public IEnumerable<ApplicationUser> AllUsers { get; internal set; }
    }
}
