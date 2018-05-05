using System;
using System.Collections.Generic;
using System.Text;

namespace Aster.Utils.Encryption {
    public interface IEncryptionService {

        string Hash(string text, string salt);

        string Encrypt(string text, string encryptionKey = "");

        string Decrypt(string text, string encryptionKey = "");
    }
}
