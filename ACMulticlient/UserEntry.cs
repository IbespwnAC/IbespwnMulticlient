namespace ACMulticlient
{
  using System;
  using System.Xml.Serialization;
  using ACMulticlient.My;
  using System.Text;
  using System.Windows.Forms;

  public class UserEntry
  {
    public string name;
    public string secret_str;
    public string key1_str;
    public string key2_str;

    [XmlIgnore]
    private Byte[] secret;
    [XmlIgnore]
    private Byte[] key1;
    [XmlIgnore]
    private Byte[] key2;
    [XmlIgnore]
    public string usedACpath;
    [XmlIgnore]
    public string usedworld;

    public UserEntry()
    {
      init();
    }

    private void init()
    {
      if (secret != null || secret_str == null || secret_str == "")
      {
        return;
      }

      secret = System.Text.Encoding.Unicode.GetBytes(secret_str);
      key1 = System.Text.Encoding.Unicode.GetBytes(key1_str);
      key2 = System.Text.Encoding.Unicode.GetBytes(key2_str);
    }

    public void setSecret(ref string p_secret)
    {
      if (p_secret == "")
      {
        secret = new Byte[0];

        return;
      }

      Byte[] bytes = EncLib.string_to_bytes(p_secret);
      EncLib.shred(ref p_secret);

      secret = EncLib.encrypt(bytes, ref key1, ref key2);
      secret_str = System.Text.Encoding.Unicode.GetString(secret);
      key1_str = System.Text.Encoding.Unicode.GetString(key1);
      key2_str = System.Text.Encoding.Unicode.GetString(key2);

      EncLib.shred(ref bytes);
    }

    public void setSecret(ref TextBox txtbox, string DEF_STRING)
    {
      if (txtbox.Text == "" || txtbox.Text == DEF_STRING)
      {
        return;
      }

      string txt = txtbox.Text;

      txtbox.Text = DEF_STRING;

      setSecret(ref txt);
    }

    public string getSecret()
    {
      init();

      if (isSecretNull())
      {
        return "";
      }
      else
      {
        return EncLib.bytes_to_string(EncLib.decrypt(secret, key1, key2)).Trim(new char[] {'\0'});
      }
    }

    public void clearSecret()
    {
      EncLib.shred(ref secret);
    }

    public override string ToString()
    {
      init();

      if (string.IsNullOrEmpty(this.name))
      {
        return "(null)";
      }
      return this.name;
    }

    public bool isSecretNull()
    {
      init();

      return (secret == null || secret.Length == 0);
    }
  }
}

