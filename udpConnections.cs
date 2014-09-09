// Decompiled with JetBrains decompiler
// Type: ACMulticlient.udpConnections
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ACMulticlient
{
  internal class udpConnections
  {
    private List<int> mOpenPorts;
    private const int CMIB_UDPROW_SIZE = 8;

    [DebuggerNonUserCode]
    public udpConnections()
    {
    }

    [DllImport("iphlpapi.dll", SetLastError = true)]
    private static extern int GetUdpTable(byte[] pUdpTable, ref int pdwSize, bool bOrder);

    public bool isPortInUse(int pcheck)
    {
      if (this.mOpenPorts == null)
        this.RefeshTable();
      List<int>.Enumerator enumerator;
      if (this.mOpenPorts != null)
      {
        try
        {
          enumerator = this.mOpenPorts.GetEnumerator();
          while (enumerator.MoveNext())
          {
            int current = enumerator.Current;
            if (pcheck == current)
              return true;
          }
        }
        finally
        {
          enumerator.Dispose();
        }
      }
      return false;
    }

    public void RefeshTable()
    {
      try
      {
        int pdwSize = 804;
        byte[] pUdpTable = new byte[checked (pdwSize + 1)];
        int udpTable = udpConnections.GetUdpTable(pUdpTable, ref pdwSize, true);
        if (udpTable == 122)
        {
          pUdpTable = new byte[checked (pdwSize + 1)];
          udpTable = udpConnections.GetUdpTable(pUdpTable, ref pdwSize, true);
        }
        if (udpTable != 0)
        {
          int num1 = (int) Interaction.MsgBox((object) ("iphlpapi->GetUdpTable returned: " + Conversions.ToString(udpTable)), MsgBoxStyle.Critical, (object) "Error");
        }
        else
        {
          this.mOpenPorts = new List<int>();
          if (pUdpTable == null || pUdpTable.Length < 4)
            return;
          int num2 = BitConverter.ToInt32(pUdpTable, 0);
          if (pUdpTable.Length < num2)
            return;
          int num3 = 0;
          byte[] numArray = new byte[9];
          while (num3 < num2)
          {
            int sourceIndex = checked (num3 * 8 + 4);
            Array.Copy((Array) pUdpTable, sourceIndex, (Array) numArray, 0, 8);
            uint num4 = BitConverter.ToUInt32(numArray, 4);
            this.mOpenPorts.Add(checked ((int) (((long) (num4 >> 8) & (long) byte.MaxValue) + (((long) num4 & (long) byte.MaxValue) << 8))));
            checked { ++num3; }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Error");
        ProjectData.ClearProjectError();
      }
    }
  }
}
