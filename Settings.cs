// Decompiled with JetBrains decompiler
// Type: ACMulticlient.Settings
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using System.Collections.Generic;

namespace ACMulticlient
{
  public class Settings
  {
    public string[] availableworlds;
    public string[] selectedworlds;
    public string Defaultworld;
    public bool startdecal;
    public List<UserEntry> accounts;
    public int[] ACPorts;
    public List<string> LaunchPaths;
    public string acmainpath;

    public Settings()
    {
      this.availableworlds = new string[9]
      {
        "Frostfell",
        "Harvestgain",
        "Leafcull",
        "Morningthaw",
        "Solclaim",
        "Thistledown",
        "Verdatine",
        "Wintersebb",
        "Darktide"
      };
      this.selectedworlds = new string[2]
      {
        "Morningthaw",
        "Darktide"
      };
      this.Defaultworld = "Morningthaw";
      this.startdecal = true;
      this.ACPorts = new int[3]
      {
        9000,
        9005,
        9010
      };
    }
  }
}
