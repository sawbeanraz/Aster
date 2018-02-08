using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Aster.Services.Security {
  public class EncryptionService: IEncryptionService {


    private string _hashAlgorithm = "SHA512";    
    private string _encryptionKey = "1457896310254654";

    private string CreateHash(byte[] data) {

      var algorithm = HashAlgorithm.Create(_hashAlgorithm);


      if (algorithm == null) {
        throw new ArgumentException("Unrecognized hash name");
      }

      var hashByteArray = algorithm.ComputeHash(data);

      return BitConverter.ToString(hashByteArray).Replace("-", "");
    }


    private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv) {
      using (var ms = new MemoryStream()) {
        using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write)) {
          var toEncrypt = Encoding.Unicode.GetBytes(data);
          cs.Write(toEncrypt, 0, toEncrypt.Length);
          cs.FlushFinalBlock();
        }
        return ms.ToArray();
      }
    }

    private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv) {
      using (var ms = new MemoryStream(data)) {
        using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read)) {
          using (var sr = new StreamReader(cs, Encoding.Unicode)) {
              return sr.ReadToEnd();
          }
        }
      }
    }

    public string Hash(string text, string salt) {

      if(string.IsNullOrEmpty(text)) {
        throw new ArgumentException(nameof(text));
      }

      return CreateHash(
        Encoding.UTF8.GetBytes(
          string.Concat(text, salt)));
    }



    public string Encrypt(string text, string encryptionKey = "") {
      if (string.IsNullOrEmpty(text)) {
        return text;
      }

      if (string.IsNullOrEmpty(encryptionKey)) {
          encryptionKey = _encryptionKey;
      }

      using (var provider = new TripleDESCryptoServiceProvider())
      {
          provider.Key = Encoding.ASCII.GetBytes(encryptionKey.Substring(0, 16));
          provider.IV = Encoding.ASCII.GetBytes(encryptionKey.Substring(8, 8));

          var encryptedBinary = EncryptTextToMemory(text, provider.Key, provider.IV);
          return Convert.ToBase64String(encryptedBinary);
      }
    }
    
    public string Decrypt(string encryptedText, string encryptionKey = "") {
      if (string.IsNullOrEmpty(encryptedText)) {
        return encryptedText;
      }

      if (string.IsNullOrEmpty(encryptionKey)) {
        encryptionKey = _encryptionKey;
      }

      using (var provider = new TripleDESCryptoServiceProvider()) {
        provider.Key = Encoding.ASCII.GetBytes(encryptionKey.Substring(0, 16));
        provider.IV = Encoding.ASCII.GetBytes(encryptionKey.Substring(8, 8));

        var buffer = Convert.FromBase64String(encryptedText);
        return DecryptTextFromMemory(buffer, provider.Key, provider.IV);
      }

    }

  }

}