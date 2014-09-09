namespace ACMulticlient
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class frmProgress : Form
    {
        public CopyProgressRoutine _copyProgressRoutine;
        [AccessedThroughProperty("lblUpdate")]
        private Label _lblUpdate;
        [AccessedThroughProperty("ProgressBar1")]
        private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("Timer1")]
        private Timer _Timer1;
        private long _totalBytesCopied;
        private long _totalFileSize;
        private IContainer components;
        public List<string> destFolder;
        public ListBox lstpaths;
        public string srcFolder;

        public frmProgress()
        {
            base.Load += new EventHandler(this.frmProgress_Load);
            this._totalFileSize = 0L;
            this._totalBytesCopied = 0L;
            this.InitializeComponent();
        }

        [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern int CopyFileEx([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpExistingFileName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpNewFileName, CopyProgressRoutine lpProgressRoutine, int lpData, int lpBool, int dwCopyFlags);
        private int CopyFiles(DirectoryInfo folder, string destinationFolder)
        {
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }
            foreach (FileInfo info in folder.GetFiles())
            {
                string path = destinationFolder + @"\" + info.Name;
                string full_path = info.FullName;
                bool flag2 = true;

                if (File.Exists(path))
                {
                    FileInfo info2 = new FileInfo(path);
                    if ((info2.Length == info.Length) && (DateTime.Compare(info.LastWriteTime, info2.LastWriteTime) == 0))
                    {
                        flag2 = false;
                    }
                }
                if (flag2 && (CopyFileEx(ref full_path, ref path, this._copyProgressRoutine, 0, 0, 0) == 0))
                {
                    return 0;
                }
                this._totalBytesCopied += info.Length;
            }
            foreach (DirectoryInfo info3 in folder.GetDirectories())
            {
                IEnumerator enumerator = null;
                bool flag = false;
                try
                {
                    enumerator = this.lstpaths.Items.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        string str2 = Conversions.ToString(enumerator.Current);
                        if (info3.FullName.ToLower() == str2.ToLower())
                        {
                            flag = true;
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (File.Exists(Path.Combine(info3.FullName, "acclient.exe")))
                {
                    flag = true;
                }
                if (!flag && (this.CopyFiles(info3, Path.Combine(destinationFolder, info3.Name)) == 0))
                {
                    return 0;
                }
            }
            return -1;
        }

        private int CopyProgress(long totalFileSize, long totalBytesTransferred, long streamSize, long streamBytesTransferred, int dwStreamNumber, int dwCallbackReason, int hSourceFile, int hDestinationFile, int lpData)
        {
            int num = 0;
            int num2 = Convert.ToInt32((double) ((((double) (this._totalBytesCopied + totalBytesTransferred)) / ((double) this._totalFileSize)) * 100.0));
            if (num2 < this.ProgressBar1.Maximum)
            {
                this.ProgressBar1.Value = num2;
            }
            if (this.Disposing)
            {
                return 1;
            }
            Application.DoEvents();
            return num;
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
            this._copyProgressRoutine = new CopyProgressRoutine(this.CopyProgress);
        }

        public void GetTotalFileSize(DirectoryInfo folder)
        {
            foreach (FileInfo info in folder.GetFiles())
            {
                this._totalFileSize += info.Length;
            }
            foreach (DirectoryInfo info2 in folder.GetDirectories())
            {
                IEnumerator enumerator = null;
                bool flag = false;
                try
                {
                    enumerator = this.lstpaths.Items.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        string str = Conversions.ToString(enumerator.Current);
                        if (info2.FullName.ToLower() == str.ToLower())
                        {
                            flag = true;
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (File.Exists(Path.Combine(info2.FullName, "acclient.exe")))
                {
                    flag = true;
                }
                if (!flag)
                {
                    this.GetTotalFileSize(info2);
                }
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProgressBar1 = new ProgressBar();
            this.Timer1 = new Timer(this.components);
            this.lblUpdate = new Label();
            this.SuspendLayout();
            Point point = new Point(12, 12);
            this.ProgressBar1.Location = point;
            this.ProgressBar1.Maximum = 110;
            this.ProgressBar1.Name = "ProgressBar1";
            Size size = new Size(0x127, 0x17);
            this.ProgressBar1.Size = size;
            this.ProgressBar1.TabIndex = 1;
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 0x7d0;
            point = new Point(12, 0x26);
            this.lblUpdate.Location = point;
            this.lblUpdate.Name = "lblUpdate";
            size = new Size(0x127, 0x11);
            this.lblUpdate.Size = size;
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.Text = "Initializing...";
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x13f, 0x36);
            this.ClientSize = size;
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.ProgressBar1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "frmProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Copy Folder Progress";
            this.ResumeLayout(false);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer1.Stop();
            foreach (string str in this.destFolder)
            {
                this._totalFileSize = 0L;
                this._totalBytesCopied = 0L;
                this.GetTotalFileSize(new DirectoryInfo(this.srcFolder));
                this.ProgressBar1.Value = 0;
                this.lblUpdate.Text = "Updating folder: " + str;
                int num = this.CopyFiles(new DirectoryInfo(this.srcFolder), str);
            }
            this.DialogResult = DialogResult.OK;
        }

        internal virtual Label lblUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblUpdate = value;
            }
        }

        public virtual ProgressBar ProgressBar1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ProgressBar1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ProgressBar1 = value;
            }
        }

        internal virtual Timer Timer1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Timer1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Timer1_Tick);
                if (this._Timer1 != null)
                {
                    this._Timer1.Tick -= handler;
                }
                this._Timer1 = value;
                if (this._Timer1 != null)
                {
                    this._Timer1.Tick += handler;
                }
            }
        }

        public delegate int CopyProgressRoutine(long totalFileSize, long totalBytesTransferred, long streamSize, long streamBytesTransferred, int dwStreamNumber, int dwCallbackReason, int hSourceFile, int hDestinationFile, int lpData);
    }
}

