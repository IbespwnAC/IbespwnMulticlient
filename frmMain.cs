// Decompiled with JetBrains decompiler
// Type: ACMulticlient.frmMain
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using ACMulticlient.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ACMulticlient
{
  [DesignerGenerated]
  public class frmMain : Form
  {
    private IContainer components;
    [AccessedThroughProperty("lstworld")]
    private ListBox _lstworld;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("cboUsername")]
    private ComboBox _cboUsername;
    [AccessedThroughProperty("btnLaunch")]
    private Button _btnLaunch;
    [AccessedThroughProperty("chkStartDecal")]
    private CheckBox _chkStartDecal;
    [AccessedThroughProperty("lblSetup")]
    private Label _lblSetup;
    [AccessedThroughProperty("lblDelete")]
    private Label _lblDelete;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("txtAc")]
    private SecureTextbox _txtAc;
    [AccessedThroughProperty("ProgressBar1")]
    private ProgressBar _ProgressBar1;
    [AccessedThroughProperty("Timer1")]
    private System.Windows.Forms.Timer _Timer1;
    private const int WM_CUSTOMMSG = 1024;
    private const int WM_CUSTOM_RESTART_ME = 1025;
    private const int WM_CUSTOM_RESTART_TEST = 1026;
    private const int WM_CUSTOM_START_CRASHHELPER = 1027;
    private const uint WM_SYSCOMMAND = 274U;
    private const int SC_CLOSE = 61536;
    private string msettingsFilePath;
    private string mACIniFilePath;
    private Settings msettings;
    private bool mRestartIsPending;
    private IntPtr mrestartAc;
    private string mrestartAcPath;
    private UserEntry mrestartUser;
    private System.Windows.Forms.Timer mLoginTimer;
    private string mproxyclientpath;
    private udpConnections mUdpcon;
    private frmSetup msetup;

    internal virtual ListBox lstworld
    {
      [DebuggerNonUserCode] get
      {
        return this._lstworld;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lstworld = value;
      }
    }

    internal virtual Label Label2
    {
      [DebuggerNonUserCode] get
      {
        return this._Label2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label2 = value;
      }
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get
      {
        return this._Label1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    internal virtual ComboBox cboUsername
    {
      [DebuggerNonUserCode] get
      {
        return this._cboUsername;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboUsername_SelectedIndexChanged);
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.cboUsername_KeyDown);
        if (this._cboUsername != null)
        {
          this._cboUsername.SelectedIndexChanged -= eventHandler;
          this._cboUsername.KeyDown -= keyEventHandler;
        }
        this._cboUsername = value;
        if (this._cboUsername == null)
          return;
        this._cboUsername.SelectedIndexChanged += eventHandler;
        this._cboUsername.KeyDown += keyEventHandler;
      }
    }

    internal virtual Button btnLaunch
    {
      [DebuggerNonUserCode] get
      {
        return this._btnLaunch;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnLaunch_Click);
        if (this._btnLaunch != null)
          this._btnLaunch.Click -= eventHandler;
        this._btnLaunch = value;
        if (this._btnLaunch == null)
          return;
        this._btnLaunch.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkStartDecal
    {
      [DebuggerNonUserCode] get
      {
        return this._chkStartDecal;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkStartDecal_CheckedChanged);
        if (this._chkStartDecal != null)
          this._chkStartDecal.CheckedChanged -= eventHandler;
        this._chkStartDecal = value;
        if (this._chkStartDecal == null)
          return;
        this._chkStartDecal.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblSetup
    {
      [DebuggerNonUserCode] get
      {
        return this._lblSetup;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblSetup_Click);
        if (this._lblSetup != null)
          this._lblSetup.Click -= eventHandler;
        this._lblSetup = value;
        if (this._lblSetup == null)
          return;
        this._lblSetup.Click += eventHandler;
      }
    }

    internal virtual Label lblDelete
    {
      [DebuggerNonUserCode] get
      {
        return this._lblDelete;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.lblDelete_Click);
        if (this._lblDelete != null)
          this._lblDelete.Click -= eventHandler;
        this._lblDelete = value;
        if (this._lblDelete == null)
          return;
        this._lblDelete.Click += eventHandler;
      }
    }

    internal virtual ToolTip ToolTip1
    {
      [DebuggerNonUserCode] get
      {
        return this._ToolTip1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ToolTip1 = value;
      }
    }

    internal virtual SecureTextbox txtAc
    {
      [DebuggerNonUserCode] get
      {
        return this._txtAc;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyPressEventHandler pressEventHandler = new KeyPressEventHandler(this.txtPassword_KeyPress);
        if (this._txtAc != null)
          this._txtAc.KeyPress -= pressEventHandler;
        this._txtAc = value;
        if (this._txtAc == null)
          return;
        this._txtAc.KeyPress += pressEventHandler;
      }
    }

    internal virtual ProgressBar ProgressBar1
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

    internal virtual System.Windows.Forms.Timer Timer1
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

    public frmMain()
    {
      this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new EventHandler(this.frmMain_Load);
      this.mproxyclientpath = string.Empty;
      this.mUdpcon = new udpConnections();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.lstworld = new ListBox();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.cboUsername = new ComboBox();
      this.btnLaunch = new Button();
      this.chkStartDecal = new CheckBox();
      this.ToolTip1 = new ToolTip(this.components);
      this.lblDelete = new Label();
      this.lblSetup = new Label();
      this.ProgressBar1 = new ProgressBar();
      this.Timer1 = new System.Windows.Forms.Timer(this.components);
      this.txtAc = new SecureTextbox();
      this.SuspendLayout();
      this.lstworld.FormattingEnabled = true;
      this.lstworld.Items.AddRange(new object[2]
      {
        (object) "Morningthaw",
        (object) "Darktide"
      });
      ListBox lstworld1 = this.lstworld;
      Point point1 = new Point(239, 5);
      Point point2 = point1;
      lstworld1.Location = point2;
      this.lstworld.Name = "lstworld";
      ListBox lstworld2 = this.lstworld;
      Size size1 = new Size(119, 108);
      Size size2 = size1;
      lstworld2.Size = size2;
      this.lstworld.TabIndex = 13;
      this.Label2.AutoSize = true;
      Label label2_1 = this.Label2;
      point1 = new Point(12, 38);
      Point point3 = point1;
      label2_1.Location = point3;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(53, 13);
      Size size3 = size1;
      label2_2.Size = size3;
      this.Label2.TabIndex = 15;
      this.Label2.Text = "Password";
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(12, 9);
      Point point4 = point1;
      label1_1.Location = point4;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(55, 13);
      Size size4 = size1;
      label1_2.Size = size4;
      this.Label1.TabIndex = 14;
      this.Label1.Text = "Username";
      this.cboUsername.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      this.cboUsername.FormattingEnabled = true;
      ComboBox cboUsername1 = this.cboUsername;
      point1 = new Point(73, 6);
      Point point5 = point1;
      cboUsername1.Location = point5;
      this.cboUsername.Name = "cboUsername";
      ComboBox cboUsername2 = this.cboUsername;
      size1 = new Size(121, 21);
      Size size5 = size1;
      cboUsername2.Size = size5;
      this.cboUsername.TabIndex = 0;
      Button btnLaunch1 = this.btnLaunch;
      point1 = new Point(12, 102);
      Point point6 = point1;
      btnLaunch1.Location = point6;
      this.btnLaunch.Name = "btnLaunch";
      Button btnLaunch2 = this.btnLaunch;
      size1 = new Size(64, 30);
      Size size6 = size1;
      btnLaunch2.Size = size6;
      this.btnLaunch.TabIndex = 4;
      this.btnLaunch.Text = "Login";
      this.ToolTip1.SetToolTip((Control) this.btnLaunch, "Start AC and Save Current Changes");
      this.btnLaunch.UseVisualStyleBackColor = true;
      this.chkStartDecal.AutoSize = true;
      CheckBox chkStartDecal1 = this.chkStartDecal;
      point1 = new Point(15, 66);
      Point point7 = point1;
      chkStartDecal1.Location = point7;
      this.chkStartDecal.Name = "chkStartDecal";
      CheckBox chkStartDecal2 = this.chkStartDecal;
      size1 = new Size(110, 17);
      Size size7 = size1;
      chkStartDecal2.Size = size7;
      this.chkStartDecal.TabIndex = 3;
      this.chkStartDecal.Text = "Start Decal Agent";
      this.chkStartDecal.UseVisualStyleBackColor = true;
      this.lblDelete.Cursor = Cursors.Hand;
      this.lblDelete.Image = (Image) Resources.eventlogError;
      Label lblDelete1 = this.lblDelete;
      point1 = new Point(200, 6);
      Point point8 = point1;
      lblDelete1.Location = point8;
      this.lblDelete.Name = "lblDelete";
      Label lblDelete2 = this.lblDelete;
      size1 = new Size(20, 19);
      Size size8 = size1;
      lblDelete2.Size = size8;
      this.lblDelete.TabIndex = 21;
      this.ToolTip1.SetToolTip((Control) this.lblDelete, "Remove username from list");
      this.lblDelete.Visible = false;
      this.lblSetup.Cursor = Cursors.Hand;
      this.lblSetup.Image = (Image) Resources.services;
      Label lblSetup1 = this.lblSetup;
      point1 = new Point(332, 116);
      Point point9 = point1;
      lblSetup1.Location = point9;
      this.lblSetup.Name = "lblSetup";
      Label lblSetup2 = this.lblSetup;
      size1 = new Size(26, 19);
      Size size9 = size1;
      lblSetup2.Size = size9;
      this.lblSetup.TabIndex = 20;
      this.ToolTip1.SetToolTip((Control) this.lblSetup, "Setup");
      this.ProgressBar1.Dock = DockStyle.Bottom;
      ProgressBar progressBar1_1 = this.ProgressBar1;
      point1 = new Point(0, 139);
      Point point10 = point1;
      progressBar1_1.Location = point10;
      this.ProgressBar1.Name = "ProgressBar1";
      ProgressBar progressBar1_2 = this.ProgressBar1;
      size1 = new Size(363, 10);
      Size size10 = size1;
      progressBar1_2.Size = size10;
      this.ProgressBar1.TabIndex = 22;
      this.Timer1.Enabled = true;
      this.Timer1.Interval = 1000;
      SecureTextbox txtAc1 = this.txtAc;
      point1 = new Point(73, 35);
      Point point11 = point1;
      txtAc1.Location = point11;
      this.txtAc.Name = "txtAc";
      SecureTextbox txtAc2 = this.txtAc;
      size1 = new Size(121, 20);
      Size size11 = size1;
      txtAc2.Size = size11;
      this.txtAc.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(363, 149);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.ProgressBar1);
      this.Controls.Add((Control) this.txtAc);
      this.Controls.Add((Control) this.lblDelete);
      this.Controls.Add((Control) this.lblSetup);
      this.Controls.Add((Control) this.chkStartDecal);
      this.Controls.Add((Control) this.btnLaunch);
      this.Controls.Add((Control) this.cboUsername);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.lstworld);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "frmMain";
      this.Text = "AC Multi Client";
      this.WindowState = FormWindowState.Minimized;
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private static extern int GetModuleFileName(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder filename, int size);

    [DllImport("user32")]
    public static extern IntPtr FindWindow(string lpClass, string lpTitle);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int RegisterWindowMessage(string lpString);

    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int GetPrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDefault, StringBuilder lpReturnedString, int nSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int FlushPrivateProfileString(int lpApplicationName, int lpKeyName, int lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int WritePrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

    [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileIntA", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int GetPrivateProfileInt([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, int nDefault, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

    private void WriteInteger(string Section, string Key, int Value, string filename)
    {
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& lpApplicationName = @Section;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& lpKeyName = @Key;
      string str = Conversions.ToString(Value);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& lpString = @str;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      string& lpFileName = @filename;
      frmMain.WritePrivateProfileString(lpApplicationName, lpKeyName, lpString, lpFileName);
      frmMain.FlushPrivateProfileString(0, 0, 0, ref filename);
    }

    private string GetString(string Section, string Key, string Default, string filename)
    {
      StringBuilder lpReturnedString = new StringBuilder(256);
      if (frmMain.GetPrivateProfileString(ref Section, ref Key, ref Default, lpReturnedString, lpReturnedString.Capacity, ref filename) > 0)
        return lpReturnedString.ToString();
      else
        return string.Empty;
    }

    private int GetInteger(string Section, string Key, int Default, string filename)
    {
      return frmMain.GetPrivateProfileInt(ref Section, ref Key, Default, ref filename);
    }

    private string GetRegistryFilePathVS(string USKey, string value, string filename)
    {
      try
      {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Classes\\VirtualStore\\MACHINE\\" + USKey, false);
        if (registryKey != null)
        {
          string path = Path.Combine(Conversions.ToString(registryKey.GetValue(value, (object) string.Empty)), filename);
          if (File.Exists(path))
            return path;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) null);
        ProjectData.ClearProjectError();
      }
      return string.Empty;
    }

    private string GetRegistryFilePath(string LMkey, string value, string filename)
    {
      try
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(LMkey, false);
        if (registryKey != null)
        {
          string str = Conversions.ToString(registryKey.GetValue(value, (object) string.Empty));
          if (!string.IsNullOrEmpty(filename))
            str = Path.Combine(str, filename);
          if (!File.Exists(str))
          {
            if (!Directory.Exists(str))
              goto label_7;
          }
          return str;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) null);
        ProjectData.ClearProjectError();
      }
