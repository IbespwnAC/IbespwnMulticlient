// Decompiled with JetBrains decompiler
// Type: ACMulticlient.frmProgress
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

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

namespace ACMulticlient
{
  [DesignerGenerated]
  public class frmProgress : Form
  {
    private IContainer components;
    [AccessedThroughProperty("ProgressBar1")]
    private ProgressBar _ProgressBar1;
    [AccessedThroughProperty("Timer1")]
    private Timer _Timer1;
    [AccessedThroughProperty("lblUpdate")]
    private Label _lblUpdate;
    public ListBox lstpaths;
    private long _totalFileSize;
    private long _totalBytesCopied;
    public frmProgress.CopyProgressRoutine _copyProgressRoutine;
    public string srcFolder;
    public List<string> destFolder;

    public virtual ProgressBar ProgressBar1
    {
      [DebuggerNonUserCode] get
      {
        return this._ProgressBar1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ProgressBar1 = value;
      }
    }

    internal virtual Timer Timer1
    {
      [DebuggerNonUserCode] get
      {
        return this._Timer1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
        if (this._Timer1 != null)
          this._Timer1.Tick -= eventHandler;
        this._Timer1 = value;
        if (this._Timer1 == null)
          return;
        this._Timer1.Tick += eventHandler;
      }
    }

    internal virtual Label lblUpdate
    {
      [DebuggerNonUserCode] get
      {
        return this._lblUpdate;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lblUpdate = value;
      }
    }

