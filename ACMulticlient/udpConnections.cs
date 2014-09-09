namespace ACMulticlient
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal class udpConnections
    {
        private const int CMIB_UDPROW_SIZE = 8;
        private List<int> mOpenPorts;

        [DllImport("iphlpapi.dll", SetLastError=true)]
        private static extern int GetUdpTable(byte[] pUdpTable, ref int pdwSize, bool bOrder);
        public bool isPortInUse(int pcheck)
        {
            if (this.mOpenPorts == null)
            {
                this.RefeshTable();
            }
            if (this.mOpenPorts != null)
            {
                foreach (int num in this.mOpenPorts)
                {
                    if (pcheck == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RefeshTable()
        {
            try
            {
                int pdwSize = 0x324;
                byte[] pUdpTable = new byte[pdwSize + 1];
                int num = GetUdpTable(pUdpTable, ref pdwSize, true);
                if (num == 0x7a)
                {
                    pUdpTable = new byte[pdwSize + 1];
                    num = GetUdpTable(pUdpTable, ref pdwSize, true);
                }
                if (num != 0)
                {
                    Interaction.MsgBox("iphlpapi->GetUdpTable returned: " + Conversions.ToString(num), MsgBoxStyle.Critical, "Error");
                }
                else
                {
                    this.mOpenPorts = new List<int>();
                    if ((pUdpTable != null) && (pUdpTable.Length >= 4))
                    {
                        int num3 = 0;
                        num3 = BitConverter.ToInt32(pUdpTable, 0);
                        if (pUdpTable.Length >= num3)
                        {
                            int num2 = 0;
                            byte[] destinationArray = new byte[9];
                            while (num2 < num3)
                            {
                                int sourceIndex = (num2 * 8) + 4;
                                Array.Copy(pUdpTable, sourceIndex, destinationArray, 0, 8);
                                uint num5 = BitConverter.ToUInt32(destinationArray, 4);
                                int item = (int) (((num5 >> 8) & 0xffL) + ((num5 & 0xffL) << 8));
                                this.mOpenPorts.Add(item);
                                num2++;
                            }
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Error");
                ProjectData.ClearProjectError();
            }
        }
    }
}

