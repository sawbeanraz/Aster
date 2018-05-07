using Aster.System.Data;

namespace Aster.Core.Domain.Security {

    public class User : BaseEntity {

        public User() { }
        public User(string Username) {
            UserName = Username;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool? EmailConfirmed { get; set; }
        //public IList<string> RoleNames { get; set; } = new List<string>();        
        public override string ToString() {
            return UserName;
        }
    }
}
