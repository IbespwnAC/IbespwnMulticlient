namespace ACMulticlient
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;

    public class SecureTextbox : TextBox
    {
        private bool mModified;
        private bool mProcessKey = false;
        private SecureString mText = new SecureString();

        public void ClearText(bool setmask)
        {
            if (setmask)
            {
                this.Text = "*******";
            }
            else
            {
                this.Text = string.Empty;
            }
            this.mModified = false;
            this.mText.Clear();
        }

        public byte[] getData(ref byte[] entrophy)
        {
            byte[] bytes;
            char[] destination = new char[(this.mText.Length - 1) + 1];
            IntPtr zero = IntPtr.Zero;
            try
            {
                zero = Marshal.SecureStringToBSTR(this.mText);
                Marshal.Copy(zero, destination, 0, this.mText.Length);
                bytes = Encoding.UTF8.GetBytes(destination);
                bytes = ProtectedData.Protect(bytes, entrophy, DataProtectionScope.CurrentUser);
            }
            finally
            {
                if (!zero.Equals(IntPtr.Zero))
                {
                    Marshal.ZeroFreeBSTR(zero);
                }
                int num2 = this.mText.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    destination[i] = '\0';
                }
                destination = new char[0];
            }
            return bytes;
        }

        public byte[] getHash()
        {
            byte[] buffer2;
            char[] destination = new char[(this.mText.Length - 1) + 1];
            SHA512 sha = new SHA512Managed();
            IntPtr zero = IntPtr.Zero;
            try
            {
                zero = Marshal.SecureStringToBSTR(this.mText);
                Marshal.Copy(zero, destination, 0, this.mText.Length);
                byte[] buffer3 = new byte[] { 13, 2, 0x21, 0xe7, 0xd3, 0x7a, 0x7b, 0x7b, 7 };
                buffer2 = sha.ComputeHash(Encoding.UTF8.GetBytes(destination));
            }
            finally
            {
                if (!zero.Equals(IntPtr.Zero))
                {
                    Marshal.ZeroFreeBSTR(zero);
                }
                int num2 = this.mText.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    destination[i] = '\0';
                }
                destination = new char[0];
            }
            return buffer2;
        }

        public bool isEqual(byte[] comparehash)
        {
            bool flag = false;
            try
            {
                byte[] buffer = this.getHash();
                if (buffer.Length != comparehash.Length)
                {
                    return false;
                }
                int num2 = buffer.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if (buffer[i] != comparehash[i])
                    {
                        return false;
                    }
                }
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, null);
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        protected override bool IsInputChar(char charCode)
        {
            bool flag = base.IsInputChar(charCode);
            if (flag)
            {
                if (!this.isModified() && (this.Text.Length > this.mText.Length))
                {
                    this.Text = string.Empty;
                    this.SelectionLength = 0;
                }
                int num = charCode;
                int selectionStart = this.SelectionStart;
                if ((!char.IsControl(charCode) && !char.IsHighSurrogate(charCode)) && !char.IsLowSurrogate(charCode))
                {
                    if (this.SelectionLength > 0)
                    {
                        int selectionLength = this.SelectionLength;
                        for (int i = 1; i <= selectionLength; i++)
                        {
                            this.mText.RemoveAt(this.SelectionStart);
                        }
                    }
                    if (selectionStart == this.mText.Length)
                    {
                        this.mText.AppendChar(charCode);
                    }
                    else
                    {
                        this.mText.InsertAt(selectionStart, charCode);
                    }
                    this.Text = new string('*', this.mText.Length);
                    selectionStart++;
                    this.mProcessKey = false;
                    this.SelectionStart = selectionStart;
                    this.mModified = true;
                    return flag;
                }
                if (8 == num)
                {
                    if ((this.SelectionLength == 0) && (selectionStart > 0))
                    {
                        selectionStart--;
                        this.mText.RemoveAt(selectionStart);
                    }
                    else if (this.SelectionLength > 0)
                    {
                        int num6 = this.SelectionLength;
                        for (int j = 1; j <= num6; j++)
                        {
                            this.mText.RemoveAt(this.SelectionStart);
                        }
                    }
                    this.mModified = true;
                    this.mProcessKey = true;
                    return flag;
                }
                if (num == 0x16)
                {
                    this.mProcessKey = false;
                }
                return flag;
            }
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
                    {
                        this.mText.Clear();
                    }
                    else if (this.SelectionLength > 0)
                    {
                        int selectionLength = this.SelectionLength;
                        for (int i = 1; i <= selectionLength; i++)
                        {
                            this.mText.RemoveAt(this.SelectionStart);
                        }
                    }
                    else if (this.SelectionStart < this.Text.Length)
                    {
                        this.mText.RemoveAt(this.SelectionStart);
                    }
                }
                else if ((keyData & Keys.Tab) == Keys.Tab)
                {
                    return base.IsInputKey(keyData);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
            return true;
        }

        public bool isModified()
        {
            return this.mModified;
        }

        protected override bool ProcessKeyMessage(ref Message m)
        {
            if (this.mProcessKey)
            {
                return base.ProcessKeyMessage(ref m);
            }
            this.mProcessKey = true;
            return true;
        }

        public SecureString SecureText
        {
            get
            {
                return this.mText;
            }
        }
    }
}