    public frmProgress()
    {
      this.Load += new EventHandler(this.frmProgress_Load);
      this._totalFileSize = 0L;
      this._totalBytesCopied = 0L;
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.ProgressBar1 = new ProgressBar();
      this.Timer1 = new Timer(this.components);
      this.lblUpdate = new Label();
      this.SuspendLayout();
      ProgressBar progressBar1_1 = this.ProgressBar1;
      Point point1 = new Point(12, 12);
      Point point2 = point1;
      progressBar1_1.Location = point2;
      this.ProgressBar1.Maximum = 110;
      this.ProgressBar1.Name = "ProgressBar1";
      ProgressBar progressBar1_2 = this.ProgressBar1;
      Size size1 = new Size(295, 23);
      Size size2 = size1;
      progressBar1_2.Size = size2;
      this.ProgressBar1.TabIndex = 1;
      this.Timer1.Enabled = true;
      this.Timer1.Interval = 2000;
      Label lblUpdate1 = this.lblUpdate;
      point1 = new Point(12, 38);
      Point point3 = point1;
      lblUpdate1.Location = point3;
      this.lblUpdate.Name = "lblUpdate";
      Label lblUpdate2 = this.lblUpdate;
      size1 = new Size(295, 17);
      Size size3 = size1;
      lblUpdate2.Size = size3;
      this.lblUpdate.TabIndex = 2;
      this.lblUpdate.Text = "Initializing...";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(319, 54);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.lblUpdate);
      this.Controls.Add((Control) this.ProgressBar1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "frmProgress";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Copy Folder Progress";
      this.ResumeLayout(false);
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int CopyFileEx([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpExistingFileName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpNewFileName, frmProgress.CopyProgressRoutine lpProgressRoutine, int lpData, int lpBool, int dwCopyFlags);

    private int CopyProgress(long totalFileSize, long totalBytesTransferred, long streamSize, long streamBytesTransferred, int dwStreamNumber, int dwCallbackReason, int hSourceFile, int hDestinationFile, int lpData)
    {
      int num1 = Convert.ToInt32((double) checked (this._totalBytesCopied + totalBytesTransferred) / (double) this._totalFileSize * 100.0);
      if (num1 < this.ProgressBar1.Maximum)
        this.ProgressBar1.Value = num1;
      if (this.Disposing)
        return 1;
      Application.DoEvents();
      int num2;
      return num2;
    }

    public void GetTotalFileSize(DirectoryInfo folder)
    {
      FileInfo[] files = folder.GetFiles();
      int index1 = 0;
      while (index1 < files.Length)
      {
        this._totalFileSize = checked (this._totalFileSize + files[index1].Length);
        checked { ++index1; }
      }
      DirectoryInfo[] directories = folder.GetDirectories();
      int index2 = 0;
      while (index2 < directories.Length)
      {
        DirectoryInfo folder1 = directories[index2];
        bool flag = false;
        try
        {
          foreach (object obj in this.lstpaths.Items)
          {
            string str = Conversions.ToString(obj);
            if (Operators.CompareString(folder1.FullName.ToLower(), str.ToLower(), false) == 0)
              flag = true;
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (File.Exists(Path.Combine(folder1.FullName, "acclient.exe")))
          flag = true;
        if (!flag)
          this.GetTotalFileSize(folder1);
        checked { ++index2; }
      }
    }

    private int CopyFiles(DirectoryInfo folder, string destinationFolder)
    {
      if (!Directory.Exists(destinationFolder))
        Directory.CreateDirectory(destinationFolder);
      FileInfo[] files = folder.GetFiles();
      int index1 = 0;
      while (index1 < files.Length)
      {
        FileInfo fileInfo1 = files[index1];
        string lpNewFileName = destinationFolder + "\\" + fileInfo1.Name;
        bool flag = true;
        if (File.Exists(lpNewFileName))
        {
          FileInfo fileInfo2 = new FileInfo(lpNewFileName);
          if (fileInfo2.Length == fileInfo1.Length && DateTime.Compare(fileInfo1.LastWriteTime, fileInfo2.LastWriteTime) == 0)
            flag = false;
        }
        if (flag)
        {
          string fullName = fileInfo1.FullName;
          if (frmProgress.CopyFileEx(ref fullName, ref lpNewFileName, this._copyProgressRoutine, 0, 0, 0) == 0)
            return 0;
        }
        this._totalBytesCopied = checked (this._totalBytesCopied + fileInfo1.Length);
        checked { ++index1; }
      }
      DirectoryInfo[] directories = folder.GetDirectories();
      int index2 = 0;
      while (index2 < directories.Length)
      {
        DirectoryInfo folder1 = directories[index2];
        bool flag = false;
        try
        {
          foreach (object obj in this.lstpaths.Items)
          {
            string str = Conversions.ToString(obj);
            if (Operators.CompareString(folder1.FullName.ToLower(), str.ToLower(), false) == 0)
              flag = true;
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (File.Exists(Path.Combine(folder1.FullName, "acclient.exe")))
          flag = true;
        if (!flag && this.CopyFiles(folder1, Path.Combine(destinationFolder, folder1.Name)) == 0)
          return 0;
        checked { ++index2; }
      }
      return -1;
    }

    private void frmProgress_Load(object sender, EventArgs e)
    {
      this._copyProgressRoutine = new frmProgress.CopyProgressRoutine(this.CopyProgress);
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Stop();
      List<string>.Enumerator enumerator;
      try
      {
        enumerator = this.destFolder.GetEnumerator();
        while (enumerator.MoveNext())
        {
          string current = enumerator.Current;
          this._totalFileSize = 0L;
          this._totalBytesCopied = 0L;
          this.GetTotalFileSize(new DirectoryInfo(this.srcFolder));
          this.ProgressBar1.Value = 0;
          this.lblUpdate.Text = "Updating folder: " + current;
          this.CopyFiles(new DirectoryInfo(this.srcFolder), current);
        }
      }
      finally
      {
        enumerator.Dispose();
      }
      this.DialogResult = DialogResult.OK;
    }

    public delegate int CopyProgressRoutine(long totalFileSize, long totalBytesTransferred, long streamSize, long streamBytesTransferred, int dwStreamNumber, int dwCallbackReason, int hSourceFile, int hDestinationFile, int lpData);
  }
}
