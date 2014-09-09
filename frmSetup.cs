// Decompiled with JetBrains decompiler
// Type: ACMulticlient.frmSetup
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACMulticlient
{
  [DesignerGenerated]
  public class frmSetup : Form
  {
    private IContainer components;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;
    [AccessedThroughProperty("lstWorlds")]
    private CheckedListBox _lstWorlds;
    [AccessedThroughProperty("Label3")]
    private Label _Label3;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Button2")]
    private Button _Button2;
    [AccessedThroughProperty("ToolTip1")]
    private ToolTip _ToolTip1;
    [AccessedThroughProperty("btnMoreports")]
    private Button _btnMoreports;
    [AccessedThroughProperty("acPorts")]
    private PortRepeater _acPorts;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("btnCopy")]
    private Button _btnCopy;
    [AccessedThroughProperty("lstPaths")]
    private ListBox _lstPaths;
    [AccessedThroughProperty("ContextMenuStrip1")]
    private ContextMenuStrip _ContextMenuStrip1;
    [AccessedThroughProperty("DeleteToolStripMenuItem")]
    private ToolStripMenuItem _DeleteToolStripMenuItem;
    [AccessedThroughProperty("txtACMainpath")]
    private TextBox _txtACMainpath;
    [AccessedThroughProperty("btnUpdatefolders")]
    private Button _btnUpdatefolders;
    [AccessedThroughProperty("Label4")]
    private Label _Label4;

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

    internal virtual CheckedListBox lstWorlds
    {
      [DebuggerNonUserCode] get
      {
        return this._lstWorlds;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lstWorlds = value;
      }
    }

    internal virtual Label Label3
    {
      [DebuggerNonUserCode] get
      {
        return this._Label3;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label3 = value;
      }
    }

    internal virtual Button Button1
    {
      [DebuggerNonUserCode] get
      {
        return this._Button1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Button1 = value;
      }
    }

    internal virtual Button Button2
    {
      [DebuggerNonUserCode] get
      {
        return this._Button2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Button2 = value;
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

    internal virtual Button btnMoreports
    {
      [DebuggerNonUserCode] get
      {
        return this._btnMoreports;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._btnMoreports = value;
      }
    }

    internal virtual PortRepeater acPorts
    {
      [DebuggerNonUserCode] get
      {
        return this._acPorts;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._acPorts = value;
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

    internal virtual Button btnCopy
    {
      [DebuggerNonUserCode] get
      {
        return this._btnCopy;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCopy_Click);
        if (this._btnCopy != null)
          this._btnCopy.Click -= eventHandler;
        this._btnCopy = value;
        if (this._btnCopy == null)
          return;
        this._btnCopy.Click += eventHandler;
      }
    }

    internal virtual ListBox lstPaths
    {
      [DebuggerNonUserCode] get
      {
        return this._lstPaths;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._lstPaths = value;
      }
    }

    internal virtual ContextMenuStrip ContextMenuStrip1
    {
      [DebuggerNonUserCode] get
      {
        return this._ContextMenuStrip1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._ContextMenuStrip1 = value;
      }
    }

    internal virtual ToolStripMenuItem DeleteToolStripMenuItem
    {
      [DebuggerNonUserCode] get
      {
        return this._DeleteToolStripMenuItem;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.DeleteToolStripMenuItem_Click);
        if (this._DeleteToolStripMenuItem != null)
          this._DeleteToolStripMenuItem.Click -= eventHandler;
        this._DeleteToolStripMenuItem = value;
        if (this._DeleteToolStripMenuItem == null)
          return;
        this._DeleteToolStripMenuItem.Click += eventHandler;
      }
    }

    internal virtual TextBox txtACMainpath
    {
      [DebuggerNonUserCode] get
      {
        return this._txtACMainpath;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._txtACMainpath = value;
      }
    }

    internal virtual Button btnUpdatefolders
    {
      [DebuggerNonUserCode] get
      {
        return this._btnUpdatefolders;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUpdatefolders_Click);
        if (this._btnUpdatefolders != null)
          this._btnUpdatefolders.Click -= eventHandler;
        this._btnUpdatefolders = value;
        if (this._btnUpdatefolders == null)
          return;
        this._btnUpdatefolders.Click += eventHandler;
      }
    }

    internal virtual Label Label4
    {
      [DebuggerNonUserCode] get
      {
        return this._Label4;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label4 = value;
      }
    }

    [DebuggerNonUserCode]
    public frmSetup()
    {
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
      this.Label2 = new Label();
      this.lstWorlds = new CheckedListBox();
      this.Label3 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.ToolTip1 = new ToolTip(this.components);
      this.btnMoreports = new Button();
      this.Label1 = new Label();
      this.btnCopy = new Button();
      this.lstPaths = new ListBox();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.DeleteToolStripMenuItem = new ToolStripMenuItem();
      this.txtACMainpath = new TextBox();
      this.btnUpdatefolders = new Button();
      this.Label4 = new Label();
      this.acPorts = new PortRepeater();
      this.ContextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.Label2.AutoSize = true;
      Label label2_1 = this.Label2;
      Point point1 = new Point(5, 9);
      Point point2 = point1;
      label2_1.Location = point2;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      Size size1 = new Size(31, 13);
      Size size2 = size1;
      label2_2.Size = size2;
      this.Label2.TabIndex = 0;
      this.Label2.Text = "Ports";
      this.ToolTip1.SetToolTip((Control) this.Label2, "Available ports to try to use");
      this.lstWorlds.CheckOnClick = true;
      this.lstWorlds.FormattingEnabled = true;
      this.lstWorlds.Items.AddRange(new object[9]
      {
        (object) "Frostfell",
        (object) "Harvestgain",
        (object) "Leafcull",
        (object) "Morningthaw",
        (object) "Solclaim",
        (object) "Thistledown",
        (object) "Verdatine",
        (object) "Wintersebb",
        (object) "Darktide"
      });
      CheckedListBox lstWorlds1 = this.lstWorlds;
      point1 = new Point(12, 53);
      Point point3 = point1;
      lstWorlds1.Location = point3;
      this.lstWorlds.MultiColumn = true;
      this.lstWorlds.Name = "lstWorlds";
      CheckedListBox lstWorlds2 = this.lstWorlds;
      size1 = new Size(301, 79);
      Size size3 = size1;
      lstWorlds2.Size = size3;
      this.lstWorlds.TabIndex = 6;
      this.Label3.AutoSize = true;
      Label label3_1 = this.Label3;
      point1 = new Point(5, 33);
      Point point4 = point1;
      label3_1.Location = point4;
      this.Label3.Name = "Label3";
      Label label3_2 = this.Label3;
      size1 = new Size(40, 13);
      Size size4 = size1;
      label3_2.Size = size4;
      this.Label3.TabIndex = 0;
      this.Label3.Text = "Worlds";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.DialogResult = DialogResult.OK;
      Button button1_1 = this.Button1;
      point1 = new Point(236, 265);
      Point point5 = point1;
      button1_1.Location = point5;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(75, 23);
      Size size5 = size1;
      button1_2.Size = size5;
      this.Button1.TabIndex = 8;
      this.Button1.Text = "Save";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button2.DialogResult = DialogResult.Cancel;
      Button button2_1 = this.Button2;
      point1 = new Point(155, 265);
      Point point6 = point1;
      button2_1.Location = point6;
      this.Button2.Name = "Button2";
      Button button2_2 = this.Button2;
      size1 = new Size(75, 23);
      Size size6 = size1;
      button2_2.Size = size6;
      this.Button2.TabIndex = 9;
      this.Button2.Text = "Cancel";
      this.Button2.UseVisualStyleBackColor = true;
      this.btnMoreports.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      Button btnMoreports1 = this.btnMoreports;
      point1 = new Point(238, 9);
      Point point7 = point1;
      btnMoreports1.Location = point7;
      this.btnMoreports.Name = "btnMoreports";
      Button btnMoreports2 = this.btnMoreports;
      size1 = new Size(72, 25);
      Size size7 = size1;
      btnMoreports2.Size = size7;
      this.btnMoreports.TabIndex = 10;
      this.btnMoreports.Text = "More ports";
      this.btnMoreports.UseVisualStyleBackColor = true;
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(5, 139);
      Point point8 = point1;
      label1_1.Location = point8;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(82, 13);
      Size size8 = size1;
      label1_2.Size = size8;
      this.Label1.TabIndex = 12;
      this.Label1.Text = "AC Main Folder:";
      this.btnCopy.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      Button btnCopy1 = this.btnCopy;
      point1 = new Point(8, 159);
      Point point9 = point1;
      btnCopy1.Location = point9;
      this.btnCopy.Name = "btnCopy";
      Button btnCopy2 = this.btnCopy;
      size1 = new Size(100, 19);
      Size size9 = size1;
      btnCopy2.Size = size9;
      this.btnCopy.TabIndex = 13;
      this.btnCopy.Text = "Copy to New Folder";
      this.btnCopy.UseVisualStyleBackColor = true;
      this.lstPaths.ContextMenuStrip = this.ContextMenuStrip1;
      this.lstPaths.FormattingEnabled = true;
      ListBox lstPaths1 = this.lstPaths;
      point1 = new Point(6, 203);
      Point point10 = point1;
      lstPaths1.Location = point10;
      this.lstPaths.Name = "lstPaths";
      ListBox lstPaths2 = this.lstPaths;
      size1 = new Size(302, 56);
      Size size10 = size1;
      lstPaths2.Size = size10;
      this.lstPaths.TabIndex = 14;
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.DeleteToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      ContextMenuStrip contextMenuStrip1 = this.ContextMenuStrip1;
      size1 = new Size(108, 26);
      Size size11 = size1;
      contextMenuStrip1.Size = size11;
      this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
      ToolStripMenuItem toolStripMenuItem = this.DeleteToolStripMenuItem;
      size1 = new Size(107, 22);
      Size size12 = size1;
      toolStripMenuItem.Size = size12;
      this.DeleteToolStripMenuItem.Text = "Delete";
      this.txtACMainpath.BackColor = SystemColors.Control;
      this.txtACMainpath.BorderStyle = BorderStyle.None;
      TextBox txtAcMainpath1 = this.txtACMainpath;
      point1 = new Point(93, 139);
      Point point11 = point1;
      txtAcMainpath1.Location = point11;
      this.txtACMainpath.Name = "txtACMainpath";
      this.txtACMainpath.ReadOnly = true;
      TextBox txtAcMainpath2 = this.txtACMainpath;
      size1 = new Size(195, 13);
      Size size13 = size1;
      txtAcMainpath2.Size = size13;
      this.txtACMainpath.TabIndex = 15;
      this.txtACMainpath.Text = "c;\\games\\turbinep";
      this.btnUpdatefolders.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      Button btnUpdatefolders1 = this.btnUpdatefolders;
      point1 = new Point(204, 159);
      Point point12 = point1;
      btnUpdatefolders1.Location = point12;
      this.btnUpdatefolders.Name = "btnUpdatefolders";
      Button btnUpdatefolders2 = this.btnUpdatefolders;
      size1 = new Size(104, 19);
      Size size14 = size1;
      btnUpdatefolders2.Size = size14;
      this.btnUpdatefolders.TabIndex = 16;
      this.btnUpdatefolders.Text = "Update All Folders";
      this.btnUpdatefolders.UseVisualStyleBackColor = true;
      this.Label4.AutoSize = true;
      Label label4_1 = this.Label4;
      point1 = new Point(9, 187);
      Point point13 = point1;
      label4_1.Location = point13;
      this.Label4.Name = "Label4";
      Label label4_2 = this.Label4;
      size1 = new Size(55, 13);
      Size size15 = size1;
      label4_2.Size = size15;
      this.Label4.TabIndex = 17;
      this.Label4.Text = "All Folders";
      this.acPorts.AutoScroll = true;
      PortRepeater acPorts1 = this.acPorts;
      point1 = new Point(64, 3);
      Point point14 = point1;
      acPorts1.Location = point14;
      this.acPorts.Name = "acPorts";
      PortRepeater acPorts2 = this.acPorts;
      size1 = new Size(168, 43);
      Size size16 = size1;
      acPorts2.Size = size16;
      this.acPorts.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      size1 = new Size(323, 300);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.btnUpdatefolders);
      this.Controls.Add((Control) this.txtACMainpath);
      this.Controls.Add((Control) this.btnCopy);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.lstPaths);
      this.Controls.Add((Control) this.btnMoreports);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.lstWorlds);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.acPorts);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmSetup";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Setup";
      this.ContextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      this.btnCopy.Enabled = false;
      try
      {
        if (Directory.Exists(this.txtACMainpath.Text))
        {
          folderBrowserDialog.Description = "Select the destination folder where to copy the files";
          folderBrowserDialog.ShowNewFolderButton = true;
          folderBrowserDialog.SelectedPath = this.txtACMainpath.Text;
          if (folderBrowserDialog.ShowDialog() != DialogResult.OK || string.Equals(this.txtACMainpath.Text, folderBrowserDialog.SelectedPath, StringComparison.CurrentCultureIgnoreCase))
            return;
          if (!File.Exists(Path.Combine(folderBrowserDialog.SelectedPath, "acclient.exe")))
          {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            if (Enumerable.Count<FileInfo>((IEnumerable<FileInfo>) directoryInfo.GetFiles()) > 0 || Enumerable.Count<DirectoryInfo>((IEnumerable<DirectoryInfo>) directoryInfo.GetDirectories()) > 0)
            {
              int num = (int) Interaction.MsgBox((object) "Folder must be empty, just create a new folder", MsgBoxStyle.Critical, (object) null);
              return;
            }
          }
          frmProgress frmProgress = new frmProgress();
          frmProgress.srcFolder = this.txtACMainpath.Text;
          frmProgress.lstpaths = this.lstPaths;
          frmProgress.destFolder = new List<string>();
          frmProgress.destFolder.Add(folderBrowserDialog.SelectedPath);
          bool flag;
          try
          {
            foreach (object obj in this.lstPaths.Items)
            {
              if (string.Equals(Conversions.ToString(obj).ToLower(), folderBrowserDialog.SelectedPath, StringComparison.CurrentCultureIgnoreCase))
                flag = true;
            }
          }
          finally
          {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (frmProgress.ShowDialog() != DialogResult.OK || flag)
            return;
          this.lstPaths.Items.Add((object) folderBrowserDialog.SelectedPath);
        }
        else
        {
          int num1 = (int) Interaction.MsgBox((object) "Ac main folder not found? ", MsgBoxStyle.Critical, (object) null);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.Critical, (object) null);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.btnCopy.Enabled = true;
      }
    }

    private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.lstPaths.SelectedIndex < 0)
        return;
      this.lstPaths.Items.RemoveAt(this.lstPaths.SelectedIndex);
    }

    private void btnUpdatefolders_Click(object sender, EventArgs e)
    {
      frmProgress frmProgress = new frmProgress();
      frmProgress.srcFolder = this.txtACMainpath.Text;
      frmProgress.lstpaths = this.lstPaths;
      frmProgress.destFolder = new List<string>();
      try
      {
        foreach (object obj in this.lstPaths.Items)
        {
          string b = Conversions.ToString(obj);
          if (!string.Equals(this.txtACMainpath.Text, b, StringComparison.CurrentCultureIgnoreCase))
            frmProgress.destFolder.Add(b);
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (frmProgress.ShowDialog() == DialogResult.OK)
        ;
    }
  }
}