label_7:
      return string.Empty;
    }

    private bool SerializeObject(string filename, object instance, string stSheet = "")
    {
      bool flag;
      try
      {
        if (instance == null)
        {
          flag = false;
          goto label_12;
        }
        else
        {
          XmlSerializer xmlSerializer = new XmlSerializer(instance.GetType());
          StreamWriter streamWriter = new StreamWriter(filename);
          if (!string.IsNullOrEmpty(stSheet))
          {
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter((TextWriter) streamWriter))
            {
              xmlTextWriter.Formatting = Formatting.Indented;
              xmlTextWriter.WriteProcessingInstruction("xml-stylesheet", stSheet);
              xmlSerializer.Serialize((XmlWriter) xmlTextWriter, RuntimeHelpers.GetObjectValue(instance));
            }
          }
          else
            xmlSerializer.Serialize((TextWriter) streamWriter, RuntimeHelpers.GetObjectValue(instance));
          streamWriter.Close();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_12;
      }
      return true;
label_12:
      return flag;
    }

    private object DeSerializeObject(string filename, System.Type objectType)
    {
      object obj = (object) null;
      FileStream fileStream = (FileStream) null;
      try
      {
        if (File.Exists(filename))
        {
          XmlSerializer xmlSerializer = new XmlSerializer(objectType);
          fileStream = new FileStream(filename, FileMode.Open);
          obj = RuntimeHelpers.GetObjectValue(xmlSerializer.Deserialize((Stream) fileStream));
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      finally
      {
        if (fileStream != null)
          fileStream.Close();
      }
      return obj;
    }

    private void startdecal()
    {
      try
      {
        string registryFilePath = this.GetRegistryFilePath("SOFTWARE\\Decal\\Agent", "AgentPath", "Denagent.exe");
        if (string.IsNullOrEmpty(registryFilePath))
        {
          int num = (int) Interaction.MsgBox((object) "Cannot find Decal Agent", MsgBoxStyle.Critical, (object) null);
        }
        else
        {
          if (!File.Exists(registryFilePath))
            return;
          Process[] processesByName = Process.GetProcessesByName("denagent");
          if (processesByName != null && Enumerable.Count<Process>((IEnumerable<Process>) processesByName) > 0)
            return;
          Process.Start(new ProcessStartInfo(registryFilePath));
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      if (this.mLoginTimer != null && this.mLoginTimer.Enabled)
        this.ProgressBar1.PerformStep();
      else
        this.ProgressBar1.Value = 0;
    }

    private bool closelauncherDialog()
    {
      IntPtr window = frmMain.FindWindow((string) null, "Failure");
      if (window.Equals((object) IntPtr.Zero))
      {
        bool flag;
        return flag;
      }
      frmMain.SendMessage(window, 274U, 61536, 0);
      return true;
    }

    private void restartACAndLogin(object sender, EventArgs e)
    {
      this.btnLaunch.Enabled = false;
      try
      {
        this.mLoginTimer.Tick -= new EventHandler(this.restartACAndLogin);
        this.mLoginTimer.Stop();
        this.relaunchac(this.mrestartUser, this.mrestartAcPath);
        this.mRestartIsPending = false;
      }
      finally
      {
        this.btnLaunch.Enabled = true;
      }
    }

    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case 1025:
        case 1026:
          if (this.mRestartIsPending)
          {
            m.Result = new IntPtr(3);
            break;
          }
          else
          {
            IntPtr num1 = IntPtr.Zero;
            if (num1.Equals((object) m.WParam))
              break;
            string str = string.Empty;
            Process processById = Process.GetProcessById((int) m.WParam);
            if (processById == null)
              break;
            string directoryName = Path.GetDirectoryName(processById.MainModule.FileName);
            string filename = Path.Combine(directoryName, "launcher.ini");
            UserEntry userentry = this.getUserentry(this.GetString("LAUNCHER", "DefaultUsername", string.Empty, filename));
            if (userentry == null)
              break;
            // ISSUE: explicit reference operation
            // ISSUE: variable of a reference type
            Message& local = @m;
            num1 = new IntPtr(1);
            IntPtr num2 = num1;
            // ISSUE: explicit reference operation
            (^local).Result = num2;
            this.mRestartIsPending = true;
            if (m.Msg != 1025)
              break;
            this.mrestartAc = m.LParam;
            this.mrestartUser = userentry;
            this.mrestartAcPath = directoryName;
            this.mLoginTimer = new System.Windows.Forms.Timer();
            this.mLoginTimer.Interval = 10000;
            this.mLoginTimer.Tick += new EventHandler(this.restartACAndLogin);
            this.mLoginTimer.Start();
            if (IntPtr.Zero.Equals((object) this.mrestartAc))
              break;
            frmMain.SendMessage(this.mrestartAc, 274U, 61536, 0);
            break;
          }
        case 1027:
          IntPtr.Zero.Equals((object) m.WParam);
          if (!IntPtr.Zero.Equals((object) m.LParam))
            break;
          else
            break;
        default:
          base.WndProc(ref m);
          break;
      }
    }

    private void btnMoreports_Click(object sender, EventArgs e)
    {
      this.msetup.acPorts.Addmore();
    }

    private void lblSetup_Click(object sender, EventArgs e)
    {
      if (this.msetup == null || this.msetup.IsDisposed)
      {
        this.msetup = new frmSetup();
        this.msetup.btnMoreports.Click += new EventHandler(this.btnMoreports_Click);
      }
      if (this.msettings != null)
      {
        Settings settings = this.msettings;
        this.msetup.txtACMainpath.Text = this.msettings.acmainpath;
        this.msetup.acPorts.setPorts(settings.ACPorts);
        if (settings.availableworlds != null && Enumerable.Count<string>((IEnumerable<string>) settings.availableworlds) > 0)
        {
          this.msetup.lstWorlds.Items.Clear();
          string[] strArray = settings.availableworlds;
          int index = 0;
          while (index < strArray.Length)
          {
            string str = strArray[index];
            if (Enumerable.Contains<string>((IEnumerable<string>) settings.selectedworlds, str))
              this.msetup.lstWorlds.Items.Add((object) str, true);
            else
              this.msetup.lstWorlds.Items.Add((object) str, false);
            checked { ++index; }
          }
        }
        this.msetup.lstPaths.Items.Clear();
        List<string>.Enumerator enumerator;
        try
        {
          enumerator = settings.LaunchPaths.GetEnumerator();
          while (enumerator.MoveNext())
            this.msetup.lstPaths.Items.Add((object) enumerator.Current);
        }
        finally
        {
          enumerator.Dispose();
        }
      }
      if (this.msetup.ShowDialog() == DialogResult.OK)
      {
        this.msettings.LaunchPaths.Clear();
        try
        {
          foreach (object obj in this.msetup.lstPaths.Items)
            this.msettings.LaunchPaths.Add(Conversions.ToString(obj));
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.lstworld.Items.Clear();
        this.msettings.selectedworlds = new string[0];
        try
        {
          foreach (object obj in this.msetup.lstWorlds.CheckedIndices)
          {
            string str = Conversions.ToString(this.msetup.lstWorlds.Items[Conversions.ToInteger(obj)]);
            this.msettings.selectedworlds = (string[]) Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array) this.msettings.selectedworlds, (Array) new string[checked (Information.UBound((Array) this.msettings.selectedworlds, 1) + 1 + 1)]);
            this.msettings.selectedworlds[Information.UBound((Array) this.msettings.selectedworlds, 1)] = str;
            this.lstworld.Items.Add((object) str);
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (this.lstworld.Items.Count > 0)
          this.lstworld.SelectedIndex = 0;
        this.lblDelete.Visible = this.cboUsername.Items.Count > 0;
        int num1 = -1;
        List<int> list = this.msetup.acPorts.Getports();
        try
        {
          foreach (int num2 in list)
          {
            if (num2 != 0)
              checked { ++num1; }
          }
        }
        finally
        {
          List<int>.Enumerator enumerator;
          enumerator.Dispose();
        }
        this.msettings.ACPorts = new int[checked (num1 + 1)];
        int index = 0;
        List<int>.Enumerator enumerator1;
        try
        {
          enumerator1 = list.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            int current = enumerator1.Current;
            if (current != 0)
            {
              this.msettings.ACPorts[index] = current;
              checked { ++index; }
            }
          }
        }
        finally
        {
          enumerator1.Dispose();
        }
      }
      this.msetup = (frmSetup) null;
    }

    private void frmMain_Activated(object sender, EventArgs e)
    {
      this.Activated -= new EventHandler(this.frmMain_Activated);
      if (this.cboUsername.Items.Count > 0)
      {
        this.cboUsername.SelectedIndex = 0;
        ((Control) this.txtAc).Select();
      }
      else
        this.cboUsername.Focus();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        this.SerializeObject(this.msettingsFilePath, (object) this.msettings, "");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      try
      {
        this.mproxyclientpath = this.GetRegistryFilePath("SOFTWARE\\ACMulticlient", "ProxyClient", string.Empty);
        if (string.IsNullOrEmpty(this.mproxyclientpath) || !File.Exists(this.mproxyclientpath))
        {
          int num = (int) Interaction.MsgBox((object) "Registry key not found: \r\nSOFTWARE\\ACMulticlient\\ProxyClient", MsgBoxStyle.Critical, (object) null);
          Application.Exit();
        }
        else
        {
          this.msettingsFilePath = this.GetRegistryFilePath("SOFTWARE\\ACMulticlient", "Path", "");
          if (string.IsNullOrEmpty(this.msettingsFilePath) || !Directory.Exists(this.msettingsFilePath))
          {
            int num = (int) Interaction.MsgBox((object) "Registry key not found: \r\nSOFTWARE\\ACMulticlient\\Path", MsgBoxStyle.Critical, (object) null);
            Application.Exit();
          }
          else
          {
            this.msettingsFilePath = Path.Combine(this.msettingsFilePath, "Settings.xml");
            this.mACIniFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Asheron's Call");
            this.mACIniFilePath = this.mACIniFilePath + "\\UserPreferences.ini";
            if (!File.Exists(this.mACIniFilePath))
            {
              int num = (int) Interaction.MsgBox((object) ("File not found: \r\n" + this.mACIniFilePath), MsgBoxStyle.Critical, (object) null);
              Application.Exit();
            }
            else
            {
              if (File.Exists(this.msettingsFilePath))
                this.msettings = (Settings) this.DeSerializeObject(this.msettingsFilePath, typeof (Settings));
              if (this.msettings == null)
                this.msettings = new Settings();
              if (this.msettings.LaunchPaths == null)
              {
                string registryFilePath = this.GetRegistryFilePath("SOFTWARE\\ACDualClient", "Path", "ACDualClient.ini");
                if (!string.IsNullOrEmpty(registryFilePath))
                {
                  int integer = this.GetInteger("General", "Paths", 0, registryFilePath);
                  if (integer > 0)
                  {
                    int num1 = 1;
                    int num2 = integer;
                    int num3 = num1;
                    while (num3 <= num2)
                    {
                      string @string = this.GetString("Paths", num3.ToString(), string.Empty, registryFilePath);
                      if (File.Exists(Path.Combine(@string, "aclauncher.exe")))
                      {
                        if (this.msettings.LaunchPaths == null)
                          this.msettings.LaunchPaths = new List<string>();
                        this.msettings.LaunchPaths.Add(@string);
                      }
                      checked { ++num3; }
                    }
                  }
                }
              }
              if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
              {
                string registryFilePath = this.GetRegistryFilePath("SOFTWARE\\Decal\\Agent", "PortalPath", "Aclauncher.exe");
                if (!string.IsNullOrEmpty(registryFilePath) && File.Exists(registryFilePath))
                {
                  this.msettings.acmainpath = Path.GetDirectoryName(registryFilePath);
                }
                else
                {
                  string registryFilePathVs = this.GetRegistryFilePathVS("SOFTWARE\\Decal\\Agent", "PortalPath", "Aclauncher.exe");
                  if (!string.IsNullOrEmpty(registryFilePathVs) && File.Exists(registryFilePathVs))
                    this.msettings.acmainpath = Path.GetDirectoryName(registryFilePathVs);
                }
                if (!string.IsNullOrEmpty(this.msettings.acmainpath) && this.msettings.LaunchPaths == null)
                {
                  this.msettings.LaunchPaths = new List<string>();
                  this.msettings.LaunchPaths.Add(this.msettings.acmainpath);
                }
              }
              if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
              {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.SelectedPath = "C:\\Games";
                folderBrowserDialog.Description = "Select the folder where AC is installed";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "acclient.exe")))
                  this.msettings.acmainpath = folderBrowserDialog.SelectedPath;
              }
              if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
              {
                Application.Exit();
              }
              else
              {
                bool flag;
                if (this.msettings.accounts == null || this.msettings.accounts.Count == 0)
                {
                  this.msettings.accounts = new List<UserEntry>();
                  flag = true;
                }
                if (this.msettings.LaunchPaths != null)
                {
label_35:
                  List<string>.Enumerator enumerator;
                  try
                  {
                    enumerator = this.msettings.LaunchPaths.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                      string current = enumerator.Current;
                      if (!File.Exists(Path.Combine(current, "aclauncher.exe")))
                      {
                        this.msettings.LaunchPaths.Remove(current);
                        goto label_35;
                      }
                      else if (flag)
                      {
                        string filename = Path.Combine(current, "launcher.ini");
                        string @string = this.GetString("LAUNCHER", "DefaultUsername", string.Empty, filename);
                        if (!string.IsNullOrEmpty(@string) && this.getUserentry(@string) == null)
                          this.msettings.accounts.Add(new UserEntry()
                          {
                            name = @string
                          });
                      }
                    }
                  }
                  finally
                  {
                    enumerator.Dispose();
                  }
                }
                else
                {
                  this.msettings.LaunchPaths = new List<string>();
                  this.msettings.LaunchPaths.Add(this.msettings.acmainpath);
                }
                if (this.msettings.startdecal)
                  this.startdecal();
                this.lstworld.Items.Clear();
                if (this.msettings.selectedworlds != null)
                {
                  int num1 = 0;
                  int num2 = -1;
                  string[] strArray = this.msettings.selectedworlds;
                  int index = 0;
                  while (index < strArray.Length)
                  {
                    string Right = strArray[index];
                    this.lstworld.Items.Add((object) Right);
                    if (Operators.CompareString(this.msettings.Defaultworld, Right, false) == 0)
                      num2 = num1;
                    checked { ++num1; }
                    checked { ++index; }
                  }
                  if (this.lstworld.Items.Count > 0)
                    this.lstworld.SelectedIndex = num2;
                }
                List<UserEntry>.Enumerator enumerator1;
                if (this.msettings.accounts != null)
                {
                  try
                  {
                    enumerator1 = this.msettings.accounts.GetEnumerator();
                    while (enumerator1.MoveNext())
                      this.cboUsername.Items.Add((object) enumerator1.Current);
                  }
                  finally
                  {
                    enumerator1.Dispose();
                  }
                }
                else
                  this.msettings.accounts = new List<UserEntry>();
                this.chkStartDecal.Checked = this.msettings.startdecal;
                this.Activated += new EventHandler(this.frmMain_Activated);
                this.WindowState = FormWindowState.Normal;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Crap an error happend");
        ProjectData.ClearProjectError();
      }
    }

    private void btnLaunch_Click(object sender, EventArgs e)
    {
      this.btnLaunch.Enabled = false;
      try
      {
        Process[] processesByName = Process.GetProcessesByName("aclauncher");
        if (processesByName != null && Enumerable.Count<Process>((IEnumerable<Process>) processesByName) > 0)
        {
          int num1 = (int) Interaction.MsgBox((object) "The aclauncer is active, close this window first.", MsgBoxStyle.Critical, (object) null);
        }
        else
        {
          string world = Conversions.ToString(this.lstworld.SelectedItem);
          if (this.lstworld.SelectedIndex == -1)
          {
            int num2 = (int) Interaction.MsgBox((object) "Select a world to login.", MsgBoxStyle.Critical, (object) null);
          }
          else
          {
            this.msettings.Defaultworld = world;
            if (string.IsNullOrEmpty(this.cboUsername.Text.Trim()))
            {
              int num3 = (int) Interaction.MsgBox((object) "A username is required.", MsgBoxStyle.Critical, (object) null);
            }
            else
              this.launchac(this.cboUsername.Text, "0", "0", world);
          }
        }
      }
      finally
      {
        this.btnLaunch.Enabled = true;
      }
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool BringWindowToTop(IntPtr hwnd);

    [DllImport("user32")]
    internal static extern bool ShowWindow(IntPtr hWnd, int showCommand);

    private string initlaunch(string preferredpath, string username)
    {
      List<string> list = new List<string>();
      Process[] processesByName = Process.GetProcessesByName("acclient");
      int index1 = 0;
      while (index1 < processesByName.Length)
      {
        Process process = processesByName[index1];
        string directoryName = Path.GetDirectoryName(process.MainModule.FileName);
        string filename = Path.Combine(directoryName, "launcher.ini");
        try
        {
          if (string.Equals(this.GetString("LAUNCHER", "DefaultUsername", string.Empty, filename), username, StringComparison.CurrentCultureIgnoreCase))
          {
            switch (new dlgIgnoreActivate().ShowDialog())
            {
              case DialogResult.Ignore:
                goto label_8;
              case DialogResult.OK:
                if (!process.MainWindowHandle.Equals((object) IntPtr.Zero))
                {
                  frmMain.ShowWindow(process.MainWindowHandle, 1);
                  frmMain.BringWindowToTop(process.MainWindowHandle);
                  break;
                }
                else
                  break;
            }
            return string.Empty;
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
label_8:
        list.Add(directoryName);
        checked { ++index1; }
      }
      string str1 = string.Empty;
      if (!string.IsNullOrEmpty(preferredpath))
      {
        List<string>.Enumerator enumerator;
        bool flag;
        try
        {
          enumerator = list.GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (Operators.CompareString(enumerator.Current.ToLower(), preferredpath.ToLower(), false) == 0)
            {
              flag = true;
              break;
            }
          }
        }
        finally
        {
          enumerator.Dispose();
        }
        if (!flag)
          str1 = preferredpath + "\\aclauncher.exe";
      }
      List<string>.Enumerator enumerator1;
      if (Operators.CompareString(str1, string.Empty, false) == 0)
      {
        try
        {
          enumerator1 = this.msettings.LaunchPaths.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            string current = enumerator1.Current;
            if (!string.IsNullOrEmpty(current) && Directory.Exists(current))
            {
              bool flag = false;
              List<string>.Enumerator enumerator2;
              try
              {
                enumerator2 = list.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                  if (Operators.CompareString(enumerator2.Current.ToLower(), current.ToLower(), false) == 0)
                  {
                    flag = true;
                    break;
                  }
                }
              }
              finally
              {
                enumerator2.Dispose();
              }
              if (!flag)
              {
                str1 = current + "\\aclauncher.exe";
                break;
              }
            }
          }
        }
        finally
        {
          enumerator1.Dispose();
        }
      }
      if (Operators.CompareString(str1, string.Empty, false) == 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "All paths are in use.\r\nYou can add a new folder in the setup", MsgBoxStyle.Critical, (object) null);
      }
      else
      {
        bool flag = false;
        this.mUdpcon.RefeshTable();
        int[] numArray = this.msettings.ACPorts;
        int index2 = 0;
        while (index2 < numArray.Length)
        {
          int pcheck = numArray[index2];
          if (!this.mUdpcon.isPortInUse(pcheck))
          {
            this.WriteInteger("Net", "UserSpecifiedPort", pcheck, this.mACIniFilePath);
            flag = true;
            break;
          }
          else
            checked { ++index2; }
        }
        if (!flag)
        {
          int num2 = (int) Interaction.MsgBox((object) "All udp ports are in use.", MsgBoxStyle.Critical, (object) null);
          str1 = string.Empty;
        }
        if (Operators.CompareString(str1, string.Empty, false) != 0)
        {
          string lpFileName1 = Path.Combine(Path.GetDirectoryName(str1), "launcher.ini");
          string str2 = "LAUNCHER";
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpApplicationName1 = @str2;
          string str3 = "Application";
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpKeyName1 = @str3;
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpString1 = @this.mproxyclientpath;
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpFileName2 = @lpFileName1;
          frmMain.WritePrivateProfileString(lpApplicationName1, lpKeyName1, lpString1, lpFileName2);
          string str4 = "LAUNCHER";
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpApplicationName2 = @str4;
          str2 = "DefaultUsername";
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpKeyName2 = @str2;
          ComboBox cboUsername = this.cboUsername;
          string text = cboUsername.Text;
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpString2 = @text;
          // ISSUE: explicit reference operation
          // ISSUE: variable of a reference type
          string& lpFileName3 = @lpFileName1;
          frmMain.WritePrivateProfileString(lpApplicationName2, lpKeyName2, lpString2, lpFileName3);
          cboUsername.Text = text;
          frmMain.FlushPrivateProfileString(0, 0, 0, ref lpFileName1);
        }
      }
      return str1;
    }

    private void clearaccountpw()
    {
      if (this.msettings.accounts == null)
        return;
      List<UserEntry>.Enumerator enumerator;
      try
      {
        enumerator = this.msettings.accounts.GetEnumerator();
        while (enumerator.MoveNext())
          enumerator.Current.secret = (byte[]) null;
      }
      finally
      {
        enumerator.Dispose();
      }
    }

    private UserEntry getUserentry(string name)
    {
      List<UserEntry>.Enumerator enumerator;
      if (this.msettings.accounts != null)
      {
        try
        {
          enumerator = this.msettings.accounts.GetEnumerator();
          while (enumerator.MoveNext())
          {
            UserEntry current = enumerator.Current;
            if (current != null && string.Equals(current.name, name, StringComparison.CurrentCultureIgnoreCase))
              return current;
          }
        }
        finally
        {
          enumerator.Dispose();
        }
      }
      return (UserEntry) null;
    }

    public void relaunchac(UserEntry useraccount, string acpath)
    {
      try
      {
        string Left = string.Empty;
        try
        {
          if (useraccount.secret != null)
          {
            byte[] bytes = ProtectedData.Unprotect(useraccount.secret, (byte[]) null, DataProtectionScope.CurrentUser);
            if (bytes != null)
              Left = Encoding.UTF8.GetString(bytes);
            else
              useraccount.secret = (byte[]) null;
          }
        }
        catch (SecurityException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Security Exception");
          useraccount.secret = (byte[]) null;
          this.txtAc.ClearText(false);
          ProjectData.ClearProjectError();
          return;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          useraccount.secret = (byte[]) null;
          this.txtAc.ClearText(false);
          ProjectData.ClearProjectError();
          return;
        }
        string str = this.initlaunch(acpath, useraccount.name);
        if (!File.Exists(str))
          return;
        useraccount.usedACpath = Path.GetDirectoryName(str);
        string arguments;
        if (Operators.CompareString(Left, string.Empty, false) != 0)
          arguments = string.Format("-Username {0} -Password {1} -DataCenter {2} -FauxDataCenter {3} -w {4} -2 -3", (object) useraccount.name, (object) Left, (object) 0, (object) 0, (object) useraccount.usedworld);
        Process process = Process.Start(new ProcessStartInfo(str, arguments)
        {
          WorkingDirectory = Path.GetDirectoryName(str)
        });
        DateTime now = DateAndTime.Now;
        bool flag;
        do
        {
          flag = DateAndTime.DateDiff(DateInterval.Second, now, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 10L;
          if (flag && this.closelauncherDialog())
          {
            flag = false;
            Thread.Sleep(1000);
          }
        }
        while (!(process.HasExited | flag));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    public void launchac(string username, string di, string da, string world)
    {
      if (Operators.CompareString(username, string.Empty, false) == 0)
        return;
      try
      {
        if (this.msettings.accounts == null)
          this.msettings.accounts = new List<UserEntry>();
        UserEntry userEntry1 = this.getUserentry(username);
        if (userEntry1 == null)
        {
          userEntry1 = new UserEntry();
          userEntry1.name = username;
          this.cboUsername.Items.Add((object) username);
          this.msettings.accounts.Add(userEntry1);
        }
        string Left = string.Empty;
        try
        {
          if (this.txtAc.isModified())
          {
            if (this.txtAc.Text.Length < 4)
            {
              userEntry1.secret = (byte[]) null;
            }
            else
            {
              UserEntry userEntry2 = userEntry1;
              SecureTextbox txtAc = this.txtAc;
              byte[] numArray = (byte[]) null;
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              byte[]& entrophy = @numArray;
              byte[] data = txtAc.getData(entrophy);
              userEntry2.secret = data;
            }
          }
          if (userEntry1.secret != null)
          {
            byte[] bytes = ProtectedData.Unprotect(userEntry1.secret, (byte[]) null, DataProtectionScope.CurrentUser);
            if (bytes != null)
              Left = Encoding.UTF8.GetString(bytes);
            else
              userEntry1.secret = (byte[]) null;
          }
        }
        catch (SecurityException ex)
        {
          ProjectData.SetProjectError((Exception) ex);
          int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) "Security Exception");
          userEntry1.secret = (byte[]) null;
          this.txtAc.ClearText(false);
          ProjectData.ClearProjectError();
          return;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          userEntry1.secret = (byte[]) null;
          this.txtAc.ClearText(false);
          ProjectData.ClearProjectError();
          return;
        }
        string str = this.initlaunch((string) null, userEntry1.name);
        if (File.Exists(str))
        {
          userEntry1.usedACpath = Path.GetDirectoryName(str);
          userEntry1.usedworld = world;
          string arguments;
          if (Operators.CompareString(Left, string.Empty, false) != 0)
            arguments = string.Format("-Username {0} -Password {1} -DataCenter {2} -FauxDataCenter {3} -w {4} -2 -3", (object) username, (object) Left, (object) di, (object) da, (object) world);
          Process process = Process.Start(new ProcessStartInfo(str, arguments)
          {
            WorkingDirectory = Path.GetDirectoryName(str)
          });
          DateTime now = DateAndTime.Now;
          bool flag;
          do
          {
            flag = DateAndTime.DateDiff(DateInterval.Second, now, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 10L;
            if (flag && this.closelauncherDialog())
            {
              flag = false;
              Thread.Sleep(1000);
            }
          }
          while (!(process.HasExited | flag));
        }
        else
        {
          if (string.IsNullOrEmpty(str))
            return;
          int num = (int) Interaction.MsgBox((object) ("File not found:\r\n" + str), MsgBoxStyle.Critical, (object) null);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) null);
        ProjectData.ClearProjectError();
      }
    }

    private void chkStartDecal_CheckedChanged(object sender, EventArgs e)
    {
      this.msettings.startdecal = this.chkStartDecal.Checked;
      if (!this.msettings.startdecal)
        return;
      this.startdecal();
    }

    private void lblDelete_Click(object sender, EventArgs e)
    {
      if (this.msettings.accounts == null)
        return;
      UserEntry userentry = this.getUserentry(this.cboUsername.Text);
      if (userentry != null)
      {
        this.cboUsername.Text = string.Empty;
        this.txtAc.ClearText(false);
        this.cboUsername.Items.Remove((object) userentry);
        this.msettings.accounts.Remove(userentry);
      }
      this.lblDelete.Visible = false;
    }

    private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int) e.KeyChar != 13)
        return;
      this.btnLaunch_Click((object) null, EventArgs.Empty);
    }

    private void cboUsername_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      UserEntry userentry = this.getUserentry(this.cboUsername.Text);
      if (userentry != null && userentry.secret != null)
      {
        this.btnLaunch_Click((object) null, EventArgs.Empty);
      }
      else
      {
        this.txtAc.ClearText(false);
        this.txtAc.Focus();
      }
    }

    private void cboUsername_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cboUsername.SelectedIndex < 0)
        return;
      UserEntry userentry = this.getUserentry(this.cboUsername.Text);
      if (userentry != null)
        this.lblDelete.Visible = true;
      if (userentry != null && userentry.secret != null)
      {
        this.txtAc.ClearText(true);
        this.btnLaunch.Focus();
      }
      else
      {
        this.txtAc.ClearText(false);
        this.txtAc.Focus();
      }
    }
  }
}
