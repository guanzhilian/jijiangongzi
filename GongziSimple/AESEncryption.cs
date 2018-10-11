// Decompiled with JetBrains decompiler
// Type: GongziSimple.AESEncryption
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GongziSimple
{
  internal class AESEncryption
  {
    private static byte[] _key1 = new byte[16]
    {
      (byte) 18,
      (byte) 52,
      (byte) 86,
      (byte) 120,
      (byte) 144,
      (byte) 171,
      (byte) 205,
      (byte) 239,
      (byte) 18,
      (byte) 52,
      (byte) 86,
      (byte) 120,
      (byte) 144,
      (byte) 171,
      (byte) 205,
      (byte) 239
    };

    public static byte[] AESEncrypt(string plainText, string strKey)
    {
      SymmetricAlgorithm symmetricAlgorithm = (SymmetricAlgorithm) Rijndael.Create();
      byte[] bytes = Encoding.UTF8.GetBytes(plainText);
      symmetricAlgorithm.Key = Encoding.UTF8.GetBytes(strKey);
      symmetricAlgorithm.IV = AESEncryption._key1;
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(bytes, 0, bytes.Length);
      cryptoStream.FlushFinalBlock();
      byte[] array = memoryStream.ToArray();
      cryptoStream.Close();
      memoryStream.Close();
      return array;
    }

    public static byte[] AESDecrypt(byte[] cipherText, string strKey)
    {
      SymmetricAlgorithm symmetricAlgorithm = (SymmetricAlgorithm) Rijndael.Create();
      symmetricAlgorithm.Key = Encoding.UTF8.GetBytes(strKey);
      symmetricAlgorithm.IV = AESEncryption._key1;
      byte[] buffer = new byte[cipherText.Length];
      MemoryStream memoryStream = new MemoryStream(cipherText);
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);
      cryptoStream.Read(buffer, 0, buffer.Length);
      cryptoStream.Close();
      memoryStream.Close();
      return buffer;
    }
  }
}
