namespace Aster.Services.Security {

    public interface IEncryptionService {        
        
        string Hash(string text, string salt);

        string Encrypt(string text, string encryptionKey = "");

        string Decrypt(string text, string encryptionKey = "");
    }
}