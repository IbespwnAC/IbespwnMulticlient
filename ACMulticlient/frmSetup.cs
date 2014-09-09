namespace ACMulticlient
{
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

    [DesignerGenerated]
    public class frmSetup : Form
    {
        [AccessedThroughProperty("acPorts")]
        private PortRepeater _acPorts;
        [AccessedThroughProperty("btnCopy")]
        private Button _btnCopy;
        [AccessedThroughProperty("btnMoreports")]
        private Button _btnMoreports;
        [AccessedThroughProperty("btnUpdatefolders")]
        private Button _btnUpdatefolders;
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Button2")]
        private Button _Button2;
        [AccessedThroughProperty("ContextMenuStrip1")]
        private ContextMenuStrip _ContextMenuStrip1;
        [AccessedThroughProperty("DeleteToolStripMenuItem")]
        private ToolStripMenuItem _DeleteToolStripMenuItem;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("Label3")]
        private Label _Label3;
        [AccessedThroughProperty("Label4")]
        private Label _Label4;
        [AccessedThroughProperty("lstPaths")]
        private ListBox _lstPaths;
        [AccessedThroughProperty("lstWorlds")]
        private CheckedListBox _lstWorlds;
        [AccessedThroughProperty("ToolTip1")]
        private ToolTip _ToolTip1;
        [AccessedThroughProperty("txtACMainpath")]
        private TextBox _txtACMainpath;
        private IContainer components;

        [DebuggerNonUserCode]
        public frmSetup()
        {
            this.InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            this.btnCopy.Enabled = false;
            try
            {
                if (Directory.Exists(this.txtACMainpath.Text))
                {
                    dialog.Description = "Select the destination folder where to copy the files";
                    dialog.ShowNewFolderButton = true;
                    dialog.SelectedPath = this.txtACMainpath.Text;
                    if ((dialog.ShowDialog() == DialogResult.OK) && !string.Equals(this.txtACMainpath.Text, dialog.SelectedPath, StringComparison.CurrentCultureIgnoreCase))
                    {
                        bool flag;
                        IEnumerator enumerator;
                        if (!File.Exists(Path.Combine(dialog.SelectedPath, "acclient.exe")))
                        {
                            DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);
                            if ((info.GetFiles().Count<FileInfo>() > 0) || (info.GetDirectories().Count<DirectoryInfo>() > 0))
                            {
                                Interaction.MsgBox("Folder must be empty, just create a new folder", MsgBoxStyle.Critical, null);
                                return;
                            }
                        }
                        frmProgress progress = new frmProgress {
                            srcFolder = this.txtACMainpath.Text,
                            lstpaths = this.lstPaths,
                            destFolder = new List<string>()
                        };
                        progress.destFolder.Add(dialog.SelectedPath);
                        try
                        {
                            enumerator = this.lstPaths.Items.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                if (string.Equals(Conversions.ToString(enumerator.Current).ToLower(), dialog.SelectedPath, StringComparison.CurrentCultureIgnoreCase))
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
                        if ((progress.ShowDialog() == DialogResult.OK) && !flag)
                        {
                            this.lstPaths.Items.Add(dialog.SelectedPath);
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("Ac main folder not found? ", MsgBoxStyle.Critical, null);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox(exception.Message, MsgBoxStyle.Critical, null);
                ProjectData.ClearProjectError();
            }
            finally
            {
                this.btnCopy.Enabled = true;
            }
        }

        private void btnUpdatefolders_Click(object sender, EventArgs e)
        {
            IEnumerator enumerator;
            frmProgress progress = new frmProgress {
                srcFolder = this.txtACMainpath.Text,
                lstpaths = this.lstPaths,
                destFolder = new List<string>()
            };
            try
            {
                enumerator = this.lstPaths.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string b = Conversions.ToString(enumerator.Current);
                    if (!string.Equals(this.txtACMainpath.Text, b, StringComparison.CurrentCultureIgnoreCase))
                    {
                        progress.destFolder.Add(b);
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
            if (progress.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstPaths.SelectedIndex >= 0)
            {
                this.lstPaths.Items.RemoveAt(this.lstPaths.SelectedIndex);
            }
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            Point point = new Point(5, 9);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            Size size = new Size(0x1f, 13);
            this.Label2.Size = size;
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Ports";
            this.ToolTip1.SetToolTip(this.Label2, "Available ports to try to use");
            this.lstWorlds.CheckOnClick = true;
            this.lstWorlds.FormattingEnabled = true;
            this.lstWorlds.Items.AddRange(new object[] { "Frostfell", "Harvestgain", "Leafcull", "Morningthaw", "Solclaim", "Thistledown", "Verdatine", "Wintersebb", "Darktide" });
            point = new Point(12, 0x35);
            this.lstWorlds.Location = point;
            this.lstWorlds.MultiColumn = true;
            this.lstWorlds.Name = "lstWorlds";
            size = new Size(0x12d, 0x4f);
            this.lstWorlds.Size = size;
            this.lstWorlds.TabIndex = 6;
            this.Label3.AutoSize = true;
            point = new Point(5, 0x21);
            this.Label3.Location = point;
            this.Label3.Name = "Label3";
            size = new Size(40, 13);
            this.Label3.Size = size;
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Worlds";
            this.Button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.Button1.DialogResult = DialogResult.OK;
            point = new Point(0xec, 0x109);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x4b, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Save";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.Button2.DialogResult = DialogResult.Cancel;
            point = new Point(0x9b, 0x109);
            this.Button2.Location = point;
            this.Button2.Name = "Button2";
            size = new Size(0x4b, 0x17);
            this.Button2.Size = size;
            this.Button2.TabIndex = 9;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.btnMoreports.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xee, 9);
            this.btnMoreports.Location = point;
            this.btnMoreports.Name = "btnMoreports";
            size = new Size(0x48, 0x19);
            this.btnMoreports.Size = size;
            this.btnMoreports.TabIndex = 10;
            this.btnMoreports.Text = "More ports";
            this.btnMoreports.UseVisualStyleBackColor = true;
            this.Label1.AutoSize = true;
            point = new Point(5, 0x8b);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x52, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 12;
            this.Label1.Text = "AC Main Folder:";
            this.btnCopy.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(8, 0x9f);
            this.btnCopy.Location = point;
            this.btnCopy.Name = "btnCopy";
            size = new Size(100, 0x13);
            this.btnCopy.Size = size;
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "Copy to New Folder";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.lstPaths.ContextMenuStrip = this.ContextMenuStrip1;
            this.lstPaths.FormattingEnabled = true;
            point = new Point(6, 0xcb);
            this.lstPaths.Location = point;
            this.lstPaths.Name = "lstPaths";
            size = new Size(0x12e, 0x38);
            this.lstPaths.Size = size;
            this.lstPaths.TabIndex = 14;
            this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.DeleteToolStripMenuItem });
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            size = new Size(0x6c, 0x1a);
            this.ContextMenuStrip1.Size = size;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            size = new Size(0x6b, 0x16);
            this.DeleteToolStripMenuItem.Size = size;
            this.DeleteToolStripMenuItem.Text = "Delete";
            this.txtACMainpath.BackColor = SystemColors.Control;
            this.txtACMainpath.BorderStyle = BorderStyle.None;
            point = new Point(0x5d, 0x8b);
            this.txtACMainpath.Location = point;
            this.txtACMainpath.Name = "txtACMainpath";
            this.txtACMainpath.ReadOnly = true;
            size = new Size(0xc3, 13);
            this.txtACMainpath.Size = size;
            this.txtACMainpath.TabIndex = 15;
            this.txtACMainpath.Text = @"c;\games\turbinep";
            this.btnUpdatefolders.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
            point = new Point(0xcc, 0x9f);
            this.btnUpdatefolders.Location = point;
            this.btnUpdatefolders.Name = "btnUpdatefolders";
            size = new Size(0x68, 0x13);
            this.btnUpdatefolders.Size = size;
            this.btnUpdatefolders.TabIndex = 0x10;
            this.btnUpdatefolders.Text = "Update All Folders";
            this.btnUpdatefolders.UseVisualStyleBackColor = true;
            this.Label4.AutoSize = true;
            point = new Point(9, 0xbb);
            this.Label4.Location = point;
            this.Label4.Name = "Label4";
            size = new Size(0x37, 13);
            this.Label4.Size = size;
            this.Label4.TabIndex = 0x11;
            this.Label4.Text = "All Folders";
            this.acPorts.AutoScroll = true;
            point = new Point(0x40, 3);
            this.acPorts.Location = point;
            this.acPorts.Name = "acPorts";
            size = new Size(0xa8, 0x2b);
            this.acPorts.Size = size;
            this.acPorts.TabIndex = 11;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            size = new Size(0x143, 300);
            this.ClientSize = size;
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.btnUpdatefolders);
            this.Controls.Add(this.txtACMainpath);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstPaths);
            this.Controls.Add(this.btnMoreports);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.lstWorlds);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.acPorts);
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

        internal virtual PortRepeater acPorts
        {
            [DebuggerNonUserCode]
            get
            {
                return this._acPorts;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._acPorts = value;
            }
        }

        internal virtual Button btnCopy
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnCopy;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnCopy_Click);
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click -= handler;
                }
                this._btnCopy = value;
                if (this._btnCopy != null)
                {
                    this._btnCopy.Click += handler;
                }
            }
        }

        internal virtual Button btnMoreports
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnMoreports;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._btnMoreports = value;
            }
        }

        internal virtual Button btnUpdatefolders
        {
            [DebuggerNonUserCode]
            get
            {
                return this._btnUpdatefolders;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.btnUpdatefolders_Click);
                if (this._btnUpdatefolders != null)
                {
                    this._btnUpdatefolders.Click -= handler;
                }
                this._btnUpdatefolders = value;
                if (this._btnUpdatefolders != null)
                {
                    this._btnUpdatefolders.Click += handler;
                }
            }
        }

        internal virtual Button Button1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Button1 = value;
            }
        }

        internal virtual Button Button2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Button2 = value;
            }
        }

        internal virtual ContextMenuStrip ContextMenuStrip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ContextMenuStrip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ContextMenuStrip1 = value;
            }
        }

        internal virtual ToolStripMenuItem DeleteToolStripMenuItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DeleteToolStripMenuItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.DeleteToolStripMenuItem_Click);
                if (this._DeleteToolStripMenuItem != null)
                {
                    this._DeleteToolStripMenuItem.Click -= handler;
                }
                this._DeleteToolStripMenuItem = value;
                if (this._DeleteToolStripMenuItem != null)
                {
                    this._DeleteToolStripMenuItem.Click += handler;
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

        internal virtual Label Label3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label3 = value;
            }
        }

        internal virtual Label Label4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label4 = value;
            }
        }

        internal virtual ListBox lstPaths
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lstPaths;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lstPaths = value;
            }
        }

        internal virtual CheckedListBox lstWorlds
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lstWorlds;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lstWorlds = value;
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

        internal virtual TextBox txtACMainpath
        {
            [DebuggerNonUserCode]
            get
            {
                return this._txtACMainpath;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._txtACMainpath = value;
            }
        }
    }
}

