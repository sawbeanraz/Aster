using System;
using Aster.Users.Abstractions;
using System.Collections.Generic;

namespace Aster.Users.Model {
    public class User : IUser {

        public User(string Username) {
            UserName = Username;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }       
        public string Email { get; set; }        
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public IList<string> RoleNames { get; set; } = new List<string>();        
        public override string ToString() {
            return UserName;
        }
    }
}