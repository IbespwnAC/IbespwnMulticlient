namespace ACMulticlient
{
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

    [DesignerGenerated]
    public class frmMain : Form
    {
        [AccessedThroughProperty("btnLaunch")]
        private Button _btnLaunch;
        [AccessedThroughProperty("btnLaunchAll")]
        private Button _btnLaunchAll;
        [AccessedThroughProperty("cboUsername")]
        private ComboBox _cboUsername;
        [AccessedThroughProperty("chkStartDecal")]
        private CheckBox _chkStartDecal;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("lblDelete")]
        private Label _lblDelete;
        [AccessedThroughProperty("lblSetup")]
        private Label _lblSetup;
        [AccessedThroughProperty("lstworld")]
        private ListBox _lstworld;
        [AccessedThroughProperty("ProgressBar1")]
        private ProgressBar _ProgressBar1;
        [AccessedThroughProperty("Timer1")]
        private System.Windows.Forms.Timer _Timer1;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("txtAc")]
        private TextBox _txtAc;
        private IContainer components;
        private string mACIniFilePath;
        private System.Windows.Forms.Timer mLoginTimer;
        private string mproxyclientpath;
        private IntPtr mrestartAc;
        private string mrestartAcPath;
        private bool mRestartIsPending;
        private UserEntry mrestartUser;
        private Settings msettings;
        private string msettingsFilePath;
        private frmSetup msetup;
        private udpConnections mUdpcon;
        private const int SC_CLOSE = 0xf060;
        private const int WM_CUSTOM_RESTART_ME = 0x401;
        private const int WM_CUSTOM_RESTART_TEST = 0x402;
        private const int WM_CUSTOM_START_CRASHHELPER = 0x403;
        private const int WM_CUSTOMMSG = 0x400;
        private const uint WM_SYSCOMMAND = 0x112;

        public frmMain()
        {
            base.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
            base.Load += new EventHandler(this.frmMain_Load);
            this.mproxyclientpath = string.Empty;
            this.mUdpcon = new udpConnections();
            this.InitializeComponent();
            _txtAc.UseSystemPasswordChar = true;
        }

        [DllImport("user32.dll", SetLastError=true)]
        private static extern bool BringWindowToTop(IntPtr hwnd);
        private void btnLaunch_Click(object sender, EventArgs e)
        {
            this.btnLaunch.Enabled = false;  
            this.btnLaunchAll.Enabled = false;

            try
            {
                Process[] processesByName = Process.GetProcessesByName("aclauncher");
                if ((processesByName != null) && (processesByName.Count<Process>() > 0))
                {
                    Interaction.MsgBox("The aclauncer is active, close this window first.", MsgBoxStyle.Critical, null);
                }
                else
                {
                    string world = Conversions.ToString(this.lstworld.SelectedItem);
                    if (this.lstworld.SelectedIndex == -1)
                    {
                        Interaction.MsgBox("Select a world to login.", MsgBoxStyle.Critical, null);
                    }
                    else
                    {
                        this.msettings.Defaultworld = world;
                        if (string.IsNullOrEmpty(this.cboUsername.Text.Trim()))
                        {
                            Interaction.MsgBox("A username is required.", MsgBoxStyle.Critical, null);
                        }
                        else
                        {
                            this.launchac(this.cboUsername.Text, "0", "0", world);
                        }
                    }
                }
            }
            finally
            {
                this.btnLaunch.Enabled = true;
                this.btnLaunchAll.Enabled = true;
            }
        }

        private void btnLaunchAll_Click(object sender, EventArgs e)
        {
          Process[] processesByName;
          this.btnLaunch.Enabled = false;
          this.btnLaunchAll.Enabled = false;

          try
          {
            processesByName = Process.GetProcessesByName("aclauncher");
            if ((processesByName != null) && (processesByName.Count<Process>() > 0))
            {
              Interaction.MsgBox("The aclauncer is active, close this window first.", MsgBoxStyle.Critical, null);
            }
            else
            {
              string world = Conversions.ToString(this.lstworld.SelectedItem);
              if (this.lstworld.SelectedIndex == -1)
              {
                Interaction.MsgBox("Select a world to login.", MsgBoxStyle.Critical, null);
              }
              else
              {
                this.msettings.Defaultworld = world;

                for (int i = 0; i < this.cboUsername.Items.Count; ++i)
                {
                  this.launchac(((UserEntry) this.cboUsername.Items[i]).name, "0", "0", world, true);

                  // TODO  Gracefully exit if aclauncher is hanging or otherwise still running 
                  //       after some period of time.
                  while (true)
                  {
                    // Slow it down so it doesn't eat up too many cycles.  
                    //  Check every 10 ms.
                    System.Threading.Thread.Sleep(10);

                    // Check to see if aclauncher is still running from the last launch.
                    processesByName = Process.GetProcessesByName("aclauncher");

                    if ((processesByName == null) || (processesByName.Count<Process>() <= 0))
                    {
                      // Break out of while loop.
                      break;
                    }
                  }
                }
              }
            }
          }
          finally
          {
            this.btnLaunch.Enabled = true;
            this.btnLaunchAll.Enabled = true;
          }
        }

        private void btnMoreports_Click(object sender, EventArgs e)
        {
            this.msetup.acPorts.Addmore();
        }

        private void txtAc_KeyDown(object sender, KeyEventArgs e)
        {
          UserEntry entry = this.getUserentry(this.cboUsername.Text);

          if (e.KeyCode == Keys.Enter)
          {
            if ((entry != null) && (entry.secret != null))
            {
              this.btnLaunch_Click(null, EventArgs.Empty);
              return;
            }
          }

          entry.secret = this.txtAc.Text;
          save_credentials(ref entry);
        }
        
        private void cboUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserEntry entry = this.getUserentry(this.cboUsername.Text);
                if ((entry != null) && (entry.secret != null))
                {
                    this.btnLaunch_Click(null, EventArgs.Empty);
                }
                else
                {
                    this.txtAc.Text = string.Empty;
                    this.txtAc.Focus();
                }
            }
        }

        private void cboUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboUsername.SelectedIndex >= 0)
            {
                UserEntry entry = this.getUserentry(this.cboUsername.Text);
                if (entry != null)
                {
                    this.lblDelete.Visible = true;
                }
                if ((entry != null) && (entry.secret != null))
                {
                    this.txtAc.Text = entry.secret;
                    // It's my opinion that with the addition of storing passwords, 
                    //  this Focus change is a detriment to the user experience.
                    //  Thus, I will remove it for now.
                    //this.btnLaunch.Focus();
                }
                else
                {
                    this.txtAc.Text = "";
                    this.txtAc.Focus();
                }
            }
        }

        private void chkStartDecal_CheckedChanged(object sender, EventArgs e)
        {
            this.msettings.startdecal = this.chkStartDecal.Checked;
            if (this.msettings.startdecal)
            {
                this.startdecal();
            }
        }

        private void clearaccountpw()
        {
            if (this.msettings.accounts != null)
            {
                foreach (UserEntry entry in this.msettings.accounts)
                {
                    entry.secret = null;
                }
            }
        }

        private bool closelauncherDialog()
        {
            bool flag = false;
            IntPtr hWnd = FindWindow(null, "Failure");
            if (!hWnd.Equals(IntPtr.Zero))
            {
                SendMessage(hWnd, 0x112, 0xf060, 0);
                return true;
            }
            return flag;
        }

        private object DeSerializeObject(string filename, System.Type objectType)
        {
            FileStream stream = null;
            object objectValue = null;
            try
            {
                if (File.Exists(filename))
                {
                    XmlSerializer serializer = new XmlSerializer(objectType);
                    stream = new FileStream(filename, FileMode.Open);
                    objectValue = RuntimeHelpers.GetObjectValue(serializer.Deserialize(stream));
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return objectValue;
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

        [DllImport("user32")]
        public static extern IntPtr FindWindow(string lpClass, string lpTitle);
        [DllImport("kernel32.dll", EntryPoint="WritePrivateProfileStringA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int FlushPrivateProfileString(int lpApplicationName, int lpKeyName, int lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);
        private void frmMain_Activated(object sender, EventArgs e)
        {
            this.Activated -= new EventHandler(this.frmMain_Activated);
            if (this.cboUsername.Items.Count > 0)
            {
                this.cboUsername.SelectedIndex = 0;
                this.txtAc.Select();
            }
            else
            {
                this.cboUsername.Focus();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.SerializeObject(this.msettingsFilePath, this.msettings, "");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, null);
                ProjectData.ClearProjectError();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.mproxyclientpath = this.GetRegistryFilePath(@"SOFTWARE\ACMulticlient", "ProxyClient", string.Empty);
                if (string.IsNullOrEmpty(this.mproxyclientpath) || !File.Exists(this.mproxyclientpath))
                {
                    Interaction.MsgBox("Registry key not found: \r\nSOFTWARE\\ACMulticlient\\ProxyClient", MsgBoxStyle.Critical, null);
                    Application.Exit();
                }
                else
                {
                    this.msettingsFilePath = this.GetRegistryFilePath(@"SOFTWARE\ACMulticlient", "Path", "");
                    if (string.IsNullOrEmpty(this.msettingsFilePath) || !Directory.Exists(this.msettingsFilePath))
                    {
                        Interaction.MsgBox("Registry key not found: \r\nSOFTWARE\\ACMulticlient\\Path", MsgBoxStyle.Critical, null);
                        Application.Exit();
                    }
                    else
                    {
                        this.msettingsFilePath = Path.Combine(this.msettingsFilePath, "Settings.xml");
                        this.mACIniFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Asheron's Call");
                        this.mACIniFilePath = this.mACIniFilePath + @"\UserPreferences.ini";
                        if (!File.Exists(this.mACIniFilePath))
                        {
                            Interaction.MsgBox("File not found: \r\n" + this.mACIniFilePath, MsgBoxStyle.Critical, null);
                            Application.Exit();
                        }
                        else
                        {
                            if (File.Exists(this.msettingsFilePath))
                            {
                                this.msettings = (Settings) this.DeSerializeObject(this.msettingsFilePath, typeof(Settings));
                            }
                            if (this.msettings == null)
                            {
                                this.msettings = new Settings();
                            }
                            if (this.msettings.LaunchPaths == null)
                            {
                                string str = this.GetRegistryFilePath(@"SOFTWARE\ACDualClient", "Path", "ACDualClient.ini");
                                if (!string.IsNullOrEmpty(str))
                                {
                                    int num = this.GetInteger("General", "Paths", 0, str);
                                    if (num > 0)
                                    {
                                        int num5 = num;
                                        for (int i = 1; i <= num5; i++)
                                        {
                                            string str2 = this.GetString("Paths", i.ToString(), string.Empty, str);
                                            if (File.Exists(Path.Combine(str2, "aclauncher.exe")))
                                            {
                                                if (this.msettings.LaunchPaths == null)
                                                {
                                                    this.msettings.LaunchPaths = new List<string>();
                                                }
                                                this.msettings.LaunchPaths.Add(str2);
                                            }
                                        }
                                    }
                                }
                            }
                            if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
                            {
                                string str3 = this.GetRegistryFilePath(@"SOFTWARE\Decal\Agent", "PortalPath", "Aclauncher.exe");
                                if (!string.IsNullOrEmpty(str3) && File.Exists(str3))
                                {
                                    this.msettings.acmainpath = Path.GetDirectoryName(str3);
                                }
                                else
                                {
                                    str3 = this.GetRegistryFilePathVS(@"SOFTWARE\Decal\Agent", "PortalPath", "Aclauncher.exe");
                                    if (!string.IsNullOrEmpty(str3) && File.Exists(str3))
                                    {
                                        this.msettings.acmainpath = Path.GetDirectoryName(str3);
                                    }
                                }
                                if (!string.IsNullOrEmpty(this.msettings.acmainpath) && (this.msettings.LaunchPaths == null))
                                {
                                    this.msettings.LaunchPaths = new List<string>();
                                    this.msettings.LaunchPaths.Add(this.msettings.acmainpath);
                                }
                            }
                            if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
                            {
                                FolderBrowserDialog dialog = new FolderBrowserDialog {
                                    SelectedPath = @"C:\Games",
                                    Description = "Select the folder where AC is installed"
                                };
                                if ((dialog.ShowDialog() == DialogResult.OK) && File.Exists(Path.Combine(dialog.SelectedPath, "acclient.exe")))
                                {
                                    this.msettings.acmainpath = dialog.SelectedPath;
                                }
                            }
                            if (string.IsNullOrEmpty(this.msettings.acmainpath) || !Directory.Exists(this.msettings.acmainpath))
                            {
                                Application.Exit();
                            }
                            else
                            {
                                bool flag = false;
                                if ((this.msettings.accounts == null) || (this.msettings.accounts.Count == 0))
                                {
                                    this.msettings.accounts = new List<UserEntry>();
                                    flag = true;
                                }
                                if (this.msettings.LaunchPaths != null)
                                {
                                  List<string>.Enumerator enumerator;
                                  enumerator = this.msettings.LaunchPaths.GetEnumerator();
                                    try
                                    {
                                    Label_03D1:
                                        while (enumerator.MoveNext())
                                        {
                                            string current = enumerator.Current;
                                            if (!File.Exists(Path.Combine(current, "aclauncher.exe")))
                                            {
                                                this.msettings.LaunchPaths.Remove(current);
                                                goto Label_03D1;
                                            }
                                            if (flag)
                                            {
                                                string filename = Path.Combine(current, "launcher.ini");
                                                string str6 = this.GetString("LAUNCHER", "DefaultUsername", string.Empty, filename);
                                                if (!string.IsNullOrEmpty(str6) && (this.getUserentry(str6) == null))
                                                {
                                                    UserEntry item = new UserEntry {
                                                        name = str6
                                                    };
                                                    this.msettings.accounts.Add(item);
                                                }
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
                                {
                                    this.startdecal();
                                }
                                this.lstworld.Items.Clear();
                                if (this.msettings.selectedworlds != null)
                                {
                                    int num4 = 0;
                                    int num3 = -1;
                                    foreach (string str7 in this.msettings.selectedworlds)
                                    {
                                        this.lstworld.Items.Add(str7);
                                        if (this.msettings.Defaultworld == str7)
                                        {
                                            num3 = num4;
                                        }
                                        num4++;
                                    }
                                    if (this.lstworld.Items.Count > 0)
                                    {
                                        this.lstworld.SelectedIndex = num3;
                                    }
                                }
                                if (this.msettings.accounts != null)
                                {
                                    foreach (UserEntry entry2 in this.msettings.accounts)
                                    {
                                        this.cboUsername.Items.Add(entry2);
                                    }
                                }
                                else
                                {
                                    this.msettings.accounts = new List<UserEntry>();
                                }
                                this.chkStartDecal.Checked = this.msettings.startdecal;
                                this.Activated += new EventHandler(this.frmMain_Activated);
                                this.WindowState = FormWindowState.Normal;
                            }
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Crap an error happend");
                ProjectData.ClearProjectError();
            }
        }

        private int GetInteger(string Section, string Key, int Default, string filename)
        {
            return GetPrivateProfileInt(ref Section, ref Key, Default, ref filename);
        }

        [DllImport("kernel32.dll", CharSet=CharSet.Auto)]
        private static extern int GetModuleFileName(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder filename, int size);
        [DllImport("kernel32.dll", EntryPoint="GetPrivateProfileIntA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetPrivateProfileInt([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, int nDefault, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);
        [DllImport("kernel32.dll", EntryPoint="GetPrivateProfileStringA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetPrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpDefault, StringBuilder lpReturnedString, int nSize, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);
        private string GetRegistryFilePath(string LMkey, string value, string filename)
        {
            try
            {
                RegistryKey key = null;
                key = Registry.LocalMachine.OpenSubKey(LMkey, false);
                if (key != null)
                {
                    string str2 = Conversions.ToString(key.GetValue(value, string.Empty));
                    if (!string.IsNullOrEmpty(filename))
                    {
                        str2 = Path.Combine(str2, filename);
                    }
                    if (File.Exists(str2) || Directory.Exists(str2))
                    {
                        return str2;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
            return string.Empty;
        }

        private string GetRegistryFilePathVS(string USKey, string value, string filename)
        {
            try
            {
                RegistryKey key = null;
                key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\VirtualStore\MACHINE\" + USKey, false);
                if (key != null)
                {
                    string path = Path.Combine(Conversions.ToString(key.GetValue(value, string.Empty)), filename);
                    if (File.Exists(path))
                    {
                        return path;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
            return string.Empty;
        }

        private string GetString(string Section, string Key, string Default, string filename)
        {
            StringBuilder lpReturnedString = new StringBuilder(0x100);
            if (GetPrivateProfileString(ref Section, ref Key, ref Default, lpReturnedString, lpReturnedString.Capacity, ref filename) > 0)
            {
                return lpReturnedString.ToString();
            }
            return string.Empty;
        }

        private UserEntry getUserentry(string name)
        {
            if (this.msettings.accounts != null)
            {
                foreach (UserEntry entry2 in this.msettings.accounts)
                {
                    if ((entry2 != null) && string.Equals(entry2.name, name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return entry2;
                    }
                }
            }
            return null;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmMain));
            this.lstworld = new ListBox();
            this.Label2 = new Label();
            this.Label1 = new Label();
            this.cboUsername = new ComboBox();
            this.btnLaunch = new Button();
            this.btnLaunchAll = new Button();
            this.chkStartDecal = new CheckBox();
            this.ToolTip1 = new ToolTip(this.components);
            this.lblDelete = new Label();
            this.lblSetup = new Label();
            this.ProgressBar1 = new ProgressBar();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtAc = new TextBox();
            this.SuspendLayout();
            this.lstworld.FormattingEnabled = true;
            this.lstworld.Items.AddRange(new object[] { "Morningthaw", "Darktide" });
            Point point = new Point(0xef, 5);
            this.lstworld.Location = point;
            this.lstworld.Name = "lstworld";
            Size size = new Size(0x77, 0x6c);
            this.lstworld.Size = size;
            this.lstworld.TabIndex = 13;
            this.Label2.AutoSize = true;
            point = new Point(12, 0x26);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x35, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Password";
            this.Label1.AutoSize = true;
            point = new Point(12, 9);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x37, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Username";
            this.cboUsername.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cboUsername.FormattingEnabled = true;
            point = new Point(0x49, 6);
            this.cboUsername.Location = point;
            this.cboUsername.Name = "cboUsername";
            size = new Size(0x79, 0x15);
            this.cboUsername.Size = size;
            this.cboUsername.TabIndex = 0;
            point = new Point(12, 0x66);
            this.btnLaunch.Location = point;
            this.btnLaunch.Name = "btnLaunch";
            size = new Size(0x40, 30);
            this.btnLaunch.Size = size;
            this.btnLaunch.TabIndex = 4;
            this.btnLaunch.Text = "Login";
            this.ToolTip1.SetToolTip(this.btnLaunch, "Start AC and Save Current Changes");
            this.btnLaunch.UseVisualStyleBackColor = true;
            point = new Point(0x58, 0x66);
            this.btnLaunchAll.Location = point;
            this.btnLaunchAll.Name = "btnLaunch";
            size = new Size(0x40, 30);
            this.btnLaunchAll.Size = size;
            this.btnLaunchAll.TabIndex = 4;
            this.btnLaunchAll.Text = "Login All";
            this.ToolTip1.SetToolTip(this.btnLaunchAll, "Start AC on all accounts and Save Current Changes");
            this.btnLaunchAll.UseVisualStyleBackColor = true;
            this.chkStartDecal.AutoSize = true;
            point = new Point(15, 0x42);
            this.chkStartDecal.Location = point;
            this.chkStartDecal.Name = "chkStartDecal";
            size = new Size(110, 0x11);
            this.chkStartDecal.Size = size;
            this.chkStartDecal.TabIndex = 3;
            this.chkStartDecal.Text = "Start Decal Agent";
            this.chkStartDecal.UseVisualStyleBackColor = true;
            this.lblDelete.Cursor = Cursors.Hand;
            this.lblDelete.Image = ACMulticlient.My.Resources.Resources.eventlogError;
            point = new Point(200, 6);
            this.lblDelete.Location = point;
            this.lblDelete.Name = "lblDelete";
            size = new Size(20, 0x13);
            this.lblDelete.Size = size;
            this.lblDelete.TabIndex = 0x15;
            this.ToolTip1.SetToolTip(this.lblDelete, "Remove username from list");
            this.lblDelete.Visible = false;
            this.lblSetup.Cursor = Cursors.Hand;
            this.lblSetup.Image = ACMulticlient.My.Resources.Resources.services;
            point = new Point(0x14c, 0x74);
            this.lblSetup.Location = point;
            this.lblSetup.Name = "lblSetup";
            size = new Size(0x1a, 0x13);
            this.lblSetup.Size = size;
            this.lblSetup.TabIndex = 20;
            this.ToolTip1.SetToolTip(this.lblSetup, "Setup");
            this.ProgressBar1.Dock = DockStyle.Bottom;
            point = new Point(0, 0x8b);
            this.ProgressBar1.Location = point;
            this.ProgressBar1.Name = "ProgressBar1";
            size = new Size(0x16b, 10);
            this.ProgressBar1.Size = size;
            this.ProgressBar1.TabIndex = 0x16;
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 0x3e8;
            point = new Point(0x49, 0x23);
            this.txtAc.Location = point;
            this.txtAc.Name = "txtAc";
            size = new Size(0x79, 20);
            this.txtAc.Size = size;
            this.txtAc.TabIndex = 1;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x16b, 0x95);
            this.ClientSize = size;
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.txtAc);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblSetup);
            this.Controls.Add(this.chkStartDecal);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnLaunchAll);
            this.Controls.Add(this.cboUsername);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstworld);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon) manager.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "AC Multi Client";
            this.WindowState = FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private string initlaunch(string preferredpath, string username, bool autoCancel = false)
        {
            string str2;
            List<string> list = new List<string>();
            foreach (Process process in Process.GetProcessesByName("acclient"))
            {
                string directoryName = Path.GetDirectoryName(process.MainModule.FileName);
                str2 = Path.Combine(directoryName, "launcher.ini");
                try
                {
                    if (string.Equals(this.GetString("LAUNCHER", "DefaultUsername", string.Empty, str2), username, StringComparison.CurrentCultureIgnoreCase))
                    {
                      if (autoCancel)
                      {
                        return string.Empty;
                      }

                      DialogResult result = new dlgIgnoreActivate().ShowDialog();
                      if (result != DialogResult.Ignore)
                      {
                        if ((result == DialogResult.OK) && !process.MainWindowHandle.Equals(IntPtr.Zero))
                        {
                          ShowWindow(process.MainWindowHandle, 1);
                          BringWindowToTop(process.MainWindowHandle);
                        }
                        return string.Empty;
                      }
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    ProjectData.ClearProjectError();
                }
                list.Add(directoryName);
            }
            string path = string.Empty;
            if (!string.IsNullOrEmpty(preferredpath))
            {
                bool flag = false;
                foreach (string str6 in list)
                {
                    if (str6.ToLower() == preferredpath.ToLower())
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    path = preferredpath + @"\aclauncher.exe";
                }
            }
            if (path == string.Empty)
            {
                foreach (string str7 in this.msettings.LaunchPaths)
                {
                    if (string.IsNullOrEmpty(str7) || !Directory.Exists(str7))
                    {
                        continue;
                    }
                    bool flag2 = false;
                    foreach (string str8 in list)
                    {
                        if (str8.ToLower() == str7.ToLower())
                        {
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        path = str7 + @"\aclauncher.exe";
                        break;
                    }
                }
            }
            if (path == string.Empty)
            {
                Interaction.MsgBox("All paths are in use.\r\nYou can add a new folder in the setup", MsgBoxStyle.Critical, null);
                return path;
            }
            bool flag3 = false;
            this.mUdpcon.RefeshTable();
            foreach (int num in this.msettings.ACPorts)
            {
                if (!this.mUdpcon.isPortInUse(num))
                {
                    this.WriteInteger("Net", "UserSpecifiedPort", num, this.mACIniFilePath);
                    flag3 = true;
                    break;
                }
            }
            if (!flag3)
            {
                Interaction.MsgBox("All udp ports are in use.", MsgBoxStyle.Critical, null);
                path = string.Empty;
            }
            if (path != string.Empty)
            {
                str2 = Path.Combine(Path.GetDirectoryName(path), "launcher.ini");
                string lpApplicationName = "LAUNCHER";
                string lpKeyName = "Application";
                WritePrivateProfileString(ref lpApplicationName, ref lpKeyName, ref this.mproxyclientpath, ref str2);
                lpKeyName = "LAUNCHER";
                lpApplicationName = "DefaultUsername";
                ComboBox cboUsername = this.cboUsername;
                string text = cboUsername.Text;
                WritePrivateProfileString(ref lpKeyName, ref lpApplicationName, ref text, ref str2);
                cboUsername.Text = text;
                FlushPrivateProfileString(0, 0, 0, ref str2);
            }
            return path;
        }

        public int launchac(string username, string di, string da, string world, bool autoCancel = false)
        {
          string str = "";
          string str3 = "";
          string path = "";
            if (username != string.Empty)
            {
                try
                {
                    if (this.msettings.accounts == null)
                    {
                        this.msettings.accounts = new List<UserEntry>();
                    }
                    UserEntry item = this.getUserentry(username);
                    if (item == null)
                    {
                        item = new UserEntry {
                            name = username
                        };
                        this.cboUsername.Items.Add(username);
                        this.msettings.accounts.Add(item);
                    }
                    str3 = string.Empty;
                    try
                    {
                        if (item.secret != null)
                        {
                          str3 = item.secret;
                        }
                    }
                    catch (SecurityException exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        SecurityException exception = exception1;
                        Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Security Exception");
                        item.secret = null;
                        ProjectData.ClearProjectError();
                        return 0;
                    }
                    catch (Exception exception4)
                    {
                        ProjectData.SetProjectError(exception4);
                        Exception exception2 = exception4;
                        item.secret = null;
                        ProjectData.ClearProjectError();
                        return 0;
                    }
                    path = this.initlaunch(null, item.name, autoCancel);
                    if (File.Exists(path))
                    {
                        str = "";
                        bool flag = false;
                        item.usedACpath = Path.GetDirectoryName(path);
                        item.usedworld = world;
                        if (str3 != string.Empty)
                        {
                            str = string.Format("-Username {0} -Password {1} -DataCenter {2} -FauxDataCenter {3} -w {4} -2 -3", new object[] { username, str3, di, da, world });
                        }
                        ProcessStartInfo startInfo = new ProcessStartInfo(path, str) {
                            WorkingDirectory = Path.GetDirectoryName(path)
                        };
                        Process process = Process.Start(startInfo);
                        DateTime now = DateAndTime.Now;
                        do
                        {
                            flag = DateAndTime.DateDiff(DateInterval.Second, now, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 10L;
                            if (flag && this.closelauncherDialog())
                            {
                                flag = false;
                                Thread.Sleep(0x3e8);
                            }
                        }
                        while (!(process.HasExited | flag));

#if DEBUG
                        Console.WriteLine("Launched (" + path + "): " + str);
#endif

                        return 1;
                    }
                    else if (!string.IsNullOrEmpty(path))
                    {
                        Interaction.MsgBox("File not found:\r\n" + path, MsgBoxStyle.Critical, null);
                    }
                }
                catch (Exception exception5)
                {
                    ProjectData.SetProjectError(exception5);
                    Exception exception3 = exception5;
                    Interaction.MsgBox(exception3.Message, MsgBoxStyle.Critical, null);
                    ProjectData.ClearProjectError();
                }
            }

#if DEBUG
            Console.WriteLine("Elected not to duplicate Path=" + path + " Account=" + str);
#endif

            return 0;
        }

        private void save_credentials(ref UserEntry entry)
        {
          entry.secret = txtAc.Text;
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            if (this.msettings.accounts != null)
            {
                UserEntry entry = this.getUserentry(this.cboUsername.Text);
                if (entry != null)
                {
                    this.cboUsername.Text = string.Empty;
                    this.cboUsername.Items.Remove(entry);
                    this.msettings.accounts.Remove(entry);
                }
                this.lblDelete.Visible = false;
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            if ((this.msetup == null) || this.msetup.IsDisposed)
            {
                this.msetup = new frmSetup();
                this.msetup.btnMoreports.Click += new EventHandler(this.btnMoreports_Click);
            }
            if (this.msettings != null)
            {
                Settings msettings = this.msettings;
                this.msetup.txtACMainpath.Text = this.msettings.acmainpath;
                this.msetup.acPorts.setPorts(msettings.ACPorts);
                if ((msettings.availableworlds != null) && (msettings.availableworlds.Count<string>() > 0))
                {
                    this.msetup.lstWorlds.Items.Clear();
                    foreach (string str in msettings.availableworlds)
                    {
                        if (msettings.selectedworlds.Contains<string>(str))
                        {
                            this.msetup.lstWorlds.Items.Add(str, true);
                        }
                        else
                        {
                            this.msetup.lstWorlds.Items.Add(str, false);
                        }
                    }
                }
                this.msetup.lstPaths.Items.Clear();
                foreach (string str2 in msettings.LaunchPaths)
                {
                    this.msetup.lstPaths.Items.Add(str2);
                }
                msettings = null;
            }
            if (this.msetup.ShowDialog() == DialogResult.OK)
            {
                IEnumerator enumerator = null;
                IEnumerator enumerator3;
                this.msettings.LaunchPaths.Clear();
                try
                {
                    enumerator = this.msetup.lstPaths.Items.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        string item = Conversions.ToString(enumerator.Current);
                        this.msettings.LaunchPaths.Add(item);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                this.lstworld.Items.Clear();
                int index = 0;
                this.msettings.selectedworlds = new string[0];
                enumerator3 = this.msetup.lstWorlds.CheckedIndices.GetEnumerator();
                try
                {
                    while (enumerator3.MoveNext())
                    {
                        int num3 = Conversions.ToInteger(enumerator3.Current);
                        string str4 = Conversions.ToString(this.msetup.lstWorlds.Items[num3]);
                        this.msettings.selectedworlds = (string[]) Microsoft.VisualBasic.CompilerServices.Utils.CopyArray((Array) this.msettings.selectedworlds, new string[(Information.UBound(this.msettings.selectedworlds, 1) + 1) + 1]);
                        this.msettings.selectedworlds[Information.UBound(this.msettings.selectedworlds, 1)] = str4;
                        this.lstworld.Items.Add(str4);
                    }
                }
                finally
                {
                    if (enumerator3 is IDisposable)
                    {
                        (enumerator3 as IDisposable).Dispose();
                    }
                }
                if (this.lstworld.Items.Count > 0)
                {
                    this.lstworld.SelectedIndex = 0;
                }
                this.lblDelete.Visible = this.cboUsername.Items.Count > 0;
                int num2 = -1;
                List<int> ports = this.msetup.acPorts.Getports();
                foreach (int num4 in ports)
                {
                    if (num4 != 0)
                    {
                        num2++;
                    }
                }
                this.msettings.ACPorts = new int[num2 + 1];
                index = 0;
                foreach (int num5 in ports)
                {
                    if (num5 != 0)
                    {
                        this.msettings.ACPorts[index] = num5;
                        index++;
                    }
                }
            }
            this.msetup = null;
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        private static extern int RegisterWindowMessage(string lpString);
        public void relaunchac(UserEntry useraccount, string acpath)
        {
            try
            {
                string str2 = string.Empty;
                try
                {
                    if (useraccount.secret != null)
                    {
                      str2 = useraccount.secret;
                    }
                }
                catch (SecurityException exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    SecurityException exception = exception1;
                    Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, "Security Exception");
                    useraccount.secret = null;
                    ProjectData.ClearProjectError();
                    return;
                }
                catch (Exception exception4)
                {
                    ProjectData.SetProjectError(exception4);
                    Exception exception2 = exception4;
                    useraccount.secret = null;
                    ProjectData.ClearProjectError();
                    return;
                }
                string path = this.initlaunch(acpath, useraccount.name);
                if (File.Exists(path))
                {
                    string str3 = "";
                    bool flag = false;
                    useraccount.usedACpath = Path.GetDirectoryName(path);
                    if (str2 != string.Empty)
                    {
                        str3 = string.Format("-Username {0} -Password {1} -DataCenter {2} -FauxDataCenter {3} -w {4} -2 -3", new object[] { useraccount.name, str2, 0, 0, useraccount.usedworld });
                    }
                    ProcessStartInfo startInfo = new ProcessStartInfo(path, str3) {
                        WorkingDirectory = Path.GetDirectoryName(path)
                    };
                    Process process = Process.Start(startInfo);
                    DateTime now = DateAndTime.Now;
                    do
                    {
                        flag = DateAndTime.DateDiff(DateInterval.Second, now, DateAndTime.Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) > 10L;
                        if (flag && this.closelauncherDialog())
                        {
                            flag = false;
                            Thread.Sleep(0x3e8);
                        }
                    }
                    while (!(process.HasExited | flag));
                }
            }
            catch (Exception exception5)
            {
                ProjectData.SetProjectError(exception5);
                Exception exception3 = exception5;
                Interaction.MsgBox(exception3.Message, MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
        }

        private void restartACAndLogin(object sender, EventArgs e)
        {
            this.btnLaunch.Enabled = false;
            this.btnLaunchAll.Enabled = false;
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
              this.btnLaunchAll.Enabled = true;
            }
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        private bool SerializeObject(string filename, object instance, [Optional, DefaultParameterValue("")] string stSheet)
        {
            try
            {
                if (instance == null)
                {
                    return false;
                }
                XmlSerializer serializer = new XmlSerializer(instance.GetType());
                StreamWriter w = new StreamWriter(filename);
                if (!string.IsNullOrEmpty(stSheet))
                {
                    using (XmlTextWriter writer2 = new XmlTextWriter(w))
                    {
                        writer2.Formatting = Formatting.Indented;
                        writer2.WriteProcessingInstruction("xml-stylesheet", stSheet);
                        serializer.Serialize((XmlWriter) writer2, RuntimeHelpers.GetObjectValue(instance));
                    }
                }
                else
                {
                    serializer.Serialize((TextWriter) w, RuntimeHelpers.GetObjectValue(instance));
                }
                w.Close();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
                return false;
            }
            return true;
        }

        [DllImport("user32")]
        internal static extern bool ShowWindow(IntPtr hWnd, int showCommand);
        private void startdecal()
        {
            try
            {
                string str = this.GetRegistryFilePath(@"SOFTWARE\Decal\Agent", "AgentPath", "Denagent.exe");
                if (string.IsNullOrEmpty(str))
                {
                    Interaction.MsgBox("Cannot find Decal Agent", MsgBoxStyle.Critical, null);
                }
                else if (File.Exists(str))
                {
                    Process[] processesByName = Process.GetProcessesByName("denagent");
                    if ((processesByName == null) || (processesByName.Count<Process>() <= 0))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(str);
                        Process process = Process.Start(startInfo);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.ApplicationModal, null);
                ProjectData.ClearProjectError();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((this.mLoginTimer != null) && this.mLoginTimer.Enabled)
            {
                this.ProgressBar1.PerformStep();
            }
            else
            {
                this.ProgressBar1.Value = 0;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnLaunch_Click(null, EventArgs.Empty);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x401:
                case 0x402:
                    IntPtr zero;
                    if (!this.mRestartIsPending)
                    {
                        zero = IntPtr.Zero;
                        if (!zero.Equals(m.WParam))
                        {
                            string directoryName = string.Empty;
                            Process processById = Process.GetProcessById((int) m.WParam);
                            if (processById != null)
                            {
                                directoryName = Path.GetDirectoryName(processById.MainModule.FileName);
                                string filename = Path.Combine(directoryName, "launcher.ini");
                                string name = this.GetString("LAUNCHER", "DefaultUsername", string.Empty, filename);
                                UserEntry entry = this.getUserentry(name);
                                if (entry != null)
                                {
                                    zero = new IntPtr(1);
                                    m.Result = zero;
                                    this.mRestartIsPending = true;
                                    if (m.Msg == 0x401)
                                    {
                                        this.mrestartAc = m.LParam;
                                        this.mrestartUser = entry;
                                        this.mrestartAcPath = directoryName;
                                        this.mLoginTimer = new System.Windows.Forms.Timer();
                                        this.mLoginTimer.Interval = 0x2710;
                                        this.mLoginTimer.Tick += new EventHandler(this.restartACAndLogin);
                                        this.mLoginTimer.Start();
                                        if (!IntPtr.Zero.Equals(this.mrestartAc))
                                        {
                                            SendMessage(this.mrestartAc, 0x112, 0xf060, 0);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                    zero = new IntPtr(3);
                    m.Result = zero;
                    break;

                case 0x403:
                    IntPtr.Zero.Equals(m.WParam);
                    if (IntPtr.Zero.Equals(m.LParam))
                    {
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void WriteInteger(string Section, string Key, int Value, string filename)
        {
            string l_val = Conversions.ToString(Value);
            WritePrivateProfileString(ref Section, ref Key, ref l_val, ref filename);
            FlushPrivateProfileString(0, 0, 0, ref filename);
        }

        [DllImport("kernel32.dll", EntryPoint="WritePrivateProfileStringA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int WritePrivateProfileString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpApplicationName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpKeyName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpString, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileName);

        internal virtual Button btnLaunch
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnLaunch;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnLaunch_Click);
                if (this._btnLaunch != null)
                {
                    this._btnLaunch.Click -= handler;
                }
                this._btnLaunch = value;
                if (this._btnLaunch != null)
                {
                    this._btnLaunch.Click += handler;
                }
            }
        }

        internal virtual Button btnLaunchAll
        {
          [DebuggerNonUserCode]
          get
          {
            return this._btnLaunchAll;
          }
          [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
          set
          {
            EventHandler handler = new EventHandler(this.btnLaunchAll_Click);
            if (this._btnLaunchAll != null)
            {
              this._btnLaunchAll.Click -= handler;
            }
            this._btnLaunchAll = value;
            if (this._btnLaunchAll != null)
            {
              this._btnLaunchAll.Click += handler;
            }
          }
        }

        internal virtual ComboBox cboUsername
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cboUsername;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.cboUsername_SelectedIndexChanged);
                KeyEventHandler handler2 = new KeyEventHandler(this.cboUsername_KeyDown);
                if (this._cboUsername != null)
                {
                    this._cboUsername.SelectedIndexChanged -= handler;
                    this._cboUsername.KeyDown -= handler2;
                }
                this._cboUsername = value;
                if (this._cboUsername != null)
                {
                    this._cboUsername.SelectedIndexChanged += handler;
                    this._cboUsername.KeyDown += handler2;
                }
            }
        }

        internal virtual CheckBox chkStartDecal
        {
            [DebuggerNonUserCode]
            get
            {
                return this._chkStartDecal;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.chkStartDecal_CheckedChanged);
                if (this._chkStartDecal != null)
                {
                    this._chkStartDecal.CheckedChanged -= handler;
                }
                this._chkStartDecal = value;
                if (this._chkStartDecal != null)
                {
                    this._chkStartDecal.CheckedChanged += handler;
                }
            }
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label1 = value;
            }
        }

        internal virtual Label Label2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label2 = value;
            }
        }

        internal virtual Label lblDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.lblDelete_Click);
                if (this._lblDelete != null)
                {
                    this._lblDelete.Click -= handler;
                }
                this._lblDelete = value;
                if (this._lblDelete != null)
                {
                    this._lblDelete.Click += handler;
                }
            }
        }

        internal virtual Label lblSetup
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblSetup;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.lblSetup_Click);
                if (this._lblSetup != null)
                {
                    this._lblSetup.Click -= handler;
                }
                this._lblSetup = value;
                if (this._lblSetup != null)
                {
                    this._lblSetup.Click += handler;
                }
            }
        }

        internal virtual ListBox lstworld
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lstworld;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lstworld = value;
            }
        }

        internal virtual ProgressBar ProgressBar1
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

        internal virtual System.Windows.Forms.Timer Timer1
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

        internal virtual ToolTip ToolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ToolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ToolTip1 = value;
            }
        }

        internal virtual TextBox txtAc
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtAc;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
              KeyEventHandler handler = new KeyEventHandler(this.txtAc_KeyDown);
              if (this._txtAc != null)
              {
                this._txtAc.KeyDown -= handler;
              }
              this._txtAc = value;
              if (this._txtAc != null)
              {
                this._txtAc.KeyDown += handler;
              }
            }
        }
    }
}

