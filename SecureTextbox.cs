// Decompiled with JetBrains decompiler
// Type: ACMulticlient.SecureTextbox
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ACMulticlient
{
  public class SecureTextbox : TextBox
  {
    private SecureString mText;
    private bool mProcessKey;
    private bool mModified;

    public SecureString SecureText
    {
      get
      {
        return this.mText;
      }
    }

    public SecureTextbox()
    {
      this.mText = new SecureString();
      this.mProcessKey = false;
    }

    public bool isModified()
    {
      return this.mModified;
    }

    public byte[] getData(ref byte[] entrophy)
    {
      char[] chArray1 = new char[checked (this.mText.Length - 1 + 1)];
      IntPtr num1 = IntPtr.Zero;
      try
      {
        num1 = Marshal.SecureStringToBSTR(this.mText);
        Marshal.Copy(num1, chArray1, 0, this.mText.Length);
        return ProtectedData.Protect(Encoding.UTF8.GetBytes(chArray1), entrophy, DataProtectionScope.CurrentUser);
      }
      finally
      {
        if (!num1.Equals((object) IntPtr.Zero))
          Marshal.ZeroFreeBSTR(num1);
        int num2 = 0;
        int num3 = checked (this.mText.Length - 1);
        int index = num2;
        while (index <= num3)
        {
          chArray1[index] = char.MinValue;
          checked { ++index; }
        }
        char[] chArray2 = new char[0];
      }
    }

    public byte[] getHash()
    {
      char[] chArray1 = new char[checked (this.mText.Length - 1 + 1)];
      SHA512 shA512 = (SHA512) new SHA512Managed();
      IntPtr num1 = IntPtr.Zero;
      try
      {
        num1 = Marshal.SecureStringToBSTR(this.mText);
        Marshal.Copy(num1, chArray1, 0, this.mText.Length);
        byte[] numArray = new byte[9]
        {
          (byte) 13,
          (byte) 2,
          (byte) 33,
          (byte) 231,
          (byte) 211,
          (byte) 122,
          (byte) 123,
          (byte) 123,
          (byte) 7
        };
        return shA512.ComputeHash(Encoding.UTF8.GetBytes(chArray1));
      }
      finally
      {
        if (!num1.Equals((object) IntPtr.Zero))
          Marshal.ZeroFreeBSTR(num1);
        int num2 = 0;
        int num3 = checked (this.mText.Length - 1);
        int index = num2;
        while (index <= num3)
        {
          chArray1[index] = char.MinValue;
          checked { ++index; }
        }
        char[] chArray2 = new char[0];
      }
    }

    public void ClearText(bool setmask)
    {
      if (setmask)
        this.Text = "*******";
      else
        this.Text = string.Empty;
      this.mModified = false;
      this.mText.Clear();
    }

    public bool isEqual(byte[] comparehash)
    {
      bool flag;
      try
      {
        byte[] hash = this.getHash();
        if (hash.Length != comparehash.Length)
        {
          flag = false;
        }
        else
        {
          int num1 = 0;
          int num2 = checked (hash.Length - 1);
          int index = num1;
          while (index <= num2)
          {
            if ((int) hash[index] != (int) comparehash[index])
            {
              flag = false;
              goto label_9;
            }
            else
              checked { ++index; }
          }
          flag = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
label_9:
      return flag;
    }

    protected override bool ProcessKeyMessage(ref Message m)
    {
      if (this.mProcessKey)
        return base.ProcessKeyMessage(ref m);
      this.mProcessKey = true;
      return true;
    }

    protected override bool IsInputChar(char charCode)
    {
      bool flag = base.IsInputChar(charCode);
      if (flag)
      {
        if (!this.isModified() && this.Text.Length > this.mText.Length)
        {
          this.Text = string.Empty;
          this.SelectionLength = 0;
        }
        int num1 = (int) charCode;
        int selectionStart = this.SelectionStart;
        if (!char.IsControl(charCode) && !char.IsHighSurrogate(charCode) && !char.IsLowSurrogate(charCode))
        {
          if (this.SelectionLength > 0)
          {
            int num2 = 1;
            int selectionLength = this.SelectionLength;
            int num3 = num2;
            while (num3 <= selectionLength)
            {
              this.mText.RemoveAt(this.SelectionStart);
              checked { ++num3; }
            }
          }
          if (selectionStart == this.mText.Length)
            this.mText.AppendChar(charCode);
          else
            this.mText.InsertAt(selectionStart, charCode);
          this.Text = new string('*', this.mText.Length);
          int num4 = checked (selectionStart + 1);
          this.mProcessKey = false;
          this.SelectionStart = num4;
          this.mModified = true;
        }
        else if (8 == num1)
        {
          if (this.SelectionLength == 0 && selectionStart > 0)
            this.mText.RemoveAt(checked (selectionStart - 1));
          else if (this.SelectionLength > 0)
          {
            int num2 = 1;
            int selectionLength = this.SelectionLength;
            int num3 = num2;
            while (num3 <= selectionLength)
            {
              this.mText.RemoveAt(this.SelectionStart);
              checked { ++num3; }
            }
          }
          this.mModified = true;
          this.mProcessKey = true;
        }
        else if (num1 == 22)
          this.mProcessKey = false;
      }
      else
        this.mProcessKey = true;
      return flag;
    }

    protected override bool IsInputKey(Keys keyData)
    {
      try
      {
        if ((keyData & Keys.Delete) == Keys.Delete)
        {
          if (this.SelectionLength == this.mText.Length)
            this.mText.Clear();
          else if (this.SelectionLength > 0)
          {
            int num1 = 1;
            int selectionLength = this.SelectionLength;
            int num2 = num1;
            while (num2 <= selectionLength)
            {
              this.mText.RemoveAt(this.SelectionStart);
              checked { ++num2; }
            }
          }
          else if (this.SelectionStart < this.Text.Length)
            this.mText.RemoveAt(this.SelectionStart);
        }
        else if ((keyData & Keys.Tab) == Keys.Tab)
          return base.IsInputKey(keyData);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return true;
    }
  }
}
