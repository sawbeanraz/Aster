using Aster.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Domain.Users
{
    public class User : BaseEntity {

        public User() { }
        public User(string Username) {
            UserName = Username;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool EmailConfirmedsss { get; set; }
        //public IList<string> RoleNames { get; set; } = new List<string>();        
        public override string ToString() {
            return UserName;
        }
    }
}
