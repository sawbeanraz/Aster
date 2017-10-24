using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aster.Users.Abstractions.Services {
    public interface ISignInService {
        Task<IUser> ValidateCredentials(string username, string password);
    }
}