// Decompiled with JetBrains decompiler
// Type: ACMulticlient.UserEntry
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using System.Diagnostics;
using System.Xml.Serialization;

namespace ACMulticlient
{
  public class UserEntry
  {
    public string name;
    [XmlIgnore]
    public byte[] secret;
    [XmlIgnore]
    public string usedACpath;
    [XmlIgnore]
    public string usedworld;

    [DebuggerNonUserCode]
    public UserEntry()
    {
    }

    public override string ToString()
    {
      if (string.IsNullOrEmpty(this.name))
        return "(null)";
      else
        return this.name;
    }
  }
}
