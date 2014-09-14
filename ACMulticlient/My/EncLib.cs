using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ACMulticlient.My
{
	class EncLib
	{
    private static EncLib instance;
    private static Aes aes;
    private static Random rnd;

    private EncLib()
    {
      rnd = new Random();
      aes = Aes.Create();

      aes.Mode = CipherMode.CBC;
      aes.Padding = PaddingMode.Zeros;
      aes.KeySize = 256;
    }

    private static void init()
    {
      if (instance == null)
      {
        instance = new EncLib();
      }
    }

    public static Byte[] encrypt(Byte[] bytes, ref Byte[] symmetricKey, ref Byte[] ivKey)
    {
      EncLib.init();

      aes.GenerateKey();
      aes.GenerateIV();

      symmetricKey = aes.Key;
      ivKey = aes.IV;

      ICryptoTransform encryptor = aes.CreateEncryptor();

      return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
    }

    public static Byte[] decrypt(Byte[] bytes, Byte[] symmetricKey, Byte[] ivKey)
    {
      EncLib.init();

      aes.Key = symmetricKey;
      aes.IV = ivKey;

      ICryptoTransform decryptor = aes.CreateDecryptor();

      return decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
    }

    public static string bytes_to_string(Byte[] bytes)
    {
      StringBuilder strb = new StringBuilder(bytes.Length);

      for (int i = 0; i < bytes.Length; ++i)
      {
        strb.Append((char) bytes[i]);
      }

      return strb.ToString();
    }

    public static Byte[] string_to_bytes(string str)
    {
      Byte[] bytes = new Byte[str.Length];

      for (int i = 0; i < str.Length; ++i)
      {
        bytes[i] = (byte) (str[i] & 0xff);
      }

      return bytes;
    }

    public static void shred(ref string p_value)
    {
      StringBuilder new_string = new StringBuilder(p_value.Length);

      init();

      for (int i = 0; i < p_value.Length; ++i)
      {
        new_string.Append((char) nextByte());
      }

      p_value = new_string.ToString();
    }

    public static void shred(ref Byte[] p_value)
    {
      init();

      for (int i = 0; i < p_value.Length; ++i)
      {
        p_value[i] = nextByte();
      }

      p_value = null;
    }

    private static byte nextByte()
    {
      return (byte) rnd.Next(0, 255);
    }
  }
}
