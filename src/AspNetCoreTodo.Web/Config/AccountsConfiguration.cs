using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Web.Config
{
    public class AccountsConfiguration
    {
        public const string Name = "Accounts";

        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string TestUserEmail { get; set; }
        public string TestUserPassword { get; set; }
    }
}
