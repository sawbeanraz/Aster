using Aster.Users.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Store.Users {
    public class UserContextSeed {
        public static async Task SeedAsync(UserContext userContext, 
            int? retry = 0) {
            int retryForAvailability = retry.Value;


            try {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if(!userContext.Users.Any()) {
                    userContext.Users.AddRange(
                        GetSeedUsers());

                    await userContext.SaveChangesAsync();
                }                
            } catch(Exception ex) {
                //if(retryForAvailability < 10) {
                //    retryForAvailability++;
                //    var log = loggerFactory.CreateLogger<userContextSeed>();
                //    log.LogError(ex.Message);
                //    await SeedAsync(userContext, loggerFactory, retryForAvailability);
                //}
                //TODO: Send Log to 
            }
        }


        static IEnumerable<User> GetSeedUsers() {
            return new List<User>()
            {                
                new User("test") { Email = "test@hotmail.com", PasswordHash = "test" },
                new User("bean") { Email = "test@hotmail.com", PasswordHash = "password" },
                new User("thang") { Email = "thang@hotmail.com", PasswordHash = "thang"}
            };
        }
    }
}